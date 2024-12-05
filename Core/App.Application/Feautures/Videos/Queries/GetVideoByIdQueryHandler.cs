using App.Application.Interfaces;
using App.Application.Models;
using App.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Feautures.Videos.Queries
{
    public class GetVideoByIdQuery : IRequest<ServiceResult<Video>>
    {
        public string Id { get; set; }
    }
    public class GetVideoByIdQueryHandler : IRequestHandler<GetVideoByIdQuery, ServiceResult<Video>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetVideoByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResult<Video>> Handle(GetVideoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var video = await _unitOfWork.VideoRepository.GetVideoWithSubtitlesAsync(request.Id);
                if (video == null)
                    return ServiceResult<Video>.Fail("Video not found", HttpStatusCode.NotFound);

                return ServiceResult<Video>.Success(video);
            }
            catch (Exception ex)
            {
                return ServiceResult<Video>.Fail(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
