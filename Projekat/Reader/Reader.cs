using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
namespace Reader
{
    public class Reader : IPosaljiDS1
    {
        public void PosaljiDS1(CollectionDescription cd)
        {
            Console.WriteLine("Primio sam poruku: id:" + cd.Id + ";dataset:" + cd.Dataset + ";code");
            foreach (Poruka p in cd.HCollection.NizPoruka)
            {
                Console.WriteLine(p.Code + ";vrijednost" + p.Vrijednost);
            }     

        }
    }
}
