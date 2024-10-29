using API.Service.AI.Anthropic.Claude.Models.Dto;
using Newtonsoft.Json;

namespace API.Service.AI.Anthropic.Claude.Models.Request
{
	public class AnthropicMessagesRequest
	{
		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("messages")]
		public List<AnthropicBaseChatMessageDto> Messages { get; set; }

		[JsonProperty("max_tokens")]
		public int MaxTokens { get; set; }
	}
}
