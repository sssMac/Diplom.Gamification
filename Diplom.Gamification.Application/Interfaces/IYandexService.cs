
using Diplom.Gamification.Application.ViewModels;

namespace Diplom.Gamification.Application.Interfaces
{
    public interface IYandexService
    {
        Task<GPTResponse> GetIntentAsync(string text);
        Task<GPTResponse> GetCodeSkillAsync(string text);
    }
}
