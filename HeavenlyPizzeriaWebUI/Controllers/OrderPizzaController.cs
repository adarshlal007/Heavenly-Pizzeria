using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeavenlyPizzeriaWebUI.Controllers
{
    public class OrderPizzaController : Controller
    {
        // GET: OrderPizza
        public ActionResult Index(int id, HeavenlyPizzeriaWebUI.Models.Pizza pizza)
        {
            var model = new HeavenlyPizzeriaWebUI.Models.PizzaOrder { Pizza = pizza };
            return View(model);
        }
    }
}