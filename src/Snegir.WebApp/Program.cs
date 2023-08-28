using React.AspNet;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Snegir.WebApp.Util;
using Serilog;
using Microsoft.AspNetCore.Hosting;

namespace Snegir.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();


            Log.Information("Starting up!");
            try
            {

                var builder = WebApplication.CreateBuilder(args);

                builder.Host.UseSerilog((context, configuration) => 
                    configuration.ReadFrom.Configuration(context.Configuration));

                builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
                builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));

                builder.Services.AddMemoryCache();
                builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                builder.Services.AddReact();
                builder.Services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName).AddChakraCore();
                builder.Services.AddControllers();

                var app = builder.Build();

                if (app.Environment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                   // app.UseSwagger();
                   // app.UseSwaggerUI();
                }

                app.UseSerilogRequestLogging();
                app.UseReact(config => { });
                app.UseDefaultFiles();
                app.UseStaticFiles();
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                app.Run();

                Log.Information("Stopped cleanly");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An unhandled exception occured during bootstrapping");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}