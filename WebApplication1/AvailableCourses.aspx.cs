using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Studentviewavailablecourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void avaic(object sender, EventArgs e)
        {
            try
            {
                string r = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
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


                SqlCommand view = new SqlCommand("SELECT * FROM FN_SemsterAvailableCourses(@semstercode)", c);
                c.Open();
                view.Parameters.AddWithValue("@semstercode", semcodee);
                SqlDataAdapter adap = new SqlDataAdapter(view);
                DataTable dataTable = new DataTable();
                adap.Fill(dataTable);
                G1.DataSource = dataTable;
                G1.DataBind();
            }

            catch(Exception ex)
            {
                Response.Write("Please enter a valid semester code.");

            }




        }

        protected void Erga3(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}