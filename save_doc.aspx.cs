using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iText.IO.Image;


namespace Royal_Elshrouq

{
    public partial class save_doc : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader dr;
        public DataTable dt;
        public save_doc()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }
        
        string up_text = "";
        string sql = "";
        string fileName = "";
        string filePath = "";
        byte[] imageData = null;










        protected void Save_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand(sql, con);

            

                if (doc.SelectedValue != null)
                {

                    if (up_text == "")

                        up_text = " name = @doc  ";

                    else
                        up_text = up_text + " ,  name = @doc  ";

                }


                if (clinic.SelectedValue != null)
                {

                    if (up_text == "")

                        up_text = " m_name = @clinic  ";


                    else
                        up_text = up_text + " , m_name  = @clinic  ";

                }

                if (fri_from.Text != null)
                {

                    if (up_text == "")

                        up_text = " day1_from = @day1_from  ";


                    else
                        up_text = up_text + " , day1_from = @day1_from  ";

                }
                if (fri_to.Text != null)
                {

                    if (up_text == "")

                        up_text = " day1_to = @day1_to  ";


                    else
                        up_text = up_text + " , day1_to = @day1_to  ";

                }

                if (sat_from.Text != null)
                {

                    if (up_text == "")

                        up_text = " day2_from = @day2_from  ";


                    else
                        up_text = up_text + " , day2_from = @day2_from  ";

                }
                if (sat_to.Text != null)
                {

                    if (up_text == "")

                        up_text = " day2_to = @day2_to  ";


                    else
                        up_text = up_text + " , day2_to = @day2_to  ";

                }
                if (sun_from.Text != null)
                {

                    if (up_text == "")

                        up_text = " day3_from = @day3_from  ";


                    else
                        up_text = up_text + " , day3_from = @day3_from  ";

                }
                if (sun_to.Text != null)
                {

                    if (up_text == "")

                        up_text = " day3_to = @day3_to  ";


                    else
                        up_text = up_text + " , day3_to = @day3_to  ";

                }
                if (mon_from.Text != null)
                {

                    if (up_text == "")

                        up_text = " day4_from = @day4_from  ";


                    else
                        up_text = up_text + " , day4_from = @day4_from  ";

                }
                if (mon_to.Text != null)
                {

                    if (up_text == "")

                        up_text = " day4_to = @day4_to  ";


                    else
                        up_text = up_text + " , day4_to = @day4_to  ";

                }
                if (tues_from.Text != null)
                {

                    if (up_text == "")

                        up_text = " day5_from = @day5_from  ";


                    else
                        up_text = up_text + " , day5_from = @day5_from  ";

                }
                if (tues_to.Text != null)
                {

                    if (up_text == "")

                        up_text = " day5_to = @day5_to  ";


                    else
                        up_text = up_text + " , day5_to = @day5_to  ";

                }
                if (wed_from.Text != null)
                {

                    if (up_text == "")

                        up_text = " day6_from = @day6_from  ";


                    else
                        up_text = up_text + " , day6_from = @day6_from  ";

                }
                if (wed_to.Text != null)
                {

                    if (up_text == "")

                        up_text = " day6_to = @day6_to  ";


                    else
                        up_text = up_text + " , day6_to = @day6_to  ";

                }
                if (thures_from.Text != null)
                {

                    if (up_text == "")

                        up_text = " day7_from = @day7_from  ";


                    else
                        up_text = up_text + " , day7_from = @day7_from  ";

                }
                if (thures_to.Text != null)
                {

                    if (up_text == "")

                        up_text = " day7_to = @day7_to  ";


                    else
                        up_text = up_text + " , day7_to = @day7_to  ";

                }

                if (vid.HasFile)
                {
                         
                         fileName = Path.GetFileName(vid.FileName);
                         filePath = Path.Combine("~/FILES/", Guid.NewGuid().ToString() + Path.GetExtension(fileName));
                         vid.SaveAs(Server.MapPath(filePath));


                       if (up_text == "")
                       {
                           up_text = "video_link = @vid";
                       }
                       else
                       {
                           up_text = up_text + " ,video_link = @vid";
                       }
                }

                if (img.HasFile)
                {
                    imageData = img.FileBytes;


                    if (up_text == "")
                    {
                        up_text = "pic = @pic";
                    }
                    else
                    {
                        up_text = up_text + " ,pic = @pic";
                    }
                }
                string notevalue  = notes.Value;
                if (notevalue != null)
                {

                    if (up_text == "")

                        up_text = " doc_info = @doc_info  ";


                    else
                        up_text = up_text + " , doc_info = @doc_info  ";

                }
                if (up_text != "")
                {
                    sql = "update hos_doctor set " + up_text + " where  code = @code";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@doc", doc.SelectedValue);
                    cmd.Parameters.AddWithValue("@clinic", clinic.SelectedValue);
                    cmd.Parameters.AddWithValue("@day1_from", fri_from.Text);
                    cmd.Parameters.AddWithValue("@day1_to", fri_to.Text);
                    cmd.Parameters.AddWithValue("@day2_from", sat_from.Text);
                    cmd.Parameters.AddWithValue("@day2_to", sat_to.Text);
                    cmd.Parameters.AddWithValue("@day3_from", sun_from.Text);
                    cmd.Parameters.AddWithValue("@day3_to", sun_to.Text);
                    cmd.Parameters.AddWithValue("@day4_from", mon_from.Text);
                    cmd.Parameters.AddWithValue("@day4_to", mon_to.Text);
                    cmd.Parameters.AddWithValue("@day5_from", tues_from.Text);
                    cmd.Parameters.AddWithValue("@day5_to", tues_to.Text);
                    cmd.Parameters.AddWithValue("@day6_from", wed_from.Text);
                    cmd.Parameters.AddWithValue("@day6_to", wed_to.Text);
                    cmd.Parameters.AddWithValue("@day7_from", thures_from.Text);
                    cmd.Parameters.AddWithValue("@day7_to", thures_to.Text);
                    cmd.Parameters.AddWithValue("@doc_info", notevalue);
                    cmd.Parameters.AddWithValue("@vid", filePath);
                    cmd.Parameters.AddWithValue("@pic", imageData);
                    cmd.Parameters.AddWithValue("@code", Session["code"].ToString());

                    con.Open();
                    cmd.ExecuteNonQuery();



                    con.Close();
                    lbl_message.Text = "تم التخزين بنجاح";


                }
                else
                {
                    lbl_message.Text = "يجب تسجيل بيان واحد على الاقل";
                    goto pp1;
                }

            }
        pp1:;

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
                
                    if (img.HasFile && vid.HasFile)
                    {

                                    vid_preview.Visible = true;
                                    string filePath = Path.Combine(Server.MapPath("~/FILES"), vid.FileName);
                                    vid.SaveAs(filePath);

                                     
                                      img_preview.Visible = true;
                                      vid_preview.Attributes["src"] = ResolveUrl("~/FILES/" + vid.FileName);

                                      img_preview.ImageUrl = $"data:image/jpeg;base64,{Convert.ToBase64String(img.FileBytes)}";

                    }
                
        
                
      
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


        /*[System.Web.Script.Services.ScriptMethod()]

        [System.Web.Services.WebMethod]
        public static List<string> GetItemName(string prefix)
        {
             List<string> docname= new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                prefix = prefix.Trim();
                if (!prefix.Equals(string.Empty))
                    prefix = prefix + "%";
                SqlCommand cmd = new SqlCommand("SELECT name FROM hos_doctor where name like N'" + prefix + "'", con);
                SqlDataReader dr =cmd.ExecuteReader();
                while(dr.Read())
                {
                    docname.Add(dr["name"].ToString());
                }
                con.Close();    
                return docname;
            }
        }*/
    }
}


    
        
    

