using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examination_Centere_Allocation
{
    public partial class section6 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string texthold = string.Empty;
        protected void rb1_CheckedChanged(object sender, EventArgs e)
        {
            lbpark.Visible = false;
            if (rb1.Checked)
            {
                rb2.Checked = false;
            }
        }

        protected void rb2_CheckedChanged(object sender, EventArgs e)
        {
            lbpark.Visible = false;
            if (rb2.Checked)
            {
                rb1.Checked = false;
            }
        }

        protected void rb3_CheckedChanged(object sender, EventArgs e)
        {
            lbproximity.Visible = false;
            if (rb3.Checked)
            {
                rb4.Checked = false;
                rb5.Checked = false;
                texthold = "Railway Station Name";
                transport.Attributes.Add("placeholder", texthold);
            }
        }

        protected void rb4_CheckedChanged(object sender, EventArgs e)
        {
            lbproximity.Visible = false;
            if (rb4.Checked)
            {
                rb3.Checked = false;
                rb5.Checked = false;
                texthold = "Bus Stand Name";
                transport.Attributes.Add("placeholder", texthold);
            }
        }

        protected void rb5_CheckedChanged(object sender, EventArgs e)
        {
            lbproximity.Visible = false;
            if (rb5.Checked)
            {
                rb3.Checked = false;
                rb4.Checked = false;
                texthold = "others";
                transport.Attributes.Add("placeholder", texthold);
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {

            if (rb1.Checked == true || rb2.Checked == true)
            {
                
            }
            else
            {
                lbpark.Visible = true;
            }
            if(rb3.Checked==true || rb4.Checked==true)
            {
                
            }
            else
            {
                lbproximity.Visible = true;
            }
            if ((rb1.Checked == true || rb2.Checked == true) && (rb3.Checked == true || rb4.Checked == true || rb5.Checked == true))
            {


                string center_code = "1301";
                string script = "document.getElementById('section6').style.backgroundColor = 'green';";
                ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);

                //parking checking code
                string parking = string.Empty;
                if (rb1.Checked)
                {
                    parking = rb1.Text;
                }
                else if (rb2.Checked)
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
                else if (rb5.Checked)
                {
                    ProximitytoTransport = rb5.Text;
                }
                else
                {
                    ProximitytoTransport = string.Empty;
                }


                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "Insert into Accessibility_And_Transport([Parking_Availability], [Proximity_to_Transport], [Name_of_Transport], [Distance], [Cent_Code]) values('" + parking + "','" + ProximitytoTransport + "','" + transport.Text + "','" + distance1.Text + "','" + center_code + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    Response.Write("<script>alert('Saved Accessibility And Transport Information.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Not Saved Accessibility And Transport Information.')</script>");
                }

            }

        }

        protected void Button2_ServerClick(object sender, EventArgs e)
        {
            transport.Text = string.Empty;
            distance1.Text = string.Empty;
            rb1.Checked = false;
            rb2.Checked = false;
            rb3.Checked = false;
            rb4.Checked = false;
            rb5.Checked = false;
        }
    }
}