using Diplom.Gamification.Application.Consts;
using System.ComponentModel.DataAnnotations;

namespace Diplom.Gamification.Application.ViewModels
{
    public class AddCourseViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название")]
        [StringLength(50, ErrorMessage = "Максимальная длинна 50 символов")]
        public string Title { get; set; }

        [Display(Name = "URL изображения")]
        [RegularExpression(@"\bhttps?:\/\/\S+\.(?:png|jpe?g|gif)\b", ErrorMessage = "Некорректный URL")]
        public string? ImgLink { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Описание")]
        [StringLength(10000, ErrorMessage = "Максимальная длинна 10000 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Сложность")]
        [Range(1, 3, ErrorMessage = "Выберите уровнь сложности")]
        public int Level { get; set; }

        public string? CreatedBy { get; set; }
    }
}
