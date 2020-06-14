using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Writer;
namespace WriterTest
{
    [TestFixture]
    public class WriterTest
    {
        [Test]
        [TestCase("../../../Writer/bin/Debug/podaci1.txt")]
        [TestCase("../../../Writer/bin/Debug/podaci2.txt")]
        [TestCase("../../../Writer/bin/Debug/podaci3.txt")]
        public void UcitajVrijednostiIzDatotekeTest(string putanja)
        {
            List<Poruka> poruke = Writer.CitajIzDatoteke.UcitajVrijednosti(putanja);

            Assert.AreNotEqual(poruke.Count, 0);
        }
    }
}
