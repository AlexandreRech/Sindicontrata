using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Sindicontrata.CommandQueries.FornecedorModule;
using Uniplac.Sindicontrata.CommandQueries.FornecedorModule.Models;
using Uniplac.Sindicontrata.Dominio.FornecedorModule;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosCommon;

namespace Uniplac.Sindicontrata.Aplicacao.FornecedorModule
{
    public interface IFornecedorService
    {

        IEnumerable<FornecedorListQuery> GetFornecedoresList();

        FornecedorResumeQuery GetFornecedorResume(int id);

        CreateNewFornecedorCommand CreateNewFornecedor(CreateNewFornecedorCommand fornecedorCommand);
    }

    public class FornecedorService : IFornecedorService
    {
        private IUnitOfWork _unitOfWork;
        private IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IUnitOfWork unitOfWork, IFornecedorRepository fornecedorRepository)
        {
            _unitOfWork = unitOfWork;
            _fornecedorRepository = fornecedorRepository;
        }

        public IEnumerable<FornecedorListQuery> GetFornecedoresList()
        {
            return _fornecedorRepository.GetAll().Select(entity =>
                new FornecedorListQuery
                {
                    Id = entity.Id,
                    Nome = entity.Nome
                });
        }

        public FornecedorResumeQuery GetFornecedorResume(int id)
        {
            var entity = _fornecedorRepository.GetById(id);

            return new FornecedorResumeQuery
                {
                    Id = entity.Id,
                    Nome = entity.Nome
                };
        }

        public CreateNewFornecedorCommand CreateNewFornecedor(CreateNewFornecedorCommand fornecedorCommand)
        {
            var entity = new Fornecedor
                {
                    Nome = fornecedorCommand.Nome
                };

            entity.Valida();

            _fornecedorRepository.Add(entity);

            _unitOfWork.SaveChanges();

            fornecedorCommand.Id = entity.Id;

            return fornecedorCommand;
        }
    }
}