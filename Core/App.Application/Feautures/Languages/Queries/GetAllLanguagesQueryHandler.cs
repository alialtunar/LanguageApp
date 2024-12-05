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
    public class GetAllLanguagesQuery : IRequest<ServiceResult<List<Language>>>
    {
    }
    public class GetAllLanguagesQueryHandler : IRequestHandler<GetAllLanguagesQuery, ServiceResult<List<Language>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllLanguagesQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResult<List<Language>>> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var languages = await _unitOfWork.LanguageRepository.GetAllAsync();
                return ServiceResult<List<Language>>.Success(languages);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Language>>.Fail(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }

}
