using System;
using System.ComponentModel.DataAnnotations;

namespace Diplom.Gamification.Application.ViewModels
{
    public class LessonViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Название")]
        public string Title { get; set; }

        [Display(Name = "Содержание")]
        public string Content { get; set; }

        [Display(Name = "Задание")]
        public AssignmentViewModel? Assignment { get; set; }
    }
}
