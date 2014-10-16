using System;

namespace Uniplac.Sindicontrata.Dominio.ContractorModule
{
    public class Contractor
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public void Validates()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new ArgumentNullException("O nome do Contractor não pode estar branco.");
        }

        public override string ToString()
        {
            return string.Format("Id: {0} - {1}", Id, Nome);
        }
    }
}