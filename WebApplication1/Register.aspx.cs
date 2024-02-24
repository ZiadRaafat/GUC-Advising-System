using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Advising_System
{
    public partial class studentregister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerStud(object sender, EventArgs e)
        {
            try
            {


                string r = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection c = new SqlConnection(r);
                String fn = fname.Text;
                String ln = lname.Text;
                String pw = password.Text;
                String fc = faculty.Text;
                String em = email.Text;
                String m = major.Text;
                int sem;
                if (string.IsNullOrWhiteSpace(fn) || string.IsNullOrWhiteSpace(ln) ||
                   string.IsNullOrWhiteSpace(pw) || string.IsNullOrWhiteSpace(fc) ||
                   string.IsNullOrWhiteSpace(em) || string.IsNullOrWhiteSpace(m) ||
                   string.IsNullOrWhiteSpace(semester.Text))
                {
                    Label2.Text = "Please fill in all the required fields.";
                    return; // Exit the method if any input is empty
                }
                if (int.TryParse(semester.Text, out sem)== false)
                {
                    Label2.Text = ("Please enter a valid semester number.");
                    return;

                }

                 sem = Int16.Parse(semester.Text);
                if (sem > 20)
                {
                    Label2.Text = ("Please enter a valid semester number.");
                    return;

                }
                

                SqlCommand rg = new SqlCommand("Procedures_StudentRegistration", c);
                c.Open();
                rg.CommandType = System.Data.CommandType.StoredProcedure;

                rg.Parameters.Add(new SqlParameter("@first_name", fn));
                rg.Parameters.Add(new SqlParameter("@last_name", ln));
                rg.Parameters.Add(new SqlParameter("@password", pw));
                rg.Parameters.Add(new SqlParameter("@faculty", fc));
                rg.Parameters.Add(new SqlParameter("@email", em));
                rg.Parameters.Add(new SqlParameter("@major", m));
                rg.Parameters.Add(new SqlParameter("@Semester", sem));

                SqlParameter sid = rg.Parameters.Add("@Student_id", System.Data.SqlDbType.Int);
                sid.Direction = System.Data.ParameterDirection.Output;


                rg.ExecuteNonQuery();

                int studentId = Convert.ToInt32(sid.Value);

                c.Close();
                Label1.Text = ("Your ID is: " + studentId);

            }
            catch(Exception ex)
            {

                Label2.Text = ("Please enter the correct credentials.");
            }
            

        }

        protected void password_TextChanged(object sender, EventArgs e)
        {

        }

        protected void goBack(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");

        }
    }
}