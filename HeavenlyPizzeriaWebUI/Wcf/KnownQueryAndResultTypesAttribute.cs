﻿namespace HeavenlyPizzeriaWebUI.Wcf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contract;

    public class KnownQueryAndResultTypesAttribute : KnownTypesAttribute
    {
        public KnownQueryAndResultTypesAttribute()
            : base(new KnownTypesDataContractResolver(QueryTypes.Union(ResultTypes)))
        {
        }

        private static IEnumerable<Type> ResultTypes => QueryTypes.Select(GetResultType);

        private static IEnumerable<Type> QueryTypes =>
            typeof(Contract.Queries.Orders.GetOrderByIdQuery).Assembly.GetExportedTypes().Where(IsQueryType);

        private static bool IsQueryType(Type type) => GetResultType(type) != null;

        private static Type GetResultType(Type queryType) => (
            from iface in queryType.GetInterfaces()
            where iface.IsGenericType && iface.GetGenericTypeDefinition() == typeof(IQuery<>)
            select iface.GetGenericArguments()[0])
            .SingleOrDefault();
    }
}
