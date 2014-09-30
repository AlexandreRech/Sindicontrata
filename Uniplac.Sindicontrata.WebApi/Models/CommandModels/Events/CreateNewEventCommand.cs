using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;
using Uniplac.Sindicontrata.WebApi.Validators;

namespace Uniplac.Sindicontrata.WebApi.Models.CommandModels.Events
{
    [Validator(typeof(CreateNewEventCommandValidator))]
    public class CreateNewEventCommand
    {
        public int Id { get; set; }

        public int PrinterId { get; set; }

        public string CriticyLevel { get; set; }

        public string DescriptionEvent { get; set; }
    }
}