using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contracts
{
    public class CollectionDescription
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private EnumDataSet dataset;

        public EnumDataSet Dataset
        {
            get { return dataset; }
            set { dataset = value; }
        }

        private HistoricalCollection hCollection;

        public HistoricalCollection HCollection
        {
            get { return hCollection; }
            set { hCollection = value; }
        }

        public CollectionDescription()
        {
          //  Id = -1;
           // Dataset = "";
            HCollection = new HistoricalCollection();
        }

        public CollectionDescription(int id, EnumDataSet dataset, HistoricalCollection hCollection)
        {
            Id = id;
            Dataset = dataset;
            HCollection = hCollection;
        }
    }
}
