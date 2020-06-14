using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public class Poruka
    {
        private CodeType code;

        public CodeType Code
        {
            get { return code; }
            set { code = value; }
        }
        private int vrijednost;

        public int Vrijednost
        {
            get { return vrijednost; }
            set { vrijednost = value; }
        }

        public Poruka()
        {
        }

        public Poruka(CodeType code, int vrijednost)
        {
            Code = code;
            Vrijednost = vrijednost;
        }
    }
}
