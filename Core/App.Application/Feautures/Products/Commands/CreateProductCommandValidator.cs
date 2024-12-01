//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Application.Feautures.Products.Commands
//{
//    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
//    {
//        public CreateProductCommandValidator()
//        {
//            RuleFor(p => p.Name)
//                .NotEmpty()
//                .MaximumLength(200);

//            RuleFor(p => p.Price)
//                .GreaterThan(0);

//            RuleFor(p => p.CategoryId)
//                .NotEmpty();
//        }
//    }
//}
