using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagement.ViewModel
{
    public class ViewUpdateUserViewModel:BaseViewModel
    {
        public List<AddUserDetailsModel> adduserlist { get; set; }
        public ViewUpdateUserViewModel()
        {
            adduserlist = new List<AddUserDetailsModel>();
            AddUserBusiness addUserBusiness = new AddUserBusiness();
            adduserlist = addUserBusiness.GetUserDetails();
        }
        
    }
}
