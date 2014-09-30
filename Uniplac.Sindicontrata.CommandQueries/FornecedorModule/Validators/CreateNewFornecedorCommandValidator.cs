using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Uniplac.Sindicontrata.CommandQueries.FornecedorModule;

namespace Uniplac.Sindicontrata.WebApi.Validators
{
    public class CreateNewFornecedorCommandValidator : AbstractValidator<CreateNewFornecedorCommand>
    {
        public CreateNewFornecedorCommandValidator()
        {            
            RuleFor(x => x.Nome)
                 .NotEmpty()
                .NotNull();            
        }

    }
}