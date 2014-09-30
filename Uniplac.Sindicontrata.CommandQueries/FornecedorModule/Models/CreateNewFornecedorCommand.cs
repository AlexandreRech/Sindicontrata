using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Sindicontrata.WebApi.Validators;

namespace Uniplac.Sindicontrata.CommandQueries.FornecedorModule
{
    [Validator(typeof(CreateNewFornecedorCommandValidator))]
    public class CreateNewFornecedorCommand
    {
        public long Id { get; set; }

        public string Nome { get; set; }
    }
}
