using ApplicationLayer.Interfaces.Session;
using ApplicationLayer.Managers;

namespace ProjectWebAPI.Test.ApplicationLayer.Test.Managers
{
    public class SessionManagerTests
    {
        [Fact]
        //MethodUnderTest_Scenario_ExpectedBehavior
        public void Access_ValidUser_ReturnsSuccess()
        {
            //Arrange
            Login login = new SessionManager();
            //Act
            bool userAccessSuccess = login.Access();
            //assert
            Assert.True(userAccessSuccess);

        }


        //empty user data , null
        public void Access_NullUserData_ReturnsFalse()
        {
        }
        //wrong user data




    }
}
