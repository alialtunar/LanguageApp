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

namespace App.Application.Feautures.Languages.Commands
{
    public class UpdateLanguageCommand : IRequest<ServiceResult<Language>>
    {
        public string Id { get; set; } = string.Empty;
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
    }
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, ServiceResult<Language>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateLanguageCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResult<Language>> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var language = await _unitOfWork.LanguageRepository.GetByIdAsync(request.Id);
                if (language == null)
                    return ServiceResult<Language>.Fail("Language not found", HttpStatusCode.NotFound);

                var existingLanguage = await _unitOfWork.LanguageRepository.AnyAsync(
                    l => l.LanguageCode == request.LanguageCode && l.Id != request.Id);
                if (existingLanguage)
                    return ServiceResult<Language>.Fail("Language code already exists", HttpStatusCode.BadRequest);

                language.LanguageName = request.LanguageName;
                language.LanguageCode = request.LanguageCode;

                _unitOfWork.LanguageRepository.Update(language);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

                if (result <= 0)
                    return ServiceResult<Language>.Fail("Failed to update language", HttpStatusCode.InternalServerError);

                return ServiceResult<Language>.Success(language);
            }
            catch (Exception ex)
            {
                return ServiceResult<Language>.Fail(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
