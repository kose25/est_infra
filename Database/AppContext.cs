using EstudiantesCore1.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesInfraestructure.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {

        }

        public DbSet<EstadoEstudiante> EstadoEstudiante { get; set; }
        public DbSet<EstadoMateriaEstudiante> EstadoMateriaEstudiante { get; set; }
        public DbSet<EstadoProfesor> EstadoProfesor { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<EstudiantesXMateria> EstudianteXMateria { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<ProfesoresXMateria> ProfesoresXMateria { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>()
                .HasIndex(b => b.documento).IsUnique(true);

            modelBuilder.Entity<Profesor>()
                .HasIndex(b => b.documento).IsUnique(true);

            modelBuilder.Entity<Materia>()
                .HasIndex(b => b.codigo).IsUnique(true);
        }
    }

}
 