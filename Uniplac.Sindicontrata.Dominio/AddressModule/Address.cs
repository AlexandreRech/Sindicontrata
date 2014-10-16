using System;

namespace Uniplac.Sindicontrata.Dominio.AddressModule
{
    public class Address
    {
        public long Id { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string CEP { get; set; }

        public void Validates()
        {
            //if (string.IsNullOrEmpty(Name))
            //    throw new ArgumentNullException("O nome do contratante não pode estar branco.");
        }

        //public override string ToString()
        //{
        //    //return string.Format("Id: {0} - {1} - {2} - {3}", Id, Name, Email, Telefone);
        //}
    }
}