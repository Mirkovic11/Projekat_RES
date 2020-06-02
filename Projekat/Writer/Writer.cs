using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    public class Writer
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

        public Writer()
        {
        }

        public Writer(CodeType code, int vrijednost)
        {
            Code = code;
            Vrijednost = vrijednost;
        }
    }
}
