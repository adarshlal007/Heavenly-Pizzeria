
using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    public static class TypeExtensions
    {
        public static Type GetQueryResultType(this Type queryType)
        {
            return queryType.GetQueryInterface().GetGenericArguments()[0];
        }

        public static Type GetQueryInterface(this Type type)
        {
            return (
                from @interface in type.GetInterfaces()
                where @interface.IsGenericType
                where typeof(IQuery<>).IsAssignableFrom(@interface.GetGenericTypeDefinition())
                select @interface)
                .SingleOrDefault();
        }
    }
}
