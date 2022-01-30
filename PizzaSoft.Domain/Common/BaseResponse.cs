using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSoft.Domain.Common
{
    public class BaseResponse<TData>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public TData Data { get; set; }
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();

        public BaseResponse(string code, string message, List<ErrorModel> errorModels)
        {
            this.Success = false;
            this.ErrorCode = code;
            this.Message = message;
            this.Errors = errorModels;
        }

        public BaseResponse(string code, string message)
        {
            this.Success = false;
            this.Message = message;
            this.ErrorCode = code;
        }

        public BaseResponse(TData data)
        {
            this.Success = true;
            this.Message = ErrorMessages.SUC000;
            this.Data = data;
        }
    }

    public class ErrorModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}
