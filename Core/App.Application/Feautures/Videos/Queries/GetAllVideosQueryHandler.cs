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
    public class GetAllVideosQuery : IRequest<ServiceResult<List<Video>>>
    {
    }
    public class GetAllVideosQueryHandler : IRequestHandler<GetAllVideosQuery, ServiceResult<List<Video>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllVideosQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResult<List<Video>>> Handle(GetAllVideosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var videos = await _unitOfWork.VideoRepository.GetAllAsync();
                return ServiceResult<List<Video>>.Success(videos);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Video>>.Fail(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
