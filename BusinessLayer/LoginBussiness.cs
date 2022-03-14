using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LoginBussiness : ILogin
    {
        public void logindetails(LoginModel loginModel)
        {
            LoginData ld = new LoginData();
            ld.loginDataDetails(loginModel);
        }
    }
}
