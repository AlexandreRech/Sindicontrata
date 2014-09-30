using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Uniplac.Sindicontrata.WebApi.Models;
using Uniplac.Sindicontrata.WebApi.Models.CommandModels.Accounts;

namespace Uniplac.Sindicontrata.WebApi.Validators
{
    public class RegisterNewAccountCommandValidator : AbstractValidator<RegisterNewAccountCommand>
    {
        public RegisterNewAccountCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty();

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password);
        }
    }
}