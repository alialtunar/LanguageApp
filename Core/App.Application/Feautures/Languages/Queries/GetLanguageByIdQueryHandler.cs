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

namespace App.Application.Feautures.Languages.Queries
{
    public class GetLanguageByIdQuery : IRequest<ServiceResult<Language>>
    {
        public string Id { get; set; }
    }
    public class GetLanguageByIdQueryHandler : IRequestHandler<GetLanguageByIdQuery, ServiceResult<Language>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetLanguageByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResult<Language>> Handle(GetLanguageByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var language = await _unitOfWork.LanguageRepository.GetByIdAsync(request.Id);
                if (language == null)
                    return ServiceResult<Language>.Fail("Language not found", HttpStatusCode.NotFound);

                return ServiceResult<Language>.Success(language);
            }
            catch (Exception ex)
            {
                return ServiceResult<Language>.Fail(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
