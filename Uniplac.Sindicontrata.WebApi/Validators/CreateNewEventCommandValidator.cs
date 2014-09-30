using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Uniplac.Sindicontrata.WebApi.Models.CommandModels.Events;

namespace Uniplac.Sindicontrata.WebApi.Validators
{
    public class CreateNewEventCommandValidator : AbstractValidator<CreateNewEventCommand>
    {
        public CreateNewEventCommandValidator()
        {
            RuleFor(x => x.DescriptionEvent)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CriticyLevel)
                 .NotEmpty()
                .NotNull();

            RuleFor(x => x.PrinterId).NotNull().NotEqual(0);
        }

    }
}