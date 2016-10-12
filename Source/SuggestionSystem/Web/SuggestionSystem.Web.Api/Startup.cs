using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using SuggestionSystem.Common.Constants;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(SuggestionSystem.Web.Api.Startup))]

namespace SuggestionSystem.Web.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            AutoMapperConfig.RegisterMappings(Assemblies.DataTransferModels);

            ConfigureAuth(app);

            var httpConfig = new HttpConfiguration();
            WebApiConfig.Register(httpConfig);
            httpConfig.EnsureInitialized();

            app
                .UseNinjectMiddleware(NinjectConfig.CreateKernel)
                .UseNinjectWebApi(httpConfig);
        }
    }
}
