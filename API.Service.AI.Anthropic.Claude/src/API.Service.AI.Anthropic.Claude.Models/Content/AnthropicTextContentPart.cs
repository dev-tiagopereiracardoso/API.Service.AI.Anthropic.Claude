using Newtonsoft.Json;

namespace API.Service.AI.Anthropic.Claude.Models.Content
{
	public class AnthropicTextContentPart : IAnthropicChatContent
	{
		[JsonProperty("type")]
		public string Type => "text";

		[JsonProperty("text")]
		public string Text { get; set; }
	}
}