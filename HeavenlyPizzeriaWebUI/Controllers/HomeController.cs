using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contract;
using Contract.DTOs;
using Contract.Queries;
using Contract.Queries.Orders;
using Contract.Queries.Pizza;


namespace HeavenlyPizzeriaWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQueryProcessor queryProcessor;

        //public HomeController()
        //{

        //}
        public HomeController(IQueryProcessor qp)
        {
            this.queryProcessor = qp;
        }


        public ActionResult Index()
        {
            var pizzas = queryProcessor.Execute(new GetAllPizzasQuery());

            var model = new Models.HomeViewModel { Pizzas = new List<Models.Pizza>()};

            //TODO: automapper this
            foreach (var pizza in pizzas)
            {
                var p = new Models.Pizza
                {
                    id =pizza.id,
                    Name = pizza.Name,
                    Description = pizza.Description,
                    Price = pizza.Price
                };
                model.Pizzas.Add(p);
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}