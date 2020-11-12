using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Hort_Ed
{
	public static class SetupSecurity
	{
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {

            IdentityUser admin = userManager.FindByEmailAsync("admin@horted.edu").Result;

            if (admin == null)
            {
                IdentityUser sysadmin = new IdentityUser();
                sysadmin.Email = "admin@horted.edu";
                sysadmin.UserName = "admin@horted.edu";

                IdentityResult result = userManager.CreateAsync(sysadmin, "1Hort_Ed@").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(sysadmin, "Administrator").Wait();
                }
            }
            IdentityUser instructor = userManager.FindByEmailAsync("instructor@horted.edu").Result;

            if (instructor == null)
            {
                IdentityUser sysadmin = new IdentityUser();
                sysadmin.Email = "instructor@horted.edu";
                sysadmin.UserName = "instructor@horted.edu";

                IdentityResult result = userManager.CreateAsync(sysadmin, "1Hort_Ed@").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(sysadmin, "Instructor").Wait();
                }
            }
            IdentityUser materialsmgmt = userManager.FindByEmailAsync("materialsmgmt@horted.edu").Result;

            if (materialsmgmt == null)
            {
                IdentityUser sysadmin = new IdentityUser();
                sysadmin.Email = "materialsmgmt@horted.edu";
                sysadmin.UserName = "materialsmgmt@horted.edu";

                IdentityResult result = userManager.CreateAsync(sysadmin, "1Hort_Ed@").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(sysadmin, "MaterialsManagement").Wait();
                }
            }
            IdentityUser billing = userManager.FindByEmailAsync("billing@horted.edu").Result;

            if (billing == null)
            {
                IdentityUser sysadmin = new IdentityUser();
                sysadmin.Email = "billing@horted.edu";
                sysadmin.UserName = "billing@horted.edu";

                IdentityResult result = userManager.CreateAsync(sysadmin, "1Hort_Ed@").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(sysadmin, "Billing").Wait();
                }
            }
        }










        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("SeminarParticipant").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "SeminarParticipant";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Instructor").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Instructor";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("MaterialsManagement").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "MaterialsManagement";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Billing").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Billing";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

    }
}
