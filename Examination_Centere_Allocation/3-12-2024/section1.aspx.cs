using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Examination_Centere_Allocation
{
    public partial class section1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                LoadDistrict();
            }
        }
        private void centcde()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select case when max(CENT_CODE) is null then 0 else  max(CENT_CODE) end as CENT_CODE from Basic_Details where District='" + ddldistrict.SelectedItem + "'  ", con);
            cmd.CommandTimeout = 0;
            string val1 = cmd.ExecuteScalar().ToString();
            if (val1 == "0")
                val1 = ddldistrict.SelectedItem.ToString().Substring(0, 2) + "00";
            int centcode = Convert.ToInt32(val1) + 1;
            Session["CENT_CODE"] = centcode;
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {

            var lblSection1 = (Label)this.Master.FindControl("sec1");

            if (lblSection1 != null)
            {
                lblSection1.Text = "Updated Section 4"; // Modify the text of Section 4
            }
            //var ecaHome = (PlaceHolder)this.Master.FindControl("eca_master");
            //Button btnSeaction2 = (Button)ecaHome.FindControl("btnseaction2");

            //if (btnSeaction2 != null)
            //{
            //    // Enable the button
            //    btnSeaction2.Enabled = true;
            //}

            //btnSaveContent.Enabled = true;
            //btnseaction3.Enabled = false;
            //btnseaction4.Enabled = true;
            //btnseaction5.Enabled = true;
            //btnseaction6.Enabled = true;
            //btnseaction7.Enabled = true;
            string status = "";
            //var firstTwoChars = dd.substring(0, 2); // Extracts characters from index 0 to index 1
            //console.log(firstTwoChars);
            centcde();
            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            string Query = "Insert into Basic_Details values('" + ddldistrict.SelectedItem.Text.Trim() + "','" + ddldivison.SelectedItem.Text.Trim() + "','" + textgpsaddress.Text.Trim() + "','" + tblecn.Text.Trim() + "','" + txtadrdess.Text.Trim() + "','" + centcode.Trim() + "','" + status.Trim() + "')";
            SqlCommand cmd = new SqlCommand(Query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
      "alert('Basic Details Saved Successfully...! Please Fill the Section2 form'); window.location.href = 'Section2.aspx';", true);

            }
            con.Close();


            string script = "document.getElementById('section1').style.backgroundColor = 'green';";
            ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);
        }
        private void LoadDistrict()
        {
            ddldistrict.Items.Insert(0, "Select District");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            string Query = "SELECT District_Code + '-' + District_Name FROM DISTRICT_MASTER";
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ddldistrict.Items.Add(dr[0].ToString());
                }
            }
            con.Close();

        }
        private void loaddivision()
        {
            ddldivison.Items.Clear();
            ddldistrict.Items.Insert(0, "Select Division");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            string Query = "select b.divison_code+'-'+b.DIVISON_NAME from DISTRICT_MASTER a inner join DIVISON_MASTER b on a.DIVISON_CODE=b.DIVISON_CODE where district_code='" + ddldistrict.SelectedItem.ToString().Substring(0, 2) + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ddldivison.Items.Add(dr[0].ToString());
                }
            }
            con.Close();
        }
        protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
        {

            loaddivision();

        }

        protected void Button2_ServerClick(object sender, EventArgs e)
        {
            ddldivison.Items.Clear();
            ddldistrict.Items.Clear();
            txtadrdess.Text = "";
            textgpsaddress.Text = "";
            tblecn.Text = "";

        }

        protected void Button3_ServerClick(object sender, EventArgs e)
        {

            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            string query = "SELECT  * FROM Basic_Details where CENT_CODE='" + centcode + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string district = dt.Rows[0]["District"].ToString();
                //ddldivison.SelectedItem.Text = dt.Rows[0]["Division"].ToString();
                loaddivision();
                string gpslocation = dt.Rows[0]["Gps_Location"].ToString();
                string centername = dt.Rows[0]["Exam_Center_Name"].ToString();
                string centernameAddress = dt.Rows[0]["Exam_Center_Name_Address"].ToString();

                if (!string.IsNullOrEmpty(district))
                {
                    ddldistrict.SelectedValue = district; // Set the selected value
                }
                //if (!string.IsNullOrEmpty(division1))
                //{
                //    ddldivison.SelectedValue = division1; // Set the selected value
                //}
                tblecn.Text = centername;
                textgpsaddress.Text = gpslocation;
                txtadrdess.Text = centernameAddress;
            }

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}