using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.ServiceModel;

namespace ReplicatorSender
{
    public class Sender : IPorukaOdWritera
    {
        public List<Poruka> listaBafer = new List<Poruka>();

        public void PrimiPorukuOdWritera(string poruka)
        {
            string[] tokens = poruka.Split(';');

            Poruka por = new Poruka((CodeType)Enum.Parse(typeof(CodeType), tokens[0]), Int32.Parse(tokens[1]));

            //Bafer b = new Bafer();
            listaBafer.Add(por);
            Console.WriteLine("Uspjesno upisana poruka");

            foreach (Poruka p in listaBafer)
            {
                Console.WriteLine(p.Code+";"+p.Vrijednost);
            }

        
         
             // Console.WriteLine(" Poslao poruku RR: " + poruka);
        }
    }
}
