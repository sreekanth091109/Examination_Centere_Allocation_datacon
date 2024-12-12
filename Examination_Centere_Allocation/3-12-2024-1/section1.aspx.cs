using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examination_Centere_Allocation
{
    public partial class section1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            string script = "document.getElementById('section1').style.backgroundColor = 'green';";
            ClientScript.RegisterStartupScript(this.GetType(), "ChangeColor", script, true);
        }
    }
}