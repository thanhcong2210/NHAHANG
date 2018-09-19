namespace NhaHangTC.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NhaHangTC.Model.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NhaHangTC.Data.NhaHangTCDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NhaHangTC.Data.NhaHangTCDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //CreateUser(context);
        }

        //private void CreateUser(NhaHangTCDbContext context)
        //{
        //    var manager = new UserManager<TaiKhoanUser>(new UserStore<TaiKhoanUser>(new NhaHangTCDbContext()));

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new NhaHangTCDbContext()));

        //    var user = new TaiKhoanUser()
        //    {
        //        TENDANGNHAP = "Thanhcong",
        //        Email = "loveyoukiss20120@gmail.com",
        //        EmailConfirmed = true,
        //        QUYENSD = "Admin",
        //        TRANGTHAIKICHHOAT = true

        //    };
        //    if (manager.Users.Count(x => x.UserName == "tedu") == 0)
        //    {
        //        manager.Create(user, "123654$");

        //        if (!roleManager.Roles.Any())
        //        {
        //            roleManager.Create(new IdentityRole { Name = "Admin" });
        //            roleManager.Create(new IdentityRole { Name = "User" });
        //        }

        //        var adminUser = manager.FindByEmail("tedu.international@gmail.com");

        //        manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        //    }

        //}
    }
}
