using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlant.Model
{
    public abstract class Entity
    {

    }

    public abstract class Entity<T> : Entity, IEntity<T>
    {
        public T Id { get; set; }
    }
}
