using Audote.Server.Domain.Entities;
using FluentValidation.Results;

namespace Audote.Server.Application.Extensions
{
    public static class ValidationResultExtensions
    {
        public static Error ToError(this ValidationResult result)
        {
            return new Error
            {
                Errors = result.Errors.Select(x => new ErrorItem
                {
                    Code = x.ErrorCode,
                    Message = x.ErrorMessage
                }).ToList()
            };
        }
    }
}
