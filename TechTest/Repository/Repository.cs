using Repository.DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        internal List<T> Entities { get; }

        public Repository(List<T> entities)
        {
            // initialize in-memory data
            Entities = (entities is null) ? new List<T>() : entities;
        }

        public IEnumerable<T> All()
        {
            return Entities;
        }

        public void Delete(IComparable id)
        {
            Entities.Remove(Entities.Where(x => x.Id.CompareTo(id) == 0).FirstOrDefault());
        }

        public T FindById(IComparable id)
        {
            return Entities.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Save(T item)
        {
            Entities.Add(item);
        }
    }
}
