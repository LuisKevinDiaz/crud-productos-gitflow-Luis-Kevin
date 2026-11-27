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
    public void Actualizar(int id, string nombre, decimal precio, int stock)
    {
        var producto = _productos.FirstOrDefault(p => p.Id == id);
        if (producto == null)
        {
            Console.WriteLine($"No se encontró un producto con ID {id}.");
            return;
        }

        producto.Nombre = nombre;
        producto.Precio = precio;
        producto.Stock = stock;
        _archivo.Guardar(_productos);
        Console.WriteLine($"Producto ID {id} actualizado correctamente.");
    }

    public void Eliminar(int id)
    {
        var producto = _productos.FirstOrDefault(p => p.Id == id);
        if (producto == null)
        {
            Console.WriteLine($"No se encontró un producto con ID {id}.");
            return;
        }

        _productos.Remove(producto);
        _archivo.Guardar(_productos);
        Console.WriteLine($"Producto ID {id} eliminado correctamente.");
    }
}