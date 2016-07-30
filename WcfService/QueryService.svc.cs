namespace WcfService
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.ServiceModel;
    using Code;

    
    [ServiceContract(Namespace = "http://schemas.datacontract.org/2004/07/Contract.DTOs")]
    [ServiceKnownType(nameof(GetKnownTypes))]
    public class QueryService
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider) =>
            Bootstrapper.GetQueryAndResultTypes();

        [OperationContract]        
        public  object ExecuteQuery(dynamic query) {
            //    => ExecuteQuery(query);
            //internal static object ExecuteQuery(dynamic query)
            //{
            //Type queryType = query.GetType();

            dynamic queryHandler = Bootstrapper.GetQueryHandlerInstance(query);

            try
            {
                return queryHandler.Handle(query);
            }
            catch (Exception ex)
            {
                Bootstrapper.Log(ex);

                var faultException = WcfExceptionTranslator.CreateFaultExceptionOrNull(ex);

                if (faultException != null)
                {
                    throw faultException;
                }

                throw;
            }
        }
    }
}