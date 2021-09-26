using DIO.Series.Enums;
using System;

namespace DIO.Series.Classes.Entities
{
    public class Serie : BaseEntity
    {
        private Genre Genre { get; set; }
        public string Title { get; private set; }
        private string Description { get; set; }
        private int Year { get; set; }
        public bool IsExcluded { get; private set; }

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            Id = id;
            Genre = genre;
            Title = title;
            Description = description;
            Year = year;
            IsExcluded = false;
        }

        public override string ToString()
        {
            string result = "";
            result += $"Genre: {Genre} {Environment.NewLine}";
            result += $"Title: {Title} {Environment.NewLine}";
            result += $"Description: {Description} {Environment.NewLine}";
            result += $"Release Year: {Year} {Environment.NewLine}";
            result += IsExcluded?$"Excluded: {IsExcluded}":"";
            return result;
        }      

        public void Exclude()
        {
            IsExcluded = true;
        }
    }
}
