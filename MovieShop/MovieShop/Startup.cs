using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MovieShop.Models;
using Owin;
using System;
using System.Linq;
using System.Security.Cryptography;

[assembly: OwinStartupAttribute(typeof(MovieShop.Startup))]
namespace MovieShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            createRolesAndAdminUser();
        }

        private void createRolesAndAdminUser()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole
                {
                    Name = "Admin"
                };

                roleManager.Create(role);

                var passwordHasher = new PasswordHasher();

                var user = new ApplicationUser
                {
                    Name = "Admin",
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    PasswordHash = passwordHasher.HashPassword("Admin123@")
                };

                var checkUser = userManger.Create(user);
                if (checkUser.Succeeded)
                {
                    userManger.AddToRole(user.Id, "Admin");
                }

            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole
                {
                    Name = "User"
                };

                roleManager.Create(role);

            }
        }

    }
}
