using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Sindicontrata.WebApi.Validators;

namespace Uniplac.Sindicontrata.CommandQueries.ContractorModule
{
    [Validator(typeof(CreateNewContractorCommandValidator))]
    public class CreateNewContractorCommand
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
