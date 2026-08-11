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

    public decimal DiscountTotal(decimal total)
    {
        const decimal discount10Percent = 0.10m;
        const decimal discount5Percent = 0.05m;

        if (total >= 50000)
        {
            Console.WriteLine("Descuento aplicado del 10%.");
            return total - (total * discount10Percent);
        }
        else if (total >= 20000)
        {
            Console.WriteLine("Descuento aplicado del 5%.");
            return total - (total * discount5Percent);
        }

        Console.WriteLine("No se aplicó ningún descuento.");
        return total;
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

                    decimal finalTotal = DiscountTotal(total);

                    Console.WriteLine("Subtotal: $" + total);
                    Console.WriteLine($"Total a pagar: ${finalTotal}");

                    open = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}


