using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                lblgrid.Visible = true;
                lblgrid.Text = "Please fill in the information for all" + " " + txtnorooms.Text + " " + "rooms in the table below";
                lblgrid.Visible = true;
            }
        }
        protected void txtnorooms_TextChanged(object sender, EventArgs e)
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
                gdv1.Visible = true;
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

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if (rdbone.Checked == true || rdbtwo.Checked == true || rdbthree.Checked == true || rdbfour.Checked == true)
            {
                string script = "document.getElementById('section2').style.backgroundColor = 'green';";
                ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);
                lbselect.Visible = false;
            }
            else
            {
                lbselect.Visible = true;

            }
        }

        protected void gvDynamic_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvDynamic_RowCreated1(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    GridView HeaderGrid = (GridView)sender;
            //    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //    TableCell HeaderCell = new TableCell();
            //    HeaderCell.Text = "Please fill in the information for all No Of rooms in the table below";
            //    HeaderGridRow.Cells.Add(HeaderCell);

            //    gvDynamic.Controls[0].Controls.AddAt(0, HeaderGridRow);

            //}
        }

        protected void rdbone_CheckedChanged(object sender, EventArgs e)
        {
            lbselect.Visible = false;
        }

        protected void rdbtwo_CheckedChanged(object sender, EventArgs e)
        {
            lbselect.Visible = false;
        }

        protected void rdbthree_CheckedChanged(object sender, EventArgs e)
        {
            lbselect.Visible = false;
        }

        protected void rdbfour_CheckedChanged(object sender, EventArgs e)
        {
            lbselect.Visible = false;
        }
    }
}