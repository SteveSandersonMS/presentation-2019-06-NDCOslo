using Microsoft.AspNetCore.Components.Electron;

namespace CarBuyer.Electron
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ComponentsElectron.Run<Startup>("wwwroot/index.html");
        }
    }
}
