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

namespace App.Application.Feautures.Subtitles.Commands
{
    public class CreateSubtitleCommand : IRequest<ServiceResult<Subtitle>>
    {
        public string VideoId { get; set; } = string.Empty;
        public string LanguageId { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Text { get; set; } = string.Empty;
    }
    public class CreateSubtitleCommandHandler : IRequestHandler<CreateSubtitleCommand, ServiceResult<Subtitle>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateSubtitleCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResult<Subtitle>> Handle(CreateSubtitleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var videoExists = await _unitOfWork.VideoRepository.AnyAsync(request.VideoId);
                if (!videoExists)
                    return ServiceResult<Subtitle>.Fail("Video not found", HttpStatusCode.NotFound);

                var languageExists = await _unitOfWork.LanguageRepository.AnyAsync(request.LanguageId);
                if (!languageExists)
                    return ServiceResult<Subtitle>.Fail("Language not found", HttpStatusCode.NotFound);

                // Validate time ranges
                if (request.EndTime <= request.StartTime)
                    return ServiceResult<Subtitle>.Fail("End time must be greater than start time", HttpStatusCode.BadRequest);

                var subtitle = new Subtitle
                {
                    VideoId = request.VideoId,
                    LanguageId = request.LanguageId,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    Text = request.Text
                };

                await _unitOfWork.SubtitleRepository.AddAsync(subtitle);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

                if (result <= 0)
                    return ServiceResult<Subtitle>.Fail("Failed to create subtitle", HttpStatusCode.InternalServerError);

                return ServiceResult<Subtitle>.Success(subtitle, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return ServiceResult<Subtitle>.Fail(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
