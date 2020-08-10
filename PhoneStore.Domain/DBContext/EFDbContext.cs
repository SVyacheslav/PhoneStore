using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStore.Domain.Entities;
using System.Data.Entity;


namespace PhoneStore.Domain.DBContext
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("DefaultConnection")
        { }

        public DbSet<Phone> Phones { get; set; }
    }
}
