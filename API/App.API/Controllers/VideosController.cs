using App.API.Abstraction;
using App.Application.Feautures.Videos.Commands;
using App.Application.Models;
using App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class VideosController : BaseApiController
    {
        public VideosController(IMediator mediator) : base(mediator)
        {
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var query = new GetAllVideosQuery();
        //    var result = await _mediator.Send(query);
        //    return CreateActionResult(result);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(string id)
        //{
        //    var query = new GetVideoByIdQuery(id);
        //    var result = await _mediator.Send(query);
        //    return CreateActionResult(result);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVideoCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateActionResult(result);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(string id, [FromBody] UpdateVideoCommand command)
        //{
        //    command.Id = id;
        //    var result = await _mediator.Send(command);
        //    return CreateActionResult(result);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var command = new DeleteVideoCommand(id);
        //    var result = await _mediator.Send(command);
        //    return CreateActionResult(result);
        //}
    }
}
