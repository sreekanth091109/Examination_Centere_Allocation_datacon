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
    public partial class section3 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbapplicable.Visible = false;

            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    string selectedItem = item.Text;
                    if (selectedItem == "Other Provisions")
                    {
                        access1.Visible = true;
                    }
                }
            }
        }
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                CheckBoxList1.Visible = true;
                RadioButton2.Checked = false;
                lbaplicable.Visible = false;
            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked)
            {
                lbaplicable.Visible = false;
                CheckBoxList1.Visible = false;
                RadioButton1.Checked = false;
                access1.Visible = false;
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if ((RadioButton1.Checked == true || RadioButton2.Checked == true) && CheckBoxList1.Text != "")
            {
                lbaplicable.Visible = false;
                lbapplicable.Visible = true;
                string center_code = "1301";
                string script = "document.getElementById('section3').style.backgroundColor = 'green';";
                ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);

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

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "Insert into Building_Information([Number_of_Floors], [Accessibility], [Other_Provisions], [Cent_Code]) values('" + floor1.SelectedItem.ToString() + "','" + accessibilityString + "','" + access1.Text + "','" + center_code + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    Response.Write("<script>alert('Saved Building Information.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Not Saved Building Information.')</script>");
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
        protected void ValidateRadioButtonGroup(object source, ServerValidateEventArgs args)
        {
            // Ensure at least one radio button is selected
            args.IsValid = RadioButton1.Checked || RadioButton2.Checked;
        }
    }
}