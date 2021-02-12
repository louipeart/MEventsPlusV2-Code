using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEventsPlusV2.Data
{
    public class DbInitializer
    {
        public static void Initialize(MEventsV2DbContext context)
        {
            context.Database.EnsureCreated();

        }
    }
}
