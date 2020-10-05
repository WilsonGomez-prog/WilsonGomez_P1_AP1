using Microsoft.EntityFrameworkCore;
// using WilsonGomez_P1_AP1.Entidades;

namespace WilsonGomez_P1_AP1
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source=DATA\Parcial1.db");
        }
    }
}