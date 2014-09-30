using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uniplac.Sindicontrata.WebApi.Models.QueryModels.Events
{
    public class EventQuery
    {
        public int Id { get; set; }
        //Tipo {System Event , Printer Event}

        public string Title { get; set; }
        public string Description { get; set; }
    }
}