using API.Service.AI.Anthropic.Claude.Models.Dto;
using API.Service.AI.Anthropic.Claude.Models.Request;

namespace API.Service.AI.Anthropic.Claude.Domain.Implementation.Interfaces
{
	public interface IAnthropicClaudeService
	{
		Task<AnthropicChatResponseDto> GenerateChatResponseAsync(QuestionRequest Content);
	}
}