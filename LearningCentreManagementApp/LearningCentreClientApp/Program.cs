using BusinessLogic.Repository;
using BusinessLogic.Repository.IRepository;
using LearningCentreClientApp.Service;
using LearningCentreClientApp.Service.IService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


namespace LearningCentreClientApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseUrl")) });
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            await builder.Build().RunAsync();
        }
    }
}
