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
    public class BillData
    {
        public List<StockModel> SearchData(StockModel add)

        {
            List<StockModel> models = new List<StockModel>();
            try
            {
                using (SqlConnection con = new SqlConnection("data source =.; database = PharmacyManagement; integrated security = SSPI"))
                {
                    string search = add.MedName;
                    string cmdst = "select MedicineName from StockDetails where ExpiryDate > GetDate() and StockAvailable >0 and MedicineName like '%" + search + "%'" ;
                    SqlCommand cmd = new SqlCommand(cmdst, con);
                    con.Open();
                    SqlDataReader read = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(read);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StockModel sm = new StockModel();
                        sm.MedName = dt.Rows[i][0].ToString();  
                        models.Add(sm);
                    }

                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("No stock available");
            }
            return models;
        }
        public List<StockModel> FetchDataByMedName(StockModel add)
        {
            List<StockModel> models = new List<StockModel>();
            try
            {
                using (SqlConnection con = new SqlConnection("data source =.; database = PharmacyManagement; integrated security = SSPI"))
                {
                    string Medname = add.MedName;
                    string cmdst = "select MedID, Price, StockAvailable from StockDetails where  MedicineName = @medname  ";
                    SqlCommand cmd = new SqlCommand(cmdst, con);
                    cmd.Parameters.AddWithValue("@medname", Medname);
                    con.Open();
                    SqlDataReader reads = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reads);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StockModel sm = new StockModel();
                        // sm.MedName = dt.Rows[i][0].ToString();
                        sm.MedID = (int)dt.Rows[i][0];
                        sm.UnitPrice = float.Parse(dt.Rows[i][1].ToString());
                        sm.StockAvailable = int.Parse(dt.Rows[i][2].ToString());
                        models.Add(sm);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in fetching");
            }
            return models;
        }
        public void Update(StockModel add)
        {
            SqlConnection connection = null;
            using (connection = new SqlConnection("data source =.; database = PharmacyManagement; integrated security = SSPI"))
            {
                string search = add.MedName;
                int qty = add.StockAvailable;
                string cmdst = "Update StockDetails set StockAvailable = " + qty + " where MedicineName = '" + search+"'";
                SqlCommand cmd = new SqlCommand(cmdst, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void SaveBillData(StockModel add)
        {
            SqlConnection conn = null;
            using (conn = new SqlConnection("data source =.; database = PharmacyManagement; integrated security = SSPI"))
            {
                double gst = add.GST;
                float TotalAmount = add.TotalAmount;
                SqlCommand cmd = new SqlCommand("SaveBill", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GST", gst);
                cmd.Parameters.AddWithValue("@TotalAmnt", TotalAmount);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Successfully");
            }
        }
        public void SaveBillData2(StockModel add)
        {
            SqlConnection conn = null;
            using (conn = new SqlConnection("data source = .; database = PharmacyManagement; integrated security = SSPI"))
            {
                string name = add.MedName;
                int qty = add.Quantity;
                int price = Convert.ToInt32(add.UnitPrice);
                int totalPrice = Convert.ToInt32(add.Total);
                
                SqlCommand cmd = new SqlCommand("SaveBillData", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@medName", name);
                cmd.Parameters.AddWithValue("@quantity", qty);
                cmd.Parameters.AddWithValue("@unitprice", price);
                cmd.Parameters.AddWithValue("@totalprice", totalPrice);
                
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Successfully");
            }
        }
        public List<StockModel> GetBillData()
        {
            List<StockModel> model = new List<StockModel>();
            SqlConnection conn = null;
            using (conn = new SqlConnection("data source = .; database = PharmacyManagement; integrated security = SSPI"))
            {                
                SqlCommand cmd = new SqlCommand("GetBillData", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "GetBillData";
                //cmd.Connection = conn;
                conn.Open();
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                //adapter.Fill(dt);
                dt.Load(dr);
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    StockModel stockModel = new StockModel();
                    stockModel.InvoiceNo = Convert.ToInt32(dt.Rows[i]["InvoiceNo"]);                    
                    
                    
                        stockModel.MedName = dt.Rows[i]["MedName"].ToString();
                        stockModel.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                        stockModel.UnitPrice = Convert.ToInt32(dt.Rows[i]["UnitPrice"]);
                        stockModel.Total = dt.Rows[i]["Price"].ToString();
                        stockModel.GST = Convert.ToInt32(dt.Rows[i]["GST"]);
                        stockModel.Date = dt.Rows[i]["Date"].ToString();
                        stockModel.TotalAmount = Convert.ToInt32(dt.Rows[i]["TotalAmount"]);
                        model.Add(stockModel);
                    
                    
                    
                }
            }
            return model;
        }
    }

 }



