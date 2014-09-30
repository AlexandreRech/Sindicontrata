using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Sindicontrata.Dominio.FornecedorModule
{
    public class Fornecedor
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public void Valida()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new ArgumentNullException("O nome do fornecedor não pode estar branco.");
        }

        public override string ToString()
        {
            return string.Format("Id: {0} - {1}", Id, Nome);
        }
    }
}