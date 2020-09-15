using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramControllerReel.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProgramControllerReelContext(

                    serviceProvider.GetRequiredService<DbContextOptions<ProgramControllerReelContext>>()))

            {
                if(context.Programs.Any())
                {
                    return;
                }

                context.Programs.AddRange(

                    new Programs
                    {
                      ProgramName = "SQL",
                      ProjectOwner = "Tolga KALAYCIOĞLU",
                      ProjectManager = "Koray Özyurt",
                      Status = "In progress",
                      DueDate = DateTime.Parse("2020-09-29")
                    },

                    new Programs
                    {
                        ProgramName = "Java",
                        ProjectOwner = "Mehmet",
                        ProjectManager = "Ahmet",
                        Status = "In progress",
                        DueDate = DateTime.Parse("2020-05-15")
                    }

                );

                context.SaveChanges();
            }

               
        }

    }
}
