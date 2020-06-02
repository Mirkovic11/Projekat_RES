using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    class Program
    {
        static void Main(string[] args)
        {
            SlanjePodataka();
        }

        static void SlanjePodataka()
        {
            Console.WriteLine("Unesite putanju tekstualne datoteke iz koje zelite ucitati vrijednosti: ");

            string opcija = Console.ReadLine();

            string trenutni = Environment.CurrentDirectory;
            string trenutni2 = Directory.GetParent(trenutni).Parent.FullName;

            List<Writer> writers = CitajIzDatoteke.UcitajVrijednosti(trenutni2 + "/bin/Debug/podaci" + opcija + ".txt");

            
             /* foreach (var writer in writers)
              {
                  Console.WriteLine(writer.Code + ";" + writer.Vrijednost);
              }*/
            Console.ReadLine();
        }
    }
}
