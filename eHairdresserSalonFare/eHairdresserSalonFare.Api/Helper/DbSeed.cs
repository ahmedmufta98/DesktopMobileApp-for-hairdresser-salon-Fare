using eHairdresserSalonFareBugojno.DBContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace eHairdresserSalonFare.Api.Helper
{
    public static class DbSeed
    {
        public static void SeedDB(AppDbContext context)
        {
            try
            {
                context.Database.Migrate();
            }catch (Exception e)
            {
                throw e;
            }
        }
    }
}