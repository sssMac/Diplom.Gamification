using Diplom.Gamification.Application.Consts;
using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Application.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace Diplom.Gamification.Infrastructure.Services
{
    public class IdentityService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(RegisterViewModel model)
        {
            IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.UserName };
            var result = await _userManager.CreateAsync(user, model.Password);

            await _userManager.AddToRoleAsync(user, Roles.Basic);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }

            return result;
        }

        public async Task<SignInResult> Login(LoginViewModel model)
        {
            var userName = "";
            if (IsValidEmail(model.Email))
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    userName = user.UserName;
                }
            }
            return await _signInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, false);
        }

        public async Task Logout()
            => await _signInManager.SignOutAsync();

        private bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
