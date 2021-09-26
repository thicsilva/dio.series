using DIO.Series.Classes;
using DIO.Series.Classes.Entities;
using DIO.Series.Classes.Repositories;
using DIO.Series.Enums;
using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
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
                        CreateSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("This is an invalid option");
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Thanks for using our system!");
        }

        private static void ViewSeries()
        {
            Console.WriteLine("Viewing Series");
            Console.Write("Enter with series Id: ");
            int id = int.Parse(Console.ReadLine());
            if (repository.Exists(id))
                Console.WriteLine(repository.GetById(id).ToString());
            else
                Console.WriteLine("Series don't exist");
        }

        private static void DeleteSeries()
        {
            Console.WriteLine("Deleting Series");
            Console.Write("Enter with series Id: ");
            int id = int.Parse(Console.ReadLine());
            if (repository.Exists(id))
            {
                Console.WriteLine("Do you really want to delete? (y/n)");
                var response = Console.ReadLine().ToUpper();
                if (response == "Y")
                    repository.Delete(id);
            }
            else
                Console.WriteLine("Series don't exist");
        }

        private static void UpdateSeries()
        {

            Console.WriteLine("Updating Series");
            Console.Write("Enter with series Id: ");
            int id = int.Parse(Console.ReadLine());
            if (repository.Exists(id))
            {
                foreach (int i in Enum.GetValues(typeof(Genre)))
                {
                    Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Genre), i));
                }
                Console.Write("Enter with one in above genre options: ");
                int genre = int.Parse(Console.ReadLine());
                Console.Write("Enter the serie title: ");
                string title = Console.ReadLine();
                Console.Write("Enter with year when series started: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Enter with the series description: ");
                string description = Console.ReadLine();

                Serie serie = new Serie(id, (Genre)genre, title, description, year);
                repository.Update(id, serie);
            }
            else
                Console.WriteLine("Series don't exist");
        }

        private static void CreateSeries()
        {
            Console.WriteLine("Creating Serie");
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}- {1}",i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Enter with one in genre options above: ");
            int genre = int.Parse(Console.ReadLine());
            Console.Write("Enter the series title: ");
            string title = Console.ReadLine();
            Console.Write("Enter with year when series started: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter with the series description: ");
            string description = Console.ReadLine();

            Serie serie = new Serie(repository.NextId(), (Genre)genre, title, description, year);
            repository.Create(serie);
        }

        private static void ShowSeries()
        {
            Console.WriteLine("Showing Series");
            var series = repository.ShowList();
            if (series.Count == 0)
                Console.WriteLine("Nothing to display here");
            else
                foreach (var serie in series)
                    Console.WriteLine(string.Format("{0} {1} {2}",$"Id: {serie.Id}", $"Title: {serie.Title}", serie.IsExcluded? $"Excluded: {serie.IsExcluded}":""));           
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to our Series System");
            Console.WriteLine("Change an option");
            Console.WriteLine("1- Show list of series");
            Console.WriteLine("2- Create a new series");
            Console.WriteLine("3- Update a series");
            Console.WriteLine("4- Delete a series");
            Console.WriteLine("5- View a series detail");
            Console.WriteLine("C- Clear screen");
            Console.WriteLine("X- Exit");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
