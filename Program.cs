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
            Console.WriteLine("3. Actualizar producto");
            Console.WriteLine("4. Eliminar producto");
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
                case "3":
                    Console.Write("ID del producto a actualizar: ");
                    int idAct = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Nuevo nombre: ");
                    string nuevoNombre = Console.ReadLine() ?? "";
                    Console.Write("Nuevo precio: ");
                    decimal nuevoPrecio = decimal.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Nuevo stock: ");
                    int nuevoStock = int.Parse(Console.ReadLine() ?? "0");
                    servicio.Actualizar(idAct, nuevoNombre, nuevoPrecio, nuevoStock);
                    break;
                case "4":
                    Console.Write("ID del producto a eliminar: ");
                    int idElim = int.Parse(Console.ReadLine() ?? "0");
                    servicio.Eliminar(idElim);
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