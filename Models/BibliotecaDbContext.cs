namespace Biblioteca.Models
{
    using Microsoft.EntityFrameworkCore;
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions db) : base(db)
        { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // no se permite borrar un registro que tenga hijos relacionados
            foreach (var relacion in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relacion.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // el correo del socio no se puede repetir
            modelBuilder.Entity<Socio>().HasIndex(s => s.Email).IsUnique();

            // datos iniciales de prueba
            modelBuilder.Entity<Autor>().HasData(
                new Autor { Id = 1, Nombre = "Gabriel", Apellido = "García Márquez", Nacionalidad = "Colombiana", Fecha_Nacimiento = new DateTime(1927, 3, 6) },
                new Autor { Id = 2, Nombre = "Jorge", Apellido = "Icaza", Nacionalidad = "Ecuatoriana", Fecha_Nacimiento = new DateTime(1906, 7, 10) },
                new Autor { Id = 3, Nombre = "Isabel", Apellido = "Allende", Nacionalidad = "Chilena", Fecha_Nacimiento = new DateTime(1942, 8, 2) });

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Novela", Descripcion = "Narrativa de ficción extensa", Estante = "A-1", Activa = true },
                new Categoria { Id = 2, Nombre = "Realismo social", Descripcion = "Obras de denuncia social", Estante = "B-2", Activa = true },
                new Categoria { Id = 3, Nombre = "Cuento", Descripcion = "Narraciones breves", Estante = "C-1", Activa = true });

            modelBuilder.Entity<Libro>().HasData(
                new Libro { Id = 1, Titulo = "Cien años de soledad", Anio_Publicacion = 1967, AutorId = 1, CategoriaId = 1 },
                new Libro { Id = 2, Titulo = "Huasipungo", Anio_Publicacion = 1934, AutorId = 2, CategoriaId = 2 },
                new Libro { Id = 3, Titulo = "La casa de los espíritus", Anio_Publicacion = 1982, AutorId = 3, CategoriaId = 1 });

            modelBuilder.Entity<Socio>().HasData(
                new Socio { Id = 1, Nombre = "María", Apellido = "López", Email = "maria.lopez@mail.com", Telefono = "0991234567" },
                new Socio { Id = 2, Nombre = "Carlos", Apellido = "Pérez", Email = "carlos.perez@mail.com", Telefono = "0987654321" });

            modelBuilder.Entity<Prestamo>().HasData(
                new Prestamo { Id = 1, Fecha_Prestamo = new DateTime(2026, 11, 10), Fecha_Devolucion = new DateTime(2026, 11, 25), LibroId = 1, SocioId = 1 },
                new Prestamo { Id = 2, Fecha_Prestamo = new DateTime(2026, 11, 15), Fecha_Devolucion = new DateTime(2026, 11, 30), LibroId = 2, SocioId = 2 });
        }
    }
}
