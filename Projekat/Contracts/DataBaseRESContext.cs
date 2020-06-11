using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class DataBaseRESContext : DbContext
    {
        public DbSet<Ds1Model> DS1 { get; set; }
        public DbSet<Ds2Model> DS2 { get; set; }
        public DbSet<Ds3Model> DS3 { get; set; }
        public DbSet<Ds4Model> DS4 { get; set; }
    }
}
