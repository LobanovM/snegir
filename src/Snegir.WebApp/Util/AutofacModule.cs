using Autofac;
using Snegir.Core.Entities;
using Snegir.Core.Interfaces;
using Snegir.Core.Services.Contents;
using Snegir.DAL;

namespace Snegir.WebApp.Util
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContentService>().As<IContentService>();

            builder.RegisterType<EFRepository<Content>>().As<IRepository<Content>>().WithParameter("context", new EFApplicationContext());
            builder.RegisterType<EFRepository<Storage>>().As<IRepository<Storage>>().WithParameter("context", new EFApplicationContext());
        }
    }
}
