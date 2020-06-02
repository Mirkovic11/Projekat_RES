using Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    public class CitajIzDatoteke
    {
        public static List<Poruka> UcitajVrijednosti(string path)
        {
            List<Poruka> values = new List<Poruka>();
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');

                Poruka cv = new Poruka((CodeType)Enum.Parse(typeof(CodeType), tokens[0]), Int32.Parse(tokens[1]));
                values.Add(cv);
            }
            sr.Close();
            stream.Close();

            return values;
        }
    }
}
