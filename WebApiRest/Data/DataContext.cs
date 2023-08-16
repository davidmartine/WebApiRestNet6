using Microsoft.EntityFrameworkCore;
using WebApiRest.Models;

namespace WebApiRest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)  { }

        public DbSet<Persona>? Persona { get; set; }



    }
}
