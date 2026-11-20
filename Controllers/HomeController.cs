using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Biblioteca.Controllers;

public class HomeController : Controller
{
    private readonly BibliotecaDbContext _context;

    public HomeController(BibliotecaDbContext context)
    {
        _context = context;
    }

    // panel con el total de registros de cada entidad y los préstamos vigentes
    public async Task<IActionResult> Index()
    {
        ViewBag.Autores = await _context.Autores.CountAsync();
        ViewBag.Categorias = await _context.Categorias.CountAsync();
        ViewBag.Libros = await _context.Libros.CountAsync();
        ViewBag.Socios = await _context.Socios.CountAsync();
        ViewBag.Prestamos = await _context.Prestamos.CountAsync();

        var vigentes = await _context.Prestamos
            .Include(p => p.Libro).ThenInclude(l => l.Autor)
            .Include(p => p.Socio)
            .Where(p => p.Fecha_Devolucion >= DateTime.Today)
            .OrderBy(p => p.Fecha_Devolucion)
            .ToListAsync();
        return View(vigentes);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
