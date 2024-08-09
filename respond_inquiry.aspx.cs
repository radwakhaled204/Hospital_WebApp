using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Security.Policy;

namespace Royal_Elshrouq
{
    public partial class respond_inquiry : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader r;
        public DataTable dt;
        string sql = "";
        string up_text = "";
 
        public respond_inquiry()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sickCode = Request.QueryString["sick_code"];
                sickCode = Server.UrlDecode(sickCode);       
                load_data(sickCode);
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (Session["admin_"] != null)
                {

                    string sessionValue = Session["admin_"].ToString();
                    lbl_m.Text = "الكود الخاص بك هو    " + sessionValue;


                    if (Session["name"] != null)
                    {
                        string name = Session["name"].ToString();
                        lbl2_m.Text = ",مرحبا       " + name;
                    }

                }

                else
                {
                    if (Session["name"] != null)
                    {
                        string name = Session["name"].ToString();
                        lbl2_m.Text = "مرحبا,       " + name;
                        string sessionValue = Session["admin_"].ToString();
                        lbl_m.Text = "الكود الخاص بك هو    " + sessionValue;
                    }

                }





            }
        }

        public DataTable load_data(string sickCode)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
         
                sql = "SELECT n1, sick_code, mob1, inquiry, inquiry_date FROM hos_sick WHERE sick_code = @sick_code";
                SqlCommand cmd = new SqlCommand(sql, con);

  
                cmd.Parameters.AddWithValue("@sick_code", sickCode);

                try
                {
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    res_inquries.DataSource = dt;
                    res_inquries.DataBind();
                }
                finally
                {
                    con.Close();
                }
            }

            return dt;
        }
 
        protected void Save_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sickCode = Request.QueryString["sick_code"];
                string name = Session["name"].ToString();

                SqlCommand cmd;
                string notevalue = notes.Value.Trim();

                if (string.IsNullOrEmpty(notevalue))
                {
                    lbl_message.Text = "اكتب ردك على الاستفسار";
                    goto pp1;
                }

                if (up_text == "")
                {
                    up_text = " inquiry_respond = @inquiry_respond";
                }
                else
                {
                    up_text += ", inquiry_respond = @inquiry_respond";
                }

                if (!string.IsNullOrEmpty(up_text))
                {
                    DateTime selectedDate = DateTime.Now;
                    string formattedDate = selectedDate.ToString("yyyy-MM-dd HH:mm:ss");

                    sql = "update hos_sick set " + up_text + ", inquiry_respond_date = @inquiry_respond_date ,inquiry_respond_user=@inquiry_respond_user where sick_code = @sick_code";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@inquiry_respond", notevalue);
                    cmd.Parameters.AddWithValue("@inquiry_respond_date", formattedDate);
                    cmd.Parameters.AddWithValue("@inquiry_respond_user", name);
                    cmd.Parameters.AddWithValue("@sick_code", sickCode);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lbl_message.Text = "تم تسجيل ردك بنجاح وسوف يتم ارساله للمريض";
                }
            pp1:;
            }
        }
    }
}