namespace TheaterService.Data
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDBContext>());
            }
        }

        private static void SeedData(AppDBContext context)
        {
            if (!context.Theaters.Any())
            {
                Console.WriteLine("--> Seeding Data");

                var theaters = context.Theaters.ToList();

                context.Theaters.AddRange(
                    theaters
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}