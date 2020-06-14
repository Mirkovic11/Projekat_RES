using Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderTest
{
    [TestFixture]
    public class ReaderTest
    {
        public static IEnumerable<TestCaseData> CDZAREADER
        {
            get
            {
                yield return new TestCaseData(new CollectionDescription(22, EnumDataSet.DataSet1, new HistoricalCollection(new List<Poruka>() { new Poruka(CodeType.CODE_ANALOG, 166), new Poruka(CodeType.CODE_DIGITAL, 0) })));
            }
        }

        [Test]
        [TestCaseSource("CDZAREADER")]
        public void ReaderTestZaUpisUBazu(CollectionDescription CD)
        {
            DataBaseRESContext context = new DataBaseRESContext();

            context.DS1.Add(new Ds1Model(0, DateTime.Now.ToString(), 1, 255));

            IPosaljiDS1 ip = new Reader.Reader();

            ip.PosaljiDS1(CD);

            List<Ds1Model> ds1 = context.DS1.ToList();

            Assert.AreEqual(ds1[ds1.Count()-1].VrijednostAnalog, CD.HCollection.NizPoruka[0].Vrijednost);
            Assert.AreEqual(ds1[ds1.Count()-1].VrijednostDigital, CD.HCollection.NizPoruka[1].Vrijednost);
        }

        public static IEnumerable<TestCaseData> CDZAREADER2
        {
            get
            {
                yield return new TestCaseData(new CollectionDescription(22, EnumDataSet.DataSet2, new HistoricalCollection(new List<Poruka>() { new Poruka(CodeType.CODE_CUSTOM, 166), new Poruka(CodeType.CODE_LIMITSET, 0) })));
            }
        }

        [Test]
        [TestCaseSource("CDZAREADER2")]
        public void ReaderTestZaUpisUBazu2(CollectionDescription CD)
        {
            DataBaseRESContext context = new DataBaseRESContext();

            context.DS2.Add(new Ds2Model(0, DateTime.Now.ToString(), 1, 255));

            IPosaljiDS1 ip = new Reader.Reader();

            ip.PosaljiDS1(CD);

            List<Ds2Model> ds2 = context.DS2.ToList();

            Assert.AreEqual(ds2[ds2.Count() - 1].VrijednostCustom, CD.HCollection.NizPoruka[0].Vrijednost);
            Assert.AreEqual(ds2[ds2.Count() - 1].VrijednostLimitSet, CD.HCollection.NizPoruka[1].Vrijednost);
        }
    }
}
