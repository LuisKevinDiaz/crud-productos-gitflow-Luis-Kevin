using CrudProductos.Services;
using CrudProductos.Utils;

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
                    string nombre = Validador.LeerTextoObligatorio("Nombre: ");
                    decimal precio = Validador.LeerDecimalPositivo("Precio: ");
                    int stock = Validador.LeerEnteroNoNegativo("Stock: ");
                    servicio.Crear(nombre, precio, stock);
                    break;
                case "2":
                    servicio.Listar();
                    break;
                case "3":
                    int idAct = Validador.LeerEnteroNoNegativo("ID del producto a actualizar: ");
                    string nuevoNombre = Validador.LeerTextoObligatorio("Nuevo nombre: ");
                    decimal nuevoPrecio = Validador.LeerDecimalPositivo("Nuevo precio: ");
                    int nuevoStock = Validador.LeerEnteroNoNegativo("Nuevo stock: ");
                    servicio.Actualizar(idAct, nuevoNombre, nuevoPrecio, nuevoStock);
                    break;
                case "4":
                    int idElim = Validador.LeerEnteroNoNegativo("ID del producto a eliminar: ");
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