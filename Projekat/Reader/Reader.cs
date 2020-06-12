using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Logger;
namespace Reader
{
    public class Reader : IPosaljiDS1
    {
        public void PosaljiDS1(CollectionDescription cd)
        {
            DataBaseRESContext dbContext = new DataBaseRESContext();

            Poruka poruka1 = new Poruka();
            Poruka poruka2 = new Poruka();

          
            foreach(Poruka p in cd.HCollection.NizPoruka)
            {
                if (p.Code == CodeType.CODE_ANALOG)
                {
                    poruka1 = p;
                } else if (p.Code == CodeType.CODE_DIGITAL)
                {
                    poruka2 = p;
                }else if (p.Code == CodeType.CODE_CUSTOM)
                {
                    poruka1 = p;
                }else if (p.Code == CodeType.CODE_LIMITSET)
                {
                    poruka2 = p;
                }else if (p.Code == CodeType.CODE_SINGLENODE)
                {
                    poruka1 = p;
                } else if (p.Code == CodeType.CODE_MULTIPLENODE)
                {
                    poruka2 = p;
                }else if (p.Code == CodeType.CODE_CONSUMER)
                {
                    poruka1 = p;
                }else if (p.Code == CodeType.CODE_SOURCE)
                {
                    poruka2 = p;
                }
            }
            List<int> NoveVrijednosti = new List<int>();
            string s = "";
            if (cd.Dataset == EnumDataSet.DataSet1)
            {
                List<Ds1Model> p = dbContext.DS1.ToList();
                if (p.Count() == 0)
                {
                    Ds1Model ds1Model = new Ds1Model(cd.Id, DateTime.Now.ToString(), poruka2.Vrijednost, poruka1.Vrijednost);
                    dbContext.DS1.Add(ds1Model);
                    dbContext.SaveChanges();
                    s = "Popunjen je Dataset1 sa ID: " + cd.Id + " sa vrijednostima Analog " + poruka1.Vrijednost + " i Digital " + poruka2.Vrijednost;
                }
                else
                {
                    NoveVrijednosti = UcitajVrijednosti(poruka1, poruka2);
                    if (NoveVrijednosti[2] == 1)
                    {
                        Ds1Model ds1Model = new Ds1Model(cd.Id, DateTime.Now.ToString(), NoveVrijednosti[1], NoveVrijednosti[0]);
                        dbContext.DS1.Add(ds1Model);
                        dbContext.SaveChanges();
                    }
                    s = "Popunjen je Dataset1 sa ID: " + cd.Id + " sa vrijednostima Analog " + NoveVrijednosti[0] + " i Digital " + NoveVrijednosti[1];
                }
                
            }
            else if (cd.Dataset == EnumDataSet.DataSet2)
            {
                List<Ds2Model> p = dbContext.DS2.ToList();
                if (p.Count() == 0)
                {
                    Ds2Model ds2Model = new Ds2Model(cd.Id, DateTime.Now.ToString(), poruka1.Vrijednost, poruka2.Vrijednost);
                    dbContext.DS2.Add(ds2Model);
                    dbContext.SaveChanges();
                    s = "Popunjen je Dataset2 sa ID: " + cd.Id + " sa vrijednostima Custom " + poruka1.Vrijednost + " i Limitset " + poruka2.Vrijednost;
                }
                else
                {
                    NoveVrijednosti = UcitajVrijednosti(poruka1, poruka2);
                    if (NoveVrijednosti[2] == 1)
                    {
                        Ds2Model ds2Model = new Ds2Model(cd.Id, DateTime.Now.ToString(), NoveVrijednosti[0], NoveVrijednosti[1]);
                        dbContext.DS2.Add(ds2Model);
                        dbContext.SaveChanges();
                    }
                    s = "Popunjen je Dataset2 sa ID: " + cd.Id + " sa vrijednostima Custom " + NoveVrijednosti[0] + " i Limitset " + NoveVrijednosti[1];
                }
                
            }
            else if (cd.Dataset == EnumDataSet.DataSet3)
            {
                List<Ds3Model> p = dbContext.DS3.ToList();
                if (p.Count() == 0)
                {
                    Ds3Model ds3Model = new Ds3Model(cd.Id, DateTime.Now.ToString(), poruka1.Vrijednost, poruka2.Vrijednost);
                    dbContext.DS3.Add(ds3Model);
                    dbContext.SaveChanges();
                    s = "Popunjen je Dataset3 sa ID: " + cd.Id + " sa vrijednostima Singlenode " + poruka1.Vrijednost + " i Multiplenode " + poruka2.Vrijednost;
                }
                else
                { 
                     NoveVrijednosti = UcitajVrijednosti(poruka1, poruka2);
                        if (NoveVrijednosti[2] == 1)
                        {
                            Ds3Model ds3Model = new Ds3Model(cd.Id, DateTime.Now.ToString(), NoveVrijednosti[0], NoveVrijednosti[1]);
                            dbContext.DS3.Add(ds3Model);
                            dbContext.SaveChanges();
                        }
                     s = "Popunjen je Dataset3 sa ID: " + cd.Id + " sa vrijednostima Singlenode " + NoveVrijednosti[0] + " i Multiplenode " + NoveVrijednosti[1];
                }
                
            }
            else
            {
                List<Ds4Model> p = dbContext.DS4.ToList();
                if (p.Count() == 0)
                {
                    Ds4Model ds4Model = new Ds4Model(cd.Id, DateTime.Now.ToString(), poruka1.Vrijednost, poruka2.Vrijednost);
                    dbContext.DS4.Add(ds4Model);
                    dbContext.SaveChanges();
                    s = "Popunjen je Dataset4 sa ID: " + cd.Id + " sa vrijednostima Consumer " + poruka1.Vrijednost + " i Source " + poruka2.Vrijednost;
                }
                else { 
                NoveVrijednosti = UcitajVrijednosti(poruka1, poruka2);
                if (NoveVrijednosti[2] == 1)
                {
                    Ds4Model ds4Model = new Ds4Model(cd.Id, DateTime.Now.ToString(), NoveVrijednosti[0], NoveVrijednosti[1]);
                    dbContext.DS4.Add(ds4Model);
                    dbContext.SaveChanges();
                }
                    s = "Popunjen je Dataset4 sa ID: " + cd.Id + " sa vrijednostima Consumer " + NoveVrijednosti[0] + " i Source " + NoveVrijednosti[1];
                }
               



            }

            LoggerFunkcije.LoggerUpisiUDatotekuPorukuRBaza(s);

               Console.WriteLine("Primio sam poruku: id:" + cd.Id + ";dataset:" + cd.Dataset + ";code");
               foreach (Poruka p in cd.HCollection.NizPoruka)
               {
                   Console.WriteLine(p.Code + ";vrijednost" + p.Vrijednost);
               }
               Logger.LoggerFunkcije.LoggerUpisiUDatotekuPorukuRRR(cd);

        }

        public List<int> UcitajVrijednosti(Poruka poruka1, Poruka poruka2)
        {
            DataBaseRESContext dbContext = new DataBaseRESContext();
            List<int> NoveVrijednosti = new List<int>();

            int promijeniti = 0;

            if(poruka1.Code == CodeType.CODE_ANALOG)
            {
                List<Ds1Model> ds1 = dbContext.DS1.ToList();
                Ds1Model poslednji = ds1[ds1.Count() - 1];
                
                if(IzracunajRazliku(poslednji.VrijednostAnalog, poruka1.Vrijednost))
                {
                    NoveVrijednosti.Add(poruka1.Vrijednost);
                }
                else
                {
                    NoveVrijednosti.Add(poslednji.VrijednostAnalog);
                }

                NoveVrijednosti.Add(poruka2.Vrijednost);
                promijeniti = 1;

                NoveVrijednosti.Add(promijeniti);
                return NoveVrijednosti;
            }
            else if(poruka1.Code == CodeType.CODE_CUSTOM)
            {
                List<Ds2Model> ds2 = dbContext.DS2.ToList();
                Ds2Model poslednji = ds2[ds2.Count() - 1];

                if (IzracunajRazliku(poslednji.VrijednostCustom, poruka1.Vrijednost))
                {
                    NoveVrijednosti.Add(poruka1.Vrijednost);
                    promijeniti = 1;
                }
                else
                {
                    NoveVrijednosti.Add(poslednji.VrijednostCustom);
                }

                if (IzracunajRazliku(poslednji.VrijednostLimitSet, poruka2.Vrijednost))
                {
                    NoveVrijednosti.Add(poruka2.Vrijednost);
                    promijeniti = 1;
                }
                else
                {
                    NoveVrijednosti.Add(poslednji.VrijednostLimitSet);
                }

                NoveVrijednosti.Add(promijeniti);
                return NoveVrijednosti;
            }
            else if(poruka1.Code == CodeType.CODE_SINGLENODE)
            {
                List<Ds3Model> ds3 = dbContext.DS3.ToList();
                Ds3Model poslednji = ds3[ds3.Count() - 1];

                if (IzracunajRazliku(poslednji.VrijednostSingleNode, poruka1.Vrijednost))
                {
                    NoveVrijednosti.Add(poruka1.Vrijednost);
                    promijeniti = 1;
                }
                else
                {
                    NoveVrijednosti.Add(poslednji.VrijednostSingleNode);
                }

                if (IzracunajRazliku(poslednji.VrijednostMultipleNode, poruka2.Vrijednost))
                {
                    NoveVrijednosti.Add(poruka2.Vrijednost);
                    promijeniti = 1;
                }
                else
                {
                    NoveVrijednosti.Add(poslednji.VrijednostMultipleNode);
                }

                NoveVrijednosti.Add(promijeniti);
                return NoveVrijednosti;

            }
            else //if(poruka1.Code == CodeType.CODE_CONSUMER)
            {
                List<Ds4Model> ds4 = dbContext.DS4.ToList();
                Ds4Model poslednji = ds4[ds4.Count() - 1];

                if (IzracunajRazliku(poslednji.VrijednostConsumer, poruka1.Vrijednost))
                {
                    NoveVrijednosti.Add(poruka1.Vrijednost);
                    promijeniti = 1;
                }
                else
                {
                    NoveVrijednosti.Add(poslednji.VrijednostConsumer);
                }

                if (IzracunajRazliku(poslednji.VrijednostSource, poruka2.Vrijednost))
                {
                    NoveVrijednosti.Add(poruka2.Vrijednost);
                    promijeniti = 1;
                }
                else
                {
                    NoveVrijednosti.Add(poslednji.VrijednostSource);
                }

                NoveVrijednosti.Add(promijeniti);
                return NoveVrijednosti;
            }
            
        }

        public bool IzracunajRazliku(int stara, int nova)
        {
            double temp = nova - stara;
            double razlika = temp / stara * 100;

            if(Math.Abs(razlika) > 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
