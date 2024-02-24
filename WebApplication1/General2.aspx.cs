using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class General2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void makeup1(object sender, EventArgs e)
        {
            Response.Redirect("makeup11.aspx");
        }



        protected void makeup2(object sender, EventArgs e)
        {
            Response.Redirect("makeup22.aspx");
        }


        protected void IC(object sender, EventArgs e)
        {
            Response.Redirect("IC.aspx");
        }



        protected void change3(object sender, EventArgs e)
        {
            Response.Redirect("change33.aspx");
        }

        protected void instal(object sender, EventArgs e)
        {
            Response.Redirect("install.aspx");
        }

        protected void next(object sender, EventArgs e)
        {
            Response.Redirect("nextt.aspx");
        }

        protected void return1(object sender, EventArgs e)
        {
            Response.Redirect("General.aspx");
        }
    }
}