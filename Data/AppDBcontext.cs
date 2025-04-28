using Hospital_Parcial_Rio.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Parcial_Rio.Data
{

    public class AppDBcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Hospital_Parcial_Rio;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Obra_Social> Obras_Sociales { get; set; }
        public DbSet<Sintoma> Sintomas { get; set; }
    }

}
