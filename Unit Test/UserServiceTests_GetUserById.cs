using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using WebAPI.Domain;
using WebAPI.Exceptions;

namespace Unit_Test
{
    public partial class UserServiceTests
    {
        [TestMethod]
        public async Task GetUserById_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var user1 = MockData.User1();

            _userRepoMock.Setup(x => x.GetUserByIdAsync(user1.Id))
                .ReturnsAsync(user1);

            // Act
            User user = await _sut.GetUserByIdAsync(user1.Id);

            //Assert
            Assert.IsTrue(CheckIfTwoEntitiesAreIdentical(user1, user));
        }

        [TestMethod]
        public async Task GetUserById_ShouldReturnException_WhenUserDoesNotExists()
        {
            // Arrange
            _userRepoMock.Setup(x => x.GetUserByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult<User>(null));

            //Assert
            await Assert.ThrowsExceptionAsync<EntityNotFoundException>(() => _sut.GetUserByIdAsync(100));
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public async Task GetUserById_ShouldReturnException_WhenUserIdentityIsInvalid(int userId)
        {
            //Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _sut.GetUserByIdAsync(userId));
        }
    }
}
