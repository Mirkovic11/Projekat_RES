using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Contracts;

namespace ReplicatorSender
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ServiceHost host = new ServiceHost(typeof(Sender)))
            {
                string address = "net.tcp://localhost:6000/IPorukaOdWritera";
                NetTcpBinding binding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IPorukaOdWritera), binding, address);

                host.Open();
                Sender sender = new Sender();

                Console.WriteLine("Servis je pokrenut na adresi " + address);
                Console.ReadKey();
                host.Close();
            }

            
            
        }
    }
}
