namespace ScheduleService.Data
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
            if (!context.Schedules.Any())
            {
                Console.WriteLine("--> Seeding Data");

                var schedules = context.Schedules.ToList();

                context.Schedules.AddRange(
                    schedules
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
