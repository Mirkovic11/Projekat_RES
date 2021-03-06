using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Contracts;

namespace ReplicatorReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Receiver)))
            {
                string address = "net.tcp://localhost:6001/IPosaljiPorukuRR";
                NetTcpBinding binding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IPosaljiPorukuRR), binding, address);

                host.Open();
                Receiver receiver = new Receiver();

                Console.WriteLine("Servis je pokrenut na adresi " + address);
                Console.ReadKey();
                host.Close();
            }

           
        }
    }
}
