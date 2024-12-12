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
using Newtonsoft.Json.Linq;


namespace Examination_Centere_Allocation
{
    public partial class section4 : System.Web.UI.Page
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
                masterPage.Masterbutton3.BackColor = System.Drawing.Color.DodgerBlue;
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
           
        }

        private void loaddata()
        {
            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
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
                string[] values = electricity.ToString().Split(',').Select(value => value.Trim()).ToArray();
                List<string> valuesList = values.ToList();
                //List<string> valuesList = values.ToString(); // Convert the array to a List<string>
                if (electricity != "")
                {
                    electricity1.Visible = true;
                    //foreach (ListItem item1 in valuesList.ToList())
                    for (int i = 0; i < valuesList.Count; i++)
                    {

                        string item = valuesList[i].Trim();
                        {
                            if (valuesList[i] == "Available")
                            {

                                foreach (ListItem item1 in electricity1.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Available")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                    }
                                }
                            }
                            else if (valuesList[i] == "Not Available")
                            {

                                foreach (ListItem item1 in electricity1.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Not Available")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                    }
                                }
                            }
                            else if (valuesList[i] == "Others")
                            {

                                foreach (ListItem item1 in electricity1.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Others")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                        electricity2.Visible = true;
                                        electricity2.Text = EcOthers;
                                    }
                                }
                            }

                        }
                    }
                }
                string[] values1 = dw.ToString().Split(',').Select(value => value.Trim()).ToArray();
                List<string> valuesList1 = values1.ToList();
                //List<string> valuesList = values.ToString(); // Convert the array to a List<string>
                if (dw != "")
                {
                    check_water.Visible = true;
                    //foreach (ListItem item1 in valuesList.ToList())
                    for (int i = 0; i < valuesList1.Count; i++)
                    {

                        string item = valuesList1[i].Trim();
                        {
                            if (valuesList1[i] == "Available")
                            {

                                foreach (ListItem item1 in check_water.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Available")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                    }
                                }
                            }
                            else if (valuesList1[i] == "Not Available")
                            {

                                foreach (ListItem item1 in check_water.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Not Available")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                    }
                                }
                            }
                            else if (valuesList1[i] == "Others")
                            {

                                foreach (ListItem item1 in check_water.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Others")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                        txtwater.Visible = true;
                                        txtwater.Text = dwothers;
                                    }
                                }
                            }

                        }

                    }
                }

                string[] values3 = bps.ToString().Split(',').Select(value => value.Trim()).ToArray();
                List<string> valuesList2 = values3.ToList();
                //List<string> valuesList = values.ToString(); // Convert the array to a List<string>
                if (bps != "")
                {
                    power.Visible = true;
                    //foreach (ListItem item1 in valuesList.ToList())
                    for (int i = 0; i < valuesList2.Count; i++)
                    {

                        string item = valuesList2[i].Trim();
                        {
                            if (valuesList2[i] == "Available")
                            {

                                foreach (ListItem item1 in power.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Available")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                    }
                                }
                            }
                            else if (valuesList2[i] == "Not Available")
                            {

                                foreach (ListItem item1 in power.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Not Available")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                    }
                                }
                            }
                            else if (valuesList2[i] == "Others")
                            {

                                foreach (ListItem item1 in power.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Others")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                        power1.Visible = true;
                                        power1.Text = bpsothers;
                                    }
                                }
                            }

                        }

                    }
                }
                string[] values4 = toilets.ToString().Split(',').Select(value => value.Trim()).ToArray();
                List<string> valuesList3 = values4.ToList();
                //List<string> valuesList = values.ToString(); // Convert the array to a List<string>
                if (toilets != "")
                {
                    check_toilet.Visible = true;
                    //foreach (ListItem item1 in valuesList.ToList())
                    for (int i = 0; i < valuesList3.Count; i++)
                    {

                        string item = valuesList3[i].Trim();
                        {

                            if (valuesList3[i] == "Female")
                            {

                                foreach (ListItem item1 in check_toilet.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Female")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                    }
                                }
                            }
                            else if (valuesList3[i] == "Male")
                            {

                                foreach (ListItem item1 in check_toilet.Items)
                                {
                                    if (item1.Value == "Male")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                    }


                                }
                            }

                        }

                    }

                }
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if (electricity1.Text != "" && power.Text != "" && check_water.Text != "" && check_toilet.Text != "")
            {
                string script = "document.getElementById('section4').style.backgroundColor = 'green';";
                ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);
                string center_code = Session["CENT_CODE"].ToString();

                List<string> accessibility = new List<string>();
                for (int i = 0; i < check_toilet.Items.Count; i++)
                {
                    if (check_toilet.Items[i].Selected)
                    {
                        accessibility.Add(check_toilet.Items[i].Text);
                    }

                }
                string toilretstring = string.Join(", ", accessibility);

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                
                string id = Session["flg"]?.ToString() ?? string.Empty;
                string query = "";

                if (id != "btnsave")
                {
                    string id1 = "update";


                    Session["flg2"] = id1;

                    Session["flg2"] = id1;
                    query = "Insert into FACILITIES([ELECTRICITY], [DRINKING_WATER], [BACKUP_POWER_SUPPLY], [TOILETS_AVAILABILITY], [Cent_Code],[EC_Others], [BPS_Others], [DW_Others]) values('" + electricity1.Text + "','" + check_water.Text + "','" + power.Text + "','" + toilretstring.Trim() + "','" + center_code.Trim() + "','" + electricity2.Text + "','" + power1.Text + "','" + txtwater.Text + "')";

                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = cmd.ExecuteNonQuery();
                    Response.Redirect("section5.aspx");
                }
                else
                {
                    query = "update FACILITIES set ELECTRICITY='" + electricity1.Text + "',DRINKING_WATER='" + check_water.Text + "',BACKUP_POWER_SUPPLY='" + power.Text + "',TOILETS_AVAILABILITY='" + toilretstring.Trim() + "',EC_Others='" + electricity2.Text + "',BPS_Others='" + power1.Text + "',DW_Others='" + txtwater.Text + "' where Cent_Code='" + center_code.Trim() + "'  ";

                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = cmd.ExecuteNonQuery();

                   

                    Session["flg"] = "btnsave";
                    string id2 = "";
                    Session["flg3"] = id2;
                    Response.Redirect("section5.aspx");
                }
               

            

            }
            else
            {
                if (electricity1.Text != "")
                {

                }
                else
                {
                    lbelecteric.Visible = true;
                }
                if (power.Text != "")
                {

                }
                else
                {
                    lbpower.Visible = true;

                }
                if (check_water.Text != "")
                {

                }
                else
                {
                    lbwater.Visible = true;
                }
                if (check_toilet.Text != "")
                {
                    lbtoilet.Visible = false;
                }
                else
                {
                    lbtoilet.Visible = true;
                }
            }
        }

        protected void Button2_ServerClick(object sender, EventArgs e)
        {
            electricity1.SelectedIndex = -1;
            power.SelectedIndex = -1;
            check_water.SelectedIndex = -1;
            check_toilet.SelectedIndex = -1;
            txtwater.Text = string.Empty;
            power1.Text = string.Empty;
            electricity2.Text = string.Empty;
        }

        protected void Button4_ServerClick(object sender, EventArgs e)
        {

            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
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
                string[] values = electricity.ToString().Split(',').Select(value => value.Trim()).ToArray();
                List<string> valuesList = values.ToList();
                //List<string> valuesList = values.ToString(); // Convert the array to a List<string>
                if (electricity != "")
                {
                    electricity1.Visible = true;
                    //foreach (ListItem item1 in valuesList.ToList())
                    for (int i = 0; i < valuesList.Count; i++)
                    {

                        string item = valuesList[i].Trim();
                        {
                            if (valuesList[i] == "Available")
                            {

                                foreach (ListItem item1 in electricity1.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Available")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                    }
                                }
                            }
                            else if (valuesList[i] == "Not Available")
                            {

                                foreach (ListItem item1 in electricity1.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Not Available")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                    }
                                }
                            }
                            else if (valuesList[i] == "Others")
                            {

                                foreach (ListItem item1 in electricity1.Items)
                                {
                                    // Check if the item's value matches the condition
                                    if (item1.Value == "Others")
                                    {
                                        item1.Selected = true;  // Check the checkbox
                                        electricity2.Visible = true;
                                        electricity2.Text = EcOthers;
                                    }
                                }
                            }

                        }

                    }
                    string[] values1 = dw.ToString().Split(',').Select(value => value.Trim()).ToArray();
                    List<string> valuesList1 = values1.ToList();
                    //List<string> valuesList = values.ToString(); // Convert the array to a List<string>
                    if (dw != "")
                    {
                        check_water.Visible = true;
                        //foreach (ListItem item1 in valuesList.ToList())
                        for (int i = 0; i < valuesList1.Count; i++)
                        {

                            string item = valuesList1[i].Trim();
                            {
                                if (valuesList1[i] == "Available")
                                {

                                    foreach (ListItem item1 in check_water.Items)
                                    {
                                        // Check if the item's value matches the condition
                                        if (item1.Value == "Available")
                                        {
                                            item1.Selected = true;  // Check the checkbox
                                        }
                                    }
                                }
                                else if (valuesList1[i] == "Not Available")
                                {

                                    foreach (ListItem item1 in check_water.Items)
                                    {
                                        // Check if the item's value matches the condition
                                        if (item1.Value == "Not Available")
                                        {
                                            item1.Selected = true;  // Check the checkbox
                                        }
                                    }
                                }
                                else if (valuesList1[i] == "Others")
                                {

                                    foreach (ListItem item1 in check_water.Items)
                                    {
                                        // Check if the item's value matches the condition
                                        if (item1.Value == "Others")
                                        {
                                            item1.Selected = true;  // Check the checkbox
                                            txtwater.Visible = true;
                                            txtwater.Text = EcOthers;
                                        }
                                    }
                                }

                            }

                        }


                        string[] values3 = bps.ToString().Split(',').Select(value => value.Trim()).ToArray();
                        List<string> valuesList2 = values3.ToList();
                        //List<string> valuesList = values.ToString(); // Convert the array to a List<string>
                        if (bps != "")
                        {
                            power.Visible = true;
                            //foreach (ListItem item1 in valuesList.ToList())
                            for (int i = 0; i < valuesList2.Count; i++)
                            {

                                string item = valuesList2[i].Trim();
                                {
                                    if (valuesList2[i] == "Available")
                                    {

                                        foreach (ListItem item1 in power.Items)
                                        {
                                            // Check if the item's value matches the condition
                                            if (item1.Value == "Available")
                                            {
                                                item1.Selected = true;  // Check the checkbox
                                            }
                                        }
                                    }
                                    else if (valuesList2[i] == "Not Available")
                                    {

                                        foreach (ListItem item1 in power.Items)
                                        {
                                            // Check if the item's value matches the condition
                                            if (item1.Value == "Not Available")
                                            {
                                                item1.Selected = true;  // Check the checkbox
                                            }
                                        }
                                    }
                                    else if (valuesList2[i] == "Others")
                                    {

                                        foreach (ListItem item1 in power.Items)
                                        {
                                            // Check if the item's value matches the condition
                                            if (item1.Value == "Others")
                                            {
                                                item1.Selected = true;  // Check the checkbox
                                                power1.Visible = true;
                                                power1.Text = EcOthers;
                                            }
                                        }
                                    }

                                }

                            }
                        }
                        string[] values4 = toilets.ToString().Split(',').Select(value => value.Trim()).ToArray();
                        List<string> valuesList3 = values4.ToList();
                        //List<string> valuesList = values.ToString(); // Convert the array to a List<string>
                        if (toilets != "")
                        {
                            check_toilet.Visible = true;
                            //foreach (ListItem item1 in valuesList.ToList())
                            for (int i = 0; i < valuesList3.Count; i++)
                            {

                                string item = valuesList3[i].Trim();
                                {

                                    if (valuesList3[i] == "Female")
                                    {

                                        foreach (ListItem item1 in check_toilet.Items)
                                        {
                                            // Check if the item's value matches the condition
                                            if (item1.Value == "Female")
                                            {
                                                item1.Selected = true;  // Check the checkbox
                                            }
                                        }
                                    }
                                    else if (valuesList3[i] == "Male")
                                    {

                                        foreach (ListItem item1 in check_toilet.Items)
                                        {
                                            if (item1.Value == "Male")
                                            {
                                                item1.Selected = true;  // Check the checkbox
                                            }


                                        }
                                    }


                                }

                            }
                        }
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }

        }

        protected void power_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbpower.Visible = false;
            foreach (ListItem item in power.Items)
            {
                if (item.Selected)
                {
                    string selectedItem = item.Text;
                    power1.Visible = false;
                    if (selectedItem == "Others")
                    {
                        power1.Visible = true;
                    }
                }
            }
        }

        protected void electricity1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbelecteric.Visible = false;
            foreach (ListItem item in electricity1.Items)
            {
                if (item.Selected)
                {
                    string selectedItem = item.Text;
                    electricity2.Visible = false;
                    if (selectedItem == "Others")
                    {
                        electricity2.Visible = true;
                    }
                }
            }
        }

        protected void check_water_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbwater.Visible = false;
            foreach (ListItem item in check_water.Items)
            {
                if (item.Selected)
                {
                    string selectedItem = item.Text;
                    txtwater.Visible = false;
                    if (selectedItem == "Others")
                    {
                        txtwater.Visible = true;
                    }
                }
            }
        }

        protected void check_toilet_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbtoilet.Visible = false;
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

