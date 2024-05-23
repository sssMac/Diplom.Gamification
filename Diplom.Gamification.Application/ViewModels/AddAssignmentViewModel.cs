using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Application.ViewModels
{
    public class AddAssignmentViewModel
    {
        [Required]
        [Display(Name = "Название")]
        [StringLength(50, ErrorMessage = "Максимальная длинна 50 символов")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Описание")]
        [StringLength(10000, ErrorMessage = "Максимальная длинна 250 символов")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Тесты")]
        public AssignmentTestViewModel? AssigmentTest { get; set; }

    }
}
