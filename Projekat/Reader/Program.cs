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
            UpaliReader1();
            UpaliReader2();
            UpaliReader3();
            UpaliReader4();
            Console.ReadKey();
        }

        public static void UpaliReader1()
        {
            ServiceHost host = new ServiceHost(typeof(Reader));
            
                string address = "net.tcp://localhost:8002/IPosaljiDS1";
                NetTcpBinding binding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IPosaljiDS1), binding, address);

                host.Open();
                Reader receiver = new Reader();

                Console.WriteLine("Servis je pokrenut na adresi " + address);
               
            
         
        }
        public static void UpaliReader2()
        {

                ServiceHost host = new ServiceHost(typeof(Reader));
            
                string address = "net.tcp://localhost:8003/IPosaljiDS1";
                NetTcpBinding binding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IPosaljiDS1), binding, address);

                host.Open();
                Reader receiver = new Reader();

                Console.WriteLine("Servis je pokrenut na adresi " + address);

            
            
        }
        public static void UpaliReader3()
        {
            ServiceHost host = new ServiceHost(typeof(Reader));
            
                string address = "net.tcp://localhost:8004/IPosaljiDS1";
                NetTcpBinding binding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IPosaljiDS1), binding, address);

                host.Open();
                Reader receiver = new Reader();

                Console.WriteLine("Servis je pokrenut na adresi " + address);

            
        }
        public static void UpaliReader4()
        {
            ServiceHost host = new ServiceHost(typeof(Reader));
            
                string address = "net.tcp://localhost:8005/IPosaljiDS1";
                NetTcpBinding binding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IPosaljiDS1), binding, address);

                host.Open();
                Reader receiver = new Reader();

                Console.WriteLine("Servis je pokrenut na adresi " + address);

            
        }
    }
}
