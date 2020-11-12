using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// Added to access Hort_EdContext.
using Hort_Ed.Models;
using Hort_Ed.Data;

namespace Hort_Ed
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			//services.AddDbContext<ApplicationDbContext>(options =>
			//	options.UseSqlServer(
			//		Configuration.GetConnectionString("DefaultConnection")));
			//services.AddDefaultIdentity<IdentityUser>()
			//	.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddDbContext<Hort_EdContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("Hort_Ed")));
		//	 Configuring SecurityContext to use Hort_EdContext connection string as well.
			services.AddDbContext<SecurityContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("Hort_Ed")));

			// Services to manage a user and role security setup.
			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<SecurityContext>()
				//Provide basic login and registration forms.
				.AddDefaultUI()
				// Handle background security in default manner.
				.AddDefaultTokenProviders();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, RoleManager<IdentityRole> roleManager,
			UserManager<IdentityUser> userManager)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			SetupSecurity.SeedRoles(roleManager);
			SetupSecurity.SeedUsers(userManager);


		}
	}
}
