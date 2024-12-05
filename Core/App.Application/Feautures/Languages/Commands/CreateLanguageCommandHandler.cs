using App.Application.Interfaces;
using App.Application.Models;
using App.Domain.Entities;
using MediatR;
using System.Net;

namespace App.Application.Feautures.Languages.Commands
{
    public class CreateLanguageCommand : IRequest<ServiceResult<Language>>
    {
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
    }

    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, ServiceResult<Language>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateLanguageCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResult<Language>> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingLanguage = await _unitOfWork.LanguageRepository.AnyAsync(l => l.LanguageCode == request.LanguageCode);
                if (existingLanguage)
                    return ServiceResult<Language>.Fail("Language code already exists", HttpStatusCode.BadRequest);

                var language = new Language
                {
                    LanguageName = request.LanguageName,
                    LanguageCode = request.LanguageCode
                };

                await _unitOfWork.LanguageRepository.AddAsync(language);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

                if (result <= 0)
                    return ServiceResult<Language>.Fail("Failed to create language", HttpStatusCode.InternalServerError);

                return ServiceResult<Language>.Success(language, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return ServiceResult<Language>.Fail(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
