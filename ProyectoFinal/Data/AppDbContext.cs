using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data.Models;
using System.Diagnostics.Eventing.Reader;

namespace ProyectoFinal.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Alumno_Actividad>()
                .HasOne(b => b.Alumno)
                .WithMany(ba => ba.Alumno_Actividads)
                .HasForeignKey(bi => bi.AlumnoId);

            modelBuilder.Entity<Alumno_Actividad>()
                .HasOne(b => b.Actividad)
                .WithMany(ba => ba.Alumno_Actividads)
                .HasForeignKey(bi => bi.ActividadId);

            modelBuilder.Entity<Alumno_Material>()
                .HasOne(x => x.Alumno)
                .WithMany(xa => xa.Alumno_Materials)
                .HasForeignKey(xi => xi.AlumnoId);

            modelBuilder.Entity<Alumno_Material>()
                .HasOne(x => x.Material)
                .WithMany(xa => xa.Alumno_Materials)
                .HasForeignKey(xi => xi.MaterialId);

            modelBuilder.Entity<Alumno_Conducta>()
                .HasOne(k => k.Alumno)
                .WithMany(ka => ka.Alumno_Conductas)
                .HasForeignKey(ki => ki.AlumnoId);

            modelBuilder.Entity<Alumno_Conducta>()
                .HasOne(k => k.Conducta)
                .WithMany(ka => ka.Alumno_Conductas)
                .HasForeignKey(ki => ki.ConductaId);



        }
        //Se utiliza para obtener y enviar datos a BD
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Actividad> Actividads { get; set; }
        public DbSet<Alumno_Actividad> Alumno_Actividads { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Alumno_Material> Alumno_Materials { get; set; }
        public DbSet<Conducta> Conductas { get; set; }
        public DbSet<Alumno_Conducta> Alumno_Conductas { get; set; }

    }
}
