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
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void exrb1_CheckedChanged(object sender, EventArgs e)
        {
            if (exrb1.Checked)
            {
                etext1.Visible = true;
                exrb2.Checked = false;
                string reason = "Reason...";
                etext1.Attributes.Add("placeholder", reason);
            }
        }

        protected void exrb2_CheckedChanged(object sender, EventArgs e)
        {
            if (exrb2.Checked)
            {
                etext1.Visible = false;
                exrb1.Checked = false;
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            string script = "document.getElementById('section7').style.backgroundColor = 'green';";
            ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);

            //emergency exit radio button code
            string emg_exit;

            if (exrb1.Checked)
            {
                emg_exit=exrb1.Text;
            }
            else if(exrb2.Checked)
            {
                emg_exit = exrb2.Text;
            }
            else
            {
                emg_exit = string.Empty;
            }
            string center_code = Session["CENT_CODE"].ToString();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "Insert into Additional_Information values('" + ddlbwall.SelectedItem.ToString().Trim() + "','" + emg_exit.Trim() + "','" + etext1.Text.Trim() + "','"+ center_code.Trim() + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                Response.Write("<script>alert('Saved Additional Information Process Completed...! Do You Want To Preview Click Preview Button.')</script>");
            }
            else
            {
                Response.Write("<script>alert('Not Saved Additional Information.')</script>");
            }
        }

        protected void Button2_ServerClick(object sender, EventArgs e)
        {
            exrb1.Checked = false;
            exrb2.Checked = false;
            ddlbwall.SelectedIndex = -1;
            etext1.Text=string.Empty;
        }

        protected void cvExitValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = exrb1.Checked || exrb2.Checked;
        }

        protected void Button3_ServerClick(object sender, EventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
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
    }


            //string centcode = Session["CENT_CODE"].ToString();
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
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
  