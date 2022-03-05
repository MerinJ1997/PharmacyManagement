using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccessLayer
{
    public class AddUserData
    {
        public void SaveUserData(AddUserDetailsModel userDetailsModel)
        {
            SqlConnection connection = null;
            using(connection = new SqlConnection("data source =LAPTOP-5PB6MEOA; database = PharmacyManagement; integrated security = SSPI"))
            {
                string Name = userDetailsModel.Name;
                string Address = userDetailsModel.Address;
                string Email = userDetailsModel.Email;
                int Phone = userDetailsModel.Phone;
                string Gender = userDetailsModel.Gender;
                int Age = userDetailsModel.Age;
                string Role = userDetailsModel.Role;
                string Username = userDetailsModel.username;
                string Password = userDetailsModel.password;
                SqlCommand command = new SqlCommand("AddUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@empname", Name);
                command.Parameters.AddWithValue("@address",Address);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@phone", Phone);
                command.Parameters.AddWithValue("@gender", Gender);
                command.Parameters.AddWithValue("@age", Age);
                command.Parameters.AddWithValue("@role", Role);
                command.Parameters.AddWithValue("@username", Username);
                command.Parameters.AddWithValue("@password", Password);
                connection.Open();
                //int rowsadded = command.ExecuteNonQuery();
                MessageBox.Show("Inserted Succesfully");
            }
        }
        public List<AddUserDetailsModel> GetUserData()       
        {
            List<AddUserDetailsModel> addUserDetailsModels = new List<AddUserDetailsModel>();
            PharmacyManagementEntities1 pharmacyManagementEntities1 = new PharmacyManagementEntities1();
            var data = from res in pharmacyManagementEntities1.UserDetails
                       select res;
            foreach (var user in data)
            {
                AddUserDetailsModel addUserDetailsModel = new AddUserDetailsModel();
                addUserDetailsModel.ID = user.EmployeeID;
                addUserDetailsModel.Name = user.EmployeeName;
                addUserDetailsModel.Address = user.EmployeeAddress;
                addUserDetailsModel.Email = user.Email;
                addUserDetailsModel.Phone = user.PhoneNo;
                addUserDetailsModel.Gender = user.Gender;
                addUserDetailsModel.Age = user.Age;
                addUserDetailsModel.Role = Convert.ToString(user.Role);
                addUserDetailsModels.Add(addUserDetailsModel);
                
            }
            return addUserDetailsModels;
        }
        public void DeleteUserData(AddUserDetailsModel addUserDetailsModel)
        {
            try
            {
                PharmacyManagementEntities1 entities = new PharmacyManagementEntities1();
                var result = from Obj in entities.UserDetails
                             where Obj.EmployeeID == addUserDetailsModel.ID
                             select Obj;
                foreach (var entity in result)
                {
                    entities.UserDetails.Remove(entity);
                }
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateUserData(AddUserDetailsModel addUserDetailsModel)
        {
            try
            {
                PharmacyManagementEntities1 entities1 = new PharmacyManagementEntities1();
                var query = from Obj in entities1.UserDetails
                            where Obj.EmployeeID == addUserDetailsModel.ID
                            select Obj;
                foreach (var entity in query)
                {
                    entity.EmployeeName = addUserDetailsModel.Name;
                    entity.Age = addUserDetailsModel.Age;
                    entity.Email = addUserDetailsModel.Email;
                    entity.EmployeeAddress = addUserDetailsModel.Address;
                    entity.Gender = addUserDetailsModel.Gender;
                    entity.PhoneNo = addUserDetailsModel.Phone;
                    entity.RoleID = addUserDetailsModel.ID;
                    entities1.UserDetails.Add(entity);
                }
                entities1.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
