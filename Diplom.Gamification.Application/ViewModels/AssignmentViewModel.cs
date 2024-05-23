using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Application.ViewModels
{
    public class AssignmentViewModel
    {
		public Guid Id { get; set; }

		[Display(Name = "Название")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Тесты")]
        public AssignmentTestViewModel? AssignmentTest { get; set; }
    }
}
