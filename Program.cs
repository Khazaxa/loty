using System;
using System.Globalization;

namespace Zadanie_ParametryTrojkata
{
  class Program
  {
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        
        //zmienna rabat
        int rabat = 0;
        Console.WriteLine($"{rabat}");

        Console.WriteLine("Program obliczy jaki przysługuje Pani/Panu rabat.");
        Console.WriteLine("Proszę podać datę urodzenia osoby której będzie bilet");
        Console.Write("Miesiąc: ");
        var miesiacUr = Convert.ToInt32(Console.ReadLine().Trim());
        Console.Write("Dzień: ");
        var dzienUr = Convert.ToInt32(Console.ReadLine().Trim());
        Console.Write("Rok: ");
        var rokUr = Convert.ToInt32(Console.ReadLine().Trim());
        DateTime urodz = new DateTime(rokUr, miesiacUr, dzienUr);

        //pobiera dzisiejszą datę
        DateTime dzis = DateTime.Today;

        //ustala date urodzenia, najmłodszego, 18 latka
        DateTime pelnoletnosc;
        pelnoletnosc = dzis.AddYears(-18);

        //ustala date urodzenia, najmłodszego, 2 latka
        var wiek2lata = dzis.AddYears(-2);


        Console.WriteLine("Proszę podać datę lotu");      
        Console.Write("Miesiąc: ");
        var miesiacLot = Convert.ToInt32(Console.ReadLine().Trim());
        Console.Write("Dzień: ");
        var dzienLot = Convert.ToInt32(Console.ReadLine().Trim());
        Console.Write("Rok: ");
        var rokLot = Convert.ToInt32(Console.ReadLine().Trim());
        DateTime dataLot = new DateTime(rokUr, miesiacUr, dzienUr);


        Console.WriteLine("Proszę wpisać, czy lot jest krajowy (K) czy międzynarodowy (M): ");
        string typLot = Console.ReadLine().Trim();

        //sprawdza czy osoba jest pełnoletnia oraz na tej zasadzie wyświetla opcję stały klient
        if(pelnoletnosc<urodz) {
            if(urodz>wiek2lata) {
                Console.WriteLine("noworodek");
            }
            else {
                if(urodz<=wiek2lata) {
                    Console.WriteLine("mlodziez");
                }
                else {
                    Console.WriteLine("dzieciak");
                }
            }
        }
        else {
            Console.Write("Proszę wpisać, czy jesteś stałym klientem (T/N): ");
            string stalyKlient = Console.ReadLine().Trim();
        }
        

        
        


 
    }
  }
}