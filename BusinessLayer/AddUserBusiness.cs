using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AddUserBusiness : IAddUser
    {
        AddUserData UserData = new AddUserData();
        public void SaveUser(AddUserDetailsModel addUser)
        {
            UserData.SaveUserData(addUser);
        }
        public List<AddUserDetailsModel> GetUserDetails()
        {            
            return UserData.GetUserData();
        }
        public void DeleteData(AddUserDetailsModel addUserDetailsModel)
        {
            UserData.DeleteUserData(addUserDetailsModel);
        }
        public void UpdateData(AddUserDetailsModel addUserDetailsModel)
        {
            UserData.UpdateUserData(addUserDetailsModel);
        }
    }
}
