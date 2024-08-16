using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pschool.BlazorWasm.IServices;
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

           
            builder.Logging.SetMinimumLevel(LogLevel.Debug);

            
            builder.Services.AddScoped<IHttpClientService, HttpClientService>();

           
            builder.Services.AddScoped<IParentService, ParentService>();
            builder.Services.AddScoped<IStudentService, StudentService>();

            await builder.Build().RunAsync();
        }
    }
}