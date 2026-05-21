using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo26
{
    public class PickupPoint
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}