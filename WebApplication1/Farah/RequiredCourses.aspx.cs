using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Studentrequiredcourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Erga3(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }

        protected void avaic(object sender, EventArgs e)
        {
            string r = WebConfigurationManager.ConnectionStrings["Advising_System1"].ToString();
            SqlConnection c = new SqlConnection(r);
            String semcodee = semcode.Text;
            int t;
            if (string.IsNullOrWhiteSpace(semcodee))
            {
                Response.Write("Please fill in all the required fields.");
                return;
            }

            if (int.TryParse(semcode.Text, out t))
            {
                Response.Write("Please enter a valid semester code.");
                return;

            }

            HttpCookie userIdCookie = Request.Cookies["userID"];
            int studid = Convert.ToInt32(userIdCookie.Value);
            SqlCommand AP = new SqlCommand("Procedures_ViewRequiredCourses", c);
            AP.Parameters.Add(new SqlParameter("@StudentID", studid));
            AP.Parameters.Add(new SqlParameter("@current_semester_code", semcodee));
            AP.CommandType = System.Data.CommandType.StoredProcedure;


            SqlDataAdapter adap = new SqlDataAdapter(AP);
            DataTable dataTable = new DataTable();
            adap.Fill(dataTable);
            G1.DataSource = dataTable;
            G1.DataBind();
        }
    }
}