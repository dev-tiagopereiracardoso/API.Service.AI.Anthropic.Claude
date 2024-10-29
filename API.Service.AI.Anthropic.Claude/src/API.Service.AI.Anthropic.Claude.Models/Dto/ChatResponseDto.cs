using Newtonsoft.Json;

namespace API.Service.AI.Anthropic.Claude.Models.Dto
{
	public class ChatResponseDto
	{
		public bool Error { set; get; }

		public string Message { set; get; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("content")]
		public string Content { get; set; }
	}
}