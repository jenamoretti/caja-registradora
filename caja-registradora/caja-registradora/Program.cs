using System.Runtime.CompilerServices;

Kiosk kiosk = new Kiosk();
kiosk.OpenCashRegister();
kiosk.menu();

class Product
{
    public string name;
    public decimal price;
    public Product(string name, decimal price)
    {
        this.name = name;
        this.price = price;
    }
}
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

    public Product addProduct()
    {
        Console.WriteLine("Ingrese el nombre del producto:");
        string productName = Console.ReadLine();
        Console.WriteLine("Ingrese el precio del producto:");
        decimal productPrice = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Producto agregado: " + productName + " - Precio: $" + productPrice);

        Product product = new Product(productName, productPrice);

        return product;
    }

    public void menu()
    {
        bool open = true;
        List<Product> cart = new List<Product>();

        while(open)
        {
            Console.WriteLine("Que desea hacer?");
            Console.WriteLine("1 - Cargar un producto");
            Console.WriteLine("2 - Cerrar la venta");
            int option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1:
                    Product newProduct = addProduct();
                    cart.Add(newProduct);
                    break;

                case 2:
                    decimal total = 0;
                    Console.WriteLine("\n=== RESUMEN DE VENTA ===");
                    foreach (Product p in cart)
                    {
                        Console.WriteLine($"- {p.name}: ${p.price}");
                        total += p.price;
                    }
                    Console.WriteLine($"Total a pagar: ${total}");

                    open = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}


