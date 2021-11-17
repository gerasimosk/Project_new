using Microsoft.EntityFrameworkCore;
using System;
using WebAPI.Domain;

namespace WebAPI.Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserTitle> UserTitle { get; set; }
        public DbSet<UserType> UserType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasData(
                    new User { Id = 1, Name = "Brian", Surname = "Glover", BirthDate = new DateTime(2019, 12, 30), UserTypeId = 1, UserTitleId = 1, EmailAddress = "Brian@example.com", IsActive = true },
                    new User { Id = 2, Name = "Samantha", Surname = "Russell", BirthDate = new DateTime(2020, 10, 25), UserTypeId = 2, UserTitleId = 2, EmailAddress = "Samantha@example.com", IsActive = true },
                    new User { Id = 3, Name = "Adele", Surname = "Stephens", BirthDate = new DateTime(2018, 09, 18), UserTypeId = 3, UserTitleId = 4, EmailAddress = "Adele@example.com", IsActive = true },
                    new User { Id = 4, Name = "Bert", Surname = "Ruell", BirthDate = new DateTime(2019, 12, 05), UserTypeId = 4, UserTitleId = 4, EmailAddress = "Bert@example.com", IsActive = true },
                    new User { Id = 5, Name = "Tyrone", Surname = "Stanley", BirthDate = new DateTime(2019, 08, 12), UserTypeId = 5, UserTitleId = 5, EmailAddress = "Tyrone@example.com", IsActive = true },
                    new User { Id = 6, Name = "Windsor", Surname = "Ryan", UserTypeId = 5, UserTitleId = 2, EmailAddress = "Windsor@example.com", IsActive = true },
                    new User { Id = 7, Name = "Willa", Surname = "Walsh", BirthDate = new DateTime(2020, 01, 07), UserTypeId = 4, UserTitleId = 3, EmailAddress = "Willa@example.com", IsActive = true },
                    new User { Id = 8, Name = "Edric", Surname = "Burrows", BirthDate = new DateTime(2020, 02, 01), UserTypeId = 2, UserTitleId = 4, EmailAddress = "Edric@example.com", IsActive = true },
                    new User { Id = 9, Name = "Fletcher", Surname = "Abbott", UserTypeId = 3, UserTitleId = 1, EmailAddress = "Fletcher@example.com", IsActive = true },
                    new User { Id = 10, Name = "Marc", Surname = "Atkinson", UserTypeId = 3, UserTitleId = 2, EmailAddress = "Marc@example.com", IsActive = true },
                    new User { Id = 11, Name = "Julia", Surname = "Blair", BirthDate = new DateTime(2019, 12, 09), UserTypeId = 1, UserTitleId = 2, EmailAddress = "Julia@example.com", IsActive = true },
                    new User { Id = 12, Name = "Maxwell", Surname = "Jackson", BirthDate = new DateTime(2020, 03, 23), UserTypeId = 5, UserTitleId = 5, EmailAddress = "Maxwell@example.com", IsActive = true },
                    new User { Id = 13, Name = "Rita", Surname = "Wheatly", UserTypeId = 3, UserTitleId = 3, EmailAddress = "Rita@example.com", IsActive = true },
                    new User { Id = 14, Name = "Pearl", Surname = "Salazar", BirthDate = new DateTime(1018, 12, 21), UserTypeId = 1, UserTitleId = 4, EmailAddress = "Pearl@example.com", IsActive = true },
                    new User { Id = 15, Name = "Zelene", Surname = "Row", BirthDate = new DateTime(2020, 10, 12), UserTypeId = 2, UserTitleId = 2, EmailAddress = "Zelene@example.com", IsActive = true }
                    );

            builder.Entity<UserTitle>()
                .HasData(
                    new UserTitle { Id = 1, Description = "userTitle 1" },
                    new UserTitle { Id = 2, Description = "userTitle 2" },
                    new UserTitle { Id = 3, Description = "userTitle 3" },
                    new UserTitle { Id = 4, Description = "userTitle 4" },
                    new UserTitle { Id = 5, Description = "userTitle 5" }
                    );

            builder.Entity<UserType>()
                .HasData(
                    new UserType { Id = 1, Description = "userType 1", Code = 'a' },
                    new UserType { Id = 2, Description = "userType 2", Code = 'b' },
                    new UserType { Id = 3, Description = "userType 3", Code = 'c' },
                    new UserType { Id = 4, Description = "userType 4", Code = 'd' },
                    new UserType { Id = 5, Description = "userType 5", Code = 'e' }
                    );

            builder.Entity<User>()
                .Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Entity<User>()
                .Property(x => x.Surname)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Entity<User>()
               .Property(x => x.BirthDate)
               .IsRequired(false);

            builder.Entity<User>()
                .Property(x => x.UserTypeId)
                .IsRequired();

            builder.Entity<User>()
                .Property(x => x.UserTitleId)
                .IsRequired();

            builder.Entity<User>()
                .Property(x => x.EmailAddress)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Entity<User>()
                .Property(x => x.IsActive)
                .IsRequired(false);

            builder.Entity<UserTitle>()
                .Property(x => x.Description)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<UserType>()
                .Property(x => x.Description)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<UserType>()
                .Property(x => x.Code)
                .HasMaxLength(2)
                .IsRequired();

            builder.Entity<User>()
                .HasOne(s => s.UserTitle)
                .WithMany(g => g.User)
                .HasForeignKey(s => s.UserTitleId);

            builder.Entity<User>()
                .HasOne(s => s.UserType)
                .WithMany(g => g.User)
                .HasForeignKey(s => s.UserTypeId);
        }
    }
}
