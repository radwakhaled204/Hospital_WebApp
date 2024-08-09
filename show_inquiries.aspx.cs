using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.ComponentModel;

namespace Royal_Elshrouq
{
    public partial class show_inquiries : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader dr;
        public DataTable dt;

        public show_inquiries()
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



        protected void inquries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string sickCode = DataBinder.Eval(e.Row.DataItem, "sick_code").ToString();


                string query = "SELECT inquiry_respond FROM hos_sick WHERE sick_code = @SickCode";

                using (SqlConnection con = new SqlConnection(connectionString))

                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@SickCode", sickCode);
                        object result = command.ExecuteScalar();

         
                        if (result != null && result != DBNull.Value)
                        {
      
                            Label lbl_respond = (Label)e.Row.FindControl("lbl_respond");
                            lbl_respond.Visible = true;

                            Button ReplyButton = (Button)e.Row.FindControl("ReplyButton");
                            ReplyButton.Visible = false;
                        }
                        else
                        {
                    
                            Label lbl_respond = (Label)e.Row.FindControl("lbl_respond");
                            lbl_respond.Visible = false;

                            Button ReplyButton = (Button)e.Row.FindControl("ReplyButton");
                            ReplyButton.Visible = true;
                        }
                    }
                }
            }
        }
        protected void ReplyButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string sickCode = btn.CommandArgument;

            string encodedSickCode = Server.UrlEncode(sickCode);

            Response.Redirect("respond_inquiry.aspx?sick_code=" + encodedSickCode);
        }

        public DataTable load_data()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT n1, sick_code, mob1, inquiry, inquiry_date FROM hos_sick WHERE inquiry IS NOT NULL AND inquiry <> '' ORDER BY inquiry_date DESC", con);

                try
                {
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    inquries.DataSource = dt;
                    inquries.DataBind();
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