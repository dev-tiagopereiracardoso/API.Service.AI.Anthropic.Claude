using Newtonsoft.Json;

namespace API.Service.AI.Anthropic.Claude.Models.Content
{
	public interface IAnthropicChatContent
	{
		[JsonProperty("type")]
		string Type { get; }
	}
}
