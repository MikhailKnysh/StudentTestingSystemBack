using System.Collections.Generic;
using System.Linq;
using FluentResults;

namespace Common.ApiErrors.Extensions
{
    public static class FluentResultExtensions
    {
        public static ApiError ToApiError(this Result fluentResult)
        {
            if (fluentResult.IsSuccess)
            {
                return null;
            }

            var items = new List<string>();
            items.Add(fluentResult
                .Errors
                .First().Message);
            
            return new ApiError(items);
        }
    }
}