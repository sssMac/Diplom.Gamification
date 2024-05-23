using AutoMapper;
using Diplom.Gamification.Application.Common;
using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Domain;
using Diplom.Gamification.Shared;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Application.Services
{
	public class AssignmentResultService : BaseService, IAssignmentResultService
	{
		private readonly UserManager<ApplicationUser> _userManager;
        public AssignmentResultService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager) :
            base(unitOfWork, mapper)
        {
            _userManager = userManager;
        }

        public async Task<bool> SuccessAssignment(Guid assignmentId, string userId)
		{

			var progress = new LearningProgress
			{
				UserId = userId,
				LessonId = (await _unitOfWork.LessonRepository.Get(x => x.Assignment.Id == assignmentId)).FirstOrDefault().Id,
				IsCompleted = true,
				CompletionDate = DateTime.UtcNow,
			};

			if((await _unitOfWork.LearningProgressRepository.Get(x => x == progress)).FirstOrDefault() is null)
			{
                try
                {
                    await _unitOfWork.LearningProgressRepository.Insert(progress);
                    await _unitOfWork.Save();

                    var user = await _userManager.FindByIdAsync(userId);

                    user.Rating += 25;

                    await _userManager.UpdateAsync(user);

                    return true;
                }
                catch (Exception)
                {
                    await Console.Out.WriteLineAsync($"не удалось добавить прогресс к заданию id = {assignmentId}");
                    return false;
                }
            }

			return false;
		}
	}
}
