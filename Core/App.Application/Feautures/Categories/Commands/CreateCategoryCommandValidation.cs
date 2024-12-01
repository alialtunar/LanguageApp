//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Application.Feautures.Categories.Commands
//{
//    public class CreateCategoryCommandValidation:AbstractValidator<CreateCategoryCommand>
//    {

//        public CreateCategoryCommandValidation()
//        {

//            RuleFor(p => p.Name)
//                .NotEmpty()
//                .NotNull()
//                .MaximumLength(200);
//        }
//    }
//}
