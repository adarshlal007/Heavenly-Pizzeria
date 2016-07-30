namespace WcfService
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Security.Principal;
    using System.Threading;
    using BusinessLayer;
    using Contract;
    using SimpleInjector;
    using WcfService.Code;
    using WcfService.CrossCuttingConcerns;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Wcf;
    

    public static class Bootstrapper
    {
        private static Container container;

        public static object GetCommandHandler(Type commandType) =>
            container.GetInstance(typeof(ICommandHandler<>).MakeGenericType(commandType));

        public static object GetQueryHandler(Type queryType) =>
            container.GetInstance(CreateQueryHandlerType(queryType));

        public static object GetInstance(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        public static T GetInstance<T>() where T : class
        {
            return container.GetInstance<T>();
        }

        public static IEnumerable<Type> GetCommandTypes() => BusinessLayerBootstrapper.GetCommandTypes();

        public static IEnumerable<Type> GetQueryAndResultTypes()
        {
            var queryTypes = BusinessLayerBootstrapper.GetQueryTypes().Select(q => q.QueryType);
            var resultTypes = BusinessLayerBootstrapper.GetQueryTypes().Select(q => q.ResultType).Distinct();
            return queryTypes.Concat(resultTypes);
        }

        public static void Bootstrap()
        {
            container = new Container();

            BusinessLayerBootstrapper.Bootstrap(container);

            container.RegisterDecorator(typeof(ICommandHandler<>),
                typeof(ToWcfFaultTranslatorCommandHandlerDecorator<>));

            container.RegisterWcfServices(Assembly.GetExecutingAssembly());

            RegisterWcfSpecificDependencies();

            container.Verify();
        }

        internal static dynamic GetQueryHandlerInstance(dynamic query)
        {
            Type queryType = query.GetType();
            var queryHandlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, queryType.GetQueryResultType());
            return container.GetInstance(queryHandlerType);
        }

        internal static dynamic GetCommandHandlerInstance(dynamic command)
        {
            Type commandHandlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            return container.GetInstance(commandHandlerType);
        }
        public static void Log(Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }

        private static void RegisterWcfSpecificDependencies()
        {
            container.RegisterSingleton<ILogger>(new DebugLogger());

            container.Register<IPrincipal>(() => Thread.CurrentPrincipal);
        }

        private static Type CreateQueryHandlerType(Type queryType) =>
            typeof(IQueryHandler<,>).MakeGenericType(queryType, new QueryInfo(queryType).ResultType);
    }
}