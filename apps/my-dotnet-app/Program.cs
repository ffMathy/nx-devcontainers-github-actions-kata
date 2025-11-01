// See https://aka.ms/new-console-template for more information
using my_dotnet_lib;

Console.WriteLine("Hello from .NET Console App in Nx!");
Console.WriteLine("=====================================\n");

var calculator = new Calculator();

Console.WriteLine("Using the Calculator library:");
Console.WriteLine($"5 + 3 = {calculator.Add(5, 3)}");
Console.WriteLine($"10 - 4 = {calculator.Subtract(10, 4)}");
Console.WriteLine($"6 * 7 = {calculator.Multiply(6, 7)}");
Console.WriteLine($"20 / 5 = {calculator.Divide(20, 5)}");

Console.WriteLine("\n✓ Successfully using my-dotnet-lib in my-dotnet-app!");
