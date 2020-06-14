using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.ServiceModel;
using System.Threading;
using System.Diagnostics;

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
                        PaljenjeNovogWritera();
                        break;
                    case 2:
                        GasenjePostojecegWritera();
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
            //Console.WriteLine("Unesite putanju tekstualne datoteke iz koje zelite ucitati vrijednosti:[1-3] ");
            int opcija;
            do
            {
                Console.WriteLine("Unesite putanju tekstualne datoteke iz koje zelite ucitati vrijednosti:[1-3] ");
                opcija = Int32.Parse(Console.ReadLine());
                
            } while (opcija < 1 || opcija > 3);
           
            string trenutni = Environment.CurrentDirectory;
            string trenutni2 = Directory.GetParent(trenutni).Parent.FullName;

            List<Poruka> writers = CitajIzDatoteke.UcitajVrijednosti(trenutni2 + "/bin/Debug/podaci" + opcija + ".txt");

 //--------------------Otvaranje konekcije ka Sender-u---------------------------
            string adresa = "net.tcp://localhost:6000/IPorukaOdWritera";
            NetTcpBinding binding = new NetTcpBinding();

            ChannelFactory<IPorukaOdWritera> kanal = new ChannelFactory<IPorukaOdWritera>(binding, adresa);
            IPorukaOdWritera proxy = kanal .CreateChannel();
//------------------------------------------------------------------------------------------------
          foreach(Poruka w in writers) //otkomentarisati kad se uradi konekcija na sender-u
            {
                proxy.PrimiPorukuOdWritera(w.Code+";"+ w.Vrijednost);
                Thread.Sleep(2000);
            }
            Console.WriteLine("Slanje podataka je uspjesno zavrseno.");
            Console.WriteLine("Pritisnite bilo koji taster da biste dalje nastavili.");

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

        public static void PaljenjeNovogWritera()
        {
            string trenutni = Environment.CurrentDirectory;
            Process.Start(trenutni+"/Writer.exe");
        }

        public static void GasenjePostojecegWritera()
        {
            Process[] listaProcesa = Process.GetProcessesByName("Writer");
            int ugasi = listaProcesa.Count()-1;

            int id = listaProcesa[ugasi].Id;
            foreach (Process proces in listaProcesa)
            {
                if(proces.Id == id)
                {
                    proces.Kill();
                }
            }
        }
    }
}
