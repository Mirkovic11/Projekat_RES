using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Logger
{
    public class LoggerFunkcije
    {
        public static void LoggerUpisiUDatotekuPoruku(Poruka por)
        {
            string trenutni = Environment.CurrentDirectory;
            string trenutni1 = Directory.GetParent(trenutni).Parent.FullName;
            string trenutni2 = Directory.GetParent(trenutni1).Parent.FullName;


            FileStream stream = new FileStream(trenutni2 + "/Projekat/Logger/bin/Debug/logovanje.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine("Proslijedjena je vrijednost " + por.Code + ": " + por.Vrijednost + " iz Writer-a u Replicator Sender.");


            sw.Close();
            stream.Close();

        }

        public static void BrisanjeLoggerDatoteke()
        {
            string trenutni = Environment.CurrentDirectory;
            string trenutni1 = Directory.GetParent(trenutni).Parent.FullName;
            string trenutni2 = Directory.GetParent(trenutni1).Parent.FullName;


            FileStream stream = new FileStream(trenutni2 + "/Projekat/Logger/bin/Debug/logovanje.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(stream);

            sw.Close();
            stream.Close();
        }

        public static void LoggerUpisiUDatotekuPorukuRSRR(Poruka por)
        {
            string trenutni = Environment.CurrentDirectory;
            string trenutni1 = Directory.GetParent(trenutni).Parent.FullName;
            string trenutni2 = Directory.GetParent(trenutni1).Parent.FullName;


            FileStream stream = new FileStream(trenutni2 + "/Projekat/Logger/bin/Debug/logovanje.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine("Proslijedjena je vrijednost " + por.Code + ": " + por.Vrijednost + " iz Replicator Sendera-a u Replicator Receiver.");


            sw.Close();
            stream.Close();

        }

        public static void LoggerUpisiUDatotekuPorukuRRR(CollectionDescription cd)
        {
            string trenutni = Environment.CurrentDirectory;
            string trenutni1 = Directory.GetParent(trenutni).Parent.FullName;
            string trenutni2 = Directory.GetParent(trenutni1).Parent.FullName;


            FileStream stream = new FileStream(trenutni2 + "/Projekat/Logger/bin/Debug/logovanje.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("Proslijedjen je sledeci Collection Description u Reader: id:" + cd.Id + ";dataset:" + cd.Dataset + ";code");
            foreach (Poruka p in cd.HCollection.NizPoruka)
            {
                sw.WriteLine(p.Code + ";vrijednost" + p.Vrijednost);
            }

            sw.Close();
            stream.Close();
        }
    }
}
