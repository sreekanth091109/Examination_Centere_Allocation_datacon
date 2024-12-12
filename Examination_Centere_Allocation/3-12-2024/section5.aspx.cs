using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examination_Centere_Allocation
{
    public partial class section5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        string cctv_instal = string.Empty;
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {

            string center_code = Session["CENT_CODE"].ToString();
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
            string query = "Insert into SECURITY_SURVEILLANCE([CCTV_INSTALLED], [Cent_Code], [SECURITY_PERSONNEL]) values ('" + selectedValue.Trim() + "','" + center_code.Trim() + "','" + message.Value.Trim() + "')";
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
    "alert('Security and Surveillance Saved Successfully...! Please Fill the Section6 form'); window.location.href = 'Section6.aspx';", true);

            }
            else
            {
                Response.Write("<script>alert('Not Saved Security And Surveillance.')</script>");
            }
            sqlcon.Close();

        }

        protected void Button3_ServerClick(object sender, EventArgs e)
        {
            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            string query = "SELECT  * FROM Security_Surveillance where CENT_CODE='" + centcode + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string cctv = dt.Rows[0]["CCTV_INSTALLED"].ToString();
                string secpersonal = dt.Rows[0]["SECURITY_PERSONNEL"].ToString();

                if (cctv == "Yes")
                {
                    option1.Checked = true;
                }
                else
                {
                    option2.Checked = true;
                }
                message.InnerText = secpersonal;
            }

        }

        protected void Button2_ServerClick(object sender, EventArgs e)
        {
            option1.Checked = false;
            option2.Checked = false;
            message.Value = string.Empty;
        }

       
    }
}