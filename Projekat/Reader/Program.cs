using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Contracts;

namespace Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Reader)))
            {
                string address = "net.tcp://localhost:6002/IPosaljiDS1";
                NetTcpBinding binding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IPosaljiDS1), binding, address);

                host.Open();
                Reader receiver = new Reader();

                Console.WriteLine("Servis je pokrenut na adresi " + address);
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
