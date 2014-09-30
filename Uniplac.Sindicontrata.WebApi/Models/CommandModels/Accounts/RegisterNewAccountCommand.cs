using FluentValidation.Attributes;
using Uniplac.Sindicontrata.WebApi.Validators;

namespace Uniplac.Sindicontrata.WebApi.Models.CommandModels.Accounts
{
    [Validator(typeof(RegisterNewAccountCommandValidator))]
    public class RegisterNewAccountCommand
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}

