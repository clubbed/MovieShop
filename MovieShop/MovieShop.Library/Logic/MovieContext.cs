using MovieShop.Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Library.Logic
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base(nameOrConnectionString: "MovieDB")
        {
            Database.SetInitializer(new MovieInitializer());
        }

        public DbSet<Movie> Movies { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
