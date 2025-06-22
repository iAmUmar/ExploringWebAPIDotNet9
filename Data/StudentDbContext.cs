using Microsoft.EntityFrameworkCore;

namespace ExploringWebAPIDotNet9.Data
{
    public class StudentDbContext(DbContextOptions<StudentDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students => Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(

                new Student { Id = 1, Name = "John Doe", DateOfBirth = new DateTime(2000, 1, 1), Address = "123 Main St", PhoneNumber = "123-456-7890", Course = "Computer Science", Fees = 1000 },
                new Student { Id = 2, Name = "Jane Smith", DateOfBirth = new DateTime(1999, 2, 2), Address = "456 Elm St", PhoneNumber = "987-654-3210", Course = "Mathematics", Fees = 1200 },
                new Student { Id = 3, Name = "Will Turner", DateOfBirth = new DateTime(1999, 2, 2), Address = "786 Elm St", PhoneNumber = "456-789-1400", Course = "History", Fees = 1500 },
                new Student { Id = 4, Name = "Muhammad Umar", DateOfBirth = new DateTime(1993, 8, 18), Address = "345 Dhoke Paracha", PhoneNumber = "312-4747-481", Course = "Litrature", Fees = 1100 },
                new Student { Id = 5, Name = "Jack Sparrow", DateOfBirth = new DateTime(1994, 2, 12), Address = "421 Satellite Town", PhoneNumber = "312-4324-567", Course = "Science", Fees = 1400 }

            );
        }
    }
}
