using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Trilha> Trilhas { get; set; }
        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<TrilhaCompetencia> TrilhaCompetencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrilhaCompetencia>()
                .HasKey(tc => new { tc.TrilhaId, tc.CompetenciaId });

            modelBuilder.Entity<TrilhaCompetencia>()
                .HasOne(tc => tc.Trilha)
                .WithMany(t => t.TrilhaCompetencias)
                .HasForeignKey(tc => tc.TrilhaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrilhaCompetencia>()
                .HasOne(tc => tc.Competencia)
                .WithMany(c => c.TrilhaCompetencias)
                .HasForeignKey(tc => tc.CompetenciaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Matriculas)
                .WithOne(m => m.Usuario)
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Trilha>()
                .HasMany(t => t.Matriculas)
                .WithOne(m => m.Trilha)
                .HasForeignKey(m => m.TrilhaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
