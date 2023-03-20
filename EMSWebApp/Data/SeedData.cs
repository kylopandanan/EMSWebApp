
using EMSWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EMSWebApp.Data
{
    public static class SeedData
    {
        public static void SeedDefaultData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department(3, "Executives"),
                new Department(4, "Construction"),
                new Department(5, "Accounting")
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee(2, "Jhansept Kylo", DateTime.Now.AddDays(1), "Jk@gmail.com", "0977467872", 1)
                );
        }
    }
}
