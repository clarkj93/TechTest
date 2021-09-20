using Repository.DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataModels
{
    public class Entity : IStoreable, IComparable<Entity>
    {
        public IComparable Id { get; set; }

        public Entity(int id)
        {
            if (id < 1) throw new ArgumentException();

            Id = id;
        }

        public int CompareTo(Entity other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}
