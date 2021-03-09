using demo_ca_app.Domain.Entities;
using demo_ca_app.Domain.ValueObjects;
using demo_ca_app.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace demo_ca_app.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Movies.Any())
            {
                context.Movies.Add(new Movie { Name = "Movie1", Description = "Description1", Duration = 120 });
                context.Movies.Add(new Movie { Name = "Movie2", Description = "Description2", Duration = 121 });
                context.Movies.Add(new Movie { Name = "Movie3", Description = "Description3", Duration = 122 });
                context.Movies.Add(new Movie { Name = "Movie4", Description = "Description4", Duration = 123 });
                context.Movies.Add(new Movie { Name = "Movie5", Description = "Description5", Duration = 124 });
                context.Movies.Add(new Movie { Name = "Movie6", Description = "Description6", Duration = 125 });
                context.Movies.Add(new Movie { Name = "Movie7", Description = "Description7", Duration = 126 });
                context.Movies.Add(new Movie { Name = "Movie8", Description = "Description7", Duration = 127 });
                context.Movies.Add(new Movie { Name = "Movie9", Description = "Description7", Duration = 128 });
                context.Movies.Add(new Movie { Name = "Movie10", Description = "Description7", Duration = 129 });

                await context.SaveChangesAsync();
            }

            if (!context.Ratings.Any())
            {
                context.Ratings.Add(new Rating { MovieId = 1, MovieName = "Movie1", Comment="comment user 1", RatingPoint=1, UserMail="user1@mail.com" });
                context.Ratings.Add(new Rating { MovieId = 1, MovieName = "Movie1", Comment="comment user 2", RatingPoint=2, UserMail="user2@mail.com" });
                context.Ratings.Add(new Rating { MovieId = 1, MovieName = "Movie1", Comment="comment user 3", RatingPoint=3, UserMail="user3@mail.com" });
                context.Ratings.Add(new Rating { MovieId = 1, MovieName = "Movie1", Comment="comment user 4", RatingPoint=4, UserMail="user4@mail.com" });
                context.Ratings.Add(new Rating { MovieId = 1, MovieName = "Movie1", Comment="comment user 5", RatingPoint=5, UserMail="user5@mail.com" });
            }
        }
    }
}
