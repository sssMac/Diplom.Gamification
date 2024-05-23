using System.ComponentModel.DataAnnotations;

namespace Diplom.Gamification.Application.ViewModels
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Название")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Сложность")]
        public int Level { get; set; }

        [Display(Name = "Созданно")]
        public string CreatedBy { get; set; }

        public string? ImgLink { get; set; }

        public List<LessonViewModel> Lessons { get; set; }

        public int Passed { get; set; }

        public string? CreatorUserName { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? AvatarLink { get; set; }
    }
}
