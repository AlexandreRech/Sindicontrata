using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uniplac.Sindicontrata.WebApi.Models.CommandModels.Events;
using Uniplac.Sindicontrata.WebApi.Models.QueryModels.Events;

namespace Uniplac.Sindicontrata.WebApi.Services
{
    public interface IEventService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<EventsListQuery> GetEventsList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EventResumeQuery GetEventResume(int id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventModel"></param>
        /// <returns></returns>
        CreateNewEventCommand CreateNewEvent(CreateNewEventCommand eventModel);
    }

    public class EventServiceStub : IEventService
    {
        public IEnumerable<EventsListQuery> GetEventsList()
        {
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                string timeMessage = string.Format("2{0} horas atrás", i + 1);

                yield return new EventsListQuery
                {
                    Id = i,
                    DateEventOccurrence = DateTime.Now.AddHours(-10 + i),
                    Information = "Esta empresa não tem impressões desde ontem",
                    TimeElapsedDateOccurrence = timeMessage,
                    Type = "System Event",
                    PrinterIp = "172.31.5." + i + 1,
                    PrinterName = "Ricoh Aficio MP C300" + i + 1,
                    Site = "172.31.0." + i + 1,
                    CriticyLevel = rnd.Next() % 2 == 0 ? "Warning" : "Danger",
                    MoreInformation = timeMessage,

                };
            }
        }

        public EventResumeQuery GetEventResume(int id)
        {
            var model = new EventResumeQuery
            {
                DateLastUpdate = DateTime.Now,
                DateEventOccurrence = DateTime.Now.AddHours(-10),
                TimeElapsedDateLastUpdate = "10 horas atrás",
                Information = "Esta empresa não tem impressões desde ontem",
                TimeElapsedDateOccurrence = "20 horas atrás",
                Type = "System Event"
            };

            return model;
        }

        public CreateNewEventCommand CreateNewEvent(CreateNewEventCommand eventCommand)
        {
            eventCommand.Id = new Random().Next(1000);

            return eventCommand;
        }
    }

}