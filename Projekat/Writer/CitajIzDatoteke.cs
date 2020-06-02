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
        public static List<Writer> UcitajVrijednosti(string path)
        {
            List<Writer> values = new List<Writer>();
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');

                Writer cv = new Writer((CodeType)Enum.Parse(typeof(CodeType), tokens[0]), Int32.Parse(tokens[1]));
                values.Add(cv);
            }
            sr.Close();
            stream.Close();

            return values;
        }
    }
}
