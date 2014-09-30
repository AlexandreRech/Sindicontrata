using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uniplac.Sindicontrata.WebApi.Models.QueryModels.Events
{
    public class EventResumeQuery
    {
        public int Id { get; set; }
        //Tipo {System Event , Printer Event}
        public string Type { get; set; }

        //Data de Ocorrencia
        public DateTime DateEventOccurrence { get; set; }

        //Tempo Decorrido da Data de Ocorrencia
        public string TimeElapsedDateOccurrence { get; set; }

        //Data Ultima Atualizacao
        public DateTime DateLastUpdate { get; set; }

        //Tempo Decorrido Data Ultima Atualizacao
        public string TimeElapsedDateLastUpdate { get; set; }

        //Informações do Evento
        public string Information { get; set; }

    }
}