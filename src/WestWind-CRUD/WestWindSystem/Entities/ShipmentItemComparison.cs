using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.Entities
{
    class ShipmentItemComparison
    {
        public int ProductID { get; internal set; }
        public int ExpectedQuantity { get; internal set; }
        public int ShipQuantity { get; internal set; }
    }
}
