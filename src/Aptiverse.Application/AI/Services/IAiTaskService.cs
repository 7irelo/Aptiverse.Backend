using Aptiverse.Application.AI.Dtos;

namespace Aptiverse.Application.AI.Services
{
    public interface IAiTaskService
    {
        Task SendTaskToQueueAsync(AiTaskPayloadDto taskPayload);
    }
}
