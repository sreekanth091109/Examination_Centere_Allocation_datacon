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
    public partial class section6 : System.Web.UI.Page
    {
        
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        string texthold=string.Empty;
        protected void rb1_CheckedChanged(object sender, EventArgs e)
        {
            if(rb1.Checked)
            {
                rb2.Checked = false;
            }
        }

        protected void rb2_CheckedChanged(object sender, EventArgs e)
        {
            if(rb2.Checked)
            {
                rb1.Checked = false;
            }
        }

        protected void rb3_CheckedChanged(object sender, EventArgs e)
        {
            if(rb3.Checked)
            {
                rb4.Checked = false;
                rb5.Checked = false;
                texthold = "Railway Station Name";
                transport.Attributes.Add("placeholder", texthold);
            }
        }

        protected void rb4_CheckedChanged(object sender, EventArgs e)
        {
            if(rb4.Checked)
            {
                rb3.Checked = false;
                rb5.Checked = false;
                texthold = "Bus Stand Name";
                transport.Attributes.Add("placeholder", texthold);
            }
        }

        protected void rb5_CheckedChanged(object sender, EventArgs e)
        {
            if(rb5.Checked)
            {
                rb3.Checked = false;
                rb4.Checked = false;
                texthold = "others";
                transport.Attributes.Add("placeholder", texthold);
            }
        }

        protected void Button1_ServerClick(object sender, EventArgs e)
        {
            string script = "document.getElementById('section6').style.backgroundColor = 'green';";
            ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);
            
            //parking checking code
            string parking = string.Empty;
            if (rb1.Checked)
            {
                parking = rb1.Text;
            }
            else if(rb2.Checked)
            {
                parking = rb2.Text;
            }
            else
            {
                parking = string.Empty;
            }

            //Proximity to Transportchecking code
            string ProximitytoTransport = string.Empty;
            if (rb3.Checked)
            {
                ProximitytoTransport = rb3.Text;
            }
            else if (rb4.Checked)
            {
                ProximitytoTransport = rb4.Text;
            }
            else if(rb5.Checked)
            {
                ProximitytoTransport = rb5.Text;
            }
            else
            {
                ProximitytoTransport = string.Empty;
            }
            string center_code = Session["CENT_CODE"].ToString();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "Insert into Accessibility_And_Transport([Parking_Availability], [Proximity_to_Transport], [Name_of_Transport], [Distance], [Cent_Code]) values('" + parking.Trim() + "','" + ProximitytoTransport.Trim() + "','" + transport.Text.Trim() + "','" + distance1.Text.Trim() + "','"+ center_code.Trim() + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
     "alert('Accessbility and Transport Saved Successfully...! Please Fill the Section7 form'); window.location.href = 'Section7.aspx';", true);

            }
            else
            {
                Response.Write("<script>alert('Not Saved Accessibility And Transport Information.')</script>");
            }
        }

        protected void Button3_ServerClick(object sender, EventArgs e)
        {
            transport.Text = string.Empty;
            distance1.Text = string.Empty;
            rb1.Checked = false;
            rb2.Checked = false;
            rb3.Checked = false;
            rb4.Checked = false;
            rb5.Checked = false;
        }

        protected void ParkingAccessibility_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = rb1.Checked || rb2.Checked;
        }

        protected void TransportValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid= rb3.Checked || rb4.Checked || rb5.Checked;
        }

        protected void Button4_ServerClick(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            string CENT = Session["CENT_CODE"].ToString();
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Accessibility_And_Transport WHERE CENT_CODE='" + CENT + "'", sqlcon);
            SqlDataReader sqlreader = cmd.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(sqlreader);
            sqlreader.Close();
            foreach (DataRow dr in DT.Rows)
            {
                string parking = dr["Parking_Availability"].ToString().Trim();
                string pr_Transport = dr["Proximity_to_Transport"].ToString().Trim();
                transport.Text = dr["Name_of_Transport"].ToString().Trim();
                distance1.Text = dr["Distance"].ToString().Trim();
                if (parking == "Available")
                {
                    rb1.Checked = true;
                }
                else if (parking == "Not Available")
                {
                    rb2.Checked = true;
                }
                if (pr_Transport == "Near by Railway Station")
                {
                    rb3.Checked = true;
                }
                else if (pr_Transport == " Near by Bus Stand")
                {
                    rb4.Checked = true;
                }
                else if (pr_Transport == "Others")
                {
                    rb5.Checked = true;
                }
            }

            sqlcon.Close();
        }


    }
}
  