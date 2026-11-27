using System.Linq;
using CrudProductos.Models;

namespace CrudProductos.Services;

public class ProductoService
{
    private readonly ArchivoService _archivo = new();
    private List<Producto> _productos;

    public ProductoService()
    {
        _productos = _archivo.Cargar();
    }

    public void Crear(string nombre, decimal precio, int stock)
    {
        int nuevoId = _productos.Count > 0 ? _productos.Max(p => p.Id) + 1 : 1;
        var producto = new Producto
        {
            Id = nuevoId,
            Nombre = nombre,
            Precio = precio,
            Stock = stock
        };

        _productos.Add(producto);
        _archivo.Guardar(_productos);
        Console.WriteLine($"Producto '{nombre}' creado con ID {nuevoId}.");
    }

    public void Listar()
    {
        if (_productos.Count == 0)
        {
            Console.WriteLine("No hay productos registrados.");
            return;
        }

        foreach (var p in _productos)
        {
            Console.WriteLine($"[{p.Id}] {p.Nombre} | Precio: ${p.Precio:F2} | Stock: {p.Stock} | Creado: {p.FechaCreacion}");
        }
    }
}