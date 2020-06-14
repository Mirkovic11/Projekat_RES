using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Contracts
{
    [ServiceContract]
    public interface IPosaljiDS1
    {
        [OperationContract]
        void PosaljiDS1(CollectionDescription cd);
    }
}
