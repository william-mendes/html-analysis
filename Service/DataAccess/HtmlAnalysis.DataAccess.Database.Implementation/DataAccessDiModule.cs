using Autofac;
using HtmlAnalysis.DataAccess.Database.Contracts;
using HtmlAnalysis.DataAccess.Database.Implementation;

namespace HtmlAnalysis.Service.Implementation
{
    public class DataAccessDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FetchRepository>().As<IFetchRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FrequencyRepository>().As<IFrequencyRepository>().InstancePerLifetimeScope();
        }
    }
}
