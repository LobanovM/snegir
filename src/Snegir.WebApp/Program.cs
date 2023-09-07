using React.AspNet;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Snegir.WebApp.Util;
using Serilog;
using Hangfire;
using Hangfire.PostgreSql;

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
                builder.Services.AddSwaggerGen();
                builder.Services.AddHangfireServer();
                builder.Services.AddHangfire(config => config.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("HangfireConnection")));
                builder.Services.AddCors();

                var app = builder.Build();

                if (app.Environment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
               
                app.UseHangfireDashboard("/hangfire");
                app.UseSerilogRequestLogging();
                app.UseReact(config => { });
                app.UseDefaultFiles();
                app.UseStaticFiles();
                app.UseRouting(); // need to delete?
                app.UseCors(builder => builder.AllowAnyOrigin());
                app.UseEndpoints(endpoints => endpoints.MapControllers());

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