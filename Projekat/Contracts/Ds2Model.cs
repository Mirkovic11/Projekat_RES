using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class Ds2Model
    {
        public int Id { get; set; }
        public string DatumUpisa { get; set; }
        public int VrijednostCustom { get; set; }
        public int VrijednostLimitSet { get; set; }

        public Ds2Model()
        {
        }

        public Ds2Model(int id, string datumUpisa, int vrijednostCustom, int vrijednostLimitSet)
        {
            Id = id;
            DatumUpisa = datumUpisa;
            VrijednostCustom = vrijednostCustom;
            VrijednostLimitSet = vrijednostLimitSet;
        }
    }
}
