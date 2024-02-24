using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Return(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");

        }

        protected void submit1_Click(object sender, EventArgs e)
        {
            string startDateValue = startDate.Text;
            string endDateValue = endDate.Text;
            string semcode = semc.Text;

            DateTime startDateParsed;
            DateTime endDateParsed;

            if (!string.IsNullOrEmpty(semcode))
            {
                if ((semcode.Length == 3 || semcode.Length == 5) && (semcode.StartsWith("W") || semcode.StartsWith("S")))
                {
                    if (DateTime.TryParse(startDateValue, out startDateParsed) && DateTime.TryParse(endDateValue, out endDateParsed))
                    {
                        if (startDateParsed < endDateParsed)
                        {
                            if (startDateParsed > DateTime.Now)
                            {
                                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

                                //USING A HELPER METHOD TO CHECK IF THE RECORD EXISTS ALREADY
                                if (!recordExists(connStr, "Semester", "semester_code", semcode))
                                {
                                    using (SqlConnection conn = new SqlConnection(connStr))
                                    {
                                        startDateParsed = DateTime.Parse(startDateValue);
                                        endDateParsed = DateTime.Parse(endDateValue);

                                        SqlCommand addsem = new SqlCommand("AdminAddingSemester", conn);
                                        addsem.CommandType = CommandType.StoredProcedure;

                                        addsem.Parameters.Add(new SqlParameter("@start_date", SqlDbType.Date)).Value = startDateParsed;
                                        addsem.Parameters.Add(new SqlParameter("@end_date", SqlDbType.Date)).Value = endDateParsed;
                                        addsem.Parameters.Add(new SqlParameter("@semester_code", SqlDbType.VarChar, 40)).Value = semcode;

                                        conn.Open();
                                        addsem.ExecuteNonQuery();
                                        conn.Close();


                                        string successLabel = "<div class='successText'>Semester Added Successfully</div>";
                                        Response.Write(successLabel);

                                    }
                                }
                                else
                                {
                                    string errorLabel = "<div class='errorText'>That semester code already exists, please use a different one</div>";
                                    Response.Write(errorLabel);
                                }

                            }
                            else
                            {
                                string errorLabel = "<div class='errorText'>Start Date must come after the current date</div>";
                                Response.Write(errorLabel);
                            }

                        }
                        else
                        {
                            string errorLabel = "<div class='errorText'>End date must come after start date</div>";
                            Response.Write(errorLabel);

                        }


                    }
                    else
                    {
                        string errorLabel = "<div class='errorText'>Please enter both date fields</div>";
                        Response.Write(errorLabel);
                    }
                }
                else
                {
                    string errorLabel = "<div class='errorText'>Semester code length must be either 3 or 5 and start with 'W' or 'S'</div>";
                    Response.Write(errorLabel);
                }
            }
            else
            {
                string errorLabel = "<div class='errorText'>Please enter semester code</div>";
                Response.Write(errorLabel);

            }
        }

        protected void submitCourse_Click(object sender, EventArgs e)
        {
            string major1 = major.Text;
            string courseSemester1 = courseSemester.Text;
            string creditHours1 = creditHours.Text;
            string courseName1 = courseName.Text;
            string isOffered1 = isOffered.SelectedValue;

            if (!string.IsNullOrEmpty(major1) && !string.IsNullOrEmpty(courseSemester1) && !string.IsNullOrEmpty(creditHours1)
                && !string.IsNullOrEmpty(courseName1) && !string.IsNullOrEmpty(isOffered1))
            {
                if (int.TryParse(creditHours1, out int creditHoursValue) && int.TryParse(courseSemester1, out int courseSemesterValue))
                {
                    if (int.TryParse(isOffered1, out int isOfferedValue) && (isOfferedValue == 0 || isOfferedValue == 1))
                    {
                        string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                        //USING A HELPER METHOD TO CHECK IF THE RECORD EXISTS ALREADY
                        if (!recordExists(connStr, "Course", "name", courseName1))
                        {
                            using (SqlConnection conn = new SqlConnection(connStr))
                            {
                                SqlCommand addcourse = new SqlCommand("Procedures_AdminAddingCourse", conn);
                                addcourse.CommandType = CommandType.StoredProcedure;


                                addcourse.Parameters.Add(new SqlParameter("@major", SqlDbType.VarChar, 40)).Value = major1;
                                addcourse.Parameters.Add(new SqlParameter("@semester", SqlDbType.Int)).Value = courseSemesterValue;
                                addcourse.Parameters.Add(new SqlParameter("@credit_hours", SqlDbType.Int)).Value = creditHoursValue;
                                addcourse.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 40)).Value = courseName1;
                                addcourse.Parameters.Add(new SqlParameter("@is_offered", SqlDbType.Int)).Value = isOfferedValue;

                                conn.Open();
                                addcourse.ExecuteNonQuery();
                                conn.Close();
                            
                                string successLabel = "<div class='successText'>Course Added Successfully</div>";
                                Response.Write(successLabel);


                            }
                        }
                        else
                        {

                            string errorLabel = "<div class='errorText'>This course already exists</div>";
                            Response.Write(errorLabel);


                        }


                    }
                    else
                    {
                        string errorLabel = "<div class='errorText'>Is Offered must either be a 1 or a 0</div>";
                        Response.Write(errorLabel);

                    }

                }
                else
                {

                    string errorLabel = "<div class='errorText'>Semester and credit hours must be a number</div>";
                    Response.Write(errorLabel);

                }


            }
            else
            {

                string errorLabel = "<div class='errorText'>None of the fields can be empty</div>";
                Response.Write(errorLabel);

            }



        }

        protected void linkInstructorToCourse_Click(object sender, EventArgs e)
        {
            string instructorid = instructorID.Text;
            string courseid = courseID.Text;
            string slotid = slotID.Text;

            if (!string.IsNullOrEmpty(instructorid) && !string.IsNullOrEmpty(courseid) && !string.IsNullOrEmpty(slotid))
            {
                if (int.TryParse(instructorid, out int instructoridValue) && int.TryParse(courseid, out int courseidValue)
                    && int.TryParse(slotid, out int slotidValue))
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                    //Check if the records exist
                    if (recordExists(connStr, "Instructor", "instructor_id", instructorid) &&
                        recordExists(connStr, "Slot", "slot_id", slotid) &&
                        recordExists(connStr, "Course", "course_id", courseid))
                    {
                        using (SqlConnection conn = new SqlConnection(connStr))
                        {
                            SqlCommand linkinstructorcourse = new SqlCommand("Procedures_AdminLinkInstructor", conn);
                            linkinstructorcourse.CommandType = CommandType.StoredProcedure;

                            linkinstructorcourse.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int)).Value = instructoridValue;
                            linkinstructorcourse.Parameters.Add(new SqlParameter("@cours_id", SqlDbType.Int)).Value = courseidValue;
                            linkinstructorcourse.Parameters.Add(new SqlParameter("@slot_id", SqlDbType.Int)).Value = slotidValue;

                            conn.Open();
                            linkinstructorcourse.ExecuteNonQuery();
                            conn.Close();

                            string successLabel = "<div class='successText'>Linked Instructor to Course Successfully</div>";
                            Response.Write(successLabel);
                        }
                    }
                    else
                    {
                        string errorLabel = "<div class='errorText'>Some or all the ID's do not exist</div>";
                        Response.Write(errorLabel);
                    }
                }
                else
                {
                    string errorLabel = "<div class='errorText'>The entries must be in numbers</div>";
                    Response.Write(errorLabel);
                }
            }
            else
            {
                string errorLabel = "<div class='errorText'>None of the fields can be empty</div>";
                Response.Write(errorLabel);
            }
        }

        protected void linkStudentToAdvisor_Click(object sender, EventArgs e)
        {
            string studentid = studentID.Text;
            string advisorid = advisorID.Text;

            if (!string.IsNullOrEmpty(studentid) && !string.IsNullOrEmpty(advisorid))
            {
                if ((int.TryParse(studentid, out int studentidValue) &&
                    int.TryParse(advisorid, out int advisoridValue)))
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                    //Check if the records exist
                    if (recordExists(connStr, "Student", "student_id", studentid) &&
                        recordExists(connStr, "Advisor", "advisor_id", advisorid))
                    {
                        using (SqlConnection conn = new SqlConnection(connStr))
                        {
                            SqlCommand linkstudentadvisor = new SqlCommand("Procedures_AdminLinkStudentToAdvisor", conn);
                            linkstudentadvisor.CommandType = CommandType.StoredProcedure;

                            linkstudentadvisor.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = studentidValue;
                            linkstudentadvisor.Parameters.Add(new SqlParameter("@advisorID", SqlDbType.Int)).Value = advisoridValue;

                            conn.Open();
                            linkstudentadvisor.ExecuteNonQuery();
                            conn.Close();

                            string successLabel = "<div class='successText'>Linked Student to Advisor Successfully</div>";
                            Response.Write(successLabel);
                        }
                    }
                    else
                    {
                        string errorLabel = "<div class='errorText'>Some or all the ID's do not exist</div>";
                        Response.Write(errorLabel);
                    }
                }
                else
                {
                    string errorLabel = "<div class='errorText'>You must enter numbers</div>";
                    Response.Write(errorLabel);
                }
            }
            else
            {
                string errorLabel = "<div class='errorText'>None of the fields can be empty</div>";
                Response.Write(errorLabel);
            }
        }

        protected void linkStudentToCourseWithInstructor_Click(object sender, EventArgs e)
        {
            string instructor_id = studentToCourseInstructorID.Text;
            string student_id = studentToCourseStudentID.Text;
            string course_id = studentToCourseCourseID.Text;
            string semester_code = studentToCourseSemesterCode.Text;

            if (string.IsNullOrEmpty(instructor_id) || string.IsNullOrEmpty(student_id) || string.IsNullOrEmpty(course_id) || string.IsNullOrEmpty(semester_code))
            {
                Response.Write("<div class='errorText'>Values can't be empty</div>");
                return;
            }

            if (!int.TryParse(studentToCourseInstructorID.Text, out int instructoridValue) ||
                !int.TryParse(studentToCourseStudentID.Text, out int studentidValue) ||
                !int.TryParse(studentToCourseCourseID.Text, out int courseidValue))
            {
                Response.Write("<div class='errorText'>The ID's must all be numbers</div>");
                return;
            }

            if (!(semester_code.Length == 3 || semester_code.Length == 5) || !(semester_code.StartsWith("W") || semester_code.StartsWith("S")))
            {
                Response.Write("<div class='errorText'>Semester code length must be either 3 or 5 and start with 'W' or 'S'</div>");
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            // Check if the records exist
            if (recordExists(connStr, "Instructor", "instructor_id", instructor_id) &&
                recordExists(connStr, "Student", "student_id", student_id) &&
                recordExists(connStr, "Course", "course_id", course_id) &&
                recordExists(connStr, "Semester", "semester_code", semester_code))
            {
                if (!recordExists2(connStr, "Student_Instructor_Course_Take", "instructor_id", instructor_id, "course_id", course_id, "student_id", student_id, "semester_code", semester_code))
                {
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        SqlCommand linkstudentcourse = new SqlCommand("Procedures_AdminLinkStudent", conn);
                        linkstudentcourse.CommandType = CommandType.StoredProcedure;

                        linkstudentcourse.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int)).Value = instructoridValue;
                        linkstudentcourse.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = studentidValue;
                        linkstudentcourse.Parameters.Add(new SqlParameter("@cours_id", SqlDbType.Int)).Value = courseidValue;
                        linkstudentcourse.Parameters.Add(new SqlParameter("@semester_code", SqlDbType.VarChar, 40)).Value = semester_code;

                        conn.Open();
                        linkstudentcourse.ExecuteNonQuery();
                        conn.Close();

                        Response.Write("<div class='successText'>Linked Student to Course Successfully</div>");
                    }
                }
                else
                {
                    Response.Write("<div class='errorText'>They are already linked</div>");
                }
            }
            else
            {
                Response.Write("<div class='errorText'>Some or all the ID's and/or semester code does not exist</div>");
            }
        }
        private bool recordExists(string connectionString,string Table,string colN, string colR)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand helper=new SqlCommand("SELECT COUNT(*) FROM "+Table+" WHERE "+colN+ " = @"+ colN,conn))
                {
                    helper.Parameters.Add(new SqlParameter("@"+colN,SqlDbType.NVarChar)).Value=colR;
                    int sum=(int)helper.ExecuteScalar();
                    if (sum > 0)
                        return true;
                    else return false;

                }

            }


            }

        private bool recordExists2(string connectionString, string Table, string colN1, string colR1, string colN2, string colR2, string colN3, string colR3, string colN4, string colR4)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand helper = new SqlCommand("SELECT COUNT(*) FROM " + Table + " WHERE " + colN1 + " = @" + colN1+" AND "+colN2 + " = @" + colN2+" AND "+colN3+" = @"+colN3+" AND "+colN4+" = @"+colN4, conn))
                { 
                    helper.Parameters.Add(new SqlParameter("@" + colN1, SqlDbType.NVarChar)).Value = colR1;
                    helper.Parameters.Add(new SqlParameter("@" + colN2, SqlDbType.NVarChar)).Value = colR2;
                    helper.Parameters.Add(new SqlParameter("@" + colN3, SqlDbType.NVarChar)).Value = colR3;
                    helper.Parameters.Add(new SqlParameter("@" + colN4, SqlDbType.NVarChar)).Value = colR4;
                    int sum = (int)helper.ExecuteScalar();
                    if (sum > 0)
                        return true;
                    else return false;

                }

            }


        }







    }
}





































//7978