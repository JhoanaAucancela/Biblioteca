# Sistema de Biblioteca – ASP.NET Core MVC + EF Core + MySQL (Scaffolding)

Aplicación web en **C#** para gestionar una biblioteca: autores, categorías, libros, socios y préstamos. Se construyó con **ASP.NET Core MVC (.NET 10)**, **Entity Framework Core (Code First)** y **MySQL (XAMPP)**. Los controladores y vistas CRUD se generaron con **scaffolding** a partir de los modelos.

## Tecnologías

- .NET 10 / ASP.NET Core MVC
- Entity Framework Core 10 (`MySql.EntityFrameworkCore`)
- MySQL / MariaDB (XAMPP)
- Bootstrap 5 y jQuery Validation

## Modelo de datos

5 entidades con 5 atributos cada una, todas relacionadas entre sí:

```
Autor (1) ──< Libro >── (1) Categoria
                │
               (1)
                │
                ^
            Prestamo >── (1) Socio
```

| Entidad | Atributos | Relaciones |
|---|---|---|
| **Autor** | Id, Nombre, Apellido, Nacionalidad, Fecha_Nacimiento | Un autor tiene muchos libros |
| **Categoria** | Id, Nombre, Descripcion, Estante, Activa | Una categoría tiene muchos libros |
| **Libro** | Id, Titulo, Anio_Publicacion, AutorId (FK), CategoriaId (FK) | Pertenece a un autor y a una categoría; tiene muchos préstamos |
| **Socio** | Id, Nombre, Apellido, Email, Telefono | Un socio tiene muchos préstamos |
| **Prestamo** | Id, Fecha_Prestamo, Fecha_Devolucion, LibroId (FK), SocioId (FK) | Une un libro con un socio |

## Estructura del proyecto

```
Biblioteca/
├── Controllers/
│   ├── AutoresController.cs      # generado con scaffolding
│   ├── CategoriasController.cs   # generado con scaffolding
│   ├── LibrosController.cs       # generado con scaffolding
│   ├── SociosController.cs       # generado con scaffolding
│   ├── PrestamosController.cs    # generado con scaffolding
│   └── HomeController.cs         # panel de inicio
├── Models/
│   ├── Autor.cs, Categoria.cs, Libro.cs, Socio.cs, Prestamo.cs
│   └── BibliotecaDbContext.cs    # DbContext, relaciones y datos iniciales
├── Views/                        # vistas Index, Create, Edit, Details, Delete por entidad
├── Migrations/                   # migración "inicial" de EF Core
├── Database/Biblioteca.sql       # script SQL generado desde la migración
├── appsettings.json              # cadena de conexión "cn"
└── Program.cs                    # registro del DbContext con UseMySQL
```

## Cómo se aplicó el scaffolding

1. Se crearon los modelos con sus validaciones (`[Required]`, `[StringLength]`, `[Range]`, `[EmailAddress]`, `[RegularExpression]`) y las propiedades de navegación.
2. Se creó `BibliotecaDbContext` con un `DbSet` por entidad y se registró en `Program.cs` con `UseMySQL`.
3. Se generaron los controladores y vistas con:

   ```bash
   dotnet aspnet-codegenerator controller -name LibrosController -m Libro -dc BibliotecaDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
   ```

   (lo mismo para Autores, Categorias, Socios y Prestamos). En Visual Studio equivale a *Agregar → Nuevo elemento con scaffolding → Controlador MVC con vistas que usan Entity Framework*.
4. Se creó la base de datos con migraciones: `dotnet ef migrations add inicial`.

### Ajustes hechos sobre el código generado

- Las listas desplegables muestran nombres legibles (nombre completo del autor o socio, nombre de la categoría, título del libro) y no solo el apellido o la descripción.
- Las vistas se tradujeron al español y se agregó un menú de navegación.
- No se puede eliminar un autor, categoría, libro o socio que tenga registros relacionados (`DeleteBehavior.Restrict`). En ese caso se muestra un mensaje.
- Validaciones extra: el correo de un socio no puede repetirse, y la fecha de devolución debe ser posterior a la del préstamo.
- Página de inicio con el total de registros de cada entidad y los préstamos vigentes.

## Instalación

1. Iniciar **MySQL** en XAMPP.
2. Crear la base de datos con **una** de estas opciones:
   - **phpMyAdmin:** abrir `http://localhost/phpmyadmin`, pestaña **SQL**, y ejecutar el contenido de `Database/Biblioteca.sql`.
   - **Consola:** `dotnet ef database update`. *Nota:* con MariaDB (la que trae XAMPP) este comando puede fallar con `Unable to cast object of type 'System.DBNull' to type 'System.Int64'`. Esto ocurre por una incompatibilidad del proveedor de Oracle con MariaDB. En ese caso, usar la opción de phpMyAdmin.
3. Si MySQL tiene contraseña, actualizarla en la cadena `cn` de `appsettings.json`.
4. Abrir el proyecto en Visual Studio y presionar **F5**, o ejecutar `dotnet run`.

## Datos de prueba

La migración incluye 3 autores, 3 categorías, 3 libros, 2 socios y 2 préstamos.

## Autora

Jhoana Aucancela – Aplicaciones Web, Semana 4
