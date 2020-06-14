using Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reader;
using System.ServiceModel;

namespace ReplicatorReceiverTest
{
    [TestFixture]
    public class ReplicatorReceiverTest
    {
        public static IEnumerable<TestCaseData> VRIJEDNOST
        {
            get
            {
                yield return new TestCaseData(new Poruka(CodeType.CODE_ANALOG, 1056));
            }
        }  

        [Test]
        [TestCaseSource("VRIJEDNOST")]
        public void TestZaReplicatorDS1(Poruka poruka)
        {
            ReplicatorReceiver.Receiver receiver = new ReplicatorReceiver.Receiver();

            receiver.PosaljiPorukuRR(poruka);

            Poruka pp = new Poruka();

            foreach(Poruka por in receiver.analog)
            {
                pp = por;
                break;
            }

            Assert.AreEqual(poruka.Vrijednost, pp.Vrijednost);
            Assert.AreEqual(poruka.Code, pp.Code);
        }

        //----
        public static IEnumerable<TestCaseData> VRIJEDNOST1
        {
            get
            {
                yield return new TestCaseData(new Poruka(CodeType.CODE_DIGITAL, 1));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST1")]
        public void TestZaReplicatorDS1a(Poruka poruka)
        {
            ReplicatorReceiver.Receiver receiver = new ReplicatorReceiver.Receiver();

            receiver.PosaljiPorukuRR(poruka);

            Poruka pp = new Poruka();

            foreach (Poruka por in receiver.digital)
            {
                pp = por;
                break;
            }

            Assert.AreEqual(poruka.Vrijednost, pp.Vrijednost);
            Assert.AreEqual(poruka.Code, pp.Code);
        }

        //-----
        public static IEnumerable<TestCaseData> VRIJEDNOST2
        {
            get
            {
                yield return new TestCaseData(new Poruka(CodeType.CODE_CUSTOM, 1000));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST2")]
        public void TestZaReplicatorDS2(Poruka poruka)
        {
            ReplicatorReceiver.Receiver receiver = new ReplicatorReceiver.Receiver();

            receiver.PosaljiPorukuRR(poruka);

            Poruka pp = new Poruka();

            foreach (Poruka por in receiver.custom)
            {
                pp = por;
                break;
            }

            Assert.AreEqual(poruka.Vrijednost, pp.Vrijednost);
            Assert.AreEqual(poruka.Code, pp.Code);
        }

        //----
        public static IEnumerable<TestCaseData> VRIJEDNOST3
        {
            get
            {
                yield return new TestCaseData(new Poruka(CodeType.CODE_LIMITSET, 2000));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST3")]
        public void TestZaReplicatorDS2a(Poruka poruka)
        {
            ReplicatorReceiver.Receiver receiver = new ReplicatorReceiver.Receiver();

            receiver.PosaljiPorukuRR(poruka);

            Poruka pp = new Poruka();

            foreach (Poruka por in receiver.limitset)
            {
                pp = por;
                break;
            }

            Assert.AreEqual(poruka.Vrijednost, pp.Vrijednost);
            Assert.AreEqual(poruka.Code, pp.Code);
        }

        //------------------------------------------------------------------------------------------------------------
        public static IEnumerable<TestCaseData> VRIJEDNOST4
        {
            get
            {
                yield return new TestCaseData(new Poruka(CodeType.CODE_SINGLENODE, 55));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST4")]
        public void TestZaReplicatorDS3(Poruka poruka)
        {
            ReplicatorReceiver.Receiver receiver = new ReplicatorReceiver.Receiver();

            receiver.PosaljiPorukuRR(poruka);

            Poruka pp = new Poruka();

            foreach (Poruka por in receiver.singlenode)
            {
                pp = por;
                break;
            }

            Assert.AreEqual(poruka.Vrijednost, pp.Vrijednost);
            Assert.AreEqual(poruka.Code, pp.Code);
        }

        //--
        public static IEnumerable<TestCaseData> VRIJEDNOST5
        {
            get
            {
                yield return new TestCaseData(new Poruka(CodeType.CODE_MULTIPLENODE, 365));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST5")]
        public void TestZaReplicatorDS3a(Poruka poruka)
        {
            ReplicatorReceiver.Receiver receiver = new ReplicatorReceiver.Receiver();

            receiver.PosaljiPorukuRR(poruka);

            Poruka pp = new Poruka();

            foreach (Poruka por in receiver.multiplenode)
            {
                pp = por;
                break;
            }

            Assert.AreEqual(poruka.Vrijednost, pp.Vrijednost);
            Assert.AreEqual(poruka.Code, pp.Code);
        }

        //-----
        public static IEnumerable<TestCaseData> VRIJEDNOST6
        {
            get
            {
                yield return new TestCaseData(new Poruka(CodeType.CODE_CONSUMER, 1234));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST6")]
        public void TestZaReplicatorDS4(Poruka poruka)
        {
            ReplicatorReceiver.Receiver receiver = new ReplicatorReceiver.Receiver();

            receiver.PosaljiPorukuRR(poruka);

            Poruka pp = new Poruka();

            foreach (Poruka por in receiver.consumer)
            {
                pp = por;
                break;
            }

            Assert.AreEqual(poruka.Vrijednost, pp.Vrijednost);
            Assert.AreEqual(poruka.Code, pp.Code);
        }

        //-----
        public static IEnumerable<TestCaseData> VRIJEDNOST7
        {
            get
            {
                yield return new TestCaseData(new Poruka(CodeType.CODE_SOURCE, 10858));
            }
        }

        [Test]
        [TestCaseSource("VRIJEDNOST7")]
        public void TestZaReplicatorDS4a(Poruka poruka)
        {
            ReplicatorReceiver.Receiver receiver = new ReplicatorReceiver.Receiver();

            receiver.PosaljiPorukuRR(poruka);

            Poruka pp = new Poruka();

            foreach (Poruka por in receiver.source)
            {
                pp = por;
                break;
            }

            Assert.AreEqual(poruka.Vrijednost, pp.Vrijednost);
            Assert.AreEqual(poruka.Code, pp.Code);
        }
    }
}
