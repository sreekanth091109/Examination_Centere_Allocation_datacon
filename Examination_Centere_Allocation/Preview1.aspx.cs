using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Web.Services.Description;

namespace Examination_Centere_Allocation
{
    public partial class Preview1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSection1();
                LoadSection2();
                LoadSection3();
                LoadSection4();
                LoadSection5();
                LoadSection6();
                LoadSection7();
            }
          
        }
        private void LoadSection1()
        {
            string centcode = Session["CENT_CODE"]?.ToString() ?? string.Empty; ;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            con.Open();
            string query = "SELECT  * FROM Basic_Details where CENT_CODE='" + centcode + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string district = dt.Rows[0]["District"].ToString();
                string division = dt.Rows[0]["Division"].ToString();
                string gpslocation = dt.Rows[0]["Gps_Location"].ToString();
                string centername = dt.Rows[0]["Exam_Center_Name"].ToString();
                string centernameAddress = dt.Rows[0]["Exam_Center_Name_Address"].ToString();


                lbldistrict.Text = district;  // Set the selected value
                lbldivison.Text = division;
                lblgpsaddress.Text = gpslocation;
                lblexamcentname.Text = centername;
                lbladrdess.Text = centernameAddress;

            }

            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void LoadSection2()
        {


            string centcode = Session["CENT_CODE"]?.ToString() ?? string.Empty; 
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

                lblboundarywall.Text = boundarywall;
                lbloption.Text = boundarywallStatus;
                lbltextarea.Text = textarea;
                lblnoofrooms.Text = noofrooms;

                gridview.DataSource = dt;
                gridview.DataBind();

            }

            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void LoadSection3()
        {
            string centcode = Session["CENT_CODE"]?.ToString() ?? string.Empty; ;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            con.Open();
            string query = "SELECT  * FROM Building_Information where CENT_CODE='" + centcode + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string nooffloors = dt.Rows[0]["Number_of_Floors"].ToString();
                string accessbility = dt.Rows[0]["Accessibility"].ToString();
                string otherprovisions = dt.Rows[0]["Other_Provisions"].ToString();
                string applicable = dt.Rows[0]["Applicable"].ToString();
                //  string otherprovisions1 = dt.Rows[0]["Other_Provisions"].ToString();


                lblnooffloors.Text = nooffloors;

                if (applicable == "" || applicable == null)
                {
                    lblaccessibility.Text = "Not Applicable";
                }
                else
                {
                    //string[] values = applicable.Split(',').Select(value => value.Trim()).ToArray();
                    string[] values = applicable.ToString().Split(',').Select(value1 => value1.Trim()).ToArray();
                    string value ="";
                    for (int i = 0; i < values.Length; i++)
                    {
                        //value = value[i].ToString();

                        

                        if (values[i] == "Other Provisions")
                        {
                            lblothers.Text = "Other Provisions: " + otherprovisions;




                        }
                        else
                        {
                            lblaccessibility.Text = "Applicable : " + applicable;
                        }
                    }
                }
            }

            cmd.ExecuteNonQuery();
            con.Close();

        }
        private void LoadSection4()
        {
            string centcode = Session["CENT_CODE"]?.ToString() ?? string.Empty; ;
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

                if (electricity == "Available")
                {
                    lblelectricity.Text = "Available";
                }
                else if (electricity == "Not Available")
                {
                    lblelectricity.Text = "Not Available";
                }
                else
                {
                    lblelectricity.Text = "Others :" + EcOthers;
                }


                if (dw == "Available")
                {
                    lbldrinkingwater.Text = "Available";
                }
                else if (dw == "Not Available")
                {
                    lbldrinkingwater.Text = "Not Available";
                }
                else
                {
                    lbldrinkingwater.Text = "Others :" + dwothers;
                }

                if (bps == "Available")
                {
                    lblbackuppower.Text = "Available";
                }
                else if (bps == "Not Available")
                {
                    lblbackuppower.Text = "Not Available";
                }
                else
                {
                    lblbackuppower.Text = "Others :" + bpsothers;
                }

                txttoilets.Text = toilets;
            }

            cmd.ExecuteNonQuery();
            con.Close();

        }
        private void LoadSection5()
        {

            string centcode = Session["CENT_CODE"]?.ToString() ?? string.Empty; ;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            con.Open();
            string query = "SELECT  * FROM Security_Surveillance where CENT_CODE='" + centcode + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string cctv = dt.Rows[0]["CCTV_INSTALLED"].ToString();
                string secpersonal = dt.Rows[0]["SECURITY_PERSONNEL"].ToString();

                txtcctvsurveillance.Text = cctv;
                lblsecuritysurveillence.Text = secpersonal;


            }
        }

        private void LoadSection6()
        {
            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string CENT = Session["CENT_CODE"]?.ToString() ?? string.Empty; ;
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
                string nameoftransport = dr["Name_of_Transport"].ToString().Trim();
                string distance = dr["Distance"].ToString().Trim();

                lblparkingavailbility.Text = parking;
                lblproximityTransport.Text = pr_Transport;
                lblnameoftranspoirt.Text = nameoftransport;
                lbldistance.Text = distance;

            }

            sqlcon.Close();
        }

        private void LoadSection7()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            string CENT = Session["CENT_CODE"]?.ToString() ?? string.Empty; ;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Additional_Information WHERE CENT_CODE='" + CENT + "'", con);
            SqlDataReader sqlreader = cmd.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(sqlreader);
            sqlreader.Close();
            foreach (DataRow dr in DT.Rows)
            {
                string examHallType = dr["Examination_Hall_Type"].ToString();
                string emer_exits = dr["Emergency_Exits"].ToString().Trim();
                string reson = dr["Emergency_Exits_Reason"].ToString().Trim();
                string no_exits = dr["No_Exits"].ToString().Trim();


                lblexaminationhalltype.Text = examHallType;
                if (emer_exits == "Available")
                {
                    lblemergencyexits.Text = "Available : " + reson;
                }
                else if (emer_exits == "Not Available")
                {
                    lblemergencyexits.Text = reson;
                }
                lblemergencyexitsavailble.Text = no_exits;
            }

            con.Close();
        }
        protected void yes_ServerClick(object sender, EventArgs e)
        {
           // Response.Redirect("Preview1.aspx");
        }

        protected void no_ServerClick(object sender, EventArgs e)
        {
            Session["flg"] = "btnsave";
            string id = "";
            Session["flg3"] = id;

            Response.Redirect("Section1.aspx");
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
          
        }
        //private void centcde()
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select case when max(CENT_CODE) is null then 0 else  max(CENT_CODE) end as CENT_CODE from Basic_Details where District='" + ddldistrict.SelectedItem + "'  ", con);
        //    cmd.CommandTimeout = 0;
        //    string val1 = cmd.ExecuteScalar().ToString();
        //    if (val1 == "0")
        //        val1 = ddldistrict.SelectedItem.ToString().Substring(0, 2) + "00";
        //    int centcode = Convert.ToInt32(val1) + 1;
        //    Session["CENT_CODE"] = centcode;
        //}
        //protected void btnSave_ServerClick(object sender, EventArgs e)
        //{

        //    var lblSection1 = (Label)this.Master.FindControl("sec1");

        //    if (lblSection1 != null)
        //    {
        //        lblSection1.Text = "Updated Section 4"; // Modify the text of Section 4
        //    }
        //    //var ecaHome = (PlaceHolder)this.Master.FindControl("eca_master");
        //    //Button btnSeaction2 = (Button)ecaHome.FindControl("btnseaction2");

        //    //if (btnSeaction2 != null)
        //    //{
        //    //    // Enable the button
        //    //    btnSeaction2.Enabled = true;
        //    //}

        //    //btnSaveContent.Enabled = true;
        //    //btnseaction3.Enabled = false;
        //    //btnseaction4.Enabled = true;
        //    //btnseaction5.Enabled = true;
        //    //btnseaction6.Enabled = true;
        //    //btnseaction7.Enabled = true;
        //    string status = "";
        //    //var firstTwoChars = dd.substring(0, 2); // Extracts characters from index 0 to index 1
        //    //console.log(firstTwoChars);
        //    centcde();
        //    string centcode = Session["CENT_CODE"].ToString();
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        //    con.Open();
        //    string Query = "Insert into Basic_Details values('" + ddldistrict.SelectedItem.Text.Trim() + "','" + ddldivison.SelectedItem.Text.Trim() + "','" + textaddress.Text.Trim() + "','" + tblecn.Text.Trim() + "','" + txtadrdess.Text.Trim() + "','" + centcode.Trim() + "','" + status.Trim() + "')";
        //    SqlCommand cmd = new SqlCommand(Query, con);
        //    int i = cmd.ExecuteNonQuery();
        //    con.Close();

        //    if (i == 1)
        //    {
        //        Response.Redirect("section2.aspx");

        //    }
        //    con.Close();


        //    string script = "document.getElementById('section1').style.backgroundColor = 'green';";
        //    ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);
        //}
    }
}