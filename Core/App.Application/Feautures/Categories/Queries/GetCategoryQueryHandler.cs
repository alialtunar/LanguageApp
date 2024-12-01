using App.Application.Interfaces;
using App.Application.Models;
using App.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Categories.Queries
{
    public class GetCategoryQuery : IRequest<ServiceResult<List<Category>>>
    {
        // Query parametreleri gerekirse buraya eklenebilir
    }

    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, ServiceResult<List<Category>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ServiceResult<List<Category>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync();

                if (categories == null || !categories.Any())
                {
                    return ServiceResult<List<Category>>.Fail("Categories not found");
                }

                return ServiceResult<List<Category>>.Success(categories);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<Category>>.Fail($"An error occurred while getting categories: {ex.Message}");
            }
        }
    }
}