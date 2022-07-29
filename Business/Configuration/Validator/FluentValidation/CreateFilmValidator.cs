using Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation
{
    public class CreateFilmValidator : AbstractValidator<CreateFilmDto>
    {
        public CreateFilmValidator()
        {
            RuleFor(film => film.Name).NotEmpty();
            RuleFor(film => film.Year).NotEmpty().GreaterThan(1950);
            RuleFor(film => film.CategoryId).GreaterThan(0);
        }
    }
}
