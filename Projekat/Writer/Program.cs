using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.ServiceModel;
using System.Threading;

namespace Writer
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int opcija;
            do
            {
                opcija = 0;
                IspisiMeni();

                try
                {
                    opcija = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unesite broj!");
                }

                switch (opcija)
                {
                  
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        SlanjePodataka();
                        break;
                    default:
                        Console.WriteLine("Pogresna opcija!");
                        break;


                }
            } while (opcija != 0);

            
        }

        static void SlanjePodataka()
        {
            Console.WriteLine("Unesite putanju tekstualne datoteke iz koje zelite ucitati vrijednosti: ");

            string opcija = Console.ReadLine();

            string trenutni = Environment.CurrentDirectory;
            string trenutni2 = Directory.GetParent(trenutni).Parent.FullName;

            List<Writer> writers = CitajIzDatoteke.UcitajVrijednosti(trenutni2 + "/bin/Debug/podaci" + opcija + ".txt");

 //--------------------Otvaranje konekcije ka Sender-u---------------------------
            string adresa = "net.tcp://localhost:6000/IPorukaOdWritera";
            NetTcpBinding binding = new NetTcpBinding();

            ChannelFactory<IPorukaOdWritera> kanal = new ChannelFactory<IPorukaOdWritera>(binding, adresa);
            IPorukaOdWritera proxy = kanal .CreateChannel();
//------------------------------------------------------------------------------------------------

          foreach(Writer w in writers) //otkomentarisati kad se uradi konekcija na sender-u
            {
                proxy.PrimiPorukuOdWritera(w.Code+";"+ w.Vrijednost);
                Thread.Sleep(2000);
            }
            Console.WriteLine("Slanje podataka je uspjesno zavrseno.");
            Console.WriteLine("Pritisnite bilo koji taster da biste dalje nastavili.");

            /* foreach (var writer in writers)
              {
                  Console.WriteLine(writer.Code + ";" + writer.Vrijednost);
              }*/
            Console.ReadLine();
        }
        public static void IspisiMeni()
        {
            Console.WriteLine("Izaberite opciju:");
            Console.WriteLine("1. Paljenje novog Writer-a");
            Console.WriteLine("2. Gasenje postojeceg Writer-a");
            Console.WriteLine("3. Slanje podataka");
            Console.WriteLine("0. Izlaz");

        }
    }
}
