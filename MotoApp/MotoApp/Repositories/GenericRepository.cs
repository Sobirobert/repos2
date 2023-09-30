

namespace MotoApp.Repositories
{
    using MotoApp.Entities;

    class GenericRepository<TEntity, TKey> 
        where TEntity : IEntity
       
    {
        public TKey? Key { get; set; }

        protected readonly List<T> _item = new();

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
