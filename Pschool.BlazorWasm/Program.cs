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

            // Налаштування базової адреси для HttpClient
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7216") });

            // Налаштування логування
            builder.Logging.SetMinimumLevel(LogLevel.Debug);

            // Зареєструвати HttpClientService
            builder.Services.AddScoped<IHttpClientService, HttpClientService>();

            // Додати сервіс ParentService з логером
            builder.Services.AddScoped<IParentService, ParentService>();

            await builder.Build().RunAsync();
        }
    }
}