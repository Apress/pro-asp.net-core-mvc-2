using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Users.Models;
using Users.Infrastructure;

namespace Users {

    public class Startup {

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

public void ConfigureServices(IServiceCollection services) {

    services.AddTransient<IPasswordValidator<AppUser>,
        CustomPasswordValidator>();
    services.AddTransient<IUserValidator<AppUser>, 
        CustomUserValidator>();

    services.AddDbContext<AppIdentityDbContext>(options =>
        options.UseSqlServer(
            Configuration["Data:SportStoreIdentity:ConnectionString"]));

    services.AddIdentity<AppUser, IdentityRole>(opts => {
        opts.User.RequireUniqueEmail = true;
        //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
        opts.Password.RequiredLength = 6;
        opts.Password.RequireNonAlphanumeric = false;
        opts.Password.RequireLowercase = false;
        opts.Password.RequireUppercase = false;
        opts.Password.RequireDigit = false;
    }).AddEntityFrameworkStores<AppIdentityDbContext>()
        .AddDefaultTokenProviders();

    services.AddMvc();
}

        public void Configure(IApplicationBuilder app) {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
