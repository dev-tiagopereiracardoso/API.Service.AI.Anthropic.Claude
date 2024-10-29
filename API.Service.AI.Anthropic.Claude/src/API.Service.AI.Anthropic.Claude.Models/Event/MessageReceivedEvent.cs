using API.Service.AI.Anthropic.Claude.Models.Dto;

namespace API.Service.AI.Anthropic.Claude.Models.Event
{
	public class MessageReceivedEvent
	{
		public ChatResponseDto Message { get; set; }
	}
}