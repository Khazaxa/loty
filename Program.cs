using System;
using System.Globalization;

namespace Zadanie_ParametryTrojkata
{
  class Program
  {
    static void Main(string[] args)
    {
        
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        
        do{
            //zmienna rabat
            int rabat = 0;

            Console.WriteLine("Program obliczy jaki przysługuje Pani/Panu rabat.");
            Console.WriteLine("Proszę podać datę urodzenia osoby której będzie bilet");

            Start:
            Console.Write("Miesiąc (NR): ");
            var miesiacUr = Convert.ToInt32(Console.ReadLine().Trim());
            Console.Write("Dzień (NR): ");
            var dzienUr = Convert.ToInt32(Console.ReadLine().Trim());
            Console.Write("Rok (NR): ");
            var rokUr = Convert.ToInt32(Console.ReadLine().Trim());
            
            DateTime urodz = new DateTime(rokUr, miesiacUr, dzienUr);

                        
                //pobiera daty
                DateTime dzis = DateTime.Today;
                DateTime za5mies = dzis.AddMonths(5);
                DateTime wiek17 = dzis.AddYears(-17);
                DateTime pelnoletnosc = dzis.AddYears(-18);
                DateTime wiek2lata = dzis.AddYears(-2);
                
                
                if(urodz>dzis) {
                    //gdy osoba się nie narodziła wyświetla komunikat i zaczyna program od początku
                    Console.WriteLine("Ta osoba jeszcze się nie urodziła! Nie potrzebuje biletu!");
                    Console.WriteLine("Proszę PONOWNIE podać datę urodzenia osoby której będzie bilet");
                    goto Start;
                }
                else{
                    Console.WriteLine("Proszę podać datę lotu");      
                    Lot:
                    Console.Write("Miesiąc (NR): ");
                    var miesiacLot = Convert.ToInt32(Console.ReadLine().Trim());
                    Console.Write("Dzień (NR): ");
                    var dzienLot = Convert.ToInt32(Console.ReadLine().Trim());
                    Console.Write("Rok (NR): ");
                    var rokLot = Convert.ToInt32(Console.ReadLine().Trim());
                    DateTime dataLot = new DateTime(rokLot, miesiacLot, dzienLot);

                    var RokZnizkiZimowej = dataLot.Year +1;

                    DateTime sezonLetniStart = new DateTime(rokLot, 03, 20);
                    DateTime sezonLetniKoniec = new DateTime(rokLot, 04, 10);

                    DateTime sezonZimowyStart = new DateTime(rokLot, 12, 20);
                    DateTime sezonZimowyKoniec = new DateTime(RokZnizkiZimowej, 01, 10);

                    DateTime Lipiec = new DateTime(rokLot, 07, 01);
                    DateTime Sierpien = new DateTime(rokLot, 08, 31);

                    //porownoje daty      
                    int result5mies = DateTime.Compare(za5mies, dataLot);


                    if(dataLot<dzis){
                        //gdy data lotu jest wcześniejsza niz dziś wyświetla komunikat i zaczyna program od początku
                        Console.WriteLine("Nie sprzedajemy biletów na ten lot! Lot już się odbył!");
                        Console.WriteLine("Proszę PONOWNIE podać datę lotu");  
                        goto Lot;
                    }
                    else{
                        TypLotu:
                        Console.Write("Proszę wpisać, czy lot jest Krajowy (K) czy Międzynarodowy (M): ");
                        string typLot = Console.ReadLine().Trim();
                        //sprawdza czy osoba jest pełnoletnia oraz na tej zasadzie wyświetla opcję stały klient
        
                        if(pelnoletnosc<urodz){
                            //niepelnoletni
                            if(typLot == "K"){
                                if(urodz>wiek2lata){
                                    //wiek < 2
                                    rabat+=80;

                                    //rabat 5 mies
                                    if(result5mies > 0){
                                        //nie naliczamy znizki
                                    }
                                    else if(result5mies <= 0){
                                        rabat+=10;
                                    }

                                    //ogranicznik rabatu 
                                    if(rabat>80){
                                        rabat=80;
                                        Console.WriteLine($"Twój rabat wynosi {rabat}%");
                                    }
                                    else{
                                        Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                                    }
                                }
                                else if(urodz<=wiek2lata && urodz>wiek17){
                                    //wiek <2; 17)
                                    rabat+=10;

                                    //rabat 5 mies
                                    if(result5mies > 0){
                                        //nie naliczamy znizki
                                    }
                                    else if(result5mies <= 0){
                                        rabat+=10;
                                    }

                                    //ogranicznik rabatu 
                                    if(rabat>30){
                                        rabat=30;
                                        Console.WriteLine($"Twój rabat wynosi {rabat}%");
                                    }
                                    else{
                                        Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                                    }
                                }
                                else if(urodz<=wiek17){
                                    //wiek <17; 18)
                                                
                                    //rabat 5 mies
                                    if(result5mies > 0){
                                        //nie naliczamy znizki
                                    }
                                    else if(result5mies <= 0){
                                        rabat+=10;
                                    }

                                    //ogranicznik rabatu 
                                        if(rabat>30){
                                        rabat=30;
                                        Console.WriteLine($"Twój rabat wynosi {rabat}%");
                                    }
                                    else{
                                        Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                                    }
                                }
                            }
                            else if (typLot == "M"){
                                if(urodz>wiek2lata){
                                    //wiek < 2
                                    rabat+=70;
                                                
                                    //rabat 5 mies
                                    if(result5mies > 0){
                                        //nie naliczamy znizki
                                    }
                                    else if(result5mies <= 0){
                                        rabat+=10;
                                    }

                                    //rabat sezonowy
                                    if(dataLot>=sezonZimowyStart && dataLot<=sezonZimowyKoniec){
                                        //nie naliczamy znizki
                                    }
                                    else if (dataLot>=sezonLetniStart && dataLot<=sezonLetniKoniec){
                                        //nie naliczamy znizki
                                    }
                                    else if(dataLot>=Lipiec && dataLot<=Sierpien){
                                    }
                                    else{
                                        //naliczamy znizke
                                        rabat+=15;
                                    }

                                    //ogranicznik rabatu 
                                    if(rabat>80){
                                        rabat=80;
                                        Console.WriteLine($"Twój rabat wynosi {rabat}%");
                                    }
                                    else{
                                        Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                                    }
                                }
                                else if(urodz<=wiek2lata && urodz>wiek17){
                                    //wiek <2; 17)
                                    //rabat sezonowy
                                    if(dataLot>=sezonZimowyStart && dataLot<=sezonZimowyKoniec){
                                        //nie naliczamy znizki
                                    }
                                    else if (dataLot>=sezonLetniStart && dataLot<=sezonLetniKoniec){
                                        //nie naliczamy znizki
                                    }
                                    else if(dataLot>=Lipiec && dataLot<=Sierpien){
                                        //nie naliczamy znizki
                                    }
                                    else{
                                        rabat+=10;
                                        //naliczamy znizke
                                        rabat+=15;

                                        //rabat 5 mies
                                        if (result5mies > 0){
                                            //nie naliczamy znizki
                                        }
                                        else if(result5mies <= 0){
                                            rabat+=10;
                                        }
                                    }

                                    //ogranicznik rabatu 
                                    if(rabat>30){
                                        rabat=30;
                                        Console.WriteLine($"Twój rabat wynosi {rabat}%");
                                    }
                                    else{
                                        Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                                    }
                                }
                                else if(urodz<=wiek17){
                                    //wiek <17; 18)
                                    //rabat sezonowy
                                    if(dataLot>=sezonZimowyStart && dataLot<=sezonZimowyKoniec){
                                        //nie naliczamy znizki
                                    }
                                    else if (dataLot>=sezonLetniStart && dataLot<=sezonLetniKoniec){
                                        //nie naliczamy znizki
                                    }
                                    else if(dataLot>=Lipiec && dataLot<=Sierpien){
                                        //nie naliczamy znizki
                                    }
                                    else{
                                        //naliczamy znizke
                                        rabat+=15;

                                        //rabat 5 mies
                                        if (result5mies > 0){
                                            //nie naliczamy znizki
                                        }
                                        else if(result5mies <= 0){
                                            rabat+=10;
                                        }
                                    }

                                    //ogranicznik rabatu
                                    if(rabat>30){
                                        rabat=30;
                                        Console.WriteLine($"Twój rabat wynosi {rabat}%");
                                    }
                                    else{
                                        Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                                    }
                                }  
                                else{
                                    Console.WriteLine("Proszę wpisać K - jeśli Krajowy, M - jeśli międzynarodowy");
                                    Console.WriteLine("");
                                    goto TypLotu;
                                }
                            }
                            else{     
                                Console.WriteLine("Proszę PONOWNIE wpisać K - jeśli Krajowy, M - jeśli międzynarodowy");
                                Console.WriteLine("");
                                goto TypLotu;               
                            }
                        }
                        else{
                            //pelnoletni
                            if(typLot == "K"){
                                //obsługa rabatu stałego klienta
                                Console.Write("Proszę wpisać, czy jesteś stałym klientem (T/N): ");
                                KlientStaly:
                                string stalyKlient = Console.ReadLine().Trim();

                                //rabat 5 mies
                                if (result5mies > 0){
                                    //nie naliczamy znizki
                                }
                                else if(result5mies <= 0){
                                    rabat+=10;
                                }

                                //rabat staly klient
                                if(stalyKlient == "T"){
                                    rabat+=15;
                                }
                                else if(stalyKlient == "N"){    
                                    //nie naliczamy rabatu  
                                }
                                else {
                                    Console.Write("Proszę PONOWNIE wpisać (T) jeśli jesteś stałym klientem, lub (N) jeśli nie jesteś stałym klientem:");
                                    Console.Write(" ");
                                    goto KlientStaly;
                                }

                                //ogranicznik rabatu
                                if(rabat>30){
                                    rabat=30;
                                    Console.WriteLine($"Twój rabat wynosi {rabat}%");
                                }
                                else{
                                    Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                                }
                            }
                            else if (typLot == "M"){

                                //obsługa rabatu stałego klienta
                                Console.Write("Proszę wpisać, czy jesteś stałym klientem (T/N): ");
                                KlientStaly:
                                string stalyKlient = Console.ReadLine().Trim();

                                //rabat sezonowy
                                if(dataLot>=sezonZimowyStart && dataLot<=sezonZimowyKoniec){
                                    //nie naliczamy znizki
                                }
                                else if (dataLot>=sezonLetniStart && dataLot<=sezonLetniKoniec){
                                    //nie naliczamy znizki
                                }
                                else if(dataLot>=Lipiec && dataLot<=Sierpien){
                                    //nie naliczamy znizki
                                }
                                else{
                                    //naliczamy znizke
                                    rabat+=15;

                                    //rabat 5 mies
                                    if(result5mies > 0){
                                        //nie naliczamy znizki
                                    }
                                    else if(result5mies <= 0){
                                        rabat+=10;
                                    }

                                    //rabat staly klient
                                    if(stalyKlient == "T"){
                                        rabat+=15;
                                    }
                                    else if(stalyKlient == "N"){  
                                        //nie naliczamy rabatu  
                                    }
                                    else {
                                        Console.Write("Proszę PONOWNIE wpisać (T) jeśli jesteś stałym klientem, lub (N) jeśli nie jesteś stałym klientem:");
                                        Console.Write(" ");
                                        goto KlientStaly;
                                    }
                                }

                                
                                //ogranicznik rabatu
                                if(rabat>30){
                                    rabat=30;
                                    Console.WriteLine($"Twój rabat wynosi {rabat}%");
                                }
                                else{
                                    Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                                }
                            }
                            else{
                                Console.WriteLine("Proszę PONOWNIE wpisać K - jeśli Krajowy, M - jeśli międzynarodowy");
                                Console.WriteLine("");
                                goto TypLotu;
                            }
                        }
                    }
                }
                
                //warunek zamkniecia programu
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Press Esc to finish");
                Console.Write("........");
            
        }while(Console.ReadKey().Key != ConsoleKey.Escape);    
    } 
  }
}
