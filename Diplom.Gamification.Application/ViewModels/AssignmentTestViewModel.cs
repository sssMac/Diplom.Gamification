using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Application.ViewModels
{
    public class AssignmentTestViewModel
    {
        [Display(Name = "Вход")]
        public string Input { get; set; }

        [Display(Name = "Выход")]
        public string Output { get; set; }

    }
}
