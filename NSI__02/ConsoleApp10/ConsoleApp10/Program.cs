using System;
using System.Collections.Generic;
using System.Linq;

namespace Obserwator
{
    enum Kategoria
    {
        Kat1, Kat2, Kat3, Kat4          
    }

    interface IObservable<T>
    {
        void Subscribe(params T[] observer);
        void Unsubscribe(params T[] observer);
        void Notify();
    }

    interface IObserver<T>
    {
        void Update(T observable);
    }

    class Artykul_Budowlany : IObservable<Customer>
    {
        //stan produktu
        public string Nazwa_artykulu { get; set; } 
        public Kategoria Kategoria { get; set; }
        public decimal Cena { get; set; }

        private decimal znizka;
        public decimal Znizka
        {
            get { return znizka; }
            set
            {
                if (value > znizka)
                {
                    Notify();
                }
                znizka = value;
            }
        }

        //sekcja zarządzająca obserwatorami
        private readonly List<Customer> observers = new List<Customer>();

        public void Notify()
        {
            observers.ForEach(observer => observer.Update(this));
        }

        public void Subscribe(params Customer[] newObservers)
        {
            observers.AddRange(newObservers);
        }

        public void Unsubscribe(params Customer[] observersToRemove)
        {

            observers.RemoveAll(observersToRemove.Contains);
        }
    }

    //sekcja obserwatora
    class Customer : IObserver<Artykul_Budowlany>
    {
        public string Nazwa_obserwatora { get; set; }
        public string Email { get; set; }
        public List<Kategoria> UlubionaKategoria { get; set; }

        public void Update(Artykul_Budowlany artykul_budowlany)
        {
            if (UlubionaKategoria.Contains(artykul_budowlany.Kategoria))
            {
                Console.WriteLine($"{artykul_budowlany.Nazwa_artykulu} cena: {artykul_budowlany.Cena * (1 - artykul_budowlany.Znizka)} wysłano: {Email} \r\n");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Nazwa_obserwatora = "Filip Rzepiela",
                    Email = "filiprzepiela@interia.pl",
                    UlubionaKategoria = new List<Kategoria> {Kategoria.Kat2, Kategoria.Kat3}
                },
                new Customer()
                {
                    Nazwa_obserwatora = "Robert Lewandowski",
                    Email = "rl9_lewuss@web.de",
                    UlubionaKategoria = new List<Kategoria> {Kategoria.Kat1, Kategoria.Kat4}
                },

                new Customer()
                {
                    Nazwa_obserwatora = "Daniel Kowalski",
                    Email = "kowalskidaniel@onet.pl",
                    UlubionaKategoria = new List<Kategoria> {Kategoria.Kat1, Kategoria.Kat2}
                },
                new Customer()
                {
                    Nazwa_obserwatora = "Tomasz Szurek",
                    Email = "tomi82@gmail.com",
                    UlubionaKategoria = new List<Kategoria> {Kategoria.Kat3, Kategoria.Kat4}
                }
            };

            var artykuly_budowlane = new List<Artykul_Budowlany>()
            {
                new Artykul_Budowlany()
                {
                    Nazwa_artykulu = "Cegła pełna 120 x 250 x 65 mm",
                    Kategoria = Kategoria.Kat1,
                    Cena = 5m,
                    Znizka = 0.1m
                },
                new Artykul_Budowlany()
                {
                    Nazwa_artykulu = "Cement budowlany Lafarge 32,5 22.5kg",
                    Kategoria = Kategoria.Kat2,
                    Cena = 25m,
                    Znizka = 0.11m
                },
                new Artykul_Budowlany()
                {
                    Nazwa_artykulu = "Drabina 3-elementowa MacAllister 3 x 6 stopni",
                    Kategoria = Kategoria.Kat3,
                    Cena = 420m,
                    Znizka = 0.07m
                },
                new Artykul_Budowlany()
                {
                    Nazwa_artykulu = "Pianka montażowa Soudal GG 650 ml",
                    Kategoria = Kategoria.Kat4,
                    Cena = 20m,
                    Znizka = 0.14m
                }
            };

            artykuly_budowlane.ForEach(artykul_budowlany => artykul_budowlany.Subscribe(customers.ToArray()));
            Console.WriteLine("\nPIERWOTNA CENA ARTYKUŁU BUDOWLANEGO: \r\n");
            artykuly_budowlane.ForEach(artykul_budowlany => artykul_budowlany.Znizka += 0.4m);


            Console.WriteLine("\nPierwsza zmiana: \r\n");
            artykuly_budowlane.ForEach(artykul_budowlany => artykul_budowlany.Znizka -= 0.4m);


            Console.WriteLine("\nDruga zmiana: \r\n");
            artykuly_budowlane
                .Where(artykul_budowlany => artykul_budowlany.Kategoria == Kategoria.Kat3)
                .ToList()
                .ForEach(artykul_budowlany => artykul_budowlany.Znizka += 0.1m);


        }
    }
}