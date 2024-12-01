using App.API.Abstraction;
using App.Application.Features.Categories.Queries;
using App.Application.Feautures.Categories.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        [HttpGet]
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> GetCategories()
        {
            var query = new GetCategoryQuery();
            var result = await _mediator.Send(query);
            return CreateActionResult(result);
        }

    }
}
