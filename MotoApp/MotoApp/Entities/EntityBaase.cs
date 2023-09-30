using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.Entities
{
    public abstract class EntityBaase : IEntity
    {
        public int Id { get; set; }
    }
}
