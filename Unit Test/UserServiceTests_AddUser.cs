using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace Unit_Test
{
    public partial class UserServiceTests
    {
        [TestMethod]
        public async Task AddUser_ShouldReturnAddedUser_WhenUserIsValid()
        {
            // Arrange
            var user1 = MockData.User1();

            _userRepoMock.Setup(x => x.AddAsync(user1))
                .ReturnsAsync(user1);

            // Act
            var user = await _sut.AddUserAsync(user1);

            //Assert
            Assert.IsTrue(CheckIfTwoEntitiesAreIdentical(user, user1));
        }

        [TestMethod]
        public async Task AddUser_ShouldReturnException_WhenUserIsNull()
        {
            //Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _sut.AddUserAsync(null));
        }

        [TestMethod]
        public async Task AddUser_ShouldReturnException_WhenUserHasLongName()
        {
            // Arrange
            var userDTO = MockData.UserWithLongName();

            //Assert
            ArgumentException ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("Name can't be longer than 20 characters", ex.Message);
        }

        [TestMethod]
        public async Task AddUser_ShouldReturnException_WhenUserHasLongSurname()
        {
            // Arrange
            var userDTO = MockData.UserWithLongSurname();

            //Assert
            ArgumentException ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("Surname can't be longer than 20 characters", ex.Message);
        }

        [TestMethod]
        public async Task AddUser_ShouldReturnException_WhenUserHasInvalidBirthDate()
        {
            // Arrange
            var userDTO = MockData.UserWithBirthDateOnFuture();

            //Assert
            ArgumentException ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("Birthday date must be less than today", ex.Message);
        }

        [TestMethod]
        public async Task AddUser_ShouldReturnException_WhenUserTypeIsNull()
        {
            // Arrange
            var userDTO = MockData.UserWithNullUserType();

            //Assert
            ArgumentException ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("User type identity must be greater then zero and not NULL", ex.Message);
        }

        [TestMethod]
        public async Task AddUser_ShouldReturnException_WhenUserTypeIsInvalid()
        {
            // Arrange
            var userDTO = MockData.UserWithInvalidUserType();

            //Assert
            ArgumentException ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("User type identity must be greater then zero and not NULL", ex.Message);
        }

        [TestMethod]
        public async Task AddUser_ShouldReturnException_WhenUserTitleIsNull()
        {
            // Arrange
            var userDTO = MockData.UserWithNullUserTitle();

            //Assert
            ArgumentException ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("User title identity must be greater then zero and not NULL", ex.Message);
        }

        [TestMethod]
        public async Task AddUser_ShouldReturnException_WhenUserTitleIsInvalid()
        {
            // Arrange
            var userDTO = MockData.UserWithInvalidUserTitle();

            //Assert
            ArgumentException ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("User title identity must be greater then zero and not NULL", ex.Message);
        }

        [TestMethod]
        public async Task AddUser_ShouldReturnException_WhenUserHasLongMail()
        {
            // Arrange
            var userDTO = MockData.UserWithLongMail();

            //Assert
            ArgumentException ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("Email can't be longer than 50 characters", ex.Message);
        }

        [TestMethod]
        public async Task AddUser_ShouldReturnException_WhenUserHasInvalidMail()
        {
            // Arrange
            var userDTO = MockData.UserWithInvalidMail();

            //Assert
            ArgumentException ex = await Assert.ThrowsExceptionAsync<ArgumentException>(() => _sut.AddUserAsync(userDTO));
            Assert.AreEqual("Email is not in the right format \"name@domain.com\"", ex.Message);
        }

        
    }
}
