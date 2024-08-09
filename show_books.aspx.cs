using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Royal_Elshrouq
{
    public partial class show_books : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader dr;
        public DataTable dt;
        public show_books()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
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
                        lbl2_m.Text = ",مرحبا       " + name;
                        string sessionValue = Session["admin_"].ToString();
                        lbl_m.Text = "الكود الخاص بك هو    " + sessionValue;
                    }

                }





            }
            if (!IsPostBack)
            {
                fill_ayada();

            }
        }
        protected void clinic_SelectedIndexChanged(object sender, EventArgs e)
        {

                fill_doc();
        }

        protected void fill_ayada()
        {


            dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT name  FROM hos_ayada", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    clinic.DataSource = dt;
                    clinic.DataTextField = "name";
                    clinic.DataValueField = "name";
                    clinic.DataBind();
                    clinic.Items.Insert(0, new ListItem("اختار عيادة", "0"));
                }
            }


        }
        protected void fill_doc()
        {
            dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectedClinicValue = clinic.SelectedValue.ToString();
                SqlCommand cmd = new SqlCommand("SELECT name, code FROM hos_doctor where m_name= @clinic", con);

                cmd.Parameters.AddWithValue("@clinic", clinic.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    string code = dt.Rows[0]["code"].ToString();
                    Session["code"] = code;
                    doc.DataSource = dt;
                    doc.DataTextField = "name";
                    doc.DataValueField = "name";

                    doc.DataBind();
                    doc.Items.Insert(0, new ListItem("اختار دكتور", "0"));


                }

            }
        }
        protected void doc_SelectedIndexChanged(object sender, EventArgs e)
        {
           books.Visible = true;
            load_data();
        }





        public DataTable load_data()
        {
            DataTable dt = new DataTable();

            if (!string.IsNullOrEmpty(doc.SelectedValue) && !string.IsNullOrEmpty(clinic.SelectedValue))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT sick_n, sick_code, mob, spec_n, book_date, day, internet_, user_n, rem_, book_time, contract_cash, company FROM tem_esl_dis_book WHERE doc_n = @doctor AND eada_n = @clinic ORDER BY book_date", con);
                    cmd.Parameters.AddWithValue("@clinic", clinic.SelectedValue);
                    cmd.Parameters.AddWithValue("@doctor", doc.SelectedValue);

                    try
                    {
                        con.Open();
                        dt.Load(cmd.ExecuteReader());

                        // Format the 'book_date' column
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["book_date"] != DBNull.Value && row["book_date"] is DateTime)
                            {
                                DateTime selectedDate = ((DateTime)row["book_date"]).Date;
                                row["book_date"] = selectedDate.ToString("yyyy-MM-dd");
                            }
                        }

                        books.DataSource = dt;
                        books.DataBind();
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return dt;
        }





    }
}