using Microsoft.EntityFrameworkCore;


namespace loginAssignment.Model
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(new UserModel
            {
                UserId = 1,
                FirstName = "costa",
                LastName = "aa",
                Email = "aab@gmail.com",
                Password = "123",
               

            }, new UserModel
            {
                UserId = 2,
                FirstName = "lahiru",
                LastName = "bb",
                Email = "bba@gmail.com",
                Password = "123",
            });
        }

        public DbSet<UserModel>Users{ get; set; }    

}
}
