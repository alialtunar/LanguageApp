using App.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.API.Abstraction
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public readonly IMediator _mediator;

        protected BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [NonAction]
        public IActionResult CreateActionResult<T>(ServiceResult<T> result)
        {
            if (result.IsFail)
                return new ObjectResult(result) { StatusCode = (int)result.Status };

            return result.Status switch
            {
                HttpStatusCode.Created => new ObjectResult(result) { StatusCode = StatusCodes.Status201Created },
                HttpStatusCode.NoContent => new ObjectResult(result) { StatusCode = StatusCodes.Status204NoContent },
                _ => new ObjectResult(result) { StatusCode = (int)result.Status }
            };
        }

        [NonAction]
        public IActionResult CreateActionResult(ServiceResult result)
        {
            if (result.IsFail)
                return new ObjectResult(result) { StatusCode = (int)result.Status };

            return result.Status switch
            {
                HttpStatusCode.NoContent => NoContent(),
                _ => new ObjectResult(result) { StatusCode = (int)result.Status }
            };
        }
    }
}
