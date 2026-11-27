namespace CrudProductos.Utils;

public static class Validador
{
    public static string LeerTextoObligatorio(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string? entrada = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(entrada))
                return entrada;

            Console.WriteLine("Error: este campo no puede estar vacío.");
        }
    }

    public static decimal LeerDecimalPositivo(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor > 0)
                return valor;

            Console.WriteLine("Error: ingrese un monto numérico mayor que 0.");
        }
    }

    public static int LeerEnteroNoNegativo(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out int valor) && valor >= 0)
                return valor;

            Console.WriteLine("Error: ingrese un número entero igual o mayor que 0.");
        }
    }
}