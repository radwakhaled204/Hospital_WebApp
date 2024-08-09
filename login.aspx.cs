using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Drawing;
using System.Text.RegularExpressions;



namespace Royal_Elshrouq
{
    public partial class _interface1 : System.Web.UI.Page
    {


        private string connectionString;
        public SqlCommand cmd;
        
        public int v_code = 1;
     
        public SqlDataReader dr;
        public _interface1()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }

        protected void user_checkedchange(object sender, EventArgs e)
        {  
                txtcode.Visible = false;
                lblcode.Visible = false;
                lblphone.Text="المستخدم";
                signup.Visible = false;

        }

        protected void patient_checkedchange(object sender, EventArgs e)
        {

            txtcode.Visible = true;
            lblcode.Visible = true;
            lblphone.Text = "رقم الهاتف";
            signup.Visible = true;
        }
        protected void Sign_up_Click(object sender, EventArgs e)
        {


            using (SqlConnection con = new SqlConnection(connectionString))
            {

                if (user.Checked == true)
                {
                        string sql = "select * from user_ where name=@name and pas=@pass ";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@name", txtphone.Text);
                        cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                  

                        SqlDataReader r;
                        con.Open();
                        r = cmd.ExecuteReader();
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {

                                Session["h1"] = r["id"].ToString();
                                Session["name"] = r["name"].ToString();
                                Session["pas"] = r["pas"].ToString();
                                Session["admin_"] = r["admin_"].ToString();
                            }


                            con.Close();
                            Session["userType"] = "user";

                               Response.Redirect($"user_page.aspx?usercheck={user.Checked}");

                        }
                        else
                        {
                            lbl_message.Text = "خطا فى الدخول";


                        }
                        con.Close();
                   


                }

                if (patient.Checked == true)
                {

                    string sql = "select * from hos_sick where mob1=@phone and p_ppass=@pass and sick_code=@code ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                    cmd.Parameters.AddWithValue("@code", txtcode.Text);

                    SqlDataReader r;
                    con.Open();
                    r = cmd.ExecuteReader();
                    if (r.HasRows)
                    {
                        while (r.Read())
                        {

                            base.Session["h1"] = r["id"].ToString();
                            base.Session["n1"] = r["n1"].ToString();
                            base.Session["sick_code"] = r["sick_code"].ToString();
                            base.Session["mob1"] = r["mob1"].ToString();
                            base.Session["p_ppass"] = r["p_ppass"].ToString();

                        }


                        con.Close();
                        Session["userType"] = "patient";

                        Response.Redirect($"patient_page.aspx?usercheck={patient.Checked}");
                    }
                    else
                    {
                        lbl_message.Text = "خطا فى الدخول";


                    }
                    con.Close();
                }
                 
            }

        }


        protected void Page_Load(object sender, EventArgs e)

        {
           
            user.Enabled= true;
            patient.Enabled = true;
            employee.Enabled = true;
            doctor.Enabled = true;

          txtphone.AutoCompleteType= AutoCompleteType.Disabled;



            txtpass.AutoCompleteType = AutoCompleteType.Disabled;


            txtcode.AutoCompleteType = AutoCompleteType.Disabled;

        }

        protected void signup_Click(object sender, EventArgs e)
        {

            if (user.Checked)
            {
                Session["userType"] = "user";
            }
            else if (patient.Checked)
            {
                Session["userType"] = "patient";
            }
            else if(employee.Checked)
            {
                Session["userType"] = "employee";
            }
            else if (doctor.Checked)
            {
                Session["userType"] = "doctor";
            }
            Response.Redirect("signup.aspx");
        }

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }
     
    }
}












