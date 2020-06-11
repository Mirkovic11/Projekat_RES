using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class Ds4Model
    {
        public int Id { get; set; }
        public string DatumUpisa { get; set; }
        public int VrijednostConsumer { get; set; }
        public int VrijednostSource { get; set; }

        public Ds4Model()
        {
        }

        public Ds4Model(int id, string datumUpisa, int vrijednostConsumer, int vrijednostSource)
        {
            Id = id;
            DatumUpisa = datumUpisa;
            VrijednostConsumer = vrijednostConsumer;
            VrijednostSource = vrijednostSource;
        }
    }
}
