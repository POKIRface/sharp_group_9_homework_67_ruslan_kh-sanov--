using System;
using Microsoft.EntityFrameworkCore;

namespace task1.Models
{
    public class CountryContext : DbContext
    {
        public DbSet<Country> Countriess { get; set; }
        public CountryContext(DbContextOptions<CountryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
