using Autofac;

namespace HtmlAnalysis.Core.DataAccess
{
    public class DatabaseDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>().InstancePerLifetimeScope();
        }
    }
}
