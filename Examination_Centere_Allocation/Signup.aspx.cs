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
    public partial class Signup : System.Web.UI.Page
    {
        private object lblMessage;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignup_ServerClick(object sender, EventArgs e)
        {
            string email = emailid.Value;
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            string password = txtPassword.Text;
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            string password1=txtpassword1.Text;
           
            if (Regex.IsMatch(email, pattern))
            {
                if (Regex.IsMatch(password, passwordPattern) && Regex.IsMatch(password1, passwordPattern))
                {
                    if (txtPassword.Text == txtpassword1.Text)
                    {
                        string name = string.Join(" ", firstname.Text, lastname.Value);
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                        con.Open();
                        string query = "insert into [dbo].[USERS]([username], [password], [Mobile], [Name],[emailId]) values ('" + username.Value + "','" + txtPassword.Text + "','" + mobileno.Value + "','" + name + "','" + emailid.Value + "');";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("Siginin.aspx");

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStartStatus", "javascript:alert('Invalid Password! Please ensure new and confirm passwords match. .');", true);
                    }
                }
                else
                {
                    //lblMessage.Text = "Invalid password. Ensure it meets the criteria.";
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage1.Text = "Invalid password. Ensure it meets the criteria.";
                    lblMessage1.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblemail.Text = "Invalid email. Ensure it meets the criteria.";
                lblemail.ForeColor = System.Drawing.Color.Red;
            }
          
        }
        
    }
}