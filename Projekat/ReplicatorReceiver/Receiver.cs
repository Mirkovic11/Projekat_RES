using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace ReplicatorReceiver
{
    public class Receiver : IPosaljiPorukuRR
    {
        public void PosaljiPorukuRR(Poruka poruka)
        {
            Console.WriteLine("Primio poruku: " + poruka.Code+";"+poruka.Vrijednost);
        }
    }
}
