using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class MissingCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void goBack(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }

        protected void avaic(object sender, EventArgs e)
        {
            string r = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection c = new SqlConnection(r);

            HttpCookie userIdCookie = Request.Cookies["userID"];
            int studid = Convert.ToInt32(userIdCookie.Value);
            SqlCommand AP = new SqlCommand("Procedures_ViewMS", c);
            AP.Parameters.Add(new SqlParameter("@StudentID", studid));
            AP.CommandType = System.Data.CommandType.StoredProcedure;


            SqlDataAdapter adap = new SqlDataAdapter(AP);
            DataTable dataTable = new DataTable();
            adap.Fill(dataTable);
            G1.DataSource = dataTable;
            G1.DataBind();







        }
    }
}