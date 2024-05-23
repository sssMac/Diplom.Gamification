using Diplom.Gamification.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Application.ViewModels
{
    public class AddLessonViewModel
    {
        [Required]
        public Guid CourseId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        [StringLength(50, ErrorMessage = "Максимальная длинна 50 символов")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Содержание")]
        [StringLength(10000, MinimumLength = 100, ErrorMessage = "Допустимая длинна 100-10000 символов")]
        public string Content { get; set; }

        [Display(Name = "Задание")]
        public AddAssignmentViewModel? Assignment { get; set; }

    }
}
