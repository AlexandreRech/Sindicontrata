using System;
using System.Collections.Generic;
using Uniplac.Sindicontrata.Dominio.AdvertisementModule;

namespace Uniplac.Sindicontrata.Dominio.AdvertiserModule
{
    public class Advertiser
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        //public string Password { get; set; }

        public int Phone { get; set; }

        public IEnumerable<Advertisement> Advertisements { get; set; }

        public void Validates()
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentNullException("O nome do anunciante não pode estar branco.");
        }

        public override string ToString()
        {
            return string.Format("Id: {0} - {1} - {2} - {3}", Id, Name, Email, Phone);
        }
    }
}