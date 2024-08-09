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
    public partial class show_complaint : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader dr;
        public DataTable dt;
        public show_complaint()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                load_data();

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
                        lbl2_m.Text = ",مرحبا       " + name;
                        string sessionValue = Session["admin_"].ToString();
                        lbl_m.Text = "الكود الخاص بك هو    " + sessionValue;
                    }

                }





            }
        }
        public DataTable load_data()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT n1, sick_code, mob1, complaint,complaint_date FROM hos_sick WHERE complaint IS NOT NULL AND complaint <> '' ORDER BY  complaint_date", con);

                try
                {
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    complaints.DataSource = dt;
                    complaints.DataBind();
                }
                finally
                {
                    con.Close();
                }
            }

            return dt;
        }
    }
}