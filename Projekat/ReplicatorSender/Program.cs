using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Contracts;
using System.Threading;
using System.IO;

namespace ReplicatorSender
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (ServiceHost host = new ServiceHost(typeof(Sender)))
            {

                Logger.LoggerFunkcije.BrisanjeLoggerDatoteke();

                string address = "net.tcp://localhost:6000/IPorukaOdWritera";
                NetTcpBinding binding = new NetTcpBinding();
                host.AddServiceEndpoint(typeof(IPorukaOdWritera), binding, address);

                host.Open();
                Sender sender = new Sender();


                string adresa = "net.tcp://localhost:6001/IPosaljiPorukuRR";
                NetTcpBinding binding1 = new NetTcpBinding();

                ChannelFactory<IPosaljiPorukuRR> kanal = new ChannelFactory<IPosaljiPorukuRR>(binding1, adresa);
                IPosaljiPorukuRR proxy = kanal.CreateChannel();

                Poruka p1 = new Poruka();
                while (true)
                {
                    p1 = Bafer.GetInstance().ProcitajPoruku();
                    if (p1 != null)
                    {
                        proxy.PosaljiPorukuRR(p1);
                    }
                }



                Console.WriteLine("Servis je pokrenut na adresi " + address);
                Console.ReadKey();
                host.Close();
            }

         

        }
    }
}
