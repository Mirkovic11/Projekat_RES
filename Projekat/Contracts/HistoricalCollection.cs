using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contracts
{
    public class HistoricalCollection
    {

        public List<Poruka> NizPoruka { get; set; }

        public HistoricalCollection()
        {
            //List<Poruka> nizPoruka = new List<Poruka>();
        }

        public HistoricalCollection(List<Poruka> nizPoruka)
        {
            NizPoruka = nizPoruka;
        }
    }
}
