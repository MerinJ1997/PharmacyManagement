//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserDetail
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }
        public string Email { get; set; }
        public int PhoneNo { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public Nullable<int> RoleID { get; set; }
    
        public virtual Role Role { get; set; }
    }
}