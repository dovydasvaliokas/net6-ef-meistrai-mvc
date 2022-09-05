using meistrai_mvc_mano.Data;
using Microsoft.EntityFrameworkCore;

namespace meistrai_mvc_mano.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new meistrai_mvc_manoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<meistrai_mvc_manoContext>>()))
            {
                // Look for any movies.
                if (context.Specialization.Any())
                {
                    return;   // DB has been seeded
                }

                context.Specialization.AddRange(
                    new Specialization
                    {
                        Name = "Mechanikas"
                    },
                    new Specialization
                    {
                        Name = "Apdaila"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
