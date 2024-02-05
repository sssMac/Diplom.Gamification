using Diplom.Gamification.Application.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Diplom.Gamification.Application.Interfaces
{
    public interface IAuthService
    {
        Task<SignInResult> Login(LoginViewModel model);
        Task Logout();
        Task<IdentityResult> Register(RegisterViewModel model);
    }
}
