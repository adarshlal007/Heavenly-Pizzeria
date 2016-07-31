namespace BusinessLayer.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Linq;
    using Contract;
    using Contract.DTOs;
    using Contract.Queries;
    using Contract.Queries.Orders;
    using Contract.Queries.Pizza;
    using Repo;


    public class GetPizzaByIdQueryHandler : IQueryHandler<GetPizzaByIdQuery, Pizza>
    {
        private readonly ILogger logger;

        public GetPizzaByIdQueryHandler(ILogger logger)
        {
            this.logger = logger;
        }

        public Pizza Handle(GetPizzaByIdQuery query)
        {
            this.logger.Log("Retrieving pizza ordered. Cowabunga!");

            return GetPizza(query.Id);
        }

        private Pizza GetPizza(int id)
        {
            var pizza = (Pizza)Repo.DbContext.Pizzas().ToList().Where(p => p.id == id).FirstOrDefault();

            return pizza;
        }
    }
}