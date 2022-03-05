using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class AddUserDetailsModel
    {
        
        public int ID { get; set;}
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

}
