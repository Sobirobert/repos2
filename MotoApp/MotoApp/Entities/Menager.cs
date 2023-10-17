using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.Entities
{
    public class Menager : Employee
    {
        public override string ToString() => base.ToString() + " (Menager)";
    }
}
