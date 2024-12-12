using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;

namespace Examination_Centere_Allocation
{
    public partial class section2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                eca masterPage = this.Master as eca;
                if (masterPage != null)
                {
                    masterPage.Mastersecpr1.Text = "Progress: 15%";
                    masterPage.Mastersecpr2.Style.Add("width", "50%");
                    masterPage.Mastersecpr2.Style.Add("background-color", "DodgerBlue");

                    masterPage.Mastersecpr2.Style["background-color"] = "DodgerBlue";
                    masterPage.Masterbutton2.BackColor = System.Drawing.Color.DodgerBlue;
                    masterPage.Masterbutton2.ForeColor = System.Drawing.Color.Black;
                    masterPage.Masterbutton1.BackColor = System.Drawing.Color.LawnGreen;
                    masterPage.Masterbutton1.ForeColor = System.Drawing.Color.Black;
                    masterPage.MasterMessageLabel1.Text = "Completed";
                    masterPage.MasterMessageLabel1.ForeColor = System.Drawing.Color.LawnGreen;
                    masterPage.MasterMessageLabel1.Font.Bold = true;
                    masterPage.MasterMessageLabel6.Font.Size = FontUnit.Large;
                }

                //txtroom.Visible = false;
            }
            gvDynamic.Visible = true;
            string id = Session["flg"]?.ToString() ?? string.Empty;
            if (id == "btnsave")
            {
               
                loaddata();
            }
            else
            {
                btnSave.Disabled = false;
            }
        }
        private void loaddata()
        {
            gdv1.Visible = true;
            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            con.Open();
            string query = "SELECT  * FROM Physical_Attributes where CENT_CODE='" + centcode + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string boundarywall = dt.Rows[0]["Boundary_wall"].ToString();
                string boundarywallStatus = dt.Rows[0]["Boundary_Wall_Status"].ToString();
                string textarea = dt.Rows[0]["Text_Area"].ToString();
                string noofrooms = dt.Rows[0]["No_Rooms"].ToString();
                string capacityofeachroom = dt.Rows[0]["Capacity_Of_Room"].ToString();
                // string centernameAddress = dt.Rows[0]["Exam_Center_Name_Address"].ToString();

                capacity.Text = capacityofeachroom;

                if (!string.IsNullOrEmpty(boundarywall))
                {
                    ddlbwall.SelectedValue = boundarywall; // Set the selected value
                }
                if (boundarywallStatus == "Open from One Side")
                {
                    rdbone.Checked = true;
                }
                else if (boundarywallStatus == "Open from Two Side")
                {
                    rdbtwo.Checked = true;
                }
                else if (boundarywallStatus == "Open from Three Side")
                {
                    rdbthree.Checked = true;
                }
                else
                {
                    rdbfour.Checked = true;
                }
                tblarea.Text = textarea;
                txtnorooms.Text = noofrooms;

                //gvDynamic.DataSource = dt;
                //gvDynamic.DataBind();

                LoadGridData();
                //gvDynamic.Rows[e.RowIndex].Cells[0].Value.ToString();
                //gvDynamic.Columns
            }

            cmd.ExecuteNonQuery();
            con.Close();
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if (rdbone.Checked == true || rdbtwo.Checked == true || rdbthree.Checked == true || rdbfour.Checked == true)
            {
                string status = "";

                string bounderstatus = "";
                if (rdbone.Checked == true)
                {
                    bounderstatus = rdbone.Text;
                }
                else if (rdbtwo.Checked == true)
                {
                    bounderstatus = rdbtwo.Text;
                }
                else if (rdbthree.Checked == true)
                {
                    bounderstatus = rdbthree.Text;
                }
                else
                {
                    bounderstatus = rdbfour.Text;
                }

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                con.Open();
                //string Query = "(Boundary_Wall,Boundary_Wall_Status,Text_Area,No_Rooms)values('" + ddlbwall.SelectedItem.Text + "','" + bounderstatus + "'," + tblarea.Text + "','" + txtnorooms.Text + "','" + status + "')";
                //SqlCommand cmd = new SqlCommand(Query, con);
                //int i = cmd.ExecuteNonQuery();
                //con.Close();

                int successFlag = 0; // To track if any row insertion is successful
                int z = 0;
                foreach (GridViewRow row in gvDynamic.Rows)
                {
                    z++;
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string centcode = Session["CENT_CODE"].ToString();


                        // Get the form data
                        string bounderywall = ddlbwall.SelectedItem.Text;
                        string bounderywallstatus = bounderstatus;  // Assuming bounderstatus is already set earlier
                        string textarea = tblarea.Text;  // Assuming tblarea is a TextBox or similar control
                        string noofrooms = txtnorooms.Text; // Assuming txtnorooms is a TextBox

                        // Get values from TextBox controls within the GridView row
                        string noOfDesks = ((TextBox)row.FindControl("txtnoofdesks")).Text;
                        string roomNo = ((TextBox)row.FindControl("txtroomno")).Text;
                        string capacity = ((TextBox)row.FindControl("txtcapacityroomno")).Text;
                        string sittingAllocation = ((TextBox)row.FindControl("txtsittingallocation")).Text;
                        string noOfBenches = ((TextBox)row.FindControl("txtnoofbenches")).Text;


                        lbgrivalue.Visible = false;
                        string query = "INSERT INTO Physical_Attributes (Boundary_Wall, Boundary_Wall_Status, Text_Area, No_Rooms, Room_No, Capacity_Of_Room, Sitting_Allocation, No_Of_Desks, No_Of_Benches,CENT_CODE, Is_Complete) " +
                                  "VALUES (@BoundaryWall, @BoundaryWallStatus, @TextArea, @NoOfRooms, @RoomNo, @Capacity, @SittingAllocation, @NoOfDesks, @NoOfBenches,@CENT_CODE, @Status)";

                        // Prepare the SQL command
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@BoundaryWall", bounderywall.Trim());
                        cmd.Parameters.AddWithValue("@BoundaryWallStatus", bounderywallstatus.Trim());
                        cmd.Parameters.AddWithValue("@TextArea", textarea.Trim());
                        cmd.Parameters.AddWithValue("@NoOfRooms", noofrooms.Trim());
                        cmd.Parameters.AddWithValue("@RoomNo", roomNo.Trim());
                        cmd.Parameters.AddWithValue("@Capacity", capacity.Trim());
                        cmd.Parameters.AddWithValue("@SittingAllocation", sittingAllocation.Trim());
                        cmd.Parameters.AddWithValue("@NoOfDesks", noOfDesks.Trim());
                        cmd.Parameters.AddWithValue("@NoOfBenches", noOfBenches.Trim());
                        cmd.Parameters.AddWithValue("@Status", status.Trim()); // Assuming status is defined earlier
                        cmd.Parameters.AddWithValue("@CENT_CODE", centcode.Trim()); // Assuming status is defined earlier
                                                                                    // Execute the command and check if any rows were inserted
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            successFlag = 1; // If any row insertion is successful, set flag to 1
                        }



                    }
                }

                // After the loop ends, show the success message if any insertions were successful
                if (successFlag == 1)
                {
                    Response.Redirect("section3.aspx");

                    string completed = "Completed";
                    Session["Completed"] = completed;

                }
                else
                {
                    // If no insertions were successful, you can show a different message
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No data was saved. Please try again.')", true);
                }

                con.Close();

                string script1 = "document.getElementById('section2').style.backgroundColor = 'green';";
                ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script1, true);
            }
            else
            {
                lbselect.Visible = true;
            }

        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            // Get the number of rows entered by the user
            int numberOfRows = 0;
            if (int.TryParse(txtnorooms.Text, out numberOfRows) && numberOfRows > 0)
            {
                // Create a DataTable to store rows temporarily
                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("Age");

                // Add empty rows to the DataTable based on the number entered by the user
                for (int i = 0; i < numberOfRows; i++)
                {
                    dt.Rows.Add(dt.NewRow());
                }

                // Bind the DataTable to GridView
                gvDynamic.DataSource = dt;
                gvDynamic.DataBind();

                // Show the GridView and Save Button
                gvDynamic.Visible = true;
                // btnSave.Visible = true;
            }
            else
            {
                // If the input is invalid, show an error message
                //  lblError.Text = "Please enter a valid number greater than 0.";
            }
        }

        protected void gvDynamic_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Check if the row is a data row (not header or footer)
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // Set the Serial Number (S.No.) based on the row index (starting from 1)
                    e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString(); // e.RowIndex is zero-based
                }

                // Find the TextBox controls in each row
                TextBox roomNumber = (TextBox)e.Row.FindControl("txtroomno");
                TextBox capasityofRooms = (TextBox)e.Row.FindControl("txtcapacityroomno");
                TextBox sittingExamination = (TextBox)e.Row.FindControl("txtsittingallocation");
                TextBox noofDesks = (TextBox)e.Row.FindControl("txtnoofdesks");
                TextBox nooftables = (TextBox)e.Row.FindControl("txtnoofbenches");
                //TextBox txtAge = (TextBox)e.Row.FindControl("txtAge");

                // Optional: Set default values for testing purposes (if needed)
                roomNumber.Text = string.Empty;
                capasityofRooms.Text = string.Empty;
                lblgrid.Text = "Please fill in the information for all" + " " + txtnorooms.Text + " " + "rooms in the table below";
                lblgrid.Visible = true;
            }

            string id = Session["buttonid"]?.ToString() ?? string.Empty;

            if (id == "Button3")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // Get the values from the DataRow
                    string roomNo = DataBinder.Eval(e.Row.DataItem, "Room_No").ToString();
                    string capacity = DataBinder.Eval(e.Row.DataItem, "Capacity_Of_Room").ToString();
                    string sittingAlloc = DataBinder.Eval(e.Row.DataItem, "Sitting_Allocation").ToString();
                    string noOfDesks = DataBinder.Eval(e.Row.DataItem, "No_Of_Desks").ToString();
                    string noOfBenches = DataBinder.Eval(e.Row.DataItem, "No_Of_Benches").ToString();

                    // Find the controls in the row and set their values
                    TextBox txtRoomNo = (TextBox)e.Row.FindControl("txtroomno");
                    TextBox txtCapacity = (TextBox)e.Row.FindControl("txtcapacityroomno");
                    TextBox txtSittingAlloc = (TextBox)e.Row.FindControl("txtsittingallocation");
                    TextBox txtNoOfDesks = (TextBox)e.Row.FindControl("txtnoofdesks");
                    TextBox txtNoOfBenches = (TextBox)e.Row.FindControl("txtnoofbenches");

                    // Assign values to the TextBox controls
                    if (txtRoomNo != null) txtRoomNo.Text = roomNo;
                    if (txtCapacity != null) txtCapacity.Text = capacity;
                    if (txtSittingAlloc != null) txtSittingAlloc.Text = sittingAlloc;
                    if (txtNoOfDesks != null) txtNoOfDesks.Text = noOfDesks;
                    if (txtNoOfBenches != null) txtNoOfBenches.Text = noOfBenches;
                }
            }
        }

        protected void txtnorooms_TextChanged(object sender, EventArgs e)
        {


            Grid();

            // Show the GridView and Save Button
            //  gvDynamic.Visible = true;
            // btnSave.Visible = true;


        }

        private void Grid()
        {
            int numberOfRows = 0;
            if (int.TryParse(txtnorooms.Text, out numberOfRows) && numberOfRows > 0)
            {
                if (ddlall.Text == "All")
                {
                    ViewState["RoomDataTable"] = null;
                }
                if (ddlall.Text == "Single")
                {
                    ViewState["RoomDataTable"] = null;
                }
                // txtroom.Visible = false;
                gvDynamic.Visible = true;
                gdv1.Visible = true;
                // Create a DataTable to store rows temporarily
                DataTable dt;
                if (ViewState["RoomDataTable"] != null)
                {
                    dt = (DataTable)ViewState["RoomDataTable"];
                }
                else
                {
                    dt = new DataTable();
                    dt.Columns.Add("RoomNumber", typeof(string));
                    dt.Columns.Add("Capacity", typeof(string));
                    dt.Columns.Add("SittingAllocation", typeof(string));
                    dt.Columns.Add("NumberOfDesks", typeof(string));
                    dt.Columns.Add("NumberOfBenches", typeof(string));
                }

                for (int i = 1; i <= numberOfRows; i++)
                {
                    DataRow row = dt.NewRow();
                    // Auto-generate the serial number
                    row["RoomNumber"] = i;
                    int captcity = Convert.ToInt32(capacity.Text);
                    row["Capacity"] = captcity;

                    int siitig = i;
                    int allocation = i * captcity;

                    row["SittingAllocation"] = i + "-" + allocation;
                    if (i > 1)
                    {
                        row["SittingAllocation"] = allocation - captcity + 1 + "-" + allocation;
                    }

                    // int numberofdeskd = captcity / 2;
                    //int numberofben = captcity / 2;

                    row["NumberOfDesks"] = desks.Text;
                    row["NumberOfBenches"] = tables.Text;
                    if (ddlall.Text == "All")
                    {
                        dt.Rows.Add(row);
                        ViewState["RoomDataTable"] = null;
                    }
                    else if (ddlall.Text == "Single")
                    {
                        if (Convert.ToInt32(Ddlselect.Text) == i)
                        {
                            dt.Rows.Add(row);
                            ViewState["RoomDataTable"] = null;
                        }
                    }
                    else if (ddlall.Text == "same")
                    {
                        int selectedRoom;
                        if (int.TryParse(Ddlselect.Text, out selectedRoom) && selectedRoom == i)
                        {
                            // Check if the row is already added
                            if (!IsRowAlreadyAdded(dt, i))
                            {
                                row = dt.NewRow();
                                row["RoomNumber"] = i;

                                captcity = Convert.ToInt32(capacity.Text);
                                row["Capacity"] = captcity;

                                allocation = i * captcity;
                                row["SittingAllocation"] = i + "-" + allocation;
                                if (i > 1)
                                {
                                    row["SittingAllocation"] = allocation - captcity + 1 + "-" + allocation;
                                }

                                row["NumberOfDesks"] = desks.Text;
                                row["NumberOfBenches"] = tables.Text;

                                dt.Rows.Add(row);
                                ViewState["RoomDataTable"] = dt;
                            }
                        }
                    }
                }

                // Save the updated DataTable in ViewState


                // Bind the DataTable to a GridView or other UI element
                gvDynamic.DataSource = dt;
                gvDynamic.DataBind();

                int z = 0;
                int sum = 0;
                foreach (GridViewRow row in gvDynamic.Rows)
                {
                    z++;
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox txtRoomNumber = (TextBox)row.FindControl("txtroomno");
                        TextBox txtCapacity = (TextBox)row.FindControl("txtcapacityroomno");
                        TextBox txtSittingAllocation = (TextBox)row.FindControl("txtsittingallocation");
                        TextBox txtNumberOfDesks = (TextBox)row.FindControl("txtnoofdesks");
                        TextBox txtNumberOfBenches = (TextBox)row.FindControl("txtnoofbenches");
                        int number = z - 1;
                        string room = dt.Rows[number]["RoomNumber"].ToString();
                        string capacities = dt.Rows[number]["Capacity"].ToString();
                        string Sittingallocation = dt.Rows[number]["SittingAllocation"].ToString();
                        string noofdesks = dt.Rows[number]["NumberOfDesks"].ToString();
                        string NoofBenches = dt.Rows[number]["NumberOfBenches"].ToString();
                        txtRoomNumber.Text = room;
                        txtCapacity.Text = capacities;
                        txtSittingAllocation.Text = Sittingallocation;
                        txtNumberOfDesks.Text = noofdesks;
                        txtNumberOfBenches.Text = NoofBenches;

                        int totalcount = Convert.ToInt32(txtCapacity.Text);

                        sum = sum + totalcount;

                        // Similarly, set or manipulate other controls
                    }
                   
                }


                // Show the GridView and Save Button
                //  gvDynamic.Visible = true;
                // btnSave.Visible = true;
            }
            else
            {

                // txtroom.Visible = true;
                gvDynamic.Visible = false;
                gdv1.Visible = false;
                // If the input is invalid, show an error message
                //  lblError.Text = "Please enter a valid number greater than 0.";
            }
        }

        protected void Button2_ServerClick(object sender, EventArgs e)
        {
            rdbone.Checked = false;
            rdbtwo.Checked = false;
            rdbthree.Checked = false;
            rdbfour.Checked = false;
            txtnorooms.Text = "";
            tblarea.Text = "";
            gvDynamic.Visible = false;
            ddlbwall.SelectedIndex = 0;
        }
        private void LoadGridData()
        {
            string centcode = Session["CENT_CODE"].ToString();
            // SQL Query to fetch the data from your table
            string query = "SELECT Room_No, Capacity_Of_Room, Sitting_Allocation, No_Of_Desks, No_Of_Benches FROM Physical_Attributes WHERE CENT_CODE = @CENT_CODE";

            // Create a connection to the database
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                // Open the connection
                con.Open();

                // Create the command to execute the query
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CENT_CODE", centcode);

                    // Use SqlDataAdapter to fetch the data into a DataTable
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind the data to the GridView
                    gvDynamic.DataSource = dt;
                    gvDynamic.DataBind();
                }

                // Close the connection
                con.Close();
            }
        }
        private bool IsRowAlreadyAdded(DataTable dt, int roomNumber)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["RoomNumber"].ToString() == roomNumber.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        protected void Button3_ServerClick(object sender, EventArgs e)
        {
            //string clickedButtonId = ((Button)sender).ClientID;
            // Session["buttonid"] = clickedButtonId;
            gdv1.Visible = true;
            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            con.Open();
            string query = "SELECT  * FROM Physical_Attributes where CENT_CODE='" + centcode + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string boundarywall = dt.Rows[0]["Boundary_wall"].ToString();
                string boundarywallStatus = dt.Rows[0]["Boundary_Wall_Status"].ToString();
                string textarea = dt.Rows[0]["Text_Area"].ToString();
                string noofrooms = dt.Rows[0]["No_Rooms"].ToString();
                // string centernameAddress = dt.Rows[0]["Exam_Center_Name_Address"].ToString();

                if (!string.IsNullOrEmpty(boundarywall))
                {
                    ddlbwall.SelectedValue = boundarywall; // Set the selected value
                }
                if (boundarywallStatus == "Open from One Side")
                {
                    rdbone.Checked = true;
                }
                else if (boundarywallStatus == "Open from Two Side")
                {
                    rdbtwo.Checked = true;
                }
                else if (boundarywallStatus == "Open from Three Side")
                {
                    rdbthree.Checked = true;
                }
                else
                {
                    rdbfour.Checked = true;
                }
                tblarea.Text = textarea;
                txtnorooms.Text = noofrooms;

                //gvDynamic.DataSource = dt;
                //gvDynamic.DataBind();

                LoadGridData();
                //gvDynamic.Rows[e.RowIndex].Cells[0].Value.ToString();
                //gvDynamic.Columns
            }

            cmd.ExecuteNonQuery();
            con.Close();
        }
        protected void capacity_TextChanged(object sender, EventArgs e)
        {
           

        }

        protected void ddlall_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlall.Text == "All")
            {
                Ddlselect.Visible = false;
                avRooms.Visible = false;
                int count;
                Ddlselect.Items.Clear(); // Clear existing items

                // Check if the input is a valid integer
                if (int.TryParse(txtnorooms.Text, out count) && count > 0)
                {
                    for (int i = 1; i <= count; i++)
                    {
                        Ddlselect.Items.Add(new ListItem(i.ToString()));
                    }
                }
            }
            else if (ddlall.Text == "same")
            {

                avRooms.Visible = true;
                Ddlselect.Visible = true;

            }
            else if (ddlall.Text == "Single")
            {
                avRooms.Visible = true;
                Ddlselect.Visible = true;

            }
        }

        protected void Ddlselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid();
            int count;
            Ddlselect.Items.Clear(); // Clear existing items

            // Check if the input is a valid integer
            if (int.TryParse(txtnorooms.Text, out count) && count > 0)
            {
                for (int i = 1; i <= count; i++)
                {
                    Ddlselect.Items.Add(new ListItem(i.ToString()));
                }
            }
            Ddlselect.Items.Insert(0, new ListItem("Select", ""));
        }
        protected void btnaddAdd_Click(object sender, EventArgs e)
        {
            Grid();

        }
        protected void rdbone_CheckedChanged(object sender, EventArgs e)
        {
            lbselect.Visible = false;
            lbboundery.Text = rdbone.Text;
            lbboundery.Visible = true;
        }

        protected void rdbtwo_CheckedChanged(object sender, EventArgs e)
        {
            lbselect.Visible = false;
            lbboundery.Text = rdbtwo.Text;
            lbboundery.Visible = true;
        }

        protected void rdbthree_CheckedChanged(object sender, EventArgs e)
        {
            lbselect.Visible = false;
            lbboundery.Text = rdbthree.Text;
            lbboundery.Visible = true;
        }

        protected void rdbfour_CheckedChanged(object sender, EventArgs e)
        {
            lbselect.Visible = false;
            lbboundery.Text = rdbfour.Text;
            lbboundery.Visible = true;
        }
        protected void ValidateInput(object source, ServerValidateEventArgs args)
        {
            string input = args.Value;

            // Check if the input is not empty and matches the regex for digits
            bool isRequired = !string.IsNullOrWhiteSpace(input);
            bool isDigitsOnly = System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d+$");

            args.IsValid = isRequired && isDigitsOnly;
        }

        protected void txtnorooms_TextChanged1(object sender, EventArgs e)
        {
            if (capacity.Text != "")
            {
                Grid();
            }
        }

        protected void txtroomno_TextChanged(object sender, EventArgs e)
        {
            TextBox currentTextBox = (TextBox)sender;

            // Logic for moving focus to the next control
            GridViewRow currentRow = (GridViewRow)currentTextBox.NamingContainer;

            TextBox txtRoomNumber = (TextBox)currentRow.FindControl("txtroomno");
            TextBox txtCapacity = (TextBox)currentRow.FindControl("txtcapacityroomno");
            TextBox txtSittingAllocation = (TextBox)currentRow.FindControl("txtsittingallocation");
            TextBox txtNumberOfDesks = (TextBox)currentRow.FindControl("txtnoofdesks");
            TextBox txtNumberOfBenches = (TextBox)currentRow.FindControl("txtnoofbenches");

            string room = txtRoomNumber.Text;
            string capcity = txtCapacity.Text;
            string SittingAllocation = txtSittingAllocation.Text;
            string NumberOfDesks = txtNumberOfDesks.Text;
            string numberofbenches = txtNumberOfBenches.Text;

            int count = gvDynamic.Rows.Count;
            TextBox currentTextBox1 = (TextBox)sender;

            // Get the parent GridViewRow of the current TextBox

            GridViewRow currentRows = (GridViewRow)currentTextBox.NamingContainer;
            int currentRowIndex;
            for (int i = Convert.ToInt32(room); i <= count; i++)
            {


                currentRowIndex = i - 1;
                int previousRowIndex = currentRowIndex - 1;
                if (currentRowIndex == 0)
                {
                    previousRowIndex = currentRowIndex;
                }



                GridViewRow currentrowvalue = gvDynamic.Rows[currentRowIndex];
                GridViewRow previousRow = gvDynamic.Rows[previousRowIndex];

                // Find the TextBox in the previous row by its ID
                TextBox txtalocatio = (TextBox)currentrowvalue.FindControl("txtsittingallocation");
                TextBox desk = (TextBox)currentrowvalue.FindControl("txtnoofdesks");
                TextBox Benches = (TextBox)currentrowvalue.FindControl("txtnoofbenches");
                TextBox capacitynos = (TextBox)currentrowvalue.FindControl("txtcapacityroomno");


                TextBox txtPreviousRoomNumber = (TextBox)previousRow.FindControl("txtsittingallocation");
                TextBox capacity = (TextBox)previousRow.FindControl("txtcapacityroomno");
                TextBox capacit1 = (TextBox)currentrowvalue.FindControl("txtcapacityroomno");
                int finalcap = Convert.ToInt32(capacit1.Text);

                string priviousallocation = txtPreviousRoomNumber.Text;
                string Priviouscapacitt = capacity.Text;
                //   GridViewRow currentRow2 = (GridViewRow)previousRowIndex.NamingContainer;
                string maxcapacity = capcity;
                //string SittingAllocations = SittingAllocation;


                string[] finalalocation = priviousallocation.Split('-');
                string sittingallocation = finalalocation[1];
                string capaciti = "";
                int sumtwo = 0;
                int siiting = 0;
                if (currentRowIndex == 0)
                {
                    sittingallocation = finalalocation[0];

                    capaciti = capcity;
                    sumtwo = Convert.ToInt32(capaciti);
                    siiting = Convert.ToInt32(sittingallocation);
                }
                else
                {


                    capaciti = capcity;
                    sumtwo = Convert.ToInt32(sittingallocation) + finalcap;
                    siiting = Convert.ToInt32(sittingallocation) + 1;
                }
                string finalvalue = siiting + "-" + sumtwo;
                txtalocatio.Text = finalvalue;

                int desks = Convert.ToInt32(capacitynos.Text);
                int finaldesk = desks / 2;
                desk.Text = finaldesk.ToString();
                Benches.Text = finaldesk.ToString();

            }
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

