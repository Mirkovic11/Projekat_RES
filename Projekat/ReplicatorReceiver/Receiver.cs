using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Logger;


namespace ReplicatorReceiver
{
    public class Receiver : IPosaljiPorukuRR
    {

        public List<Poruka> analog = new List<Poruka>();
        public List<Poruka> digital = new List<Poruka>();
        public List<Poruka> custom = new List<Poruka>();
        public List<Poruka> limitset = new List<Poruka>();
        public List<Poruka> singlenode = new List<Poruka>();
        public List<Poruka> multiplenode = new List<Poruka>();
        public List<Poruka> consumer = new List<Poruka>();
        public List<Poruka> source = new List<Poruka>();

        int brojac = 0;
        public void PosaljiPorukuRR(Poruka poruka)
        {

            List<Poruka> por = new List<Poruka>();
            por.Add(poruka);
            HistoricalCollection hc = new HistoricalCollection(por);
            if (poruka.Code == CodeType.CODE_ANALOG)
            {
                //CollectionDescription cd = new CollectionDescription(brojac, EnumDataSet.DataSet1, hc);
                analog.Add(poruka);
                PosaljiDS1(poruka);
            }
            else if (poruka.Code == CodeType.CODE_DIGITAL)
            {
                //CollectionDescription cd = new CollectionDescription(brojac, EnumDataSet.DataSet1, hc);
                digital.Add(poruka);
                PosaljiDS1(poruka);
            }
            else if (poruka.Code == CodeType.CODE_CUSTOM)
            {
                //CollectionDescription cd = new CollectionDescription(brojac, EnumDataSet.DataSet2, hc);
                custom.Add(poruka);
                PosaljiDS2(poruka);
            }
            else if (poruka.Code == CodeType.CODE_LIMITSET)
            {
                //CollectionDescription cd = new CollectionDescription(brojac, EnumDataSet.DataSet2, hc);
                limitset.Add(poruka);
                PosaljiDS2(poruka);
            }
            else if (poruka.Code == CodeType.CODE_SINGLENODE)
            {
                //CollectionDescription cd = new CollectionDescription(brojac, EnumDataSet.DataSet3, hc);
                singlenode.Add(poruka);
                PosaljiDS3(poruka);
            }
            else if (poruka.Code == CodeType.CODE_MULTIPLENODE)
            {
                //CollectionDescription cd = new CollectionDescription(brojac, EnumDataSet.DataSet3, hc);
                multiplenode.Add(poruka);
                PosaljiDS3(poruka);
            }
            else if (poruka.Code == CodeType.CODE_CONSUMER)
            {
                //CollectionDescription cd = new CollectionDescription(brojac, EnumDataSet.DataSet4, hc);
                consumer.Add(poruka);
                PosaljiDS4(poruka);
            }
            else if (poruka.Code == CodeType.CODE_SOURCE)
            {
                //CollectionDescription cd = new CollectionDescription(brojac, EnumDataSet.DataSet4, hc);
                source.Add(poruka);
                PosaljiDS4(poruka);
            }

            Console.WriteLine("Primio poruku: " + poruka.Code + ";" + poruka.Vrijednost);
        }

        //public bool DS1Spreman = false;
        public void PosaljiDS1(Poruka poruka)
        {
            if (poruka.Code == CodeType.CODE_ANALOG)
            {
                if (digital.Count > 0)
                {
                    string adresa = "net.tcp://localhost:6002/IPosaljiDS1";
                    NetTcpBinding binding1 = new NetTcpBinding();

                    ChannelFactory<IPosaljiDS1> kanal = new ChannelFactory<IPosaljiDS1>(binding1, adresa);
                    IPosaljiDS1 proxy = kanal.CreateChannel();
                    HistoricalCollection hc = new HistoricalCollection(new List<Poruka>());

                    foreach (Poruka por in digital)
                    {
                        hc.NizPoruka.Add(por);
                        digital.Remove(por);
                        break;
                    }

                    foreach (Poruka por in analog)
                    {
                        hc.NizPoruka.Add(por);
                        analog.Remove(por);
                        break;
                    }



                    CollectionDescription cd = new CollectionDescription(++brojac, EnumDataSet.DataSet1, hc);

                    proxy.PosaljiDS1(cd);

                    kanal.Close();
                }
            }
            else if (poruka.Code == CodeType.CODE_DIGITAL)
            {
                if (analog.Count > 0)
                {
                    string adresa = "net.tcp://localhost:6002/IPosaljiDS1";
                    NetTcpBinding binding1 = new NetTcpBinding();

                    ChannelFactory<IPosaljiDS1> kanal = new ChannelFactory<IPosaljiDS1>(binding1, adresa);
                    IPosaljiDS1 proxy = kanal.CreateChannel();
                    HistoricalCollection hc = new HistoricalCollection(new List<Poruka>());

                    foreach (Poruka por in digital)
                    {
                        hc.NizPoruka.Add(por);
                        digital.Remove(por);
                        break;
                    }

                    foreach (Poruka por in analog)
                    {
                        hc.NizPoruka.Add(por);
                        analog.Remove(por);
                        break;
                    }

                    CollectionDescription cd = new CollectionDescription(++brojac, EnumDataSet.DataSet1, hc);


                    proxy.PosaljiDS1(cd);

                    kanal.Close();
                }
            }

        }
        public void PosaljiDS2(Poruka poruka)
        {
            if (poruka.Code == CodeType.CODE_CUSTOM)
            {
                if (limitset.Count > 0)
                {
                    string adresa = "net.tcp://localhost:6002/IPosaljiDS1";
                    NetTcpBinding binding1 = new NetTcpBinding();

                    ChannelFactory<IPosaljiDS1> kanal = new ChannelFactory<IPosaljiDS1>(binding1, adresa);
                    IPosaljiDS1 proxy = kanal.CreateChannel();
                    HistoricalCollection hc = new HistoricalCollection(new List<Poruka>());

                    foreach (Poruka por in custom)
                    {
                        hc.NizPoruka.Add(por);
                        digital.Remove(por);
                        break;
                    }

                    foreach (Poruka por in limitset)
                    {
                        hc.NizPoruka.Add(por);
                        analog.Remove(por);
                        break;
                    }



                    CollectionDescription cd = new CollectionDescription(++brojac, EnumDataSet.DataSet2, hc);

                    proxy.PosaljiDS1(cd);

                    kanal.Close();
                }
            }
            else if (poruka.Code == CodeType.CODE_LIMITSET)
            {
                if (custom.Count > 0)
                {
                    string adresa = "net.tcp://localhost:6002/IPosaljiDS1";
                    NetTcpBinding binding1 = new NetTcpBinding();

                    ChannelFactory<IPosaljiDS1> kanal = new ChannelFactory<IPosaljiDS1>(binding1, adresa);
                    IPosaljiDS1 proxy = kanal.CreateChannel();
                    HistoricalCollection hc = new HistoricalCollection(new List<Poruka>());

                    foreach (Poruka por in custom)
                    {
                        hc.NizPoruka.Add(por);
                        digital.Remove(por);
                        break;
                    }

                    foreach (Poruka por in limitset)
                    {
                        hc.NizPoruka.Add(por);
                        analog.Remove(por);
                        break;
                    }

                    CollectionDescription cd = new CollectionDescription(++brojac, EnumDataSet.DataSet2, hc);


                    proxy.PosaljiDS1(cd);

                    kanal.Close();
                }
            }

        }
        public void PosaljiDS3(Poruka poruka)
        {
            if (poruka.Code == CodeType.CODE_SINGLENODE)
            {
                if (multiplenode.Count > 0)
                {
                    string adresa = "net.tcp://localhost:6002/IPosaljiDS1";
                    NetTcpBinding binding1 = new NetTcpBinding();

                    ChannelFactory<IPosaljiDS1> kanal = new ChannelFactory<IPosaljiDS1>(binding1, adresa);
                    IPosaljiDS1 proxy = kanal.CreateChannel();
                    HistoricalCollection hc = new HistoricalCollection(new List<Poruka>());

                    foreach (Poruka por in singlenode)
                    {
                        hc.NizPoruka.Add(por);
                        digital.Remove(por);
                        break;
                    }

                    foreach (Poruka por in multiplenode)
                    {
                        hc.NizPoruka.Add(por);
                        analog.Remove(por);
                        break;
                    }



                    CollectionDescription cd = new CollectionDescription(++brojac, EnumDataSet.DataSet3, hc);

                    proxy.PosaljiDS1(cd);

                    kanal.Close();
                }
            }
            else if (poruka.Code == CodeType.CODE_MULTIPLENODE)
            {
                if (singlenode.Count > 0)
                {
                    string adresa = "net.tcp://localhost:6002/IPosaljiDS1";
                    NetTcpBinding binding1 = new NetTcpBinding();

                    ChannelFactory<IPosaljiDS1> kanal = new ChannelFactory<IPosaljiDS1>(binding1, adresa);
                    IPosaljiDS1 proxy = kanal.CreateChannel();
                    HistoricalCollection hc = new HistoricalCollection(new List<Poruka>());

                    foreach (Poruka por in singlenode)
                    {
                        hc.NizPoruka.Add(por);
                        digital.Remove(por);
                        break;
                    }

                    foreach (Poruka por in multiplenode)
                    {
                        hc.NizPoruka.Add(por);
                        analog.Remove(por);
                        break;
                    }

                    CollectionDescription cd = new CollectionDescription(++brojac, EnumDataSet.DataSet3, hc);


                    proxy.PosaljiDS1(cd);

                    kanal.Close();
                }
            }

        }
        public void PosaljiDS4(Poruka poruka)
        {
            if (poruka.Code == CodeType.CODE_CONSUMER)
            {
                if (source.Count > 0)
                {
                    string adresa = "net.tcp://localhost:6002/IPosaljiDS1";
                    NetTcpBinding binding1 = new NetTcpBinding();

                    ChannelFactory<IPosaljiDS1> kanal = new ChannelFactory<IPosaljiDS1>(binding1, adresa);
                    IPosaljiDS1 proxy = kanal.CreateChannel();
                    HistoricalCollection hc = new HistoricalCollection(new List<Poruka>());

                    foreach (Poruka por in consumer)
                    {
                        hc.NizPoruka.Add(por);
                        digital.Remove(por);
                        break;
                    }

                    foreach (Poruka por in source)
                    {
                        hc.NizPoruka.Add(por);
                        analog.Remove(por);
                        break;
                    }



                    CollectionDescription cd = new CollectionDescription(++brojac, EnumDataSet.DataSet4, hc);

                    proxy.PosaljiDS1(cd);

                    kanal.Close();
                }
            }
            else if (poruka.Code == CodeType.CODE_SOURCE)
            {
                if (consumer.Count > 0)
                {
                    string adresa = "net.tcp://localhost:6002/IPosaljiDS1";
                    NetTcpBinding binding1 = new NetTcpBinding();

                    ChannelFactory<IPosaljiDS1> kanal = new ChannelFactory<IPosaljiDS1>(binding1, adresa);
                    IPosaljiDS1 proxy = kanal.CreateChannel();
                    HistoricalCollection hc = new HistoricalCollection(new List<Poruka>());

                    foreach (Poruka por in consumer)
                    {
                        hc.NizPoruka.Add(por);
                        digital.Remove(por);
                        break;
                    }

                    foreach (Poruka por in source)
                    {
                        hc.NizPoruka.Add(por);
                        analog.Remove(por);
                        break;
                    }

                    CollectionDescription cd = new CollectionDescription(++brojac, EnumDataSet.DataSet1, hc);


                    proxy.PosaljiDS1(cd);

                    kanal.Close();
                }
            }

            Console.WriteLine("Primio poruku: " + poruka.Code+";"+poruka.Vrijednost);

            LoggerFunkcije.LoggerUpisiUDatotekuPorukuRSRR(poruka);


        }
    }
}
