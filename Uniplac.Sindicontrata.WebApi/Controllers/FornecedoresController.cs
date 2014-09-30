using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders.Providers;
using Kendo.Mvc.UI;
using Ninject.Extensions.Logging;
using Uniplac.Sindicontrata.Aplicacao.FornecedorModule;
using Uniplac.Sindicontrata.CommandQueries.FornecedorModule;

namespace Uniplac.Sindicontrata.WebApi.Controllers
{
    [RoutePrefix("api/fornecedores")]
    public class FornecedoresController : ApiControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedoresController(IFornecedorService fornecedorService,
            ILoggerFactory loggerFactory
        )
            : base(loggerFactory)
        {
            _fornecedorService = fornecedorService;
        }


        public IHttpActionResult GetAllFornecedors([ModelBinder] DataSourceRequest queryParameters)
        {
            var list = _fornecedorService.GetFornecedoresList();

            if (list == null || !list.Any())
            {
                return NotFound();
            }

            return Ok(list);
        }

        [Route("{id:int}", Name = "GetFornecedorById")]
        public IHttpActionResult GetFornecedorById(int id)
        {
            var model = _fornecedorService.GetFornecedorResume(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
        public IHttpActionResult PostCreateNewFornecedor([FromBody]CreateNewFornecedorCommand fornecedorCommand)
        {
            fornecedorCommand = _fornecedorService.CreateNewFornecedor(fornecedorCommand);            

            var link = Url.Link("GetFornecedorById", new { id = fornecedorCommand.Id });

            return Created(link, fornecedorCommand);
        }
        public IHttpActionResult Delete(int id)
        {
            //remove logic
            return Ok();
        }



    }
}