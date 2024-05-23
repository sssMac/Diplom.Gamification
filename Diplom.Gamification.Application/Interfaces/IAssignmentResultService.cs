using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Application.Interfaces
{
	public interface IAssignmentResultService
	{
		Task<bool> SuccessAssignment(Guid assignmentId, string userId);
	}
}
