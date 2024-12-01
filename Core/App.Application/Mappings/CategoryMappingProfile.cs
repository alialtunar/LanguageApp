using App.Application.Feautures.Categories.Commands;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
           
            CreateMap<CreateCategoryCommand, Category>();
          
        }
    }
}
