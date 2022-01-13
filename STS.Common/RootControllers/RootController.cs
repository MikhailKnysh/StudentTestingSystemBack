using System.Net;
using STS.Common.ApiErrors.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using STS.Common.Constans;

namespace STS.Common.RootControllers
{
    [ApiController]
    [Route("[controller]")]
    public class RootController : Controller
    {
        protected readonly ILogger<RootController> _logger;

        public RootController(
            ILogger<RootController> logger
        )
        {
            _logger = logger;
        }

        protected IActionResult ToApiResult(Result result) => ToApiResult<object>(result);

        protected IActionResult ToApiResult<T>(T value) => ToApiResult(Result.Ok(value));

        protected IActionResult ToApiResult<T>(Result<T> result)
        {
            if (result.IsFailed)
            {
                var apiError = result.ToResult().ToApiError();
                if (apiError.Items.Contains(ErrorConstants.CommonErrors.DataNotFound))
                {
                    return StatusCode((int)HttpStatusCode.NoContent, apiError);
                }
                _logger.LogError(JsonConvert.SerializeObject(apiError));

                return StatusCode((int)HttpStatusCode.BadRequest, apiError);
            }

            if (result.Value is not null)
            {
                return StatusCode((int)HttpStatusCode.OK, result.Value);
            }

            if (result.IsSuccess)
            {
                return StatusCode((int)HttpStatusCode.OK);
            }

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}