namespace SınavProjesi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SınavProjesi.Context.ExamContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SınavProjesi.Context.ExamContext context)
        {
            context.Users.AddOrUpdate(x => x.UserId, new Models.User()
            {
                UserId=1,
                Password = "12345",
                UserName = "Admin"
            },
            new Models.User { UserId=2,UserName = "Kullanici", Password = "1234" });
        }
    }
}

