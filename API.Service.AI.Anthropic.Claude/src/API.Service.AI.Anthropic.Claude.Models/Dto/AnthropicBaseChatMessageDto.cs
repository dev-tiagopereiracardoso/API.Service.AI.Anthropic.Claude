using Newtonsoft.Json;

namespace API.Service.AI.Anthropic.Claude.Models.Dto
{
	public class AnthropicBaseChatMessageDto 
	{
		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("content")]
		public string Content { get; set; }
	}
}