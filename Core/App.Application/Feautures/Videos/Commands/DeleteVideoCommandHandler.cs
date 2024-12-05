using App.Application.Interfaces;
using App.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Feautures.Videos.Commands
{
    public class DeleteVideoCommand : IRequest<ServiceResult>
    {
        public string Id { get; set; }
    }
    public class DeleteVideoCommandHandler : IRequestHandler<DeleteVideoCommand, ServiceResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteVideoCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResult> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var video = await _unitOfWork.VideoRepository.GetByIdAsync(request.Id);
                if (video == null)
                    return ServiceResult.Fail("Video not found", HttpStatusCode.NotFound);

                _unitOfWork.VideoRepository.Delete(video);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

                if (result <= 0)
                    return ServiceResult.Fail("Failed to delete video", HttpStatusCode.InternalServerError);

                return ServiceResult.Success(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
