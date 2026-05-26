using Microsoft.Extensions.Hosting;

namespace Diogenes.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<IRunner, Runner>();
            builder.Services.AddHostedService<RunnerBackgroundService>();

            // ADD THIS
            builder.Services.AddHealthChecks();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapRazorPages()
               .WithStaticAssets();

            // ADD THIS
            app.MapHealthChecks("/health");

            app.Run();
        }
    }
}