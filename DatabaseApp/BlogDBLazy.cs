using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseApp
{
   
    internal class BlogDBLazy : DbContext
    {
        public DbSet<Blog> Blogs { get;set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data source=.; initial catalog = SampleDatabase; integrated security = True;TrustServerCertificate=True;");
        }
    }
}
