using FluentValidation.Results;
using PizzaSoft.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaSoft.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
         : base("")
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
