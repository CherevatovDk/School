using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pschool.BlazorWasm.Services;

namespace Pschool.BlazorWasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7216") });
            builder.Services.AddScoped<IParentService, ParentService>();

            await builder.Build().RunAsync();
        }
    }
}