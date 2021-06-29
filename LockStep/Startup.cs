using Autofac;
using Autofac.Integration.Mvc;
using Owin;
using System.Web.Mvc;
using LockStep.Library.Persistence;
using LockStep.Library.Persistence.Repositories;

namespace LockStep.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<LibraryDbContext>();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>();
            builder.RegisterType<BookAuthorRepository>().As<IBookAuthorRepository>();
            builder.RegisterType<BookGenreRepository>().As<IBookGenreRepository>();
            builder.RegisterType<BookCommentRepository>().As<IBookCommentRepository>();
            builder.RegisterType<BookVoteRepository>().As<IBookVoteRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<PriceRepository>().As<IPriceRepository>();

           

           


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}