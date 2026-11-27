using CrudProductos.Services;

namespace CrudProductos;

class Program
{
    static void Main(string[] args)
    {
        var servicio = new ProductoService();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n=== GESTIÓN DE PRODUCTOS ===");
            Console.WriteLine("1. Crear producto");
            Console.WriteLine("2. Listar productos");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine() ?? "";
                    Console.Write("Precio: ");
                    decimal precio = decimal.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Stock: ");
                    int stock = int.Parse(Console.ReadLine() ?? "0");
                    servicio.Crear(nombre, precio, stock);
                    break;
                case "2":
                    servicio.Listar();
                    break;
                case "0":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}