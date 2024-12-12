using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examination_Centere_Allocation
{
    public partial class Siginin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignin_ServerClick(object sender, EventArgs e)
        {
    
            string query = "select * from users where username=@username and password=@password";

            // create a connection to the database
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultconnection"].ToString()))
            {
                // open the connection
                con.Open();

                // create the command to execute the query
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@username", txtusername.Value);
                    cmd.Parameters.AddWithValue("@password", password.Value);
                    // use sqldataadapter to fetch the data into a datatable
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        Response.Redirect("eca_home.aspx");
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showstartstatus", "javascript:alert('please enter vallid user details');", true);
                    }
                }

                // close the connection
                con.Close();
            }
            //Response.Redirect("eca_home.aspx");
        }

       
        protected void signup_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }
    }
}