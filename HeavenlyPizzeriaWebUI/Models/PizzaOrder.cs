using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeavenlyPizzeriaWebUI.Models
{
    public class PizzaOrder
    {
        public Pizza Pizza { get; set; }

        public String Name { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public string Instructions { get; set; }
    }
}