using System.Runtime.CompilerServices;

const string kioskName = "El Recreo";

Console.WriteLine("Ingrese el nombre del cajero:");
string cashierName = Console.ReadLine();

Console.WriteLine("===KIOSCO" + kioskName.ToUpper() + "===");
Console.WriteLine("Nombre del cajero: " + cashierName);
Console.WriteLine("Bienvenido al sistema, " + cashierName + ". Caja abierta.");
