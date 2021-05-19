using System;

namespace LabaChM8Library
{
    public static class Funk
    {
        public static double Function(double x, double y)
        {
            return Math.Pow(Math.E, -1.8 * x) * (Math.Pow(y, 2) + 1.8);
        }
    }
    public class Runge
    {
        public void RungeKuttaMethod()
        {
            double k1, k2, k3, k4, h = 0.1, eps;
            int n = 40, m = 4;
            double[] x = new double[n + 2];
            double[] y = new double[n + 2];
            int i = 0;
            Console.WriteLine("Метод Рунге-Кутта\nx\ty\t\teps");
            do
            {   
                x[i + 1] = x[i] + h;
                k1 = Funk.Function(x[i], y[i]);
                k2 = Funk.Function(x[i] + (h / 2), y[i] + (h * k1 / 2));
                k3 = Funk.Function(x[i] + (h / 2), y[i] + (h * k2 / 2));
                k4 = Funk.Function(x[i] + h, y[i] + (h * k3));
                eps = (Math.Pow(y[i], h) - Math.Pow(y[i], h / 2)) / (Math.Pow(2, m) - 1);
                if (Math.Abs((k2 - k3) / (k1 - k2)) > 0.09)
                {
                    h /= 2;
                }
                y[i + 1] = y[i] + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4); //Наближене значення у в наступній точці
                Console.WriteLine($"{x[i]:f1}\t{y[i]:f5}\t\t{eps:f6}");
                i++;
            } while (x[i] < m + h);
        }
    }
    public class AdamsClass
    {
        public void Adams()
        {
            double k1, k2, k3, k4, eps, yInter;
            double h = 0.1;
            int n = 78, m = 4; 
            double[] x = new double[n + 1]; //array of x
            double[] y = new double[n + 1]; //array of y
            Console.WriteLine("\nметод Адамса\nx\ty\t\teps");
            int i = 0;
            do
            {
                x[i + 1] = x[i] + h;
                k1 = Funk.Function(x[i], y[i]);
                k2 = Funk.Function(x[i] + (h / 2), y[i] + (h * k1 / 2));
                k3 = Funk.Function(x[i] + (h / 2), y[i] + (h * k2 / 2));
                k4 = Funk.Function(x[i] + h, y[i] + (h * k3));
                eps = (Math.Pow(y[i], h) - Math.Pow(y[i], h / 2)) / (Math.Pow(2, m) - 1); //правило Рунге

                if (Math.Abs((k2 - k3) / (k1 - k2)) > 0.09) //якщо дріб перевищує декілька сотих, то крок зменшуємо удвічі
                {
                    h /= 2;
                }
                Console.WriteLine($"{x[i]:f1}\t{y[i]:f5}\t\t{eps:f6}");
                y[i + 1] = y[i] + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4);
                i++;
            } while (i < 3);
            h /= 2;
            int k = 3;
            do
            {
                x[k + 1] = x[k] + h;
                //екстраполяційна формула
                y[k + 1] = y[k] + (h / 24) * (55 * Funk.Function(x[k], y[k]) - 59 * Funk.Function(x[k - 1], y[k - 1]) + 37 * Funk.Function(x[k - 2], y[k - 2]) - 9 * Funk.Function(x[k - 3], y[k - 3]));
                //інтерполяційна формула
                yInter = y[k] + (h / 24) * (9 * Funk.Function(x[k + 1], y[k + 1]) + 19 * Funk.Function(x[k], y[k]) - 5 * Funk.Function(x[k - 1], y[k - 1]) + Funk.Function(x[k - 2], y[k - 2]));
                if (Math.Abs(yInter - y[k + 1]) > 0.09)
                    h /= 2;
                eps = (Math.Pow(y[k], h) - Math.Pow(y[k], h / 2)) / (Math.Pow(2, m) - 1);
                if (k % 2 != 0) //щоб виводилиль тількі круглі значення х (0,1 0,2.....)
                    Console.WriteLine($"{x[k]:f2}\t{y[k]:f5}\t\t{eps:f6}");
                k++;
            }
            while (x[k] < 4);
        }
    }
}
