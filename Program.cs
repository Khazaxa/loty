using System;
using System.Globalization;

namespace Zadanie_ParametryTrojkata
{
  class Program
  {
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        

        //var rabat = 0;

        Console.WriteLine("Proszę podać datę urodzenia");
        Console.Write("Miesiąc: ");
        var miesiacUr = Convert.ToInt32(Console.ReadLine());

        Console.Write("Dzień: ");
        var dzienUr = Convert.ToInt32(Console.ReadLine());

        Console.Write("Rok: ");
        var rokUr = Convert.ToInt32(Console.ReadLine());

        DateTime urodz = new DateTime(rokUr, miesiacUr, dzienUr);

        
        DateTime dzis = DateTime.Today;
        Console.WriteLine($"dzis = {dzis}");

       // var compare date= 
        
        Console.WriteLine($"pelno {pelno}");
/*
        //Console.WriteLine($"{urodz}");

        Console.Write("Proszę podać datę lotu: ");      
        Console.Write("Miesiąc: ");
        var miesiacLot = Convert.ToInt32(Console.ReadLine());

        Console.Write("Dzień: ");
        var dzienLot = Convert.ToInt32(Console.ReadLine());

        Console.Write("Rok: ");
        var rokLot = Convert.ToInt32(Console.ReadLine());

        DateTime dataLot = new DateTime(rokUr, miesiacUr, dzienUr);

        //Console.WriteLine($"{dataLot}");

        Console.WriteLine("Proszę wpisać, czy lot jest krajowy czy międzynarodowy: ");
        string typLot = Console.ReadLine();

        if(urodz > )
        Console.WriteLine("Proszę wpisać, czy jesteś stałym klientem (tylko 18+): ");
        string stalyKlient = Console.ReadLine();
 */
 
    }
  }
}