using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Examination_Centere_Allocation
{
    public partial class section3 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            eca masterPage = this.Master as eca;
            if (masterPage != null)
            {
                masterPage.Mastersecpr1.Text = "Progress: 45%";
                masterPage.Mastersecpr2.Style.Add("width", "50%");
                masterPage.Mastersecpr2.Style.Add("background-color", "DodgerBlue");
                masterPage.Mastersecpr3.Style.Add("width", "50%");
                masterPage.Mastersecpr3.Style.Add("background-color", "DodgerBlue");
                masterPage.Masterbutton2.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton2.ForeColor = System.Drawing.Color.Black;
                masterPage.Masterbutton1.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton1.ForeColor = System.Drawing.Color.Black;
                masterPage.Masterbutton3.BackColor = System.Drawing.Color.LawnGreen;
                masterPage.Masterbutton3.ForeColor = System.Drawing.Color.Black;
                masterPage.MasterMessageLabel1.Text = "Completed";
                masterPage.MasterMessageLabel1.ForeColor = System.Drawing.Color.LawnGreen;
                masterPage.MasterMessageLabel2.Text = "Completed";
                masterPage.MasterMessageLabel2.ForeColor = System.Drawing.Color.LawnGreen;
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
            else
            {
                btnSave.Disabled = false;
            }
        }
        private void loaddata()
        {
            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            con.Open();
            string query = "SELECT  * FROM Building_Information where CENT_CODE='" + centcode + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string boundarywall = dt.Rows[0]["Number_of_Floors"].ToString();
                string accessbility = dt.Rows[0]["Accessibility"].ToString();
                string otherprovisions = dt.Rows[0]["Other_Provisions"].ToString();
                string applicable = dt.Rows[0]["Applicable"].ToString();
                string otherprovisions1 = dt.Rows[0]["Other_Provisions"].ToString();
                // string centernameAddress = dt.Rows[0]["Exam_Center_Name_Address"].ToString();
                string[] values = applicable.ToString().Split(',').Select(value => value.Trim()).ToArray();


                // Convert the array to a List
                List<string> valuesList = values.ToList(); // Convert the array to a List<string>
                if (applicable != "")
                {
                    CheckBoxList1.Visible = true;
                    // Loop through the List (valuesList)
                    for (int i = 0; i < valuesList.Count; i++)
                    {
                        // Access each item in the List by index
                        string item = valuesList[i].Trim();


                        if (valuesList[i] == "Ramps")
                        {

                            foreach (ListItem item1 in CheckBoxList1.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Ramps")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                            }
                        }
                        else if (valuesList[i] == "Elevators")
                        {
                            foreach (ListItem item1 in CheckBoxList1.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Elevators")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                            }
                        }
                        else if (valuesList[i] == "Physical Helpers")
                        {
                            foreach (ListItem item1 in CheckBoxList1.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Physical Helpers")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                            }
                        }
                        else if (valuesList[i] == "Wheel Chairs")
                        {
                            foreach (ListItem item1 in CheckBoxList1.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Wheel Chairs")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                            }
                        }
                        else if (valuesList[i] == "Parking")
                        {
                            foreach (ListItem item1 in CheckBoxList1.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Parking")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                            }
                        }
                        else if (valuesList[i] == "Other Provisions")
                        {
                            foreach (ListItem item1 in CheckBoxList1.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Other Provisions")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                            }
                            access1.Visible = true;
                            access1.Text = otherprovisions1;
                        }
                    }

                    if (!string.IsNullOrEmpty(boundarywall))
                    {
                        floor1.SelectedValue = boundarywall; // Set the selected value
                    }

                    if (accessbility == "Applicable")
                    {
                        RadioButton1.Checked = true;
                    }

                    else
                    {
                        RadioButton2.Checked = true;
                    }

                    access1.Text = otherprovisions;

                }

                //gvDynamic.DataSource = dt;
                //gvDynamic.DataBind();
                //gvDynamic.Rows[e.RowIndex].Cells[0].Value.ToString();
                //gvDynamic.Columns
            }

            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbapplicable.Visible = false;


            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    string selectedItem = item.Text;
                    access1.Visible = false;
                    if (selectedItem == "Other Provisions")
                    {
                        access1.Visible = true;
                    }
                }
            }

        }
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lbaplicable.Visible = false;
            if (RadioButton1.Checked)
            {
                CheckBoxList1.Visible = true;
                RadioButton2.Checked = false;
            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lbaplicable.Visible = false;
            if (RadioButton2.Checked)
            {
                CheckBoxList1.Visible = false;
                RadioButton1.Checked = false;
                access1.Visible = false;
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if ((RadioButton1.Checked == true || RadioButton2.Checked == true) && CheckBoxList1.Text != "")
            {
                string script = "document.getElementById('section3').style.backgroundColor = 'green';";
                ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);

                string centcode = Session["CENT_CODE"].ToString();

                //selected accessibility items
                List<string> accessibility = new List<string>();
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        accessibility.Add(CheckBoxList1.Items[i].Text);
                    }

                }
                string accessibilityString = string.Join(", ", accessibility);
                string ACCESBILITY = "";
                if (RadioButton1.Checked == true)
                {
                    ACCESBILITY = RadioButton1.Text;
                }
                else
                {
                    ACCESBILITY = RadioButton2.Text;
                }

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "";
                string id = Session["flg"]?.ToString() ?? string.Empty;
                if (id != "btnsave")
                {
                    string id1 = "update";


                    Session["flg2"] = id1;

                    Session["flg2"] = id1;
                    query = "Insert into Building_Information  values('" + floor1.SelectedItem.ToString().Trim() + "','" + ACCESBILITY.Trim() + "','" + access1.Text.Trim() + "','" + centcode.Trim() + "','" + accessibilityString.Trim() + "')";

                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = cmd.ExecuteNonQuery();

                    Response.Redirect("section4.aspx");
                }
                else
                {
                    query = "update Building_Information set Number_of_Floors='" + floor1.SelectedItem.ToString().Trim() + "',Accessibility='" + ACCESBILITY.Trim() + "',Other_Provisions='" + access1.Text.Trim() + "',Applicable='"+ accessibilityString + "' where Cent_Code='"+ centcode.Trim() + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = cmd.ExecuteNonQuery();

               

                    Session["flg"] = "btnsave";
                    string id2 = "";
                    Session["flg3"] = id2;

                    Response.Redirect("section4.aspx");
                }
             
               
            }
            else
            {
                if (RadioButton1.Checked == true)
                {
                    lbaplicable.Visible = false;
                    if (CheckBoxList1.Text == "")
                    {
                        lbapplicable.Visible = true;
                    }
                }
                else if (RadioButton2.Checked == true)
                {
                    lbaplicable.Visible = false;
                }
                else if (RadioButton1.Checked == false || RadioButton2.Checked == false)
                {
                    lbaplicable.Visible = true;

                }

            }
        }

        protected void Button2_ServerClick(object sender, EventArgs e)
        {

            floor1.SelectedIndex = -1;
            access1.Text = string.Empty;
            RadioButton1.Checked = false;
            if (RadioButton1.Checked == false)
            {
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    item.Selected = false;  // Unchecks each item in the CheckBoxList
                }
                CheckBoxList1.Visible = false;
            }
            RadioButton2.Checked = false;
        }

        protected void Button3_ServerClick(object sender, EventArgs e)
        {
            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            con.Open();
            string query = "SELECT  * FROM Building_Information where CENT_CODE='" + centcode + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string boundarywall = dt.Rows[0]["Number_of_Floors"].ToString();
                string accessbility = dt.Rows[0]["Accessibility"].ToString();
                string otherprovisions = dt.Rows[0]["Other_Provisions"].ToString();
                string applicable = dt.Rows[0]["Applicable"].ToString();
                string otherprovisions1 = dt.Rows[0]["Other_Provisions"].ToString();
                // string centernameAddress = dt.Rows[0]["Exam_Center_Name_Address"].ToString();
                string[] values = applicable.ToString().Split(',').Select(value => value.Trim()).ToArray();


                // Convert the array to a List
                List<string> valuesList = values.ToList(); // Convert the array to a List<string>
                if (applicable != "")
                {
                    CheckBoxList1.Visible = true;
                    // Loop through the List (valuesList)
                    for (int i = 0; i < valuesList.Count; i++)
                    {
                        // Access each item in the List by index
                        string item = valuesList[i].Trim();


                        if (valuesList[i] == "Ramps")
                        {

                            foreach (ListItem item1 in CheckBoxList1.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Ramps")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                            }
                        }
                        else if (valuesList[i] == "Elevators")
                        {
                            foreach (ListItem item1 in CheckBoxList1.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Elevators")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                            }
                        }
                        else if (valuesList[i] == "Physical Helpers")
                        {
                            foreach (ListItem item1 in CheckBoxList1.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Physical Helpers")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                            }
                        }
                        else if (valuesList[i] == "Wheel Chairs")
                        {
                            foreach (ListItem item1 in CheckBoxList1.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Wheel Chairs")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                            }
                        }
                        else if (valuesList[i] == "Parking")
                        {
                            foreach (ListItem item1 in CheckBoxList1.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Parking")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                            }
                        }
                        else if (valuesList[i] == "Other Provisions")
                        {
                            foreach (ListItem item1 in CheckBoxList1.Items)
                            {
                                // Check if the item's value matches the condition
                                if (item1.Value == "Other Provisions")
                                {
                                    item1.Selected = true;  // Check the checkbox
                                }
                            }
                            access1.Visible = true;
                            access1.Text = otherprovisions1;
                        }
                    }

                    if (!string.IsNullOrEmpty(boundarywall))
                    {
                        floor1.SelectedValue = boundarywall; // Set the selected value
                    }

                    if (accessbility == "Applicable")
                    {
                        RadioButton1.Checked = true;
                    }

                    else
                    {
                        RadioButton2.Checked = true;
                    }

                    access1.Text = otherprovisions;

                }

                //gvDynamic.DataSource = dt;
                //gvDynamic.DataBind();
                //gvDynamic.Rows[e.RowIndex].Cells[0].Value.ToString();
                //gvDynamic.Columns
            }

            cmd.ExecuteNonQuery();
            con.Close();
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