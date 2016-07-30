[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(HeavenlyPizzeriaWebUI.Bootstrapper), "Bootstrap")]
namespace HeavenlyPizzeriaWebUI
{
    //using Client.Code;
    //using Client.CrossCuttingConcerns;
    using Contract;
    using SimpleInjector;
    using Microsoft.AspNet.Identity;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web.Mvc;
    using System.Web.Mvc;
    //using Client;
    using System.Reflection;
    using HeavenlyPizzeriaWebUI.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Controllers;
    using SimpleInjector.Diagnostics;
    using Code;
    using CrossCuttingConcerns;
    using QueryService;
    using CommandService;

    //simpleinjector
    public static class Bootstrapper
    {
        private static Container container;

        public static void Bootstrap()
        {
            container = new Container();
            container.Options.AllowOverridingRegistrations = true;

            container.RegisterSingleton<IQueryProcessor>(new DynamicQueryProcessor(container));
            container.RegisterPerWebRequest<CommandServiceClient>(() => new CommandServiceClient());
            container.RegisterPerWebRequest<QueryServiceClient>(() => new QueryServiceClient());
            container.Register(typeof(ICommandHandler<>), typeof(WcfServiceCommandHandlerProxy<>));
            container.Register(typeof(IQueryHandler<,>), typeof(WcfServiceQueryHandlerProxy<,>));

            container.RegisterDecorator(typeof(ICommandHandler<>),
                typeof(FromWcfFaultTranslatorCommandHandlerDecorator<>));

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            var registration = Lifestyle.Transient.CreateRegistration(typeof(HomeController), container);
            container.AddRegistration(typeof(HomeController), registration);
            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,"Ignored");

            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        public static TService GetInstance<TService>() where TService : class
        {
            return container.GetInstance<TService>();
        }
    }
}
