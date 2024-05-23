using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Application.Common
{
    public class BaseResponse
    {
        public bool Success { get; private set; }
        public string Error { get; private set; }

        public Guid CreatedId { get; private set; }

        private BaseResponse(bool success = true, Guid createdId = default, string error = null)
        {
            Success = success;
            Error = error;
            CreatedId = createdId;
        }


        public static BaseResponse Succeed() => new BaseResponse(true);
        public static BaseResponse Succeed(Guid createdId) => new BaseResponse(true, createdId);
        public static BaseResponse Failed(string error) => new BaseResponse(error: error);
    }
}
