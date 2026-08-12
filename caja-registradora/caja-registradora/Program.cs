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

    const decimal discount10Percent = 0.10m;
    const decimal discount5Percent = 0.05m;
    const decimal recharge15Percent = 0.15m;
    public decimal DiscountTotal(decimal total)
    {

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

    public void PaymentMenu(List<Product> cart)
    {
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

        Console.WriteLine();
        Console.WriteLine("=== MEDIOS DE PAGO ===");
        Console.WriteLine("1 - Efectivo (+10% descuento)");
        Console.WriteLine("2 - Débito");
        Console.WriteLine("3 - Crédito (+15% recargo)");

        int paymentMethod = int.Parse(Console.ReadLine());

        switch (paymentMethod)
        {
            case 1:
                finalTotal += finalTotal * discount10Percent;
                Console.WriteLine("Pago en efectivo. Se aplicó un descuento del 10%.");
                Console.WriteLine("Total final a pagar: $" + finalTotal);
                break;

            case 2:
                Console.WriteLine("Pago con débito. No se aplican descuentos ni recargos.");
                Console.WriteLine("Total final a pagar: $" + finalTotal);
                break;

            case 3:
                finalTotal += finalTotal * recharge15Percent;
                Console.WriteLine("Pago con crédito. Se aplicó un recargo del 15%.");
                Console.WriteLine("Total final a pagar: $" + finalTotal);
                break;

            default:
                Console.WriteLine("Opción de pago no válida.");
                break;
        }
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
                    PaymentMenu(cart);
                    open = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}


