using Newtonsoft.Json;

namespace API.Service.AI.Anthropic.Claude.Models.Response
{
	public class AnthropicMessagesErrorResponse
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("error")]
		public ErrorDetails Error { get; set; }

		public class ErrorDetails
		{
			[JsonProperty("type")]
			public string Type { get; set; }

			[JsonProperty("message")]
			public string Message { get; set; }
		}
	}
}