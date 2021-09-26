using DIO.Series.Classes;
using DIO.Series.Classes.Entities;
using DIO.Series.Classes.Repositories;
using DIO.Series.Enums;
using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repositorio = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();
            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ShowSeries();
                        break;
                    case "2":
                        CreateSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("This option is invalid");
                }
                userOption = GetUserOption();
            }
        }

        private static void UpdateSerie()
        {

            Console.WriteLine("Creating Serie");
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Enter with one in above genre options: ");
            int genre = int.Parse(Console.ReadLine());
            Console.Write("Enter the serie title: ");
            string title = Console.ReadLine();
            Console.Write("Enter with year when serie started: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter with the serie description: ");
            string description = Console.ReadLine();

            Serie serie = new Serie(repositorio.NextId(), (Genre)genre, title, description, year);
        }

        private static void CreateSerie()
        {
            Console.WriteLine("Creating Serie");
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}- {1}",i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Enter with one in above genre options: ");
            int genre = int.Parse(Console.ReadLine());
            Console.Write("Enter the serie title: ");
            string title = Console.ReadLine();
            Console.Write("Enter with year when serie started: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter with the serie description: ");
            string description = Console.ReadLine();

            Serie serie = new Serie(repositorio.NextId(), (Genre)genre, title, description, year);
            repositorio.Create(serie);
        }

        private static void ShowSeries()
        {
            Console.WriteLine("Showing Series");
            var series = repositorio.ShowList();
            if (series.Count == 0)
                Console.WriteLine("Nothing to display here");
            else
                foreach(var serie in series)            
                    Console.WriteLine($"Id: {serie.Id} Title: {serie.Title}");           
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to our Series System");
            Console.WriteLine("Change an option");
            Console.WriteLine("1- Show Series");
            Console.WriteLine("2- Create a new serie");
            Console.WriteLine("3- Update a serie");
            Console.WriteLine("4- Delete a serie");
            Console.WriteLine("5- Show a serie");
            Console.WriteLine("C- Clear screen");
            Console.WriteLine("X- Exit");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
