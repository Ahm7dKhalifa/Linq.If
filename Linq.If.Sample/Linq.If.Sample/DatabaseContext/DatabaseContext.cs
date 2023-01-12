using Linq.If.Sample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.If.Sample
{
    public class DatabaseContext : DbContext
    {
        public bool UsingInMemoryDatabase { get; set; } = false;
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options,bool usingInMemoryDatabase) :base(options) { UsingInMemoryDatabase = usingInMemoryDatabase; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!UsingInMemoryDatabase)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LinqIfSample;Trusted_Connection=True;");
            }
        }

       

        public DbSet<Product> Products { get; set; }

    }
}
