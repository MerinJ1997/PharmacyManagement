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
    public class LoginData
    {
        public void loginDataDetails(LoginModel loginModel)
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=.;Database=PharmacyManagement;Integrated Security=SSPI");
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    LoginModel lm = new LoginModel();
                    string User = loginModel.username;
                    string Pass = loginModel.password;


                    sqlCon.Open();
                    string query = "select RoleID,EmployeeName,EmployeeAddress,PhoneNo,Email from UserDetails where Username=@Username AND Password=@Password";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@Username", User);
                    sqlCmd.Parameters.AddWithValue("@Password", Pass);
                    int RoleID = Convert.ToInt32(sqlCmd.ExecuteScalar());

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = sqlCmd;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        loginModel.name = dataSet.Tables[0].Rows[0]["EmployeeName"].ToString();
                        loginModel.address = dataSet.Tables[0].Rows[0]["EmployeeAddress"].ToString();
                        loginModel.phone = dataSet.Tables[0].Rows[0]["PhoneNo"].ToString();
                        loginModel.email = dataSet.Tables[0].Rows[0]["Email"].ToString();
                        loginModel.roleid = RoleID;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data found");
            }






        }

    }
}
