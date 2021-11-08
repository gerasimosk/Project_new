using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebAPI.Domain;
using WebAPI.Repositories;
using WebAPI.Services.Implementations;

namespace Unit_Test
{
    [TestClass]
    public partial class UserServiceTests
    {
        private UserService _sut;
        private Mock<IUserRepository> _userRepoMock;


        [TestInitialize]
        public void Setup()
        {
            _userRepoMock = new Mock<IUserRepository>();
            _sut = new UserService(_userRepoMock.Object);
        }

        private bool CheckIfTwoEntitiesAreIdentical(User user1, User user2)
        {
            return user1.Name.Equals(user2.Name) && user1.Surname.Equals(user2.Surname) && user1.BirthDate.Equals(user2.BirthDate) && user1.UserTypeId == user2.UserTypeId
                && user1.UserTitleId == user2.UserTitleId && user1.EmailAddress.Equals(user2.EmailAddress) && user1.IsActive == user2.IsActive;
        }
    }
}
