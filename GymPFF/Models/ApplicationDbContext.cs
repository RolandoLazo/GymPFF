using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymPFF.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<RayosUV> RayosUV { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Clase> Clases { get; set; }
    }
}
