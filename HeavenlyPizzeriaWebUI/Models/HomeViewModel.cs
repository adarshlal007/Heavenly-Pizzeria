using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using DTO = Contract.DTOs;

namespace HeavenlyPizzeriaWebUI.Models
{
    public class HomeViewModel
    {
        public List<Pizza> Pizzas { get; set; }

    }
}