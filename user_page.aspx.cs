using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Org.BouncyCastle.Crypto.Generators;

namespace Royal_Elshrouq
{
    public partial class user_page : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader dr;
        public user_page()
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
        }

       /* private void Checksession()
        {
          
                if (Session["_admin"] != null && (int)Session["_admin"] == 2)
                {
                   Response.Redirect("signup.aspx");
                }

                else
                {
                    ShowAlert();
                }
            
        }
        private void ShowAlert()
        {
            string script = "alert('غير مسموح لك الوصول الى هذه الصفحة');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script,false);
            
        }*/
    }
}