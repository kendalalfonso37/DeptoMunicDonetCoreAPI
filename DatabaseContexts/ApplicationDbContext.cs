using DepartamentosMunicipiosAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepartamentosMunicipiosAPI.DatabaseContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        // Add Entities
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }

    }
}
