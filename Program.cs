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
        //Console.WriteLine($"{rabat}");

        Console.WriteLine("Program obliczy jaki przysługuje Pani/Panu rabat.");
        Console.WriteLine("Proszę podać datę urodzenia osoby której będzie bilet");
        Start:
        Console.Write("Miesiąc: ");
        var miesiacUr = Convert.ToInt32(Console.ReadLine().Trim());
        Console.Write("Dzień: ");
        var dzienUr = Convert.ToInt32(Console.ReadLine().Trim());
        Console.Write("Rok: ");
        var rokUr = Convert.ToInt32(Console.ReadLine().Trim());
        DateTime urodz = new DateTime(rokUr, miesiacUr, dzienUr);

        //pobiera daty
        DateTime dzis = DateTime.Today;
        DateTime za5mies = dzis.AddMonths(5);
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
            Console.Write("Miesiąc: ");
            var miesiacLot = Convert.ToInt32(Console.ReadLine().Trim());
            Console.Write("Dzień: ");
            var dzienLot = Convert.ToInt32(Console.ReadLine().Trim());
            Console.Write("Rok: ");
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

            if(dataLot<dzis) {
                //gdy data lotu jest wcześniejsza niz dziś wyświetla komunikat i zaczyna program od początku
                Console.WriteLine("Nie sprzedajemy biletów na ten lot! Lot już się odbył!");
                Console.WriteLine("Proszę PONOWNIE podać datę lotu");  
                goto Lot;
            }
            else{
                TypLotu:
                Console.WriteLine("Proszę wpisać, czy lot jest Krajowy (K) czy Międzynarodowy (M): ");
                string typLot = Console.ReadLine().Trim();
                //sprawdza czy osoba jest pełnoletnia oraz na tej zasadzie wyświetla opcję stały klient
 
                if(pelnoletnosc<urodz){
//###################################################################################################           
            if(typLot == "K"){
                if(urodz>wiek2lata) {
                    if(urodz>dzis) {
                        //gdy osoba się nie narodziła wyświetla komunikat i zaczyna program od początku
                        Console.WriteLine("Ta osoba jeszcze się nie urodziła! Nie potrzebuje biletu!");
                        goto Start;
                    }
                    else {
                        //tu liczymy dla wiek <0; 2)

                        //rabat 5 mies
                        if (result5mies > 0){
                            //5mies>lot
                            //nie naliczamy znizki
                            Console.WriteLine($"nie naliczamy znizki");
                        }
                        else if (result5mies == 0){
                            //data lotu taka sama jak data minimalna dla znizki 5 miesiecy
                            //naliczamy znizke
                            Console.WriteLine($"jest ta data naliczamy znizke");
                        }
                        else if(result5mies < 0){
                            //5mies<lot
                            //naliczamy znizke
                            Console.WriteLine($"jest pozniej naliczamy znizke");
                        }

                        //ogranicznik rabatu niemowle
                        if(rabat>80){
                            rabat=80;
                            Console.WriteLine($"Twój rabat wynosi {rabat}%");
                        }
                        else{
                            Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                        }
                  }               
                }
                else {
                    if(urodz<=wiek2lata) {
                        //tu liczymy gdy wiek <2; 17)
                        
                        //rabat 5 mies
                        if (result5mies > 0){
                            //5mies>lot
                            //nie naliczamy znizki
                            //Console.WriteLine($"nie naliczamy znizki = {rabat}");
                        }
                        else if (result5mies == 0){
                            //data lotu taka sama jak data minimalna dla znizki 5 miesiecy
                            //naliczamy znizke
                            rabat+=10;
                            //Console.WriteLine($"jest ta data naliczamy znizke = {rabat}");
                        }
                        else if(result5mies < 0){
                            //5mies<lot
                            //naliczamy znizke
                            rabat+=10;
                            //Console.WriteLine($"jest pozniej naliczamy znizke = {rabat}");
                        }

                        //ogranicznik rabatu <2; 17)
                        if(rabat>30){
                        rabat=30;
                        Console.WriteLine($"Twój rabat wynosi {rabat}%");
                        }
                        else{
                            Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                        }
                    }
                    else {
                        //tu liczymy dla wiek <17; 18)

                        //rabat 5 mies
                        if (result5mies > 0){
                            //5mies>lot
                            //nie naliczamy znizki
                            //Console.WriteLine($"nie naliczamy znizki = {rabat}");
                        }
                        else if (result5mies == 0){
                            //data lotu taka sama jak data minimalna dla znizki 5 miesiecy
                            //naliczamy znizke
                            rabat+=10;
                            //Console.WriteLine($"jest ta data naliczamy znizke = {rabat}");
                        }
                        else if(result5mies < 0){
                            //5mies<lot
                            //naliczamy znizke
                            rabat+=10;
                            //Console.WriteLine($"jest pozniej naliczamy znizke = {rabat}");
                        }

                        //ogranicznik rabatu <17; 18)
                        if(rabat>30){
                            rabat=30;
                            Console.WriteLine($"Twój rabat wynosi {rabat}%");
                        }
                        else{
                            Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                        }
                    }
                }
            }
//###################################################################################################            
            else if (typLot == "M")
            {
                if(urodz>wiek2lata) {
                    if(urodz>dzis) {
                        //gdy osoba się nie narodziła wyświetla komunikat i zaczyna program od początku
                        Console.WriteLine("Ta osoba jeszcze się nie urodziła! Nie potrzebuje biletu!");
                        goto Start;
                    }
                    else {
                        //tu liczymy dla wiek <0; 2)
                        Console.WriteLine("noworodek");

                        //rabat 5 miesiecy
                        if (result5mies > 0){
                            //5mies>lot
                            //nie naliczamy znizki
                            Console.WriteLine($"nie naliczamy znizki");
                        }
                        else if (result5mies == 0){
                            //data lotu taka sama jak data minimalna dla znizki 5 miesiecy
                            //naliczamy znizke
                            Console.WriteLine($"jest ta data naliczamy znizke");
                        }
                        else if(result5mies < 0){
                            //5mies<lot
                            //naliczamy znizke
                            Console.WriteLine($"jest pozniej naliczamy znizke");
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
                            Console.WriteLine($"Sezon rabat przed: {rabat}");
                            rabat+=15;
                            Console.WriteLine($"Sezon po naliczeniu: {rabat}");
                        }

                        //ogranicznik rabatu niemowle
                        if(rabat>70){
                            rabat=70;
                            Console.WriteLine($"Twój rabat wynosi {rabat}%");
                        }
                        else{
                            Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                        }
                    }               
                }
                else {
                    if(urodz<=wiek2lata) {
                        //tu liczymy gdy wiek <2; 17)
                        Console.WriteLine("mlodziez");


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
                            Console.WriteLine($"Sezon rabat przed: {rabat}");
                            rabat+=15;
                            Console.WriteLine($"Sezon po naliczeniu: {rabat}");
                        }

                        //ogranicznik rabatu <2; 17)
                        if(rabat>30){
                            rabat=30;
                            Console.WriteLine($"Twój rabat wynosi {rabat}%");
                        }
                        else{
                            Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                        }
                    }
                    else {
                        //tu liczymy dla wiek <17; 18)
                        Console.WriteLine("17 lat");


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
                            Console.WriteLine($"Sezon rabat przed: {rabat}");
                            rabat+=15;
                            Console.WriteLine($"Sezon po naliczeniu: {rabat}");
                        }

                        //ogranicznik rabatu <17; 18)
                        if(rabat>30){
                            rabat=30;
                            Console.WriteLine($"Twój rabat wynosi {rabat}%");
                        }
                        else{
                            Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                        }
                    }
                }
            }
            else {
                Console.WriteLine("Proszę wpisać K - jeśli Krajowy, M - jeśli międzynarodowy");
                Console.WriteLine("");
                goto TypLotu;
            }        
        }
                else {
                    //pelnoletni
//###################################################################################################            
                    if(typLot == "K"){
                        //rabat 5 mies
                        if (result5mies > 0){
                            //5mies>lot
                            //nie naliczamy znizki
                            Console.WriteLine($"nie naliczamy znizki");
                        }
                        else if (result5mies == 0){
                                //data lotu taka sama jak data minimalna dla znizki 5 miesiecy
                                //naliczamy znizke
                                
                                
                                Console.WriteLine($"jest ta data naliczamy znizke");
                                Console.WriteLine($"Rabat przed naliczeniem: {rabat}");
                                rabat+=10;
                                Console.WriteLine($"Znizka po naliczeniu: {rabat}");
                        }
                        else if(result5mies < 0){
                                //5mies<lot
                                //naliczamy znizke
                                
                                
                                Console.WriteLine($"jest pozniej naliczamy znizke");
                                Console.WriteLine($"Rabat przed naliczeniem: {rabat}");
                                rabat+=10;
                                Console.WriteLine($"Znizka po naliczeniu: {rabat}");
                        }
                    }                
//###################################################################################################            
                    else if (typLot == "M"){
                        //rabat 5 mies
                        if (result5mies > 0){
                            //5mies>lot
                            //nie naliczamy znizki
                            Console.WriteLine($"nie naliczamy znizki");
                        }
                        else if (result5mies == 0){
                                //data lotu taka sama jak data minimalna dla znizki 5 miesiecy
                                //naliczamy znizke
                                
                                
                                Console.WriteLine($"jest ta data naliczamy znizke");
                                Console.WriteLine($"Rabat przed naliczeniem: {rabat}");
                                rabat+=10;
                                Console.WriteLine($"Rabat po naliczeniu: {rabat}");
                        }
                        else if(result5mies < 0){
                                //5mies<lot
                                //naliczamy znizke
                                
                                Console.WriteLine($"jest pozniej naliczamy znizke");
                                Console.WriteLine($"Rabat przed naliczeniem: {rabat}");
                                rabat+=10;
                                Console.WriteLine($"Rabat po naliczeniu: {rabat}");
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
                            Console.WriteLine($"Sezon rabat przed: {rabat}");
                            rabat+=15;
                            Console.WriteLine($"Sezon po naliczeniu: {rabat}");
                        }
                    } 
//###################################################################################################            
                    else {
                        Console.WriteLine("Proszę wpisać K - jeśli Krajowy, M - jeśli międzynarodowy");
                        Console.WriteLine("");
                        goto TypLotu;
                    }
//###################################################################################################
                    //obsługa rabatu stałego klienta
                    Console.Write("Proszę wpisać, czy jesteś stałym klientem (T/N): ");
                    string stalyKlient = Console.ReadLine().Trim();

                    if(stalyKlient == "T"){
                        Console.WriteLine($"Staly Klient przed naliczeniem: {rabat}");
                        rabat+=10;
                        Console.WriteLine($"Po naliczeniu: {rabat}");
                    }
                    else if(stalyKlient == "N"){    
                    }
                    else {
                        Console.WriteLine("Proszę wpisać (T) jeśli jesteś stałym klientem, lub (N) jeśli nie jesteś stałym klientem");
                    }
  
                     //ogranicznik rabatu dorosłego
                        if(rabat>30){
                            rabat=30;
                            Console.WriteLine($"Twój rabat wynosi {rabat}%");
                        }
                        else{
                            Console.WriteLine($"Twój rabat wynosi: {rabat}%");
                        }
                }

            }    
        } 







/*

Obsługa Krajowy/Miedzynarodowy
Obsluga Staly Klient
Obsługa wieku
*/
        
        


 
    }
  }
}