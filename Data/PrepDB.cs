using System;

namespace PlatformService.Data
{
    public class PrepDB
    {
        public static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Seed data");
                context.Platforms.AddRange(
                    new Models.Platform() { Name = ".Net", Publisher = "Microsoft", Cost = "Free"},
                    new Models.Platform() { Name = ".SQL Express", Publisher = "Microsoft", Cost = "Free" },
                    new Models.Platform() { Name = "Kubernetes", Publisher = "Cloud Native foundation", Cost = "Free" });

                context.SaveChanges();
            }
            else {
                Console.WriteLine("Have data");
            }
        }
    }
}
