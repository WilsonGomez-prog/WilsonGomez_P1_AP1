using Microsoft.EntityFrameworkCore;
using WilsonGomez_P1_AP1.Entidades;

namespace WilsonGomez_P1_AP1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ciudades> ciudades { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source=DATA\Parcial_1.db");
        }
    }
}