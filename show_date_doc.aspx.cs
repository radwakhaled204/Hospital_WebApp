using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Royal_Elshrouq
{
    public partial class show_date_doc : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader r;
        public DataTable dt;
        public show_date_doc()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill_ayada();


            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "";
                string searchTerm = searchBox.Text;

                if (!string.IsNullOrEmpty(searchTerm))
                {
                  
                    sql = "SELECT name FROM hos_doctor WHERE name LIKE @searchTerm";
                }
                else
                {
                    string selectedClinic = clinic.SelectedValue;
                    string selectedDoctor = doc.SelectedValue;

                    if (!string.IsNullOrEmpty(selectedClinic) && !string.IsNullOrEmpty(selectedDoctor))
                    {
                        sql = "SELECT name, code FROM hos_doctor WHERE m_name = @clinic AND name = @doc";

                    }
                    else
                    {
                        lbl_message.Text = "الرجاء اختيار العيادة والدكتور.";
                        return;
                    }
                }

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@searchTerm", "'%" + searchTerm + "%'");
                cmd.Parameters.AddWithValue("@clinic", clinic.SelectedValue);
                cmd.Parameters.AddWithValue("@doc", doc.SelectedValue);
                

                con.Open();
                r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        string code = r["code"].ToString();
                        Session["code"] = code;
                        if (!string.IsNullOrEmpty(code))
                        {
                            DataTable dt = Getdt(code);

                            if (dt.Rows.Count > 0)
                            {
                                img.Visible = true;
                                vid.Visible = true;
                                day1.Text = dt.Rows[0]["day1_1"].ToString();
                                day2.Text = dt.Rows[0]["day1_2"].ToString();
                                day3.Text = dt.Rows[0]["day1_3"].ToString();
                                day4.Text = dt.Rows[0]["day1_4"].ToString();
                                day5.Text = dt.Rows[0]["day1_5"].ToString();
                                day6.Text = dt.Rows[0]["day1_6"].ToString();
                                day7.Text = dt.Rows[0]["day1_7"].ToString();

                               
                                byte[] imageData = (byte[])dt.Rows[0]["pic"];
                                if (imageData != null && imageData.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        img.Src= "data:image/jpeg;base64," + Convert.ToBase64String(ms.ToArray());
                                    }
                                }

                                // Display video
                                string videoLink = dt.Rows[0]["video_link"].ToString();
                                if (!string.IsNullOrEmpty(videoLink))
                                {
                                    vid.Attributes["src"] = videoLink;
                                    vid.Attributes["width"] = "640";
                                    vid.Attributes["height"] = "360";
                                    vid.Controls.Add(new LiteralControl("<track label='English' kind='subtitles' srclang='en' src='" + videoLink.Replace("mp4", "vtt") + "' default></track>"));
                                }
                            }
                        
                    
                
                        }
                    }
                }
                else
                {
                  
                    lbl_message.Text = "لم يتم العثور على نتائج.";
                }

                con.Close();
            }
        }



        private DataTable Getdt(string code)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT day1_1,day1_2 , day1_3, day1_4, day1_5,day1_6,day1_7 ,pic ,video_link FROM hos_doctor WHERE code = @code";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@code", code);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
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
                SqlCommand cmd = new SqlCommand("SELECT name FROM hos_doctor where m_name= @clinic", con);

                cmd.Parameters.AddWithValue("@clinic", clinic.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
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













