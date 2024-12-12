using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examination_Centere_Allocation
{
    public partial class forgetpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_ServerClick(object sender, EventArgs e)
        {
            string password = txtnPassword.Text;
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            string password1 = txtconfpassword1.Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            con.Open();
            string query = "select * from USERS where Mobile like '" + Mobileno.Value + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows) // If a record with the given mobile number exists
            {
                reader.Close();
                if (Regex.IsMatch(password, passwordPattern) && Regex.IsMatch(password1, passwordPattern))
                {
                    if (txtnPassword.Text == txtconfpassword1.Text)
                    {
                        string query1 = "update USERS set password= '" + txtnPassword.Text + "' where Mobile='" + Mobileno.Value + "'";
                        SqlCommand cmd1 = new SqlCommand(query1, con);
                        int count1 = cmd1.ExecuteNonQuery();
                        if (count1 > 0)
                        {
                            Response.Redirect("Siginin.aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStartStatus", "javascript:alert('Check password.');", true);
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid password. Ensure it meets the criteria.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage1.Text = "Invalid password. Ensure it meets the criteria.";
                    lblMessage1.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStartStatus", "javascript:alert('Please, Enter the correct Mobile Number.');", true);
            }
        }
    }
}