//using App.Application.Interfaces;
//using App.Application.Models;
//using App.Domain.Entities;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Application.Feautures.Categories.Commands
//{
//    public class CreateCategoryCommand : IRequest<ServiceResult<Category>>
//    {
//        public string Name { get; set; }
//        public string Description { get; set; }
//    }
//    public class CreateCategoryCommandHandler: IRequestHandler<CreateCategoryCommand,ServiceResult<Category>>
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<ServiceResult<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
//        {
//            try
//            {
//                var category = new Category()
//                {
//                    Name = request.Name,
//                    Description = request.Description,
//                };

//                await _unitOfWork.Categories.AddAsync(category);

//                var saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);
//                if (saveResult <= 0)
//                    return ServiceResult<Category>.Fail("Database save operation failed", HttpStatusCode.InternalServerError);

//                var createdCategory = await _unitOfWork.Categories.GetCategoryWithProducts(category.Id);
//                if (createdCategory == null)
//                    return ServiceResult<Category>.Fail("Category was created but could not be retrieved", HttpStatusCode.InternalServerError);

//                return ServiceResult<Category>.Success(createdCategory, HttpStatusCode.Created);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }
//    }
//}
