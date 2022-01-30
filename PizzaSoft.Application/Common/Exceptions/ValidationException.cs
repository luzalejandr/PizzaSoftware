using System;
using PizzaSoft.Domain.Common;
using PizzaSoft.Domain.Errors;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSoft.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
         : base(ErrorMessage.VAL001)
        {
            Errors = new List<ErrorModel>();
        }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            List<ErrorModel> errorModels = new List<ErrorModel>();
            for (int i = 0; i < failures.ToList().Count; i++)
            {
                ErrorModel errorModel = new ErrorModel()
                {
                    FieldName = failures[i].PropertyName,
                    Message = failures[i].ErrorMessage
                };
                errorModels.Add(errorModel);
            }
            Errors = errorModels;
        }

        public List<ErrorModel> Errors { get; }
    }
}
