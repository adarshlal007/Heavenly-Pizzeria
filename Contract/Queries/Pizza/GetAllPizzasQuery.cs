using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO = Contract.DTOs;


namespace Contract.Queries.Pizza
{
    public class GetAllPizzasQuery : IQuery<DTO.Pizza[]>
    {
    }
}
