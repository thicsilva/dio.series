using DIO.Series.Classes.Entities;
using DIO.Series.Interfaces;
using System.Collections.Generic;

namespace DIO.Series.Classes.Repositories
{
    public class SerieRepository : IRepository<Serie>
    {
        private readonly List<Serie> series = new List<Serie>();

        public void Update(int id, Serie entidade)
        {
            series[id] = entidade;
        }

        public void Delete(int id)
        {
            if (!series[id].IsExcluded)
                series[id].Exclude();
        }

        public void Create(Serie entidade)
        {
            series.Add(entidade);
        }

        public List<Serie> ShowList()
        {
            return series;
        }

        public int NextId()
        {
            return series.Count;
        }

        public Serie GetById(int id)
        {
            return series[id];
        }

        public bool Exists(int id)
        {
            return id >= 0 && id < series.Count;
        }
    }
}
