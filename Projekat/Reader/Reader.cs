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

            if (cd.Dataset == EnumDataSet.DataSet1)
            {
                Ds1Model ds1Model = new Ds1Model(cd.Id, DateTime.Now.ToString(), poruka1.Vrijednost, poruka2.Vrijednost);
                dbContext.DS1.Add(ds1Model);
                dbContext.SaveChanges();
            }
            else if (cd.Dataset == EnumDataSet.DataSet2)
            {
                Ds2Model ds2Model = new Ds2Model(cd.Id, DateTime.Now.ToString(), poruka1.Vrijednost, poruka2.Vrijednost);
                dbContext.DS2.Add(ds2Model);
                dbContext.SaveChanges();
            }
            else if (cd.Dataset == EnumDataSet.DataSet3)
            {
                Ds3Model ds3Model = new Ds3Model(cd.Id, DateTime.Now.ToString(), poruka1.Vrijednost, poruka2.Vrijednost);
                dbContext.DS3.Add(ds3Model);
                dbContext.SaveChanges();
            }
            else 
            {
                Ds4Model ds4Model = new Ds4Model(cd.Id, DateTime.Now.ToString(), poruka1.Vrijednost, poruka2.Vrijednost);
                dbContext.DS4.Add(ds4Model);
                dbContext.SaveChanges();
            }
               Console.WriteLine("Primio sam poruku: id:" + cd.Id + ";dataset:" + cd.Dataset + ";code");
               foreach (Poruka p in cd.HCollection.NizPoruka)
               {
                   Console.WriteLine(p.Code + ";vrijednost" + p.Vrijednost);
               }
               Logger.LoggerFunkcije.LoggerUpisiUDatotekuPorukuRRR(cd);

        }
    }
}
