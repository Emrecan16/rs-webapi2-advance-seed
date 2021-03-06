namespace RS.Core.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RS.Core.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RS.Core.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RS.Core.Models.ApplicationDbContext context)
        {
            //Veritabanında admin kullanıcısına ait bir kayıt yoksa, ilgili kaydın atamasını yapmaktadır.
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var PasswordHash = new PasswordHasher();
            if (!context.Users.Any(x => x.UserName == "info@remmsoft.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "info@remmsoft.com",
                    Email = "info@remmsoft.com",
                    PasswordHash = PasswordHash.HashPassword("Test123*")
                };

                UserManager.Create(user);
            }
        }
    }
}
