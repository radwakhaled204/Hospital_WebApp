using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Royal_Elshrouq
{
    public partial class master3 : System.Web.UI.MasterPage
    {
        private string connectionString;
        public SqlCommand cmd;
        DataTable dt;
        public int v_code = 1;
        string sql = "";
        public SqlDataReader dr;
        public master3()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }



        private void SetSocialLink(HyperLink socialLink, string columnName)
        {
            DataTable dt = data();

            if (dt.Rows.Count > 0)
            {
                string socialLinkUrl = dt.Rows[0][columnName] as string;

                if (!string.IsNullOrEmpty(socialLinkUrl))
                {
                    socialLink.NavigateUrl = socialLinkUrl;
                    socialLink.Visible = true;
                }
                else
                {
                    socialLink.Visible = false;
                }
            }
            else
            {
                socialLink.Visible = false;
            }
        }


        private DataTable data()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                sql = "SELECT hos_logo1, hos_logo2  , hos_img,h_icon1,h_icon2,h_icon3,h_icon4,h_icon5,h_icon6 ,ist_logo1,ist_logo2 ,ist_img  ,ist_icon1,ist_icon2,ist_icon3,ist_icon4,ist_icon5,ist_icon6 FROM links where code = 1";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataTable dt = data();
                if (dt.Rows.Count > 0)
                {


                    byte[] imageData = dt.Rows[0]["hos_logo1"] as byte[];

                    if (imageData != null && imageData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            string base64String = Convert.ToBase64String(imageData);
                            logo1.ImageUrl = "data:image/png;base64," + base64String;
                        }
                    }


                    SetSocialLink(face, "h_icon1");
                    SetSocialLink(X, "h_icon2");
                    SetSocialLink(link, "h_icon3");
                    SetSocialLink(inst, "h_icon4");
                    SetSocialLink(yt, "h_icon5");
                    SetSocialLink(whats, "h_icon6");
                }


            }


        }


    }

}