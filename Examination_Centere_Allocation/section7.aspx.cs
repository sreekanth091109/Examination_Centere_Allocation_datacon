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
    public partial class section7 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            eca masterPage = this.Master as eca;
            if (masterPage != null)
            {
                masterPage.Mastersecpr1.Text = "Progress: 85%";
                masterPage.Mastersecpr2.Style.Add("width", "50%");
                masterPage.Mastersecpr2.Style.Add("background-color", "DodgerBlue");
                masterPage.Mastersecpr3.Style.Add("width", "50%");
                masterPage.Mastersecpr3.Style.Add("background-color", "DodgerBlue");
                masterPage.Mastersecpr4.Style.Add("width", "50%");
                masterPage.Mastersecpr4.Style.Add("background-color", "DodgerBlue");
                masterPage.Mastersecpr5.Style.Add("width", "50%");
                masterPage.Mastersecpr5.Style.Add("background-color", "DodgerBlue");
                masterPage.Mastersecpr6.Style.Add("width", "50%");
                masterPage.Mastersecpr6.Style.Add("background-color", "DodgerBlue");
                masterPage.Mastersecpr7.Style.Add("width", "50%");
                masterPage.Mastersecpr7.Style.Add("background-color", "DodgerBlue");
                masterPage.Mastersecpr8.Style.Add("width", "50%");
                masterPage.Mastersecpr8.Style.Add("background-color", "DodgerBlue");
                masterPage.Masterbutton2.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton2.ForeColor = System.Drawing.Color.Black;
                masterPage.Masterbutton1.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton1.ForeColor = System.Drawing.Color.Black;
                masterPage.Masterbutton3.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton3.ForeColor = System.Drawing.Color.Black;
                masterPage.Masterbutton4.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton4.ForeColor = System.Drawing.Color.Black;
                masterPage.Masterbutton5.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton5.ForeColor = System.Drawing.Color.Black;
                masterPage.Masterbutton6.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton6.ForeColor = System.Drawing.Color.Black;
                masterPage.Masterbutton7.BackColor = System.Drawing.Color.DodgerBlue;
                masterPage.Masterbutton7.ForeColor = System.Drawing.Color.Black;
                masterPage.MasterMessageLabel1.Text = "Completed";
                masterPage.MasterMessageLabel1.ForeColor = System.Drawing.Color.LawnGreen;
                masterPage.MasterMessageLabel2.Text = "Completed";
                masterPage.MasterMessageLabel2.ForeColor = System.Drawing.Color.LawnGreen;
                masterPage.MasterMessageLabel3.Text = "Completed";
                masterPage.MasterMessageLabel3.ForeColor = System.Drawing.Color.LawnGreen;
                masterPage.MasterMessageLabel4.Text = "Completed";
                masterPage.MasterMessageLabel4.ForeColor = System.Drawing.Color.LawnGreen;
                masterPage.MasterMessageLabel5.Text = "Completed";
                masterPage.MasterMessageLabel5.ForeColor = System.Drawing.Color.LawnGreen;
                masterPage.MasterMessageLabel6.Text = "Completed";
                masterPage.MasterMessageLabel6.ForeColor = System.Drawing.Color.LawnGreen;
                masterPage.Mastersecpr1.Text = "Progress: 85%";
                masterPage.Mastersecpr8.Style.Add("width", "50%");
                masterPage.Mastersecpr8.Style.Add("background-color", "lightgray");
               
                
                string id3 = Session["flg2"]?.ToString() ?? string.Empty;
                string id2 = Session["flg3"]?.ToString() ?? string.Empty;

                if (id3 != "update")
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

            string id = Session["Button"]?.ToString() ?? string.Empty;
            if (id == "ButtonSave")
            {
                eca masterPage1 = this.Master as eca;
                if (masterPage1 != null)
                {
                    masterPage1.Mastersecpr1.Text = "Progress: 100%";
                    masterPage1.Mastersecpr8.Style.Add("width", "50%");
                    masterPage1.Mastersecpr8.Style.Add("background-color", "DodgerBlue");
                    masterPage1.MasterMessageLabel7.Text = "Completed";
                    masterPage1.MasterMessageLabel7.ForeColor = System.Drawing.Color.GreenYellow;
                    masterPage1.Mastersecpr8.Style.Add("width", "50%");
                    masterPage1.Mastersecpr8.Style.Add("background-color", "DodgerBlue");
                }
            }
            string id1 = Session["flg"]?.ToString() ?? string.Empty;
            if (id1 == "btnsave")
            {
                 id1 = Session["flg2"]?.ToString() ?? string.Empty;
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
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string CENT = Session["CENT_CODE"].ToString();
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Additional_Information WHERE CENT_CODE='" + CENT + "'", sqlcon);
            SqlDataReader sqlreader = cmd.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(sqlreader);
            sqlreader.Close();
            foreach (DataRow dr in DT.Rows)
            {
               string selectedValue= dr["Examination_Hall_Type"].ToString();

                ddlbwall.SelectedValue = selectedValue;
                string emer_exits = dr["Emergency_Exits"].ToString().Trim();
                string reson = dr["Emergency_Exits_Reason"].ToString().Trim();
                string no_exits= dr["No_Exits"].ToString().Trim();
                if (emer_exits == "Available")
                {
                    exrb1.Checked = true;
                    etext1.Visible = true;
                    etext1.Text = reson;
                    emergency.Visible = true;
                    txtemergency.Visible = true;
                    txtemergency.Text = no_exits;
                }
                else if (emer_exits == "Not Available")
                {
                    exrb2.Checked = true;
                    etext1.Visible = false;
                }
               
            }

            sqlcon.Close();
        }
   
        protected void exrb1_CheckedChanged(object sender, EventArgs e)
        {
            if (exrb1.Checked)
            {
                RequiredFieldValidator1.Visible = true;
                // lbemergency.Visible = false;
                etext1.Visible = true;
                exrb2.Checked = false;
                emergency.Visible = true;
                txtemergency.Visible = true;
                string reason = "Reason...";
                etext1.Attributes.Add("placeholder", reason);
            }
        }

        protected void exrb2_CheckedChanged(object sender, EventArgs e)
        {
            RequiredFieldValidator1.Visible = false;
            if (exrb2.Checked)
            {
                //lbemergency.Visible = true;
                etext1.Visible = false;
                exrb1.Checked = false;
                emergency.Visible = false;
                txtemergency.Visible = false;
            }
        }
        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            //if ((!IsDigitsOnly(txtemergency.Text) && txtemergency.Visible == true) || txtemergency.Text == "")
            //{
            //    // lbdigits.Visible = true;
            //}
            string id = "ButtonSave";
            Session["Button"] = id;


            if (exrb1.Checked == true || exrb2.Checked == true)
            {
                // lbdigits.Visible = false;
                //lbemergency1.Visible = false;
                string script = "document.getElementById('section7').style.backgroundColor = 'green';";
                ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);

                //emergency exit radio button code
                string emg_exit;

                if (exrb1.Checked)
                {
                    emg_exit = exrb1.Text;
                }
                else if (exrb2.Checked)
                {
                    emg_exit = exrb2.Text;
                }
                else
                {
                    emg_exit = string.Empty;
                }
                string center_code = Session["CENT_CODE"].ToString();

                string value1 = txtemergency.Text;
                string emgerency = exrb1.Text;
                string no_exits= value1;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();


                string id5 = Session["flg"]?.ToString() ?? string.Empty;
                string query = "";
                if (id5 != "btnsave")
                {
                    string id1 = "update";

                    Session["flg2"] = id1;
                     query = "Insert into Additional_Information values('" + ddlbwall.SelectedItem.ToString().Trim() + "','" + emgerency.Trim() + "','" + etext1.Text.Trim() + "','" + center_code.Trim() + "','" + no_exits + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = cmd.ExecuteNonQuery();
                }
                else
                {
                    query = "Update Additional_Information set Examination_Hall_Type='" + ddlbwall.SelectedItem.ToString().Trim() + "',Emergency_Exits='" + emgerency.Trim() + "',Emergency_Exits_Reason='" + etext1.Text.Trim() + "',No_Exits='" + no_exits + "' where CENT_CODE='" + center_code.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = cmd.ExecuteNonQuery();
                    Session["flg"] = "btnsave";
                    string id2 = "";
                    Session["flg3"] = id2;
                }
            }
            else
            {
                // lbemergency.Visible = true;
            }
        }

        protected void Button2_ServerClick(object sender, EventArgs e)
        {
            exrb1.Checked = false;
            exrb2.Checked = false;
            ddlbwall.SelectedIndex = -1;
            etext1.Text = string.Empty;
            txtemergency.Text = string.Empty;
        }

        protected void cvExitValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = exrb1.Checked || exrb2.Checked;
        }

        protected void Button3_ServerClick(object sender, EventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string CENT = Session["CENT_CODE"].ToString();
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Additional_Information WHERE CENT_CODE='" + CENT + "'", sqlcon);
            SqlDataReader sqlreader = cmd.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(sqlreader);
            sqlreader.Close();
            foreach (DataRow dr in DT.Rows)
            {
                ddlbwall.SelectedValue = dr["Examination_Hall_Type"].ToString();
                string emer_exits = dr["Emergency_Exits"].ToString().Trim();
                string reson = dr["Emergency_Exits_Reason"].ToString().Trim();
                if (emer_exits == "Available")
                {
                    exrb1.Checked = true;
                    etext1.Visible = true;
                    etext1.Text = reson;
                }
                else if (emer_exits == "Not Available")
                {
                    exrb2.Checked = true;
                    etext1.Visible = false;
                }
            }

            sqlcon.Close();
        }
        protected void yes_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Preview1.aspx");
        }

        protected void no_ServerClick(object sender, EventArgs e)
        {

        }
    }


    //string centcode = Session["CENT_CODE"].ToString();
    //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
    //con.Open();
    //string query = "SELECT  * FROM Basic_Details where CENT_CODE='" + centcode + "' ";
    //SqlCommand cmd = new SqlCommand(query, con);
    //SqlDataAdapter da = new SqlDataAdapter(cmd);
    //DataTable dt = new DataTable();
    //da.Fill(dt);
    //if (dt.Rows.Count > 0)
    //{

    //    string district = dt.Rows[0]["District"].ToString();
    //    string division = dt.Rows[0]["Division"].ToString();
    //    string gpslocation = dt.Rows[0]["Gps_Location"].ToString();
    //    string centername = dt.Rows[0]["Exam_Center_Name"].ToString();
    //    string centernameAddress = dt.Rows[0]["Exam_Center_Name_Address"].ToString();

    //    if (!string.IsNullOrEmpty(district))
    //    {
    //        ddldistrict.SelectedValue = district; // Set the selected value
    //    }
    //    if (!string.IsNullOrEmpty(division))
    //    {
    //        ddldivison.SelectedValue = division; // Set the selected value
    //    }
    //    tblecn.Text = centername;
    //    textgpsaddress.Text = gpslocation;
    //    txtadrdess.Text = centernameAddress;
    //}

    //cmd.ExecuteNonQuery();
    //con.Close();
}
