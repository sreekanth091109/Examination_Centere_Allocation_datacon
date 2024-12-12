using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examination_Centere_Allocation
{
    public partial class section5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string cctv_instal = string.Empty;
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if (option1.Checked == true || option2.Checked == true)
            {
                options.Visible = false;

                string center_code = "1301";
                string script = "document.getElementById('section5').style.backgroundColor = 'green';";
                ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);

                SqlConnection sqlcon = new SqlConnection(connectionString);
                string selectedValue = string.Empty;
                if (option1.Checked)
                {

                    selectedValue = "YES";
                }
                else if (option2.Checked)
                {
                    selectedValue = "NO";
                }
                else
                {
                    selectedValue = "";
                }
                sqlcon.Open();
                string query = "Insert into SECURITY_SURVEILLANCE([CCTV_INSTALLED], [Cent_Code], [SECURITY_PERSONNEL]) values ('" + selectedValue + "','" + center_code + "','" + message.Value + "')";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    Response.Write("<script>alert('Saved Security And Surveillance.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Not Saved Security And Surveillance.')</script>");
                }
                sqlcon.Close();
            }
            else
            {
                options.Visible = true;
            }
        }

        protected void Button2_ServerClick(object sender, EventArgs e)
        {
            option1.Checked = false;
            option2.Checked = false;
            message.Value = string.Empty;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void option2_ServerChange(object sender, EventArgs e)
        {

        }
    }
}