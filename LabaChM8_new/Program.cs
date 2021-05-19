using System;
using LabaChM8Library;
namespace LabaChM8_new
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("y' = e^(-1.8*x)*(y^2+1.8), [0;4]");
            Console.ResetColor();
            Runge r = new Runge();
            r.RungeKuttaMethod();
            AdamsClass a = new AdamsClass();
            a.Adams();
            Console.ReadKey();
        }
    }
}
