﻿using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicatorSender
{
    public class Bafer
    {

        public static Bafer instance;

        public static List<Poruka> baferLista = new List<Poruka>();

        public static Bafer GetInstance()
        {
            if(instance == null)
            {
                instance = new Bafer();
            }
            return instance;
        }

        public void DodajPoruku(Poruka poruka)
        {
            baferLista.Add(poruka);
        }

        private Bafer()
        {
            baferLista = new List<Poruka>();
        }
              
    }
}
