using System;

namespace Uniplac.Sindicontrata.Dominio.ContractorModule
{
    public class Contractor
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public void Validates()
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentNullException("O nome do contratante não pode estar branco.");
        }

        public override string ToString()
        {
            return string.Format("Id: {0} - {1}", Id, Name);
        }
    }
}