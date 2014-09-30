using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uniplac.Sindicontrata.WebApi.Models.QueryModels.Events
{
    public class EventsListQuery
    {
        public int Id { get; set; }
        //Tipo {System Event , Printer Event}
        public string Type { get; set; }

        //Data de Ocorrencia
        public DateTime DateEventOccurrence { get; set; }

        //Tempo Decorrido da Data de Ocorrencia
        public string TimeElapsedDateOccurrence { get; set; }

        //Informações do Evento
        public string Information { get; set; }

        public string MoreInformation { get; set; }

        public string Site { get; set; }

        public string CriticyLevel { get; set; }

        public string PrinterName { get; set; }

        public string PrinterIp { get; set; }

    }
}