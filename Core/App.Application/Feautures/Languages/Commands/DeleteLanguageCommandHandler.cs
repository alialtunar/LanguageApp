using App.Application.Interfaces;
using App.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Feautures.Languages.Commands
{
    public class DeleteLanguageCommand : IRequest<ServiceResult>
    {
        public string Id { get; set; }
    }
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, ServiceResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResult> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var language = await _unitOfWork.LanguageRepository.GetByIdAsync(request.Id);
                if (language == null)
                    return ServiceResult.Fail("Language not found", HttpStatusCode.NotFound);

                // Check if language is in use
                var inUseByVideos = await _unitOfWork.VideoRepository.AnyAsync(v => v.LanguageId == request.Id);
                var inUseBySubtitles = await _unitOfWork.SubtitleRepository.AnyAsync(s => s.LanguageId == request.Id);

                if (inUseByVideos || inUseBySubtitles)
                    return ServiceResult.Fail("Language is in use and cannot be deleted", HttpStatusCode.BadRequest);

                _unitOfWork.LanguageRepository.Delete(language);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

                if (result <= 0)
                    return ServiceResult.Fail("Failed to delete language", HttpStatusCode.InternalServerError);

                return ServiceResult.Success(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
