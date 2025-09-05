using ApplicationLayer.Interfaces.Session;
using DataAccessLayer.Models.DTOS;

namespace ApplicationLayer.Managers
{
    public class SessionManager : Login, Logout
    {
        public bool Access()
        {
            var user = new UserDTO();
            return true;
        }

        public bool Exit()
        {
            return true;
        }
    }
}
