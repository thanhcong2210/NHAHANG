using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using NhaHangTC.Data;
using NhaHangTC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace NhaHangTC.Web.App_Start
{
    public class TaiKhoanStore : UserStore<TaiKhoanUser>
    {
        public TaiKhoanStore(NhaHangTCDbContext context)
            : base(context)
        {
        }
    }
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class TaiKhoanManager : UserManager<TaiKhoanUser>
    {
        public TaiKhoanManager(IUserStore<TaiKhoanUser> store)
            : base(store)
        {
        }

        public static TaiKhoanManager Create(IdentityFactoryOptions<TaiKhoanManager> options, IOwinContext context)
        {
            var manager = new TaiKhoanManager(new UserStore<TaiKhoanUser>(context.Get<NhaHangTCDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<TaiKhoanUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);

            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<TaiKhoanUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<TaiKhoanUser, string>
    {
        public ApplicationSignInManager(TaiKhoanManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(TaiKhoanUser user)
        {
            return user.GenerateUserIdentityAsync((TaiKhoanManager)UserManager, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<TaiKhoanManager>(), context.Authentication);
        }
    }
}