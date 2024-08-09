using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using iText.IO.Image;
using Org.BouncyCastle.Asn1.X509;
using static System.Net.Mime.MediaTypeNames;
using static Org.BouncyCastle.Utilities.Test.FixedSecureRandom;

namespace Royal_Elshrouq
{
    public partial class save_links : System.Web.UI.Page
    {

        private string connectionString;
        public SqlDataReader r;
        public SqlCommand cmd;
        DataTable dt;
        public int v_code = 1;
        string sql = "";



        public save_links()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }





        protected void ist_update(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                byte[] imageData4 = null;
                byte[] imageData5 = null;
                byte[] imageData6 = null;


                if (ist_logo1.HasFile)
                {
                    imageData4 = ist_logo1.FileBytes;

                }
                if (ist_logo2.HasFile)
                {

                    imageData5 = ist_logo2.FileBytes;
                }

                if (ist_img.HasFile)
                {

                    imageData6 = ist_img.FileBytes;
                }

                   sql = "UPDATE links SET ist_logo1=@ist_logo1, ist_logo2=@ist_logo2, " +
                          "ist_img=@ist_img, ist_icon1=@ist_icon1, ist_icon2=@ist_icon2, ist_icon3=@ist_icon3, " +
                          "ist_icon4=@ist_icon4, ist_icon5=@ist_icon5, ist_icon6=@ist_icon6 WHERE code = 1";
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@ist_logo1", imageData4);
                cmd.Parameters.AddWithValue("@ist_logo2", imageData5);
                cmd.Parameters.AddWithValue("@ist_img", imageData6);

                cmd.Parameters.AddWithValue("@ist_icon1", ist_lnk_f.Text);
                cmd.Parameters.AddWithValue("@ist_icon2", ist_lnk_linked.Text);
                cmd.Parameters.AddWithValue("@ist_icon3", ist_lnk_x.Text);
                cmd.Parameters.AddWithValue("@ist_icon4", ist_lnk_inst.Text);
                cmd.Parameters.AddWithValue("@ist_icon5", ist_lnk_yt.Text);
                cmd.Parameters.AddWithValue("@ist_icon6", ist_lnk_whats.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



                ist_lbl.Text = "تم التحديث بنجاح";



            }
        }

        protected void hos_update(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                byte[] imageData = null;
                byte[] imageData2 = null;
                byte[] imageData3 = null;

                if (logo1.HasFile)
                {
                    imageData = logo1.FileBytes;

                }

                if (logo2.HasFile)
                {

                    imageData2 = logo2.FileBytes;
                }
                if (hos_img.HasFile)
                {
                    imageData3 = hos_img.FileBytes;

                }

                sql = "UPDATE links SET hos_logo1=@hos_logo1, hos_logo2=@hos_logo2, hos_img=@hos_img, " +
                         "h_icon1=@h_icon1, h_icon2=@h_icon2, h_icon3=@h_icon3, h_icon4=@h_icon4, " +
                         "h_icon5=@h_icon5, h_icon6=@h_icon6 WHERE code = 1";


                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@hos_logo1", imageData);
                cmd.Parameters.AddWithValue("@hos_logo2", imageData2);
                cmd.Parameters.AddWithValue("@hos_img", imageData3);
                cmd.Parameters.AddWithValue("@h_icon1", lnk_f.Text);
                cmd.Parameters.AddWithValue("@h_icon2", lnk_linked.Text);
                cmd.Parameters.AddWithValue("@h_icon3", lnk_x.Text);
                cmd.Parameters.AddWithValue("@h_icon4", lnk_inst.Text);
                cmd.Parameters.AddWithValue("@h_icon5", lnk_yt.Text);
                cmd.Parameters.AddWithValue("@h_icon6", lnk_whats.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



                hos_lbl.Text = "تم التحديث بنجاح";
            }
        }
    }
}