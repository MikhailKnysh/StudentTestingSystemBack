using System.Collections.Generic;

namespace STS.Common.ApiErrors
{
    public class ApiError
    {
        public List<string> Items { get; set; }

        public ApiError(List<string> messages)
        {
            Items = messages;
        }
    }
}