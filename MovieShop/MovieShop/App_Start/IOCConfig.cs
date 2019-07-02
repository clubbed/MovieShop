using Autofac;
using Autofac.Integration.Mvc;
using MovieShop.Data;
using MovieShop.Data.Interfaces;
using MovieShop.Data.Repository;
using MovieShop.Models;
using System.Reflection;
using System.Web.Mvc;

namespace MovieShop.App_Start
{
    public class IOCConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<MovieRepository>().As<IMovieRepository>();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>();
            builder.RegisterType<RentRepository>().As<IRentRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}