using API.Service.AI.Anthropic.Claude.Domain.Implementation.Interfaces;
using API.Service.AI.Anthropic.Claude.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Service.AI.Anthropic.Claude.Service.Controllers
{
	[Route("v1/claude")]
	[ApiController]
	[ApiExplorerSettings(GroupName = "claude")]
	public class AnthropicClaudeController : ControllerBase
	{
		private readonly IAnthropicClaudeService _anthropicClaudeService;

		public AnthropicClaudeController(
				IAnthropicClaudeService anthropicClaudeService
			)
		{
			_anthropicClaudeService = anthropicClaudeService;
		}

		[HttpPost("question")]
		[SwaggerOperation(Summary = "")]
		[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(List<object>))]
		[SwaggerResponse(StatusCodes.Status400BadRequest)]
		[SwaggerResponse(StatusCodes.Status401Unauthorized)]
		[SwaggerResponse(StatusCodes.Status417ExpectationFailed)]
		public IActionResult Question(QuestionRequest Obj)
		{
			var Data = _anthropicClaudeService.GenerateChatResponseAsync(Obj).Result;

			if (Data.Error)
				return BadRequest(Data);

			return Ok(Data);
		}
	}
}
