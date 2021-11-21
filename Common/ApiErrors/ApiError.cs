using System.Collections.Generic;
using System.Drawing;

namespace Common.ApiErrors
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