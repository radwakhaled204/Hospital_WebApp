using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iText.IO.Image;
using static Org.BouncyCastle.Utilities.Test.FixedSecureRandom;

namespace Royal_Elshrouq
{
    public partial class inquiry : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader dr;
        public DataTable dt;
        string sql = "";
        string up_text = "";
        public inquiry()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                count();
            }

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

        protected void count()
        {
            DataTable dt = load_data();

            if (dt.Rows.Count > 0)
            {
                DataRow firstRow = dt.Rows[0];

                if (!string.IsNullOrEmpty(firstRow["inquiry"].ToString()))
                {
                    div_respond.Visible = true;

                    respond.Text = !string.IsNullOrEmpty(firstRow["inquiry_respond"].ToString()) ? firstRow["inquiry_respond"].ToString() : string.Empty;

                    last_inquiry.Text = firstRow["inquiry"].ToString();
                }
                else
                {
                    div_respond.Visible = false;
                }
            }
            else
            {
                div_respond.Visible = false;
            }
        }

        private DataTable load_data()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                sql = "SELECT inquiry, inquiry_respond FROM hos_sick WHERE sick_code = @sick_code";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@sick_code", Session["sick_code"].ToString());

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
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
                    lbl_message.Text = "اكتب استفسارك";
                    goto pp1;
                }

                if (up_text == "")
                {
                    up_text = " inquiry = @inquiry";
                }
                else
                {
                    up_text += ", inquiry = @inquiry";
                }

                if (!string.IsNullOrEmpty(up_text))
                {
                    DateTime selectedDate = DateTime.Now;
                    string formattedDate = selectedDate.ToString("yyyy-MM-dd HH:mm:ss");

                    sql = "update hos_sick set " + up_text + ", inquiry_date = @inquiry_date where sick_code = @sick_code";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@inquiry", notevalue);
                    cmd.Parameters.AddWithValue("@inquiry_date", formattedDate);
                    cmd.Parameters.AddWithValue("@sick_code", Session["sick_code"].ToString());

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lbl_message.Text = "تم ارسال استفسارك بنجاح وسوف يتم الرد في أقرب وقت";
                }
            pp1:;
            }
        }






    }
}