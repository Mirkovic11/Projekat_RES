using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace ReplicatorReceiver
{
    public class Receiver : IPorukaOdWritera
    {
        public void PrimiPorukuOdWritera(string poruka)
        {
            Console.WriteLine("Primio poruku: " + poruka);
        }
    }
}
