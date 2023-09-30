using MotoApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.Repositories
{
    internal class GenericRepositoryWithRemove<T, TKey> : GenericRepository<T, TKey> where T : IEntity
    {
        public void Remove(T item) 
        { 
            _item .Remove(item);
        }
    }
}
