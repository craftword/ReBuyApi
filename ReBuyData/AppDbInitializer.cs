using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using ReBuyModels;

namespace ReBuyData
{
    public class AppDbInitializer
    {
        public static async Task Seed(ApplicationDBContext context, RoleManager<IdentityRole> roleManager, UserManager<UsersModel> userManager)
        {


            try
            {
                context.Database.EnsureCreated();

                if (!roleManager.Roles.Any())
                {
                    var listOfRoles = new List<IdentityRole>
                {
                    new IdentityRole("Admin"),
                    new IdentityRole("Customer")

                };
                    foreach (var role in listOfRoles)
                    {
                        await roleManager.CreateAsync(role);
                    }
                }
                if (!context.Users.Any())
                {
                    var data = File.ReadAllText(@"C:\Users\craft\source\repos\ReBuyApi\ReBuyData\SeedData\data.json");
                    var listOfUsers = JsonConvert.DeserializeObject<List<UsersModel>>(data);
                    int count = 0;
                    foreach (var user in listOfUsers)
                    {
                        var newUser = new UsersModel()
                        {
                            UserName = user.Email,
                            Email = user.Email,
                            FullName = user.FullName,
                            Gender = user.Gender,
                            AvatarUrl = "default.jpg",
                            IsActive = user.IsActive


                        };

                        var userAdded = await userManager.CreateAsync(newUser, "Test@1234");

                        if (userAdded.Succeeded)
                        {
                            if (count > 0)
                            {
                                await userManager.AddToRoleAsync(newUser, "Customer");

                            }
                            else
                            {
                                await userManager.AddToRoleAsync(newUser, "Admin");
                            }

                        }

                        count++;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
