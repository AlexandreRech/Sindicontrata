using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders.Providers;
using Kendo.Mvc.UI;
using Ninject.Extensions.Logging;
using Uniplac.Sindicontrata.WebApi.Models.CommandModels.Events;
using Uniplac.Sindicontrata.WebApi.Services;

namespace Uniplac.Sindicontrata.WebApi.Controllers
{
    [RoutePrefix("api/events")]
    public class EventsController : ApiControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService,
            ILoggerFactory loggerFactory
        )
            : base(loggerFactory)
        {
            _eventService = eventService;
        }


        public IHttpActionResult GetAllEvents([ModelBinder] DataSourceRequest queryParameters)
        {
            var list = _eventService.GetEventsList();

            if (list == null || !list.Any())
            {
                return NotFound();
            }

            return Ok(list);
        }

        [Route("{id:int}", Name = "GetEventById")]
        public IHttpActionResult GetEventById(int id)
        {
            var model = _eventService.GetEventResume(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
        public IHttpActionResult PostCreateNewEvent([FromBody]CreateNewEventCommand eventCommand)
        {
            eventCommand = _eventService.CreateNewEvent(eventCommand);

            //var link = Url.Link("DefaultApi", new { controller = "Events", id = eventCommand.Id })

            var link = Url.Link("GetEventById", new { id = eventCommand.Id });

            return Created(link, eventCommand);
        }
        public IHttpActionResult Delete(int id)
        {
            //remove logic
            return Ok();
        }



    }
}