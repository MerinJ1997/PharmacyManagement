using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public bool ValidateData(AddUserDetailsModel userDetailsModel, CancelEventArgs e)
        {
            return false;
        }
        public void SaveUserData(AddUserDetailsModel userDetailsModel)
        {
            //ValidateData(userDetailsModel, new CancelEventArgs());
            SqlConnection connection = null;
            using(connection = new SqlConnection("data source =.; database = PharmacyManagement; integrated security = SSPI"))
            {
                try
                {
                    string Name = userDetailsModel.Name;
                    string Address = userDetailsModel.Address;
                    string Email = userDetailsModel.Email;
                    string Phone = userDetailsModel.Phone;
                    string Gender = userDetailsModel.Gender;
                    int Age = userDetailsModel.Age;
                    string Role = userDetailsModel.Role;
                    string Username = userDetailsModel.username;
                    string Password = userDetailsModel.password;
                    SqlCommand command = new SqlCommand("AddUser", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@empname", Name);
                    command.Parameters.AddWithValue("@address", Address);
                    command.Parameters.AddWithValue("@email", Email);
                    command.Parameters.AddWithValue("@phone", Phone);
                    command.Parameters.AddWithValue("@gender", Gender);
                    command.Parameters.AddWithValue("@age", Age);
                    command.Parameters.AddWithValue("@role", Role);
                    command.Parameters.AddWithValue("@username", Username);
                    command.Parameters.AddWithValue("@password", Password);
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Inserted Succesfully");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public List<AddUserDetailsModel> GetUserData()
        {
            try
            {
                List<AddUserDetailsModel> addUserDetailsModels = new List<AddUserDetailsModel>();
                PharmacyManagementEntities pharmacyManagementEntities = new PharmacyManagementEntities();
                var data = from userobj in pharmacyManagementEntities.UserDetails
                           join roleobj in pharmacyManagementEntities.Roles on userobj.RoleID equals roleobj.RoleID
                           select userobj;
                foreach (var user in data)
                {
                    AddUserDetailsModel addUserDetailsModel = new AddUserDetailsModel();
                    addUserDetailsModel.Roling = new RoleData();
                    addUserDetailsModel.ID = user.EmployeeID;
                    addUserDetailsModel.Name = user.EmployeeName;
                    addUserDetailsModel.Address = user.EmployeeAddress;
                    addUserDetailsModel.Email = user.Email;
                    addUserDetailsModel.Phone = user.PhoneNo;
                    addUserDetailsModel.Gender = user.Gender;
                    addUserDetailsModel.Age = user.Age;
                    if (user.RoleID == 1)
                    {
                        addUserDetailsModel.Roling.RoleName = "Employee";
                    }
                    else
                    {
                        addUserDetailsModel.Roling.RoleName = "Manger";
                    }
                    //addUserDetailsModel.Roling.RoleName = user.Role.RoleName;
                    addUserDetailsModels.Add(addUserDetailsModel);
                }
                return addUserDetailsModels;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public void DeleteUserData(AddUserDetailsModel addUserDetailsModel)
        {
            try
            {
                PharmacyManagementEntities entities = new PharmacyManagementEntities();
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
                PharmacyManagementEntities entities = new PharmacyManagementEntities();
                var query = from Obj in entities.UserDetails
                            join roleobj in entities.Roles on Obj.RoleID equals roleobj.RoleID
                            where Obj.EmployeeID == addUserDetailsModel.ID
                            select Obj;
                foreach (var entity in query)
                {
                    addUserDetailsModel.Roling = new RoleData();
                    entity.EmployeeName = addUserDetailsModel.Name;
                    entity.Age = addUserDetailsModel.Age;
                    entity.Email = addUserDetailsModel.Email;
                    entity.EmployeeAddress = addUserDetailsModel.Address;
                    entity.Gender = addUserDetailsModel.Gender;
                    entity.PhoneNo = addUserDetailsModel.Phone;
                    if(addUserDetailsModel.Role=="Manager")
                    {
                        entity.RoleID = 2;
                    }
                    else
                    { entity.RoleID = 1;}
                    //entity.Role.RoleName = addUserDetailsModel.Role;
                    //entities.UserDetails.Add(entity);
                }
               entities.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
