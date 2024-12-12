using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;


namespace Examination_Centere_Allocation
{
    public partial class section4 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            string script = "document.getElementById('section4').style.backgroundColor = 'green';";
            ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);
            string center_code = Session["CENT_CODE"].ToString();


            //Electricity Selection code
            string selected_electricity = string.Empty;
            if (available.Checked)
            {
                selected_electricity = "Available";
            }
            else if (notAvailable.Checked)
            {
                selected_electricity = "Not Available";
            }
            else if (others.Checked)
            {
                selected_electricity = "Others";
            }
            else
            {
                selected_electricity = "";
            }

            //Backup Power Supply section code
            string backup_section = string.Empty;
            if (available1.Checked)
            {
                backup_section = "Available";
            }
            else if (notAvailable1.Checked)
            {
                backup_section = "Not Available";
            }
            else if (others1.Checked)
            {
                backup_section = "Others";
            }
            else
            {
                backup_section = "";
            }

            //Drinking Water and Toilets Section code
            string drinking_water = string.Empty;
            if (available2.Checked)
            {
                drinking_water = "Available";
            }
            else if (notAvailable2.Checked)
            {
                drinking_water = "Not Available";
            }
            else if (others2.Checked)
            {
                drinking_water = "Others";
            }
            else
            {
                drinking_water = "";
            }

            //Toilets Section code
            string toilet = string.Empty;
            if (female.Checked)
            {
                toilet = "Female";
            }
            else if (male.Checked)
            {
                toilet = "Male";
            }
            else
            {
                toilet = "";
            }

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "Insert into FACILITIES([ELECTRICITY], [DRINKING_WATER], [BACKUP_POWER_SUPPLY], [TOILETS_AVAILABILITY], [Cent_Code]) values('" + selected_electricity.Trim() + "','" + backup_section.Trim() + "','" + drinking_water.Trim() + "','" + toilet.Trim() + "','" + center_code.Trim() + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
     "alert('Facilities Information Saved Successfully...! Please Fill the Section5 form'); window.location.href = 'Section5.aspx';", true);

            }
            else
            {
                Response.Write("<script>alert('Not Saved Facilities Information.')</script>");
            }

        }

        protected void Button2_ServerClick(object sender, EventArgs e)
        {
            available.Checked = false;
            notAvailable.Checked = false;
            others.Checked = false;
            available1.Checked = false;
            notAvailable1.Checked = false;
            others1.Checked = false;
            available2.Checked = false;
            notAvailable2.Checked = false;
            others2.Checked = false;
            female.Checked = false;
            male.Checked = false;
        }

        protected void Button4_ServerClick(object sender, EventArgs e)
        {

            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            string query = "SELECT  * FROM FACILITIES where CENT_CODE='" + centcode + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                
               
                string electricity = dt.Rows[0]["ELECTRICITY"].ToString();
                string dw = dt.Rows[0]["DRINKING_WATER"].ToString();
                string bps = dt.Rows[0]["BACKUP_POWER_SUPPLY"].ToString();

                string toilets = dt.Rows[0]["TOILETS_AVAILABILITY"].ToString();
                string EcOthers = dt.Rows[0]["EC_Others"].ToString();
                string bpsothers = dt.Rows[0]["BPS_Others"].ToString();
                string dwothers = dt.Rows[0]["DW_Others"].ToString();

               if(electricity== "Available")
                {
                    available.Checked = true;
                }
               else if(electricity == "Not Available")
                {
                    notAvailable.Checked = true;
                }
                else 
                {
                    others.Checked = true;
                    otherDetails.Visible = true;
                }


                if (bps == "Available")
                {
                    available1.Checked = true;
                }
                else if (bps == "Not Available")
                {
                    notAvailable1.Checked = true;
                }
                else
                {
                    others1.Checked = true;
                    otherDetails1.Visible = true;
                }


                if (dw == "Available")
                {
                    available2.Checked = true;
                }
                else if (dw == "Not Available")
                {
                    notAvailable2.Checked = true;
                }
                else
                {
                    others2.Checked = true;
                    otherDetails2.Visible = true;
                }


                if (toilets == "Female")
                {
                    female.Checked = true;
                }
                else if (toilets == "Male")
                {
                    male.Checked = true;
                }
            }

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}


