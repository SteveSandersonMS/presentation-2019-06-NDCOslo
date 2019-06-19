using Microsoft.AspNetCore.Blazor.Hosting;
using System.Globalization;

namespace CarBuyer.ClientSide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
