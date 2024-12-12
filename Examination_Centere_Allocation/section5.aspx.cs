using System;
using System.Collections;
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
            eca masterPage = this.Master as eca;
            if (masterPage != null)
            {
                masterPage.Mastersecpr1.Text = "Progress: 65%";
                masterPage.Mastersecpr2.Style.Add("width", "50%");
                masterPage.Mastersecpr2.Style.Add("background-color", "DodgerBlue");
                masterPage.Mastersecpr3.Style.Add("width", "50%");
                masterPage.Mastersecpr3.Style.Add("background-color", "DodgerBlue");
                masterPage.Mastersecpr4.Style.Add("width", "50%");
                masterPage.Mastersecpr4.Style.Add("background-color", "DodgerBlue");
                masterPage.Mastersecpr5.Style.Add("width", "50%");
                masterPage.Mastersecpr5.Style.Add("background-color", "DodgerBlue");
                masterPage.Masterbutton2.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton2.ForeColor = System.Drawing.Color.Black;
                masterPage.Masterbutton1.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton1.ForeColor = System.Drawing.Color.Black;
                masterPage.Masterbutton3.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton3.ForeColor = System.Drawing.Color.Black;
                masterPage.Masterbutton4.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton4.ForeColor = System.Drawing.Color.Black;
                masterPage.Masterbutton5.BackColor = System.Drawing.Color.DodgerBlue;
                masterPage.Masterbutton5.ForeColor = System.Drawing.Color.Black;
                masterPage.MasterMessageLabel1.Text = "Completed";
                masterPage.MasterMessageLabel1.ForeColor = System.Drawing.Color.LawnGreen;
                masterPage.MasterMessageLabel2.Text = "Completed";
                masterPage.MasterMessageLabel2.ForeColor = System.Drawing.Color.LawnGreen;
                masterPage.MasterMessageLabel3.Text = "Completed";
                masterPage.MasterMessageLabel3.ForeColor = System.Drawing.Color.LawnGreen;
                masterPage.MasterMessageLabel4.Text = "Complete";
                masterPage.MasterMessageLabel4.ForeColor = System.Drawing.Color.LawnGreen;
            }
            string id = Session["flg"]?.ToString() ?? string.Empty;
            if (id == "btnsave")
            {

                string id1 = Session["flg2"]?.ToString() ?? string.Empty;
                string id2 = Session["flg3"]?.ToString() ?? string.Empty;

                if (id1 != "update")
                {


                }

                else if (id2 == "update1")
                {

                }
                else
                {
                    loaddata();
                    id2 = "update1";
                    Session["flg3"] = id2;
                }

            }

        }
        private void loaddata()
        {
            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
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
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string cctv_instal = string.Empty;
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if (option1.Checked == true || option2.Checked == true)
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



                string id = Session["flg"]?.ToString() ?? string.Empty;
                string query = "";
                if (id != "btnsave")
                {
                    string id1 = "update";

                    Session["flg2"] = id1;

                    query = "Insert into SECURITY_SURVEILLANCE([CCTV_INSTALLED], [Cent_Code], [SECURITY_PERSONNEL]) values ('" + selectedValue.Trim() + "','" + center_code.Trim() + "','" + message.Value.Trim() + "')";


                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        Response.Redirect("section6.aspx");

                    }
                }
                else
                {
                    query = "Update SECURITY_SURVEILLANCE set CCTV_INSTALLED='" + selectedValue.Trim() + "',SECURITY_PERSONNEL='" + message.Value.Trim() + "' where CENT_CODE='" + center_code.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    int count = cmd.ExecuteNonQuery();
                  
                        Session["flg"] = "btnsave";
                        string id2 = "";
                        Session["flg3"] = id2;
                        Response.Redirect("section6.aspx");

                  
                }
                sqlcon.Close();
            }
            else
            {
                options.Visible = true;
            }

        }

        protected void Button3_ServerClick(object sender, EventArgs e)
        {
            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
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

        protected void yes_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Preview1.aspx");
        }

        protected void no_ServerClick(object sender, EventArgs e)
        {

        }
    }
}