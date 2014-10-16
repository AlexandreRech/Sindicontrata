using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Uniplac.Sindicontrata.CommandQueries.ContractorModule;

namespace Uniplac.Sindicontrata.WebApi.Validators
{
    public class CreateNewContractorCommandValidator : AbstractValidator<CreateNewContractorCommand>
    {
        public CreateNewContractorCommandValidator()
        {            
            RuleFor(x => x.Name)
                 .NotEmpty()
                .NotNull();            
        }

    }
}