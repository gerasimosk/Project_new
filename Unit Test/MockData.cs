using System;
using WebAPI.Domain;

namespace Unit_Test
{
    public static class MockData
    {
        public static User User1()
        {
            return new User
            {
                Id = 1,
                Name = "name1",
                Surname = "surname1",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = 1,
                UserTitleId = 1,
                EmailAddress = "mail@domainName.com",
                IsActive = true
            };
        }

        public static User User2()
        {
            return new User
            {
                Id = 1,
                Name = "name2",
                Surname = "surname2",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = 2,
                UserTitleId = 2,
                EmailAddress = "mail2@domainName2.com",
                IsActive = true
            };
        }

        public static User UserNikos()
        {
            return new User
            {
                Id = 1,
                Name = "Nikos",
                Surname = "Papadopoulos",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = 1,
                UserTitleId = 1,
                EmailAddress = "nikos@domainName.com",
                IsActive = true
            };
        }

        public static User UserWithLongName()
        {
            return new User
            {
                Id = 1,
                Name = "name1name1name1name1name1",
                Surname = "surname1",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = 1,
                UserTitleId = 1,
                EmailAddress = "mail@domainName.com",
                IsActive = true
            };
        }

        public static User UserWithLongSurname()
        {
            return new User
            {
                Id = 1,
                Name = "name1",
                Surname = "surname1surname1surname1",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = 1,
                UserTitleId = 1,
                EmailAddress = "mail@domainName.com",
                IsActive = true
            };
        }

        public static User UserWithBirthDateOnFuture()
        {
            return new User
            {
                Id = 1,
                Name = "name1",
                Surname = "surname1",
                BirthDate = DateTime.Today.AddDays(1),
                UserTypeId = 1,
                UserTitleId = 1,
                EmailAddress = "mail@domainName.com",
                IsActive = true
            };
        }

        public static User UserWithNullUserType()
        {
            return new User
            {
                Id = 1,
                Name = "name1",
                Surname = "surname1",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTitleId = 1,
                EmailAddress = "mail@domainName.com",
                IsActive = true
            };
        }

        public static User UserWithInvalidUserType()
        {
            return new User
            {
                Id = 1,
                Name = "name1",
                Surname = "surname1",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = -1,
                UserTitleId = 1,
                EmailAddress = "mail@domainName.com",
                IsActive = true
            };
        }

        public static User UserWithNullUserTitle()
        {
            return new User
            {
                Id = 1,
                Name = "name1",
                Surname = "surname1",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = 1,
                EmailAddress = "mail@domainName.com",
                IsActive = true
            };
        }

        public static User UserWithInvalidUserTitle()
        {
            return new User
            {
                Id = 1,
                Name = "name1",
                Surname = "surname1",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = 1,
                UserTitleId = -1,
                EmailAddress = "mail@domainName.com",
                IsActive = true
            };
        }

        public static User UserWithLongMail()
        {
            return new User
            {
                Id = 1,
                Name = "name1",
                Surname = "surname1",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = 1,
                UserTitleId = 1,
                EmailAddress = "mail@domainNamedomainNamedomainNamedomainNamedomainName.com",
                IsActive = true
            };
        }

        public static User UserWithInvalidMail()
        {
            return new User
            {
                Id = 1,
                Name = "name1",
                Surname = "surname1",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = 1,
                UserTitleId = 1,
                EmailAddress = "mail.com",
                IsActive = true
            };
        }
    }
}
