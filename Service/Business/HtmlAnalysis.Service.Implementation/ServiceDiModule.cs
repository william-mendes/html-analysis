using Autofac;
using HtmlAnalysis.Service.Contracts.Adapters;
using HtmlAnalysis.Service.Contracts.Services;
using HtmlAnalysis.Service.Implementation.Adapters;
using HtmlAnalysis.Service.Implementation.Services;
using System.Net.Http;

namespace HtmlAnalysis.Service.Implementation
{
    public class ServiceDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new HttpClient()).As<HttpClient>();

            builder.RegisterType<DocumentService>().As<IDocumentService>().InstancePerLifetimeScope();
            builder.RegisterType<FetchService>().As<IFetchService>().InstancePerLifetimeScope();
            builder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerLifetimeScope();

            builder.RegisterType<FrequencyAdapter>().As<IFrequencyAdapter>().InstancePerLifetimeScope();
        }
    }
}
