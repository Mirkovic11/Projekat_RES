using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace ReplicatorReceiver
{
    public class HistoricalCollection
    {

        public List<Poruka> NizPoruka { get; set; }

        public HistoricalCollection()
        {
            List<Poruka> nizPoruka = new List<Poruka>();
        }

        public HistoricalCollection(List<Poruka> nizPoruka)
        {
            NizPoruka = nizPoruka;
        }
    }
}
