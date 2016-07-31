using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Contract.DTOs;

namespace Repo
{
    public class DbContext
    {
        public static Pizza[] Pizzas()
        {  
            var pizzas = new List<Pizza> {
                                            new Pizza {id=1, Name = "Chastity", Description="Pure pizza with only the best ingriedents to love.", Price=10D },
                                            new Pizza {id=2, Name = "Temperance", Description="Vege lovers delight.", Price=9D },
                                            new Pizza {id=3, Name = "Charity", Description="Meat Lovers are going to be oncloud 9.", Price=15D },
                                            new Pizza {id=4, Name = "Curiousity", Description="Dice with the devil for a random chance pizza.", Price=15D },
                                            new Pizza {id=5, Name = "Devotion", Description="Chicken, garlic and secret sauce made from the foountain of youth.", Price=15D },

                                        };

            return pizzas.ToArray();
        }
    }
}
