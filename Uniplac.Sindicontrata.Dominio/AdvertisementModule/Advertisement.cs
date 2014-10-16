using System;
using Uniplac.Sindicontrata.Dominio.AdvertiserModule;

namespace Uniplac.Sindicontrata.Dominio.AdvertisementModule
{
    public class Advertisement
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public AdvertisementType Type { get; set; }
        
        public void Validates()
        {
            //if (string.IsNullOrEmpty(Name))
            //    throw new ArgumentNullException("O nome do anunciante não pode estar branco.");
        }

        //public override string ToString()
        //{
        //    //return string.Format("Id: {0} - {1} - {2} - {3}", Id, Name, Email, Phone);
        //}
    }
}