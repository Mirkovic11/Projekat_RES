using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class Ds3Model
    {
        public int Id { get; set; }
        public string DatumUpisa { get; set; }
        public int VrijednostSingleNode { get; set; }
        public int VrijednostMultipleNode { get; set; }

        public Ds3Model()
        {
        }

        public Ds3Model(int id, string datumUpisa, int vrijednostSingleNode, int vrijednostMultipleNode)
        {
            Id = id;
            DatumUpisa = datumUpisa;
            VrijednostSingleNode = vrijednostSingleNode;
            VrijednostMultipleNode = vrijednostMultipleNode;
        }
    }
}
