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
                masterPage.Masterbutton6.BackColor = System.Drawing.Color.DodgerBlue;
                masterPage.Masterbutton6.ForeColor = System.Drawing.Color.Black;
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
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
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
                string park1 = parking;
                if(park1 !=null)
                {
                    rb1.Checked = true;
                }
                if (rb1.Checked == true)
                {
                    
                   
                    string[] values = parking.ToString().Split(',').Select(value => value.Trim()).ToArray();
           
                    for (int i = 0; i < values.Length; i++)
                    {
                        string Examiners1 = values[i].ToString();
                        if(Examiners1== "Examiners")
                        {
                            foreach (ListItem item1 in checkpark.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Examiners")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                                else
                                {
                                    item1.Selected = true;
                                }
                            }
                        }
                        else if(Examiners1 == "Student")
                        {

                        }
                        else
                        {

                        }
                    }


                    rb1.Checked = true;
                    parking1.Visible = true;
                    checkpark.Visible = true;

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

        string texthold = string.Empty;
        protected void rb1_CheckedChanged(object sender, EventArgs e)
        {
            lbpark.Visible = false;
            if (rb1.Checked)
            {
                rb2.Checked = false;
                parking1.Visible = true;
                checkpark.Visible = true;
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
            if (rb3.Checked == true || rb4.Checked == true || rb5.Checked == true)
            {

            }
            else
            {
                lbproximity.Visible = true;
            }
            if ((rb1.Checked == true || rb2.Checked == true) && (rb3.Checked == true || rb4.Checked == true || rb5.Checked == true))
            {

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

                List<string> prakingspace = new List<string>();
                for (int i = 0; i < checkpark.Items.Count; i++)
                {
                    if (checkpark.Items[i].Selected)
                    {
                        prakingspace.Add(checkpark.Items[i].Text);
                    }

                }
                string parkspace = string.Join(", ", prakingspace);
                parking = string.Join("- ", parkspace);


                string center_code = Session["CENT_CODE"].ToString();

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();


                string id = Session["flg"]?.ToString() ?? string.Empty;
                string query = "";
                if (id != "btnsave")
                {
                    string id1 = "update";

                    Session["flg2"] = id1;

                    query = "Insert into Accessibility_And_Transport([Parking_Availability], [Proximity_to_Transport], [Name_of_Transport], [Distance], [Cent_Code]) values('" + parking.Trim() + "','" + ProximitytoTransport.Trim() + "','" + transport.Text.Trim() + "','" + distance1.Text.Trim() + "','" + center_code.Trim() + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        Response.Redirect("section7.aspx");

                    }
                }
                else
                {
                    query = "Update Accessibility_And_Transport set Parking_Availability='" + parking.Trim() + "',Proximity_to_Transport='" + ProximitytoTransport.Trim() + "',Name_of_Transport='" + transport.Text.Trim() + "',Distance='" + distance1.Text.Trim() + "' where CENT_CODE='" + center_code.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        Session["flg"] = "btnsave";
                        string id2 = "";
                        Session["flg3"] = id2;
                        Response.Redirect("section7.aspx");

                    }
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
            checkpark.SelectedIndex = 0;
        }

        protected void ParkingAccessibility_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = rb1.Checked || rb2.Checked;
        }

        protected void TransportValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = rb3.Checked || rb4.Checked || rb5.Checked;
        }

        protected void Button4_ServerClick(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
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

        protected void yes_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Preview1.aspx");
        }

        protected void no_ServerClick(object sender, EventArgs e)
        {

        }
    }
}
