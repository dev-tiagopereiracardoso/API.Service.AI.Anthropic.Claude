using API.Service.AI.Anthropic.Claude.Models.Dto;
using API.Service.AI.Anthropic.Claude.Models.Settings;

namespace API.Service.AI.Anthropic.Claude.Models.Request
{
	public class AnthropicChatRequest : ChatRequest<AnthropicChatSettings, AnthropicBaseChatMessageDto>
	{
		public AnthropicChatRequest() { }

		public AnthropicChatRequest(List<AnthropicBaseChatMessageDto> messages, AnthropicChatSettings chatSettings)
		{
			Messages = messages;
			Settings = chatSettings;
		}
	}

	public class ChatRequest<TSettings, TMessage>
	{
		public string Model { get; set; }
		public string Instructions { get; set; }
		public List<TMessage> Messages { get; set; }
		public TSettings Settings { get; set; }
	}
}