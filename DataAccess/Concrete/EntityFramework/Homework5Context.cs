using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class Homework5Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Homework5;Trusted_Connection=true", options => options.EnableRetryOnFailure());
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
