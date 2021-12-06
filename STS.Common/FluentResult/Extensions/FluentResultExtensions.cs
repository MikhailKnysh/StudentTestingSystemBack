using System.Collections.Generic;
using FluentResults;

namespace STS.Common.FluentResult.Extensions
{
    public static class FluentResultExtensions
    {
        public static Result CheckDbResponse(this int response, string errorMessage)
        {
            return response > 0 ? Result.Ok() : Result.Fail(errorMessage);
        }

        public static Result<T> CheckEntityNull<T>(this T entity, string errorMessage)
            where T : class
        {
            return entity is not null ? Result.Ok(entity) : Result.Fail(errorMessage);
        }

        public static Result<List<T>> CheckCollectionNullOrEmpty<T>(this List<T> entities, string errorMessage)
            where T : class
        {
            return entities is not null && entities.Count > 0 ? Result.Ok(entities) : Result.Fail(errorMessage);
        }
    }
}