using meistrai_mvc_mano.Data;
using Microsoft.EntityFrameworkCore;

namespace meistrai_mvc_mano.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // Kintamųjų objektai

            // Specializations
            using (var context = new meistrai_mvc_manoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<meistrai_mvc_manoContext>>()))
            {
                if (!context.Specialization.Any())
                {

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

            // AutoService
            using (var context = new meistrai_mvc_manoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<meistrai_mvc_manoContext>>()))
            {
                if (!context.AutoService.Any())
                {
                    context.AutoService.AddRange(
                        new AutoService
                        {
                            Name = "Servisiukas",
                            Manager = "Antanas Antanauskas",
                            Address = "3 Beleko g., Kaimas"
                        },
                        new AutoService
                        {
                            Name = "Mašinų Namai",
                            Manager = "Beleka Belekauskas",
                            Address = "1, Pragaro g., Skuodas"
                        }
                    );

                    context.SaveChanges();
                }
            }

            // AutoWorker
            using (var context = new meistrai_mvc_manoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<meistrai_mvc_manoContext>>()))
            {
                if (!context.AutoWorker.Any())
                {
                    context.AutoWorker.AddRange(
                        new AutoWorker
                        {
                            Name = "Aidas",
                            Surname = "Opss",
                            City = "Kaunas",
                            Nuotrauka = "asjdasd",
                            AutoService = new AutoService(1)

                        },
                        new AutoWorker
                        {
                            Name = "Vidas",
                            Surname = "Video",
                            City = "Skuodas",
                            Nuotrauka = "Sfregfrs",
                            AutoService = new AutoService(2)
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
