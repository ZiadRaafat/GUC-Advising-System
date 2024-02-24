using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class grad_courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);


            try
            {
                String First_Name = first_name.Text;
                String Last_Name = last_name.Text;
                String Password = pass.Text;
                String Faculty = fac.Text;
                String Email = email.Text;
                String Major = major.Text;
                int Semester = Int16.Parse(Sem.Text);

                SqlCommand loginproc = new SqlCommand("Procedures_StudentRegistration", conn);
                loginproc.CommandType = System.Data.CommandType.StoredProcedure;
                loginproc.Parameters.Add(new SqlParameter("@first_name", First_Name));
                loginproc.Parameters.Add(new SqlParameter("@last_name", Last_Name));
                loginproc.Parameters.Add(new SqlParameter("@password", Password));
                loginproc.Parameters.Add(new SqlParameter("@faculty", Faculty));
                loginproc.Parameters.Add(new SqlParameter("@email", Email));
                loginproc.Parameters.Add(new SqlParameter("@major", Major));
                loginproc.Parameters.Add(new SqlParameter("@semester", Semester));

                SqlParameter ID = loginproc.Parameters.Add("@studentID", System.Data.SqlDbType.Int); //output

                ID.Direction = System.Data.ParameterDirection.Output;

                conn.Open();
                loginproc.ExecuteNonQuery();
                conn.Close();

                if (ID.Value.ToString() == "1")
                {
                    Response.Write("Welcome!");
                }
 
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.Message);
            }
            }
            }
    }
