using App.Application.Interfaces;
using App.Application.Models;
using App.Domain.Entities;
using MediatR;
using System.Net;

namespace App.Application.Feautures.Videos.Commands
{
    public class UpdateVideoCommand : IRequest<ServiceResult<Video>>
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public string LanguageId { get; set; } = string.Empty;
    }

    public class UpdateVideoCommandHandler : IRequestHandler<UpdateVideoCommand, ServiceResult<Video>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateVideoCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResult<Video>> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var video = await _unitOfWork.VideoRepository.GetByIdAsync(request.Id);
                if (video == null)
                    return ServiceResult<Video>.Fail("Video not found", HttpStatusCode.NotFound);

                var languageExists = await _unitOfWork.LanguageRepository.AnyAsync(request.LanguageId);
                if (!languageExists)
                    return ServiceResult<Video>.Fail("Language not found", HttpStatusCode.NotFound);

                video.Title = request.Title;
                video.Url = request.Url;
                video.Duration = request.Duration;
                video.LanguageId = request.LanguageId;

                _unitOfWork.VideoRepository.Update(video);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

                if (result <= 0)
                    return ServiceResult<Video>.Fail("Failed to update video", HttpStatusCode.InternalServerError);

                var updatedVideo = await _unitOfWork.VideoRepository.GetVideoWithSubtitlesAsync(video.Id);
                return ServiceResult<Video>.Success(updatedVideo!);
            }
            catch (Exception ex)
            {
                return ServiceResult<Video>.Fail(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
