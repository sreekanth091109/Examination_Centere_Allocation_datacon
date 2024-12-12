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

namespace Examination_Centere_Allocation
{
    public partial class section2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Grid();
            }
            gvDynamic.Visible = true;
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            string status = "";

            string bounderstatus = "";
            if (rdbone.Checked == true)
            {
                bounderstatus = rdbone.Text;
            }
            else if(rdbtwo.Checked==true)
            {
                bounderstatus = rdbtwo.Text;
            }
            else if(rdbthree.Checked==true)
            {
                bounderstatus = rdbthree.Text;
            }
            else
            {
                bounderstatus = rdbfour.Text;
            }

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            //string Query = "(Boundary_Wall,Boundary_Wall_Status,Text_Area,No_Rooms)values('" + ddlbwall.SelectedItem.Text + "','" + bounderstatus + "'," + tblarea.Text + "','" + txtnorooms.Text + "','" + status + "')";
            //SqlCommand cmd = new SqlCommand(Query, con);
            //int i = cmd.ExecuteNonQuery();
            //con.Close();

            int successFlag = 0; // To track if any row insertion is successful

            foreach (GridViewRow row in gvDynamic.Rows)
            {
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

                    // Define the SQL query for insertion
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
     "alert('Physical Attributes Saved Successfully...! Please Fill the Section3 form'); window.location.href = 'Section3.aspx';", true);

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
        }
        protected void txtnorooms_TextChanged(object sender, EventArgs e)
        {
            gvDynamic.Visible = true;

            
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
                //  gvDynamic.Visible = true;
                // btnSave.Visible = true;
            }
            else
            {
                // If the input is invalid, show an error message
                //  lblError.Text = "Please enter a valid number greater than 0.";
            }
        }

        private void Grid()
        {
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
                //  gvDynamic.Visible = true;
                // btnSave.Visible = true;
            }
            else
            {
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
        }

        protected void Button3_ServerClick(object sender, EventArgs e)
        {

            string centcode = Session["CENT_CODE"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
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
                if(boundarywallStatus== "Open from One Side")
                {
                    rdbone.Checked = true;
                }
                else if(boundarywallStatus== "Open from Two Side")
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

                gvDynamic.DataSource = dt;
                gvDynamic.DataBind();
                //gvDynamic.Rows[e.RowIndex].Cells[0].Value.ToString();
                //gvDynamic.Columns
            }

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}