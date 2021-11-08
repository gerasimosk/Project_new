using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var userId = 1;

            _userRepoMock.Setup(x => x.DeleteUserAsync(userId));

            // Act
            try
            {
                await _sut.DeleteUserAsync(userId);

            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task DeleteUser_ShouldReturnException_WhenUserDoesNotExists()
        {
            // Arrange
            _userRepoMock.Setup(x => x.DeleteUserAsync(100))
                .Throws(new EntityNotFoundException());

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
