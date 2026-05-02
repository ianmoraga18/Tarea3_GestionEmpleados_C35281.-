using Microsoft.EntityFrameworkCore;
using GestionE.Models;

namespace GestionE.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Empleado> Empleados { get; set; }  
    

    }
}
