using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Examination_Centere_Allocation
{
    public partial class eca : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblprogress = new Label { Text = "Progress: 0%" };
            section1 = new HtmlGenericControl("div");
            section2 = new HtmlGenericControl("div");
            section3 = new HtmlGenericControl("div");
            section4 = new HtmlGenericControl("div");
            section5 = new HtmlGenericControl("div");
            section6 = new HtmlGenericControl("div");
            section7 = new HtmlGenericControl("div");
            this.Controls.Add(lblprogress);
            this.Controls.Add(section1);
            this.Controls.Add(section2);
            this.Controls.Add(section3);
            this.Controls.Add(section4);
            this.Controls.Add(section5);
            this.Controls.Add(section6);
            this.Controls.Add(section7);

            //section2 = new HtmlGenericControl("div");
            //section3 = new HtmlGenericControl("div");
            //section4 = new HtmlGenericControl("div");
        }
        public Label MasterMessageLabel1
        {
            get { return lblsec1status; }
        }
        public Label MasterMessageLabel2
        {
            get { return lblsec2status; }
        }
        public Label MasterMessageLabel3
        {
            get { return lblsec3status; }
        }
        public Label MasterMessageLabel4
        {
            get { return lblsec4status; }
        }
        public Label MasterMessageLabel5
        {
            get { return lblsec5status; }
        }
        public Label MasterMessageLabel6
        {
            get { return lblsec6status; }
        }
        public Label MasterMessageLabel7
        {
            get { return lblsec7status; }
        }
        public Button Masterbutton1
        {
            get { return btnseaction1; }
        }
        public Button Masterbutton2
        {
            get { return btnseaction2; }
        }
        public Button Masterbutton3
        {
            get { return btnseaction3; }

        }
        public Button Masterbutton4
        {
            get { return btnseaction4; }
        }
        public Button Masterbutton5
        {
            get { return btnseaction5; }
        }
        public Button Masterbutton6
        {
            get { return btnseaction6; }
        }
        public Button Masterbutton7
        {
            get { return btnseaction7; }
        }
        public Label Mastersecpr1
        {
            get { return lblprogress; }
            set { lblprogress = value; }
        }
        public HtmlGenericControl Mastersecpr2
        {
            get { return section1; }
            set { section1 = value; }
        }
        public HtmlGenericControl Mastersecpr3
        {
            get { return section2; }
            set { section2 = value; }
        }
        public HtmlGenericControl Mastersecpr4
        {
            get { return section3; }
            set { section3 = value; }
        }
        public HtmlGenericControl Mastersecpr5
        {
            get { return section4; }
            set { section4 = value; }
        }
        public HtmlGenericControl Mastersecpr6
        {
            get { return section5; }
            set { section5 = value; }
        }
        public HtmlGenericControl Mastersecpr7
        {
            get { return section6; }
            set { section6 = value; }
        }
        public HtmlGenericControl Mastersecpr8
        {
            get { return section7; }
            set { section7 = value; }
        }
      

        protected void Section1_Click(object sender, EventArgs e)
        {
            Response.Redirect("section1.aspx");
        }

        protected void Section2_Click(object sender, EventArgs e)
        {
            Response.Redirect("section2.aspx");
        }

        protected void Section3_Click(object sender, EventArgs e)
        {
            Response.Redirect("section3.aspx");
        }

        protected void Section4_Click(object sender, EventArgs e)
        {
            Response.Redirect("section4.aspx");
        }

        protected void Section5_Click(object sender, EventArgs e)
        {
            Response.Redirect("section5.aspx");
        }

        protected void Section6_Click(object sender, EventArgs e)
        {
            Response.Redirect("section6.aspx");
        }

        protected void Section7_Click(object sender, EventArgs e)
        {
            Response.Redirect("section7.aspx");
        }

        protected void Section7_Click1(object sender, EventArgs e)
        {
            Response.Redirect("section7.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Siginin.aspx");
        }
    }
}