//using App.Application.Interfaces;
//using App.Application.Models;
//using App.Domain.Entities;
//using MediatR;
//using System.Net;

//namespace App.Application.Feautures.Products.Commands
//{
//    public class CreateProductCommand : IRequest<ServiceResult<Product>>
//    {
//        public string Name { get; set; }
//        public decimal Price { get; set; }
//        public string Description { get; set; }
//        public string CategoryId { get; set; }
//    }
//    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResult<Product>>
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<ServiceResult<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
//        {
//            try
//            {
//                var product = new Product
//                {
//                    Name = request.Name,
//                    Price = request.Price,
//                    Description = request.Description,
//                    CategoryId = request.CategoryId
//                };

//                await _unitOfWork.Products.AddAsync(product);
//                await _unitOfWork.SaveChangesAsync(cancellationToken);

//                var createdProduct = await _unitOfWork.Products.GetProductWithCategory(product.Id);
//                return ServiceResult<Product>.Success(createdProduct, HttpStatusCode.Created);
//            }
//            catch (Exception ex)
//            {
//                return ServiceResult<Product>.Fail(ex.Message, HttpStatusCode.InternalServerError);
//            }
//        }
//    }
//}
