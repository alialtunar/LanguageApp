using App.API.Abstraction;
using App.Application.Feautures.Categories.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{

    public class CategoryController : BaseApiController
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
           var result = await _mediator.Send(command);
            return CreateActionResult(result);
        }

    }
}
