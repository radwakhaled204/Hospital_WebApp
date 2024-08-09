using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Newtonsoft.Json.Linq;
using PdfSharp.Pdf.IO;

namespace Royal_Elshrouq
{
    public partial class _interface : System.Web.UI.MasterPage
    {
        private string connectionString;
        public SqlCommand cmd;
        DataTable dt;
        public int v_code = 1;
        string sql = "";
        public SqlDataReader dr;
        public _interface()
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
            if (Session["SelectedDoctor"] != null)
            {
         
                doc.Items.Clear();
                Session.Remove("SelectedDoctor");
            }

            if (!IsPostBack)
            {
                DataTable dt = data();
                if (dt.Rows.Count > 0)
                {


                    byte[] imageData = dt.Rows[0]["hos_logo1"] as byte[];
                    byte[] imageData2 = dt.Rows[0]["hos_logo2"] as byte[];
                    byte[] imageData3 = dt.Rows[0]["hos_img"] as byte[];

                    byte[] imageData4 = dt.Rows[0]["ist_logo1"] as byte[];
                    byte[] imageData5 = dt.Rows[0]["ist_logo2"] as byte[];
                    byte[] imageData6 = dt.Rows[0]["ist_img"] as byte[];
                    if (imageData != null && imageData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            string base64String = Convert.ToBase64String(imageData);
                            logo1.ImageUrl = "data:image/png;base64," + base64String;
                        }
                    }

                    if (imageData2 != null && imageData2.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData2))
                        {
                            string base64String = Convert.ToBase64String(imageData2);
                            logo2.ImageUrl = "data:image/png;base64," + base64String;
                        }
                    }
                    if (imageData3 != null && imageData3.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData3))
                        {
                            string base64String = Convert.ToBase64String(imageData3);
                            h_img.ImageUrl = "data:image/png;base64," + base64String;
                        }
                    }

                    if (imageData4 != null && imageData4.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData4))
                        {
                            string base64String = Convert.ToBase64String(imageData4);
                            ist_logo1.ImageUrl = "data:image/png;base64," + base64String;
                        }
                    }
                    if (imageData5 != null && imageData5.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData5))
                        {
                            string base64String = Convert.ToBase64String(imageData5);
                            ist_logo2.ImageUrl = "data:image/png;base64," + base64String;
                        }
                    }

                    if (imageData6 != null && imageData6.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData6))
                        {
                            string base64String = Convert.ToBase64String(imageData6);
                            ist_img.ImageUrl = "data:image/png;base64," + base64String;
                        }
                    }
                }
                fill_about();
                fill_floor();
                fill_ayada();          



                SetSocialLink(face, "h_icon1");
                SetSocialLink(X, "h_icon2");
                SetSocialLink(link, "h_icon3");
                SetSocialLink(inst, "h_icon4");
                SetSocialLink(yt, "h_icon5");
                SetSocialLink(whats, "h_icon6");
                SetSocialLink(f_face, "ist_icon1");
                SetSocialLink(f_link, "ist_icon2");
                SetSocialLink(f_X, "ist_icon3");
                SetSocialLink(f_inst, "ist_icon4");
                SetSocialLink(f_yt, "ist_icon5");
                SetSocialLink(f_whats, "ist_icon6");

            }


        }

        protected void doc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doc.SelectedValue != null && !string.IsNullOrEmpty(doc.SelectedValue))
            {
                Session["SelectedDoctor"] = doc.SelectedValue;

                if (IsPostBack && ((DropDownList)sender).ID == "doc")
                {
                    Response.Redirect("show_video.aspx");
                }
            }
        }

        protected void fill_ayada()
        {
            try
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
                        ayada.DataSource = dt;
                        ayada.DataTextField = "name";
                        ayada.DataValueField = "name";
                        ayada.DataBind();
                        ayada.Items.Insert(0, new System.Web.UI.WebControls.ListItem("العيادات", string.Empty));
                    }
                }
            }
            catch (Exception ex)
            {

                Response.Write($"<script>alert('حدث خطأ: {ex.Message}');</script>");
            }

        }

        protected void fill_floor()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT name FROM hos_floor", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        floor.DataSource = dt;
                        floor.DataTextField = "name";
                        floor.DataValueField = "name";
                        floor.DataBind();
                        floor.Items.Insert(0, new System.Web.UI.WebControls.ListItem("الادوار", string.Empty));
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write($"<script>alert('حدث خطأ: {ex.Message}');</script>");
            }
        }
        protected void fill_about()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT info_aboutus FROM about_us", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        about.DataSource = dt;
                        about.DataTextField = "info_aboutus";
                        about.DataValueField = "info_aboutus";
                        about.DataBind();
                        about.Items.Insert(0, new System.Web.UI.WebControls.ListItem("عننا", string.Empty));
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write($"<script>alert('حدث خطأ: {ex.Message}');</script>");
            }
        }

        protected void fill_rooms()
        {
            try
            {
                dt = new DataTable();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Parameters.Clear();
                    sql = "SELECT name FROM hos_rom WHERE flo = @floor";
                    cmd.Parameters.AddWithValue("@floor", floor.SelectedValue.ToString());

                    cmd.Connection = con;
                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        room.DataSource = dt;
                        room.DataTextField = "name";
                        room.DataValueField = "name";
                        room.DataBind();
                        room.Items.Insert(0, new System.Web.UI.WebControls.ListItem("الغرف", string.Empty));
                    }
                    else
                    {
                        room.Items.Clear();
                        room.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- لا توجد غرف --", string.Empty));
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('حدث خطأ: {ex.Message}');</script>");
            }
        }

        protected void fill_doc()
        {
            try
            {
                dt = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string selectedClinicValue = ayada.SelectedValue.ToString();
                    SqlCommand cmd = new SqlCommand("SELECT name FROM hos_doctor where m_name= @clinic", con);
                    cmd.Parameters.AddWithValue("@clinic", selectedClinicValue);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();

                    if (dt.Rows.Count > 0)
                    {
                        doc.DataSource = dt;
                        doc.DataTextField = "name";
                        doc.DataValueField = "name";
                        doc.DataBind();
                        doc.Items.Insert(0, new System.Web.UI.WebControls.ListItem("الدكاترة", string.Empty));
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('حدث خطأ: {ex.Message}');</script>");
            }

        }
       
        protected void about_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void floor_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_rooms();
        }
        protected void ayada_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_doc();
        }




    }
}
