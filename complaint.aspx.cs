using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Royal_Elshrouq
{
    public partial class complaint : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader dr;
        public DataTable dt;
        string sql = "";
        string up_text = "";
        public complaint()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (Session["sick_code"] != null)
                {
                    string mob = Session["mob1"].ToString();
                    string pass = Session["p_ppass"].ToString();
                    string sessionValue = Session["sick_code"].ToString();
                    lbl_m.Text = "الكود الخاص بك هو       " + sessionValue;


                    if (Session["n1"] != null)
                    {
                        string name = Session["n1"].ToString();
                        lbl2_m.Text = ",مرحبا       " + name;
                    }

                }

                else
                {
                    if (Session["name"] != null)
                    {
                        string name = Session["name"].ToString();
                        lbl2_m.Text = ",مرحبا       " + name;
                        string pass = Session["pas"].ToString();
                        lbl_m.Text = "الباسورد الخاص بك هو    " + pass;
                    }

                }



            }

        }


        protected void Save_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                string notevalue = notes.Value.Trim();

                if (string.IsNullOrEmpty(notevalue))
                {
                    lbl_message.Text = "اكتب شكوتك";
                    goto pp1;
                }

                if (up_text == "")
                {
                    up_text = " complaint = @complaint";
                }
                else
                {
                    up_text += ", complaint = @complaint";
                }

                if (!string.IsNullOrEmpty(up_text))
                {
                    DateTime selectedDate = DateTime.Now;
                    string formattedDate = selectedDate.ToString("yyyy-MM-dd HH:mm:ss");

                    sql = "update hos_sick set " + up_text + ", complaint_date = @complaint_date where sick_code = @sick_code";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@complaint", notevalue);
                    cmd.Parameters.AddWithValue("@complaint_date", formattedDate);
                    cmd.Parameters.AddWithValue("@sick_code", Session["sick_code"].ToString());

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lbl_message.Text = "تم ارسال شكوتك بنجاح ";
                }
            pp1:;
            }
        }

 
    }
}