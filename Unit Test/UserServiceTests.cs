using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;
using WebAPI.Repositories;
using WebAPI.Services.Implementations;

namespace Unit_Test
{
    [TestClass]
    public class UserServiceTests
    {
        private readonly UserService _sut;
        private readonly Mock<IUserRepository> _userRepoMock = new Mock<IUserRepository>();

        public UserServiceTests()
        {
            _sut = new UserService(_userRepoMock.Object);
        }

        [TestMethod]
        public void GetUsersAsync_ShouldReturnUsers_WhenUsersExists()
        {
            // Arrange
            var user1Id = 1;
            var user1DTO = new User
            {
                Id = user1Id,
                Name = "name1",
                Surname = "surname1"
            };

            var user2Id = 2;
            var user2DTO = new User
            {
                Id = user2Id,
                Name = "name2",
                Surname = "surname2"
            };

            _userRepoMock.Setup(x => x.GetUsersAsync(1, 100, null))
                .ReturnsAsync(new List<User>() { user1DTO, user2DTO });

            // Act
            List<User> users = _sut.GetUsersAsync(1, 100, null).Result;

            //Assert
            Assert.AreEqual(2, users.Count());

            Assert.AreEqual("name1", users[0].Name);
            Assert.AreEqual("surname1", users[0].Surname);

            Assert.AreEqual("name2", users[1].Name);
            Assert.AreEqual("surname2", users[1].Surname);
        }

        [TestMethod]
        public void GetUsersAsync_ShouldReturnUsersWithFullNameStartsWith_Nik_WhenUsersExists()
        {
            // Arrange
            var user1Id = 1;
            var user1DTO = new User
            {
                Id = user1Id,
                Name = "name1",
                Surname = "surname1"
            };

            var user2Id = 2;
            var user2DTO = new User
            {
                Id = user2Id,
                Name = "Nikos",
                Surname = "surname2"
            };

            _userRepoMock.Setup(x => x.GetUsersAsync(1, 100, "Nik"))
                .ReturnsAsync(new List<User>() { user2DTO });

            // Act
            List<User> users = _sut.GetUsersAsync(1, 100, "Nik").Result;

            //Assert
            Assert.AreEqual(1, users.Count());

            Assert.AreEqual("Nikos", users[0].Name);
            Assert.AreEqual("surname2", users[0].Surname);
        }

        [TestMethod]
        public void GetUsersAsync_ShouldReturnNothing_WhenUsersDoesNotExists()
        {
            // Arrange
            _userRepoMock.Setup(x => x.GetUsersAsync(1, 100, null))
                .ReturnsAsync(() => null);

            // Act
            List<User> users = _sut.GetUsersAsync(1, 100, null).Result;

            //Assert
            Assert.IsNull(users);
        }

        [TestMethod]
        public async Task GetUsersAsync_ShouldReturnException_WhenPageSizePageSizeNotGiven()
        {
            //Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _sut.GetUsersAsync(0, 1, null));
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _sut.GetUsersAsync(-1, 1, null));
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _sut.GetUsersAsync(0, 0, null));
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _sut.GetUsersAsync(0, -1, null));
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _sut.GetUsersAsync(1, 0, null));
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _sut.GetUsersAsync(1, -1, null));
        }

        [TestMethod]
        public async Task GetByGetUSerById_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var userDTO = new User
            {
                Id = userId,
                Name = "name1",
                Surname = "surname1"
            };
            _userRepoMock.Setup(x => x.GetUserByIdAsync(userId))
                .ReturnsAsync(userDTO);

            // Act
            User user = await _sut.GetUserByIdAsync(userId);

            //Assert
            Assert.AreEqual(userDTO.Name, user.Name);
            Assert.AreEqual(userDTO.Surname, user.Surname);
        }

        [TestMethod]
        public async Task GetByGetUSerById_ShouldReturnNothing_WhenUserDoesNotExists()
        {
            // Arrange
            _userRepoMock.Setup(x => x.GetUserByIdAsync(100))
                .ReturnsAsync(() => null);

            // Act
            User user = await _sut.GetUserByIdAsync(100);

            //Assert
            Assert.IsNull(user);
        }

        [TestMethod]
        public async Task GetByGetUSerById_ShouldReturnException_WhenUserIdentityIsInvalid()
        {
            //Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _sut.GetUserByIdAsync(-1));
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _sut.GetUserByIdAsync(0));
        }

        [TestMethod]
        public async Task AddUser_ShouldReturnAddedUser_WhenUserIsValid()
        {
            // Arrange
            var user1Id = 1;
            var userDTO = new User
            {
                Id = user1Id,
                Name = "name1",
                Surname = "surname1",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = 1,
                UserTitleId = 1,
                EmailAddress = "mail@domainName.com",
                IsActive = true
            };

            _userRepoMock.Setup(x => x.AddAsync(userDTO))
                .ReturnsAsync(userDTO);

            // Act
            var user = await _sut.AddUserAsync(userDTO);

            //Assert

            Assert.AreEqual("name1", user.Name);
            Assert.AreEqual("surname1", user.Surname);
            Assert.AreEqual(DateTime.Today.AddDays(-1), user.BirthDate);
            Assert.AreEqual(1, user.UserTypeId);
            Assert.AreEqual(1, user.UserTitleId);
            Assert.AreEqual("mail@domainName.com", user.EmailAddress);
            Assert.AreEqual(true, user.IsActive);
        }

        [TestMethod]
        public async Task AddUser_ShouldReturnException_WhenUserIsNotValid()
        {
            // Arrange
            var user1Id = 1;
            var userDTO = new User
            {
                Id = user1Id,
                Name = "name1",
                Surname = "surname1",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = 1,
                UserTitleId = 1,
                EmailAddress = "mail@domainName.com",
                IsActive = true
            };

            _userRepoMock.Setup(x => x.AddAsync(userDTO))
                .ReturnsAsync(userDTO);

            //Assert
            ArgumentException ex = null;

            //Max length of Name
            userDTO.Name = "name1name1name1name1name1";
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("Name can't be longer than 20 characters", ex.Message);
            userDTO.Name = "name1";

            //Max length of Surname
            userDTO.Surname = "surname1surname1surname1";
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("Surname can't be longer than 20 characters", ex.Message);
            userDTO.Surname = "surname1";

            //Date of birthday which is in future
            userDTO.BirthDate = DateTime.Today.AddDays(1);
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("Birthday date must be less than today", ex.Message);
            userDTO.BirthDate = DateTime.Today.AddDays(-1);

            //User type must not be empty
            userDTO.UserTypeId = 0;
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("User type identity must be greater then zero and not NULL", ex.Message);
            userDTO.UserTypeId = 1;

            //User type must be greater than zero
            userDTO.UserTypeId = -1;
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("User type identity must be greater then zero and not NULL", ex.Message);
            userDTO.UserTypeId = 1;

            //User title must not be empty
            userDTO.UserTitleId = 0;
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("User title identity must be greater then zero and not NULL", ex.Message);
            userDTO.UserTitleId = 1;

            //User title must be greater than zero
            userDTO.UserTitleId = -1;
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("User title identity must be greater then zero and not NULL", ex.Message);
            userDTO.UserTitleId = 1;

            //Max length of mail
            userDTO.EmailAddress = "mail@domainNamedomainNamedomainNamedomainNamedomainName.com";
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("Email can't be longer than 50 characters", ex.Message);
            userDTO.EmailAddress = "mail@domainName.com";

            //Invalid mail
            userDTO.EmailAddress = "mail.com";
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("Email is not in the right format \"name@domain.com\"", ex.Message);
            userDTO.EmailAddress = "mail@domainName.com";
        }

        [TestMethod]
        public async Task UpdateUser_ShouldReturnUpdatedUser_WhenUserIsValid()
        {
            // Arrange
            var user1Id = 1;
            var userDTOChanged = new User
            {
                Id = user1Id,
                Name = "name1Changed",
                Surname = "surname1Changed",
                BirthDate = DateTime.Today.AddDays(-2),
                UserTypeId = 2,
                UserTitleId = 2,
                EmailAddress = "mail@domainNameChanged.com",
                IsActive = false
            };

            _userRepoMock.Setup(x => x.UpdateAsync(userDTOChanged))
                .ReturnsAsync(userDTOChanged);

            // Act
            var user = await _sut.UpdateUserAsync(userDTOChanged);

            //Assert

            Assert.AreEqual("name1Changed", user.Name);
            Assert.AreEqual("surname1Changed", user.Surname);
            Assert.AreEqual(DateTime.Today.AddDays(-2), user.BirthDate);
            Assert.AreEqual(2, user.UserTypeId);
            Assert.AreEqual(2, user.UserTitleId);
            Assert.AreEqual("mail@domainNameChanged.com", user.EmailAddress);
            Assert.AreEqual(false, user.IsActive);
        }

        [TestMethod]
        public async Task UpdateUser_ShouldReturnException_WhenUserIsNotValid()
        {
            // Arrange
            var user1Id = 1;
            var userDTO = new User
            {
                Id = user1Id,
                Name = "name1",
                Surname = "surname1",
                BirthDate = DateTime.Today.AddDays(-1),
                UserTypeId = 1,
                UserTitleId = 1,
                EmailAddress = "mail@domainName.com",
                IsActive = true
            };

            _userRepoMock.Setup(x => x.UpdateAsync(userDTO))
                .ReturnsAsync(userDTO);

            //Assert
            ArgumentException ex = null;

            //Max length of Name
            userDTO.Name = "name1name1name1name1name1";
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.UpdateUserAsync(userDTO));
            Assert.AreEqual("Name can't be longer than 20 characters", ex.Message);
            userDTO.Name = "name1";

            //Max length of Surname
            userDTO.Surname = "surname1surname1surname1";
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.UpdateUserAsync(userDTO));
            Assert.AreEqual("Surname can't be longer than 20 characters", ex.Message);
            userDTO.Surname = "surname1";

            //Date of birthday which is in future
            userDTO.BirthDate = DateTime.Today.AddDays(1);
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.UpdateUserAsync(userDTO));
            Assert.AreEqual("Birthday date must be less than today", ex.Message);
            userDTO.BirthDate = DateTime.Today.AddDays(-1);

            //User type must not be empty
            userDTO.UserTypeId = 0;
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.UpdateUserAsync(userDTO));
            Assert.AreEqual("User type identity must be greater then zero and not NULL", ex.Message);
            userDTO.UserTypeId = 1;

            //User type must be greater than zero
            userDTO.UserTypeId = -1;
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.UpdateUserAsync(userDTO));
            Assert.AreEqual("User type identity must be greater then zero and not NULL", ex.Message);
            userDTO.UserTypeId = 1;

            //User title must not be empty
            userDTO.UserTitleId = 0;
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.UpdateUserAsync(userDTO));
            Assert.AreEqual("User title identity must be greater then zero and not NULL", ex.Message);
            userDTO.UserTitleId = 1;

            //User title must be greater than zero
            userDTO.UserTitleId = -1;
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.UpdateUserAsync(userDTO));
            Assert.AreEqual("User title identity must be greater then zero and not NULL", ex.Message);
            userDTO.UserTitleId = 1;

            //Max length of mail
            userDTO.EmailAddress = "mail@domainNamedomainNamedomainNamedomainNamedomainName.com";
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.UpdateUserAsync(userDTO));
            Assert.AreEqual("Email can't be longer than 50 characters", ex.Message);
            userDTO.EmailAddress = "mail@domainName.com";

            //Invalid mail
            userDTO.EmailAddress = "mail.com";
            ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.UpdateUserAsync(userDTO));
            Assert.AreEqual("Email is not in the right format \"name@domain.com\"", ex.Message);
            userDTO.EmailAddress = "mail@domainName.com";
        }

        [TestMethod]
        public async Task DeleteUser_ShouldReturnNothing_WhenUserIsValid()
        {
            // Arrange
            var userId = 1;

            _userRepoMock.Setup(x => x.DeleteUserAsync(userId));

            // Act
            try {
                await _sut.DeleteUserAsync(userId);
                
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task DeleteUser_ShouldReturnException_WhenUserIdentityIsNotValid()
        {
            // Arrange
            var userId = 0;

            _userRepoMock.Setup(x => x.DeleteUserAsync(userId));

            // Assert
            ArgumentOutOfRangeException ex = await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _sut.DeleteUserAsync(userId));
            Assert.AreEqual("The Identity of a user cannot be zero or negative", ex.ParamName);
        }
    }
}
