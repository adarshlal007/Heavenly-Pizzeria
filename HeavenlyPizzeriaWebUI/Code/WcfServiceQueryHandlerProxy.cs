namespace HeavenlyPizzeriaWebUI.Code
{
    using System;
    using System.Diagnostics;
    using Contract;
    using QueryService;

    public sealed class WcfServiceQueryHandlerProxy<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {

        private readonly QueryServiceClient _service;

        public WcfServiceQueryHandlerProxy(QueryServiceClient queryServiceClient)
        {
            _service = queryServiceClient;
        }

        [DebuggerStepThrough]
        public TResult Handle(TQuery query)
        {
            //var service = new QueryService.QueryServiceClient();

            try
            {
                var result = _service.ExecuteQuery(query);
                return (TResult)result;
            }
            finally
            {
                try
                {
                    ((IDisposable)_service).Dispose();
                }
                catch
                {
                    // Against good practice and the Framework Design Guidelines, WCF can throw an
                    // exception during a call to Dispose, which can result in loss of the original exception.
                    // See: https://marcgravell.blogspot.com/2008/11/dontdontuse-using.html
                    // See: https://msdn.microsoft.com/en-us/library/aa355056.aspx
                }
            }
        }
    }
}