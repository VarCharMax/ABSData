using Microsoft.EntityFrameworkCore;
using System.Linq;
using ABSDataFramework.Models;

namespace ABSDataFramework
{
    public class SeedData
    {
        public static void SeedDatabase(ApplicationDbContext context)
        {
            context.Database.Migrate();

            /*
            if (context.States.Count() == 0)
            {
                context.States.AddRange(
                        new state { name = "Australian Capital Territory" },
                        new state { name = "Northern Territory" },
                        new state { name = "New South Wales" },
                        new state { name = "South Australia" },
                        new state { name = "Queensland" },
                        new state { name = "Tasmania" },
                        new state { name = "Victoria" },
                        new state { name = "Western Australia" },
                        new state { name = "Other Territories" }
                    );
            }
            */

            /*
            if (context.Sexes.Count() == 0)
            {
                context.Sexes.AddRange(
                    new sex_abs { name = "Males" },
                    new sex_abs { name = "Females" },
                    new sex_abs { name = "Persons" }
                    );
            }
            */

            context.SaveChanges();
        }
    }
}