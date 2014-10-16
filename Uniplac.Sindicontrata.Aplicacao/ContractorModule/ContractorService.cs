using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Sindicontrata.CommandQueries.ContractorModule;
using Uniplac.Sindicontrata.CommandQueries.ContractorModule.Models;
using Uniplac.Sindicontrata.Dominio.ContractorModule;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosCommon;

namespace Uniplac.Sindicontrata.Aplicacao.ContractorModule
{
    public interface IContractorService
    {

        IEnumerable<ContractorListQuery> GetContractorsList();

        ContractorResumeQuery GetContractorResume(int id);

        CreateNewContractorCommand CreateNewContractor(CreateNewContractorCommand ContractorCommand);
    }

    public class ContractorService : IContractorService
    {
        private IUnitOfWork _unitOfWork;
        private IContractorRepository _ContractorRepository;

        public ContractorService(IUnitOfWork unitOfWork, IContractorRepository ContractorRepository)
        {
            _unitOfWork = unitOfWork;
            _ContractorRepository = ContractorRepository;
        }

        public IEnumerable<ContractorListQuery> GetContractorsList()
        {
            return _ContractorRepository.GetAll().Select(entity =>
                new ContractorListQuery
                {
                    Id = entity.Id,
                    Nome = entity.Nome
                });
        }

        public ContractorResumeQuery GetContractorResume(int id)
        {
            var entity = _ContractorRepository.GetById(id);

            return new ContractorResumeQuery
                {
                    Id = entity.Id,
                    Nome = entity.Nome
                };
        }

        public CreateNewContractorCommand CreateNewContractor(CreateNewContractorCommand ContractorCommand)
        {
            var entity = new Contractor
                {
                    Nome = ContractorCommand.Nome
                };

            entity.Validates();

            _ContractorRepository.Add(entity);

            _unitOfWork.SaveChanges();

            ContractorCommand.Id = entity.Id;

            return ContractorCommand;
        }
    }
}