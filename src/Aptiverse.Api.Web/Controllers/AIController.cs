using Aptiverse.Application.AI.Dtos;
using Aptiverse.Application.AI.Services;
using Aptiverse.Application.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aptiverse.Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController(IAiTaskService aiTaskService) : ControllerBase
    {
        private readonly IAiTaskService _aiTaskService = aiTaskService;
        [HttpPost("ai/summarize")]
        public async Task<IActionResult> Summarize([FromBody] string inputText)
        {
            var task = new AiTaskPayloadDto
            {
                TaskType = "summarization",
                InputText = inputText,
                UserId = User.Identity?.Name ?? "anonymous"
            };

            await _aiTaskService.SendTaskToQueueAsync(task);
            return Accepted(new { message = "Task queued" });
        }
    }
}
