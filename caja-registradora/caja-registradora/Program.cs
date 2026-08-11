using System.Runtime.CompilerServices;

Kiosk kiosk = new Kiosk();
kiosk.addProduct();
class Kiosk
{
    public void OpenCashRegister()
    {
        const string kioskName = "El Recreo";

        Console.WriteLine("Ingrese el nombre del cajero:");
        string cashierName = Console.ReadLine();

        Console.WriteLine("===KIOSCO" + kioskName.ToUpper() + "===");
        Console.WriteLine("Nombre del cajero: " + cashierName);
        Console.WriteLine("Bienvenido al sistema, " + cashierName + ". Caja abierta.");

    }

    public void addProduct()
    {
        Console.WriteLine("Ingrese el nombre del producto:");
        string productName = Console.ReadLine();
        Console.WriteLine("Ingrese el precio del producto:");
        decimal productPrice = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Producto agregado: " + productName + " - Precio: $" + productPrice);
    }
}


