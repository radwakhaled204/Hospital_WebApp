using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
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
    public partial class patient_info : System.Web.UI.Page
    {


        private string connectionString;
        public SqlDataReader dr;
        public patient_info()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }
  /**********************************************NUMIRIC FUN********************************************************************/

        private bool IsNumeric(string str)
        {
            foreach (char s in str)
            {
                if (!char.IsDigit(s))
                {
                    return false;
                }
            }
            return true;
        }
/**********************************************PERCENTAGE FUN********************************************************************/
        protected void CalculatePercentage(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pat_per.Text))
            {
                sup_per.Text = "";
                return;
            }

            int percentage1 = Convert.ToInt32(pat_per.Text);
            int percentage2 = 100 - percentage1;
            sup_per.Text = percentage2.ToString();

        }
 /**********************************************INFO CLICK********************************************************************/

        protected void info_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                byte[] imageData = null;
                byte[] imageData2= null;
                byte[] imageData3= null;

                string sql = "";

                SqlCommand cmd = new SqlCommand(sql, con);


   /****************************CARD VALIDATION********************************************************************/
               
                if (nation.SelectedValue == "اجنبى")
                {

                    if (string.IsNullOrWhiteSpace(gaz.Text))
                    {
                        lbl_message.Text = "يرجى إدخال رقم الجواز";
                        return;
                    }


                }

                else if (nation.SelectedValue == "مصرى")
                {
                    string cardNumber = card.Text;

                    if (string.IsNullOrWhiteSpace(card.Text))
                    {
                        lbl_message.Text = "يرجى إدخال رقم البطاقة";
                        return;
                    }

                    else if (!IsNumeric(cardNumber))
                    {
                        lbl_message.Text = "رقم البطاقة يجب ان يحتوى على ارقام من 0 الى 9 ";
                        return;
                    }
                    else 
                    {
                      
                        if (cardNumber.Length != 14)
                        {
                            lbl_message.Text = "رقم البطاقة يجب أن يكون 14 رقمًا";
                            return;
                        }
                    }


                }
                else
                {
                    lbl_message.Text = "يرجى ادخال رقم البطاقة او الجواز";
                    return;
                }

   /****************************WHATS VALIDATION********************************************************************/

                string IfExist = "select count(*) from hos_sick where wats = @wats ";
                SqlCommand check = new SqlCommand(IfExist, con);
                check.Parameters.AddWithValue("@wats", whats.Text);

                con.Open();
                int count = (int)check.ExecuteScalar();
                con.Close();
  
                if (string.IsNullOrWhiteSpace(whats.Text))
                {
                    lbl_message.Text = "يرجى إدخال رقم واتس";
                    return;
                }

                string phoneno = whats.Text;

                if (!IsNumeric(phoneno))
                {
                        lbl_message.Text = "رقم الواتس يجب ان يحتوى على ارقام من 0 الى 9 ";
                        return;
                }
                if (nation.SelectedValue == "مصرى")
                {

                    string pattern = "^(011|012|010|015)";
                    bool isValidPrefix = Regex.IsMatch(phoneno, pattern);

                    if (!isValidPrefix)
                    {
                        lbl_message.Text = "رقم الواتس يجب أن يبدأ بـ 011 أو 012 أو 010 أو 015";
                        return;
                    }


                    else if (phoneno.Length != 11)

                    {
                        lbl_message.Text = "رقم الواتس يجب ان يكون 11 رقم ";
                        return;
                    }
                }

                /**********************************************UPDATE ********************************************************************/

                string up_text = "";
                            
                if (nation.SelectedValue != null)
                {

                  if (up_text == "")
                                  
                  up_text = " nat = @nat  ";
                                   
                   else
                   up_text = up_text + " ,  nat = @nat  ";
                                   
                } 
                        

                if (gaz.Text != null)
                {

                        if (up_text == "")
                        
                        up_text = " gaz1 = @gaz1  ";


                        else
                            up_text = up_text + " , gaz1 = @gaz1  ";
                        
                }

                if (card.Text != null)
                {

                    if (up_text == "")
                    
                        up_text = " crd1 = @crd1  ";


                    else
                            up_text = up_text + " ,  crd1 = @crd1  ";
                    
                }




                if (city.SelectedValue != null)
                {

                        if (up_text == "")
                        
                            up_text = " city = @city  ";


                        else
                                up_text = up_text + ", city = @city  ";
                        
                }


                if (gov.SelectedValue != null)
                {

                    if (up_text == "")

                        up_text = " gov = @gov  ";


                    else
                        up_text = up_text + ", gov = @gov  ";

                }
                if (address.Text != null)
                {

                    if (up_text == "")

                        up_text = " addr = @addr  ";


                    else
                        up_text = up_text + " ,  addr = @addr  ";

                }
                if (tam_n.Text != null)
                {

                    if (up_text == "")

                        up_text = " tam_no = @tam_no  ";


                    else
                        up_text = up_text + " ,  tam_no = @tam_no  ";

                }
                if (doc_n.Text != null)
                {

                    if (up_text == "")

                        up_text = " document_no = @document_no ";


                    else
                        up_text = up_text + " , document_no = @document_no  ";

                }
                if (c_n.SelectedValue != null)
                {

                    if (up_text == "")

                        up_text = " comp_n = @comp_n ";


                    else
                        up_text = up_text + " ,comp_n = @comp_n  ";

                }
   
                if (b_n.SelectedValue != null)
                {

                    if (up_text == "")

                        up_text = " book_n = @book_n ";


                    else
                        up_text = up_text + " ,book_n = @book_n  ";

                }
                if (memb_n.Text != null)
                {

                    if (up_text == "")

                        up_text = "  memb_no = @memb_no ";


                    else
                        up_text = up_text + " , memb_no = @memb_no  ";

                }
                if (dos_n.Text != null)
                {

                    if (up_text == "")

                        up_text = " dos_no = @dos_no ";


                    else
                        up_text = up_text + " ,dos_no = @dos_no  ";

                }
                if (raf_n.Text != null)
                {

                    if (up_text == "")

                        up_text = " raf_no = @raf_no ";


                    else
                        up_text = up_text + " ,raf_no = @raf_no ";

                }
                if (job.Text != null)
                {

                    if (up_text == "")

                        up_text = " jop_n = @jop_n ";


                    else
                        up_text = up_text + " ,jop_n = @jop_n ";

                }
                if (work.Text != null)
                {

                    if (up_text == "")

                        up_text = " work_n = @work_n ";


                    else
                        up_text = up_text + " ,work_n = @work_n ";

                }

                if (sick_type.SelectedValue != null)
                {

                    if (up_text == "")

                        up_text = "  sick_type = @sick_type ";


                    else
                        up_text = up_text + " , sick_type = @sick_type ";

                }

                if (whats.Text != null)
                {

                    if (up_text == "")

                        up_text = "  wats = @wats ";


                    else
                        up_text = up_text + " ,  wats = @wats ";

                }

                if (face.Text != null)
                {

                    if (up_text == "")

                        up_text = "  face = @face ";


                    else
                        up_text = up_text + " , face = @face ";

                }

                if (txtEmail.Text != null)
                {

                    if (up_text == "")

                        up_text = "   mail = @mail ";


                    else
                        up_text = up_text + " ,  mail = @mail ";

                }

                if (sex.SelectedValue != null)
                {

                    if (up_text == "")

                        up_text = "  sex = @sex ";


                    else
                        up_text = up_text + " , sex = @sex ";

                }
                if (pat_per.Text != null)
                {

                    if (up_text == "")

                        up_text = "  pat_per = @pat_per ";


                    else
                        up_text = up_text + " , pat_per = @pat_per ";

                }


                if (p_pic.HasFile)
                {
                    imageData = p_pic.FileBytes;


                    if (up_text == "")
                    {
                        up_text = "p_pic = @p_pic";
                    }
                    else
                    {
                        up_text = up_text + " ,p_pic = @p_pic";
                    }
                }



                if (pic.HasFile)
                {
  
                    imageData2 = pic.FileBytes;

                    if (up_text == "")
                    {
                        up_text = "pic = @pic";
                    }
                    else
                    {
                        up_text = up_text + " ,pic = @pic";
                    }
                }

                if (card_pic.HasFile)
                {
                    imageData3 = card_pic.FileBytes;
       

                    if (up_text == "")
                    {
                        up_text = "card_pic = @card_pic";
                    }
                    else
                    {
                        up_text = up_text + " ,card_pic = @card_pic";
                    }
                }


                if (up_text != "")
                    {
                    sql = "update hos_sick set " + up_text + " where  sick_code = @sick_code";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@nat", nation.SelectedValue);
                    cmd.Parameters.AddWithValue("@crd1", card.Text);
                    cmd.Parameters.AddWithValue("@gaz1", gaz.Text);
                    cmd.Parameters.AddWithValue("@gov", gov.SelectedValue);
                    cmd.Parameters.AddWithValue("@city", city.SelectedValue);
                    cmd.Parameters.AddWithValue("@addr", address.Text);
                    cmd.Parameters.AddWithValue("@tam_no", tam_n.Text);
                    cmd.Parameters.AddWithValue("@document_no", doc_n.Text);
                    cmd.Parameters.AddWithValue("@comp_n", c_n.SelectedValue);
                    cmd.Parameters.AddWithValue("@book_n", b_n.SelectedValue);
                    cmd.Parameters.AddWithValue("@memb_no", memb_n.Text);
                    cmd.Parameters.AddWithValue("@dos_no", dos_n.Text);
                    cmd.Parameters.AddWithValue("@raf_no", raf_n.Text);
                    cmd.Parameters.AddWithValue("@jop_n", job.Text);
                    cmd.Parameters.AddWithValue("@work_n", work.Text);
                    cmd.Parameters.AddWithValue("@wats", whats.Text);
                    cmd.Parameters.AddWithValue("@face", face.Text);
                    cmd.Parameters.AddWithValue("@mail", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@sick_type", sick_type.SelectedValue);
                    cmd.Parameters.AddWithValue("@sex", sex.SelectedValue);
                    cmd.Parameters.AddWithValue("@pat_per", pat_per.Text);
                    cmd.Parameters.AddWithValue("@sup_per", sup_per.Text);
                    cmd.Parameters.AddWithValue("@card_pic", imageData3);
                    cmd.Parameters.AddWithValue("@p_pic", imageData);
                    cmd.Parameters.AddWithValue("@pic", imageData2);
                    cmd.Parameters.AddWithValue("@sick_code", Session["sick_code"].ToString());
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
  /**********************************************PAGE LOAD********************************************************************/

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

                string sickcode = Session["sick_code"]?.ToString();

                if (!string.IsNullOrEmpty(sickcode))
                {

                    DataTable dt = Getdt(sickcode);

                    if (dt.Rows.Count > 0)
                    {
                        Im_p_pic.Visible = true;
                        Im_pic.Visible = true;
                        Im_card_pic.Visible = true;
                        gaz.Text = dt.Rows[0]["gaz1"].ToString();
                        whats.Text = dt.Rows[0]["wats"].ToString();
                        card.Text = dt.Rows[0]["crd1"].ToString();
                        gov.SelectedValue = dt.Rows[0]["gov"].ToString();
                        city.SelectedValue = dt.Rows[0]["city"].ToString();
                        address.Text = dt.Rows[0]["addr"].ToString();
                        tam_n.Text = dt.Rows[0]["tam_no"].ToString();
                        doc_n.Text = dt.Rows[0]["document_no"].ToString();
                        c_n.SelectedValue = dt.Rows[0]["comp_n"].ToString();
                        b_n.SelectedValue = dt.Rows[0]["book_n"].ToString();
                        memb_n.Text = dt.Rows[0]["memb_no"].ToString();
                        dos_n.Text = dt.Rows[0]["dos_no"].ToString();
                        raf_n.Text = dt.Rows[0]["raf_no"].ToString();
                        job.Text = dt.Rows[0]["jop_n"].ToString();
                        work.Text = dt.Rows[0]["work_n"].ToString();
                        face.Text = dt.Rows[0]["face"].ToString();
                        txtEmail.Text = dt.Rows[0]["mail"].ToString();
                        sick_type.SelectedValue = dt.Rows[0]["sick_type"].ToString();
                        sex.SelectedValue = dt.Rows[0]["sex"].ToString();
                        pat_per.Text = dt.Rows[0]["pat_per"].ToString();
                        sup_per.Text = dt.Rows[0]["sup_per"].ToString();



                        byte[] imageData = dt.Rows[0]["p_pic"] as byte[];
                        byte[] imageData2 = dt.Rows[0]["pic"] as byte[];
                        byte[] imageData3 = dt.Rows[0]["card_pic"] as byte[];

                        if (imageData != null && imageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                string base64String = Convert.ToBase64String(imageData);
                                Im_p_pic.ImageUrl = "data:image/png;base64," + base64String;
                            }
                        }

                        if (imageData2 != null && imageData2.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData2))
                            {
                                string base64String = Convert.ToBase64String(imageData2);
                                Im_pic.ImageUrl = "data:image/png;base64," + base64String;
                            }
                        }

                        if (imageData3 != null && imageData3.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData3))
                            {
                                string base64String = Convert.ToBase64String(imageData3);
                                Im_card_pic.ImageUrl = "data:image/png;base64," + base64String;
                            }
                        }



                    }

                }/*
                card.TextChanged += Card_TextChanged;

               
                card.Attributes["maxlength"] = "14";*/
            }
        }
 /**********************************************GET DATA********************************************************************/

        private DataTable Getdt(string sickcode)
        {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sql = "SELECT wats,gaz1,crd1 ,nat, gov,city,document_no, face,tam_no,addr,comp_n,memb_no,dos_no,raf_no,jop_n,work_n, book_n,mail,sick_type,sex,pat_per,sup_per ,p_pic, card_pic, pic FROM hos_sick WHERE sick_code = @sick_code";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@sick_code", sickcode);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }

        /* protected void Card_TextChanged(object sender, EventArgs e)
         {

             cardDigitCount.Text = "تم ادخال  " + card.Text.Length +"رقم ";
         }*/
    }
}