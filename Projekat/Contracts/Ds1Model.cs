using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class Ds1Model
    {
        public int Id { get; set; }
        public string DatumUpisa { get; set; }
        public int VrijednostDigital { get; set; }
        public int VrijednostAnalog { get; set; }

        public Ds1Model()
        {
        }

        public Ds1Model(int id, string datumUpisa, int vrijednostDigital, int vrijednostAnalog)
        {
            Id = id;
            DatumUpisa = datumUpisa;
            VrijednostDigital = vrijednostDigital;
            VrijednostAnalog = vrijednostAnalog;
        }
    }
}
