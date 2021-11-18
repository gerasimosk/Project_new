using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using WebAPI.Exceptions;

namespace Unit_Test
{
    public partial class UserServiceTests
    {
        [TestMethod]
        public async Task DeleteUser_ShouldReturnNothing_WhenUserIsValid()
        {
            // Arrange
            var user1 = MockData.User1();
            _userRepoMock.Setup(x => x.GetUserByIdAsync(user1.Id))
                .ReturnsAsync(user1);

            // Act
            try
            {
                await _sut.DeleteUserAsync(user1.Id);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task DeleteUser_ShouldReturnException_WhenUserDoesNotExists()
        {
            //Assert
            await Assert.ThrowsExceptionAsync<EntityNotFoundException>(() => _sut.DeleteUserAsync(100));
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public async Task DeleteUser_ShouldReturnException_WhenUserIdentityIsInvalid(int userId)
        {
            //Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _sut.DeleteUserAsync(userId));
        }
    }
}
