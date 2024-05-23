using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Application.ViewModels
{
    public class ErrorModel
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class CompilationResultModel
    {
        public List<ErrorModel> Errors { get; set; } = [];
        public bool BuildSucceed { get; set; }
        public string ElapsedTime { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
    }

    public class TestResultModel
    {
        public string ElapsedTime { get; set; } = string.Empty;
        public int Passed { get; set; }
        public int Total { get; set; }
    }
}
