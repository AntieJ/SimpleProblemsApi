using System.Reflection;
using System.Web.Http;
using Autofac;
using SimpleProblemsApi.Features.EulerProblems.Services;
using Autofac.Integration.WebApi;

namespace SimpleProblemsApi
{
    public class AutofacDependencyInjection
    {
        public static IContainer BuildContainer(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ProblemFactory>()
                .As<IProblemFactory>();
            builder.RegisterType(typeof(FibonacciSumService)).AsSelf();
            builder.RegisterType(typeof(MultipleSumService)).AsSelf();
            builder.RegisterType(typeof(HighestPrimeFactorService)).AsSelf();

            // Register Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            builder.RegisterHttpRequestMessage(configuration);

            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }
    }
}