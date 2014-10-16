using Ninject.Extensions.Logging;
using System.Linq;
using System.Web.Http;
using Uniplac.Sindicontrata.Aplicacao.ContractorModule;
using Uniplac.Sindicontrata.CommandQueries.ContractorModule;

namespace Uniplac.Sindicontrata.WebApi.Controllers
{
    [RoutePrefix("api/contractors")]
    public class ContractorsController : ApiControllerBase
    {
        private readonly IContractorService _ContractorService;

        public ContractorsController(IContractorService ContractorService,
            ILoggerFactory loggerFactory
        )
            : base(loggerFactory)
        {
            _ContractorService = ContractorService;
        }

        [Route("")]
        public IHttpActionResult GetAllContractors()
        {
            var list = _ContractorService.GetContractorsList();

            if (list == null || !list.Any())
            {
                return NotFound();
            }

            return Ok(list);
        }

        [Route("{id:int}")]
        public IHttpActionResult GetContractorById(int id)
        {
            var model = _ContractorService.GetContractorResume(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [Route("")]
        public IHttpActionResult PostCreateNewContractor(CreateNewContractorCommand ContractorCommand)
        {
            ContractorCommand = _ContractorService.CreateNewContractor(ContractorCommand);

            var link = Url.Link("GetContractorById", new { id = ContractorCommand.Id });

            return Created(link, ContractorCommand);
        }

        public IHttpActionResult Delete(int id)
        {
            //remove logic
            return Ok();
        }
    }
}