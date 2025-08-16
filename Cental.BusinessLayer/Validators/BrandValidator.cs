using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators
{
    public class BrandValidator: AbstractValidator<Brand>
    {
        public BrandValidator() 
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("cannot be left blank").MinimumLength(3).WithMessage("minimum character is must be 3");
            
        }
    }
}
