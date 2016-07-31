using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace HeavenlyPizzeriaWebUI.Models
{
    public class PizzaOrder
    {
        public Pizza Pizza { get; set; }

        [Required(ErrorMessage ="Thine name is a must")]
        public String Name { get; set; }
        [Required(ErrorMessage = "We ought to know where to go")]
        public string Address { get; set; }
        [Required(ErrorMessage = "You have a number in mind?")]
        public int Quantity { get; set; }
        public string Instructions { get; set; }
    }
}