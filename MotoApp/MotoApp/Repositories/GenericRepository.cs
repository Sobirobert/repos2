using MotoApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.Repositories
{
    public class GenericRepository<T> where T : IEntity
    {
        private readonly List<T> _item = new();

        public void Add(T item)
        {
            item.Id = _item.Count + 1;
            _item.Add(item);
        }

        public void Save()
        {
            foreach (var item in _item)
            {
                Console.WriteLine(item);
            }
        }

        public T GetById(int id)
        {
            return _item.Single(item => item.Id == id);
        }
    }
}
