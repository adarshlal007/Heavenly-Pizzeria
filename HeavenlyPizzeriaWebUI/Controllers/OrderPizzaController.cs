using Contract;
using Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contract.Queries;
using Contract.Queries.Orders;
using Contract.Queries.Pizza;

namespace HeavenlyPizzeriaWebUI.Controllers
{
    public class OrderPizzaController : Controller
    {
        private readonly IQueryProcessor queryProcessor;

        public OrderPizzaController(IQueryProcessor qp)
        {
            queryProcessor = qp;
        }
        // GET: OrderPizza
        public ActionResult Index(int id)
        {

            var query = new GetPizzaByIdQuery { Id = id };
            var pizza = queryProcessor.Execute(query);

            var model = new HeavenlyPizzeriaWebUI.Models.PizzaOrder
            {
                Pizza = new Models.Pizza
                {
                    id = pizza.id,
                    Description = pizza.Description,
                    Name = pizza.Name,
                    Price = pizza.Price
                }
            };
            return View(model);
        }
    }
}