using API.Service.AI.Anthropic.Claude.Models.Content;
using Newtonsoft.Json;

namespace API.Service.AI.Anthropic.Claude.Models.Response
{
	public class AnthropicMessagesResponse
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("content")]
		public List<Content> Content { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("stop_reason")]
		public string StopReason { get; set; }

		[JsonProperty("stop_sequence")]
		public object StopSequence { get; set; }

		[JsonProperty("usage")]
		public Usage Usage { get; set; }
	}

	public class Usage
	{
		[JsonProperty("input_tokens")]
		public int InputTokens { get; set; }

		[JsonProperty("output_tokens")]
		public int OutputTokens { get; set; }
	}

	public class Content
	{
		[JsonProperty("type")]
		public string type { get; set; }

		[JsonProperty("text")]
		public string text { get; set; }
	}
}