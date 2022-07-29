using Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation
{
    public class UpdateFilmValidator : AbstractValidator<UpdateFilmDto>
    {
        public UpdateFilmValidator()
        {
           RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).MinimumLength(4);
            RuleFor(x => x.Year).GreaterThan(1950);
            RuleFor(x => x.CategoryId).GreaterThan(0);
        }
    }
}
