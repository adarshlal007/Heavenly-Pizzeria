namespace BusinessLayer.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contract;
    using Contract.DTOs;
    using Contract.Queries;
    using Contract.Queries.Orders;
    using Contract.Queries.Pizza;


    public class GetAllPizzasQueryHandler
        : IQueryHandler<GetAllPizzasQuery, Pizza[]>
    {
        private readonly ILogger logger;

        public GetAllPizzasQueryHandler(ILogger logger)
        {
            this.logger = logger;
        }

        public Pizza[] Handle(GetAllPizzasQuery query)
        {
            this.logger.Log("Retrieving all pizzas. Cowabunga!");

            return GetAllPizzas();
        }

        private Pizza[] GetAllPizzas()
        {
            //This would be call to DAL layer (entity framework or massive micro ORM)
            var pizzas = Repo.DbContext.Pizzas();
            //var pizzas = new List<Pizza> {
            //                                new Pizza {id=1, Name = "Chastity", Description="Pure pizza with only the best ingriedents to love.", Price=10D },
            //                                new Pizza {id=1, Name = "Temperance", Description="Vege lovers delight.", Price=9D },
            //                                new Pizza {id=1, Name = "Charity", Description="Meat Lovers are going to be oncloud 9.", Price=15D },
            //                                new Pizza {id=1, Name = "Curiousity", Description="Dice with the devil for a random chance pizza.", Price=15D },
            //                                new Pizza {id=1, Name = "Devotion", Description="Chicken, garlic and secret sauce made from the foountain of youth.", Price=15D },

            //                            };

            return pizzas.ToArray();
        }
    }
}