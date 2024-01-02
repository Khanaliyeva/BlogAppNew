using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.Category
{
    public class CategoryCreateDto
    {
        public string? Name { get; set; }
        public IFormFile? Logo { get; set; }
    }

    public class CategoryCreateDtoValidation : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidation()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().
                WithMessage("ad bos olmaz")
               .MaximumLength(55)
               .WithMessage("max 55 simvol ola biler")
               .MinimumLength(3)
               .WithMessage("minimum 3 simvol ola biler");

            RuleFor(c => c.Logo)
                .NotEmpty()
                .NotNull()
                .WithMessage("Logo bos olmaz");
        }
    }
}
