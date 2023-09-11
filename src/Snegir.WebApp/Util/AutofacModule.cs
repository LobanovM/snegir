using Autofac;
using Microsoft.EntityFrameworkCore;
using Snegir.Core.Entities;
using Snegir.Core.Interfaces;
using Snegir.Core.Services;
using Snegir.Core.Services.Contents;
using Snegir.DAL;

namespace Snegir.WebApp.Util
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();

                var opt = new DbContextOptionsBuilder<EFApplicationContext>();
                opt.UseNpgsql(config.GetSection("ConnectionStrings:SnegirDatabase").Value);

                return new EFApplicationContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<ContentService>().As<IContentService>();
            builder.RegisterType<LogService>().As<ILogService>();

            
            builder.RegisterType<EFRepository<Content>>().As<IRepository<Content>>();
            builder.RegisterType<EFRepository<Storage>>().As<IRepository<Storage>>();
        }
    }
}
