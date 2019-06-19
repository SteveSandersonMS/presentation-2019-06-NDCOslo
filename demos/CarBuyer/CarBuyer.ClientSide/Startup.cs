using CarBuyer.Core.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CarBuyer.ClientSide
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICatalogService, SampleCatalogService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<Core.Components.App>("app");
        }
    }
}
