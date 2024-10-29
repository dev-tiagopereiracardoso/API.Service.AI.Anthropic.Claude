using API.Service.AI.Anthropic.Claude.Domain.Implementation.Interfaces;
using API.Service.AI.Anthropic.Claude.Models.Dto;
using API.Service.AI.Anthropic.Claude.Models.Event;
using API.Service.AI.Anthropic.Claude.Models.Request;
using API.Service.AI.Anthropic.Claude.Models.Response;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace API.Service.AI.Anthropic.Claude.Domain.Implementation.Services
{
	public class AnthropicClaudeService : IAnthropicClaudeService
	{
		private string? _anthropicApiKey { set; get; }

		public AnthropicClaudeService(
				IConfiguration configuration
			)
		{
			_anthropicApiKey = configuration["AnthropicApiKey"]! ?? null;
		}

		public async Task<AnthropicChatResponseDto> GenerateChatResponseAsync(QuestionRequest Content)
		{
			var body = new AnthropicMessagesRequest
			{
				Model = "claude-3-5-sonnet-20241022",
				Messages = new List<AnthropicBaseChatMessageDto>()
				{
					new AnthropicBaseChatMessageDto()
					{
						Role = "user",
						Content = Content.Question
					}
				},
				MaxTokens = 1024
			};

			using (var response = await SendMessagesRequest(body, "v1/messages"))
			{
				var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync());
				var assistantMessage = new StringBuilder();

				AnthropicMessagesResponse messagesResponse = null;

				while (!streamReader.EndOfStream)
				{
					var line = await streamReader.ReadLineAsync();
					var test = line;

					if (string.IsNullOrEmpty(line))
					{
						continue;
					}

					if (line.Contains("\"type\":\"error\""))
					{
						var error = JsonConvert.DeserializeObject<AnthropicMessagesErrorResponse>(line);

						return new AnthropicChatResponseDto { Error = true, Message = error.Error.Message };
					}

					if (line.ToString().ToLower().Contains("content"))
					{
						messagesResponse = JsonConvert.DeserializeObject<AnthropicMessagesResponse>(line)!;

						if (line.Contains("\"type\":\"content_block_delta\""))
						{
							var deltaEvent = JsonConvert.DeserializeObject<ContentBlockDeltaEvent>(line);
							if (deltaEvent!.Delta?.Type != "text_delta")
							{
								continue;
							}

							assistantMessage.Append(deltaEvent.Delta.Text);
						}
						else
						{
							assistantMessage.Append(JsonConvert.SerializeObject(messagesResponse!.Content));
						}
					}
					else
					{
						return new AnthropicChatResponseDto { Error = true, Message = "Failed to read AI message" };
					}
				}

				return new AnthropicChatResponseDto { Content = assistantMessage.ToString(), Role = "assistant" };
			}
		}

		private async Task<HttpResponseMessage> SendMessagesRequest(AnthropicMessagesRequest body, string endpoint)
		{
			var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
			request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");


			var client = new HttpClient { Timeout = TimeSpan.FromMinutes(4) };
			client.BaseAddress = new Uri("https://api.anthropic.com/");
			client.Timeout = TimeSpan.FromMinutes(4);
			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Add("x-api-key", $"{_anthropicApiKey}");
			client.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			var response = await client.SendAsync(request);
			return response;
		}
	}
}