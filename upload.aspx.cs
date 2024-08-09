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
    public partial class upload : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader dr;
        public DataTable dt;
        public upload()
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

    }
}