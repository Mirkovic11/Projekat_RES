using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using System.IO;
using ReplicatorSender;
using Autofac.Extras.Moq;
using Contracts;

namespace ReplicatorSenderTest
{
    [TestFixture]
    public class ReplicatorSenderTest
    {
        [Test]
        public void TestBrisanjeIzSvihDatoteka()
        {
            LoggerFunkcije.BrisanjeLoggerDatoteke();

            FileStream stream = new FileStream("../../../Logger/bin/Debug/logovanje.txt", FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";

            line = sr.ReadLine();

            Assert.AreEqual(line, null);

            sr.Close();
            stream.Close();

        }

        public static IEnumerable<TestCaseData> VRIJEDNOSTZALOGER
        {
            get
            {
                yield return new TestCaseData(new Poruka(CodeType.CODE_ANALOG, 105));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOSTZALOGER")]
        public void TestUpisLoggerUDatoteku(Poruka poruka)
        {
            LoggerFunkcije.BrisanjeLoggerDatoteke();

            LoggerFunkcije.LoggerUpisiUDatotekuPoruku(poruka);

            FileStream stream = new FileStream("../../../Logger/bin/Debug/logovanje.txt", FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";

            line = sr.ReadLine();

            Assert.AreNotEqual(line, null);

            sr.Close();
            stream.Close();

        }
        

        private Poruka BaferPopuni()
        {
            return new Poruka(CodeType.CODE_ANALOG, 105);
        }

        [Test]
        public void TestCitanjaIzBafera()
        {
            Poruka porukaPisanje = new Poruka(CodeType.CODE_ANALOG, 105);

            Bafer.GetInstance().DodajPoruku(porukaPisanje);

            Poruka porukaCitanje = Bafer.GetInstance().ProcitajPoruku();

            Assert.AreEqual(porukaPisanje, porukaCitanje);
              
        }

        /*public static IEnumerable<TestCaseData> STRINGZATEST
        {
            get
            {
                yield return new TestCaseData(string );
            }
        }*/

        [Test]
        [TestCase("CODE_ANALOG;105")]
        public void TestPrijemPorukeOdWritera(string poruka)
        {
            Sender sender = new Sender();

            sender.PrimiPorukuOdWritera(poruka);

            Poruka poruka1 = Bafer.GetInstance().ProcitajPoruku();

            string porukica = poruka1.Code + ";" + poruka1.Vrijednost;

            Assert.AreEqual(porukica, poruka);
        }
    }

}
