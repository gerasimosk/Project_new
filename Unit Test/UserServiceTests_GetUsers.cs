using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;

namespace Unit_Test
{
    public partial class UserServiceTests
    {
        [TestMethod]
        public void GetUsersAsync_ShouldReturnUsers_WhenUsersExists()
        {
            // Arrange
            var user1 = MockData.User1();
            var user2 = MockData.User2();

            _userRepoMock.Setup(x => x.GetUsersAsync(1, 100, null))
                .ReturnsAsync(new List<User>() { user1, user2 });

            // Act
            List<User> users = _sut.GetUsersAsync(1, 100, null).Result;

            //Assert
            Assert.AreEqual(2, users.Count());
            Assert.IsTrue(CheckIfTwoEntitiesAreIdentical(user1, users[0]));
            Assert.IsTrue(CheckIfTwoEntitiesAreIdentical(user2, users[1]));
        }

        [TestMethod]
        public void GetUsersAsync_ShouldReturnUsersWithFullNameStartsWith_Nik_WhenUsersExists()
        {
            // Arrange
            var userNikos = MockData.UserNikos();

            _userRepoMock.Setup(x => x.GetUsersAsync(1, 100, "Nik"))
                .ReturnsAsync(new List<User>() { userNikos });

            // Act
            List<User> users = _sut.GetUsersAsync(1, 100, "Nik").Result;

            //Assert
            Assert.AreEqual(1, users.Count());
            Assert.IsTrue(CheckIfTwoEntitiesAreIdentical(userNikos, users[0]));
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

        [DataTestMethod]
        [DataRow(0, 1)]
        [DataRow(-1, 1)]
        [DataRow(0, 0)]
        [DataRow(0, -1)]
        [DataRow(1, 0)]
        [DataRow(1, -1)]
        public async Task GetUsersAsync_ShouldReturnException_WhenPageSizePageSizeNotGiven(int pageNumber, int pageSize)
        {
            //Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => _sut.GetUsersAsync(pageNumber, pageSize, null));
        }
    }
}
