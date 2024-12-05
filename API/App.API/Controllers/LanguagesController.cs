using App.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class LanguagesController : BaseApiController
    {
        public LanguagesController(IMediator mediator) : base(mediator)
        {
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var query = new GetAllLanguagesQuery();
        //    var result = await _mediator.Send(query);
        //    return CreateActionResult(result);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(string id)
        //{
        //    var query = new GetLanguageByIdQuery(id);
        //    var result = await _mediator.Send(query);
        //    return CreateActionResult(result);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] CreateLanguageCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return CreateActionResult(result);
        //}
    }
}
