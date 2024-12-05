using App.Application.Interfaces;
using App.Application.Models;
using App.Domain.Entities;
using MediatR;
using System.Net;


namespace App.Application.Feautures.Videos.Commands
{
    public class CreateVideoCommand : IRequest<ServiceResult<Video>>
    {
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public string LanguageId { get; set; } = string.Empty;
    }
    public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommand, ServiceResult<Video>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateVideoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult<Video>> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var languageExists = await _unitOfWork.LanguageRepository.AnyAsync(request.LanguageId);
                if (!languageExists)
                    return ServiceResult<Video>.Fail("Language not found", HttpStatusCode.NotFound);

                var video = new Video
                {
                    Title = request.Title,
                    Url = request.Url,
                    Duration = request.Duration,
                    LanguageId = request.LanguageId
                };

                await _unitOfWork.VideoRepository.AddAsync(video);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

                if (result <= 0)
                    return ServiceResult<Video>.Fail("Failed to create video", HttpStatusCode.InternalServerError);

                var createdVideo = await _unitOfWork.VideoRepository.GetVideoWithSubtitlesAsync(video.Id);
                return ServiceResult<Video>.Success(createdVideo!, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return ServiceResult<Video>.Fail(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}

