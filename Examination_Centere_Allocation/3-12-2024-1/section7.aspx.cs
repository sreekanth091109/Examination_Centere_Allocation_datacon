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
    public partial class section7 : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void exrb1_CheckedChanged(object sender, EventArgs e)
        {
            lbavailbe.Visible = false;
            if (exrb1.Checked)
            {
                etext1.Visible = true;
                exrb2.Checked = false;
                string reason = "Reason...";
                etext1.Attributes.Add("placeholder", reason);
            }
        }

        protected void exrb2_CheckedChanged(object sender, EventArgs e)
        {
            lbavailbe.Visible = false;
            if (exrb2.Checked)
            {
                etext1.Visible = false;
                exrb1.Checked = false;
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if (exrb1.Checked == true || exrb2.Checked == true)
            {



                string center_code = "1301";
                string script = "document.getElementById('section7').style.backgroundColor = 'green';";
                ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);

                //emergency exit radio button code
                string emg_exit;

                if (exrb1.Checked)
                {
                    emg_exit = exrb1.Text;
                }
                else if (exrb2.Checked)
                {
                    emg_exit = exrb2.Text;
                }
                else
                {
                    emg_exit = string.Empty;
                }

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "Insert into Additional_Information([Examination_Hall_Type], [Emergency_Exits], [Emergency_Exits_Reason], [Cent_Code]) values('" + ddlbwall.SelectedItem.ToString() + "','" + emg_exit + "','" + etext1.Text + "','" + center_code + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    Response.Write("<script>alert('Saved Additional Information.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Not Saved Additional Information.')</script>");
                }
            }
            else
            {
                lbavailbe.Visible = true;
            }
        }

        protected void Button2_ServerClick(object sender, EventArgs e)
        {
            exrb1.Checked = false;
            exrb2.Checked = false;
            ddlbwall.SelectedIndex = -1;
            etext1.Text = string.Empty;
        }
    }
}