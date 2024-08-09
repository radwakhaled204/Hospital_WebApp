using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using iTextSharp.text.pdf;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using PdfWriter = iTextSharp.text.pdf.PdfWriter;
using System.Globalization;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using Image = iTextSharp.text.Image;



namespace Royal_Elshrouq
{
    public partial class book : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader r;
        public DataTable dt;
        public SqlCommand cmd;
        public int v_code = 1;
        string notevalue;
        string sql = "";
        string IfExist = "";
        public SqlCommand check;
        int count;

        public book()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }

        /**********************************************  IsNumeric ********************************************************************/
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

        /**********************************************  IsAdminSession ********************************************************************/
        private bool IsAdminSession()
        {
            return Session["admin_"] != null;
        }

        /**********************************************  Page_Load ********************************************************************/
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
                        lbl2_m.Text = "مرحبا,   " + name;
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

            if (IsAdminSession())
            {
                patient_save.Visible = true;
            }
            if (!IsPostBack)
            {
                fill_ayada();
                fill_internet();
                fill_company();

            }

        }
        /********************************************** user_patient_signup ********************************************************************/

        protected void user_patient_signup(object sender, EventArgs e)
        {
            if (IsAdminSession())
            {
                p_sinup.Visible = true;
            }

        }

        /**********************************************  Sign_up_Click ********************************************************************/

        protected void Sign_up_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {/*PHONE CHECK*/

                sql = "";
                IfExist = "select count(*) from hos_sick where mob1 = @phone ";
                check = new SqlCommand(IfExist, con);
                check.Parameters.AddWithValue("@phone", txtphone.Text);

                con.Open();
                count = (int)check.ExecuteScalar();
                con.Close();



                if (count > 0)
                {

                    lbl_sign.Text = "رقم الهاتف موجود بالفعل";
                    return;
                }
                string phoneno = txtphone.Text;

                if (!IsNumeric(phoneno))
                {
                    lbl_sign.Text = "رقم الهاتف يجب ان يحتوى على ارقام من 0 الى 9 ";
                    return;
                }



                if (nat.SelectedValue == "اجنبى")
                {

                    if (string.IsNullOrWhiteSpace(txtphone.Text))
                    {
                        lbl_sign.Text = "يرجى إدخال رقم الهاتف ";
                        return;
                    }


                }
                else if (nat.SelectedValue == "مصرى")
                {
                    string pattern = "^(011|012|010|015)";
                    bool isValidPrefix = Regex.IsMatch(phoneno, pattern);

                    if (!isValidPrefix)
                    {
                        lbl_sign.Text = "رقم الهاتف يجب أن يبدأ بـ 011 أو 012 أو 010 أو 015";
                        return;
                    }


                    else if (phoneno.Length != 11)

                    {
                        lbl_sign.Text = "رقم الهاتف يجب ان يكون 11 رقم ";
                        return;
                    }


                }
                else if (string.IsNullOrWhiteSpace(nat.SelectedValue))
                {


                    lbl_sign.Text = "يرجى اختيار الجنسيه   ";
                    return;


                }


                /*RANDOM*/

                Random rnd = new Random();

            yy:
                txtpass.Text = rnd.Next(1000, 10000000).ToString();


                sql = " select  * from hos_sick where p_ppass = @pass ";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pass", txtpass.Text);


                con.Open();
                r = cmd.ExecuteReader();
                r.Read();



                if (r.HasRows)
                {
                    r.Close();
                    con.Close();
                    goto yy;
                }
                r.Close();
                con.Close();


                /*MAX  SICK_CODE*/


                sql = "select max(sick_code) as sick_code from hos_sick";
                cmd = new SqlCommand(sql, con);


                con.Open();
                r = cmd.ExecuteReader();
                r.Read();
                if (r.HasRows)
                {
                    if (r["sick_code"] != DBNull.Value)
                    {
                        v_code = Convert.ToInt32(r["sick_code"]);
                        v_code = v_code + 1;
                    }
                }

                r.Close();
                con.Close();


                /*SIGN UP*/
                sql = "insert into hos_sick(n1,mob1,p_ppass,nat,sick_code) values (@name,@phone,@pass,@nat,@sick_code)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@nat", nat.SelectedValue);
                cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                cmd.Parameters.AddWithValue("@sick_code", v_code);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lbl_sign.Text = "تم التسجيل بنجاح";
                Session["sick_code"] = v_code;
                Session["n1"] = txtname.Text;
                Session["mob1"] = txtphone.Text;
                Session["p_ppass"] = txtpass.Text;
            }
        }


        /**********************************************  login_Click ********************************************************************/

        protected void login_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string selectedCompany = (!string.IsNullOrWhiteSpace(type_company.Text)) ? type_company.Text : company.SelectedValue;
                
                if (company.SelectedValue == "اخرى")
                {
                    if (string.IsNullOrWhiteSpace(type_company.Text))
                    {
                        lbl_message.Text = "يرجى كتابة الجهه المتعاقدة";
                        return;
                    }
                    else
                    {
                        IfExist = "SELECT COUNT(*) FROM hos_comp WHERE name = @type_company";
                        check = new SqlCommand(IfExist, con);

                        check.Parameters.AddWithValue("@type_company", selectedCompany);

                        con.Open();
                        count = (int)check.ExecuteScalar();
                        con.Close();

                        if (count > 0)
                        {
                            lbl_message.Text = "الجهه المتعاقده الذى ادخلتها موجوده بالفعل";
                            return;
                        }
                        else
                        {
                            sql = "INSERT INTO hos_comp (name) VALUES (@type_company)";

                            using (cmd = new SqlCommand(sql, con))
                            {
                                cmd.Parameters.AddWithValue("@type_company", selectedCompany);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }

                        }
                    }
                }
              
                string selectedInternet = (!string.IsNullOrWhiteSpace(type_internet.Text)) ? type_internet.Text : internet.SelectedValue;
               
                if (internet.SelectedValue == "اخرى")
                {
                    if (string.IsNullOrWhiteSpace(type_internet.Text))
                    {
                        lbl_message.Text = "يرجى كتابة وسيلة التعارف";
                        return;
                    }
                    else
                    {
                        IfExist = "SELECT COUNT(*) FROM hos_internet WHERE name = @type_internet";
                        check = new SqlCommand(IfExist, con);

                        check.Parameters.AddWithValue("@type_internet", selectedInternet);

                        con.Open();
                        count = (int)check.ExecuteScalar();
                        con.Close();

                        if (count > 0)
                        {
                            lbl_message.Text = " وسيلة التعارف الذى ادخلتها موجوده بالفعل";
                            return;
                        }
                        else
                        {
                            sql = "INSERT INTO hos_internet (name) VALUES (@type_internet)";

                            using (cmd = new SqlCommand(sql, con))
                            {
                                cmd.Parameters.AddWithValue("@type_internet", selectedInternet);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }

                        }
                    }
                }

                notevalue = notes.Value;
                string time = hour.Text;
                string date = txtDate.Text;
                DateTime selectedDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture).Date;

                string formattedDate = selectedDate.ToString("yyyy-MM-dd");

                TimeSpan selectedTime = TimeSpan.ParseExact(time, "hh\\:mm", CultureInfo.InvariantCulture);

                IfExist = "SELECT COUNT(*) FROM tem_esl_dis_book WHERE doc_n = @doc AND eada_n = @clinic AND book_date = @date AND book_time = @hour";
                 check = new SqlCommand(IfExist, con);

                check.Parameters.AddWithValue("@date", formattedDate);
                check.Parameters.AddWithValue("@hour", selectedTime);
                check.Parameters.AddWithValue("@clinic", clinic.SelectedValue);
                check.Parameters.AddWithValue("@doc", doc.SelectedValue);

                con.Open();
                count = (int)check.ExecuteScalar();
                con.Close();

                if (count > 0)
                {
                    lbl_message.Text = "تم حجز نفس الميعاد في نفس اليوم، برجاء اختيار ميعاد آخر بعد هذا الميعاد بنصف ساعة";
                    return;
                }
                if (IsAdminSession())
                {
                    string sql = "insert into tem_esl_dis_book(sick_n,sick_code,mob,p_idd,doc_n,eada_n,spec_n,book_date,day,internet_,user_n,rem_,book_time,contract_cash,company) values (@name,@sick_code,@phone,@pass,@doc,@clinic,@serv,@date,@day,@internet,@user_n,@note,@hour,@contract,@company)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@date", formattedDate);
                    cmd.Parameters.AddWithValue("@hour", selectedTime);
                    cmd.Parameters.AddWithValue("@company", selectedCompany);
                    cmd.Parameters.AddWithValue("@internet", selectedInternet);
                    cmd.Parameters.AddWithValue("@note", notevalue);
                    cmd.Parameters.AddWithValue("@day", day.Text);
                    cmd.Parameters.AddWithValue("@serv", serv.SelectedValue);
                    cmd.Parameters.AddWithValue("@clinic", clinic.SelectedValue);
                    cmd.Parameters.AddWithValue("@doc", doc.SelectedValue);
                    cmd.Parameters.AddWithValue("@contract", contract.SelectedValue);
                    cmd.Parameters.AddWithValue("@phone", Session["mob1"].ToString());
                    cmd.Parameters.AddWithValue("@pass", Session["p_ppass"].ToString());
                    cmd.Parameters.AddWithValue("@sick_code", Session["sick_code"].ToString());
                    cmd.Parameters.AddWithValue("@name", Session["n1"].ToString());
                    cmd.Parameters.AddWithValue("@user_n", Session["name"].ToString());

                    con.Open();
                    cmd.ExecuteNonQuery();



                    con.Close();
                    lbl_message.Text = "تم التخزين بنجاح";

                }
                else
                {
                    string sql = "insert into tem_esl_dis_book(sick_n,sick_code,mob,p_idd,doc_n,eada_n,spec_n,book_date,day,internet_,rem_,book_time,contract_cash,company) values (@n1,@s_c,@mob,@pas,@doc,@clinic,@serv,@date,@day,@internet,@note,@hour,@contract,@company)";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@date", selectedDate);
                    cmd.Parameters.AddWithValue("@hour", selectedTime);
                    cmd.Parameters.AddWithValue("@company", selectedCompany);
                    cmd.Parameters.AddWithValue("@internet", selectedInternet);
                    cmd.Parameters.AddWithValue("@note", notevalue);
                    cmd.Parameters.AddWithValue("@day", day.Text);
                    cmd.Parameters.AddWithValue("@serv", serv.SelectedValue);
                    cmd.Parameters.AddWithValue("@clinic", clinic.SelectedValue);
                    cmd.Parameters.AddWithValue("@doc", doc.SelectedValue);
                    cmd.Parameters.AddWithValue("@contract", contract.SelectedValue);
                    cmd.Parameters.AddWithValue("@mob", Session["mob1"].ToString());
                    cmd.Parameters.AddWithValue("@pas", Session["p_ppass"].ToString());
                    cmd.Parameters.AddWithValue("@s_c", Session["sick_code"].ToString());
                    cmd.Parameters.AddWithValue("@n1", Session["n1"].ToString());

                    con.Open();
                    cmd.ExecuteNonQuery();

                    con.Close();
                    lbl_message.Text = "تم التخزين بنجاح";
                }
            }
        }

        /**********************************************  fill ********************************************************************/

        protected void company_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (company.SelectedValue == "اخرى")
            {
                company_type.Visible = true;
                div_type.Visible = true;

                if (string.IsNullOrWhiteSpace(type_company.Text))
                {
                    lbl_message.Text = "يرجى كتابة الجهه المتعاقدة";
                    return;
                }

            }
            else
            {
                company_type.Visible = false;
            }

            lbl_message.Text = "";
        }

        protected void internet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (internet.SelectedValue == "اخرى")
            {
                internet_type.Visible = true;
                div_type.Visible = true;

                if (string.IsNullOrWhiteSpace(type_internet.Text))
                {
                    lbl_message.Text = "يرجى كتابة وسيلة التعارف";
                    return;
                }
            }
            else
            {
                internet_type.Visible = false;
            }


            lbl_message.Text = "";
        }

        protected void clinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_doc();
        }


        protected void doc_SelectedIndexChanged(object sender, EventArgs e)
        {

            fill_serv();

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
                    clinic.Items.Insert(0, new System.Web.UI.WebControls.ListItem("اختار عيادة", "0"));
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
                    doc.Items.Insert(0, new System.Web.UI.WebControls.ListItem("اختار دكتور", "0"));
                }

            }
        }
        protected void fill_serv()
        {
            dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {


                con.Open();
                string selectedClinicValue = clinic.SelectedValue.ToString();
                SqlCommand cmd = new SqlCommand("SELECT name FROM hos_serv WHERE m_name = @clinic", con);
                cmd.Parameters.AddWithValue("@clinic", clinic.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    serv.DataSource = dt;
                    serv.DataTextField = "name";
                    serv.DataValueField = "name";
                    serv.DataBind();
                    serv.Items.Insert(0, new System.Web.UI.WebControls.ListItem("اختار الخدمة", "0"));
                }

            }
        }
        protected void fill_company()
        {
            dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {


                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT name FROM hos_comp ", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    company.DataSource = dt;
                    company.DataTextField = "name";
                    company.DataValueField = "name";
                    company.DataBind();
                    company.Items.Insert(0, new System.Web.UI.WebControls.ListItem("اختار شركة", "0"));
                }

            }
        }
        protected void fill_internet()
        {
            dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {


                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT name FROM  hos_internet ", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    internet.DataSource = dt;
                    internet.DataTextField = "name";
                    internet.DataValueField = "name";
                    internet.DataBind();
                    internet.Items.Insert(0, new System.Web.UI.WebControls.ListItem("اختار وسيلة تعارف", "0"));

                }

            }
        }
        /**********************************************   btnPrint_Click ********************************************************************/


        /*   protected void btnPrint_Click(object sender, EventArgs e)
           {
               try
               {
                   string fileName = "تقرير.pdf";
                   Response.ContentType = "application/pdf";
                   Response.AddHeader("content-disposition", $"attachment;filename={fileName}");
                   Response.ContentEncoding = Encoding.UTF8;
                   Response.Cache.SetCacheability(HttpCacheability.NoCache);

                   using (MemoryStream ms = new MemoryStream())
                   {
                       using (Document doc = new Document(PageSize.A4, 50f, 50f, 30f, 30f))
                       {
                           PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                           BaseFont bf = BaseFont.CreateFont(Server.MapPath("Hacen Egypt.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                           Font arabicFont = new Font(bf, 16, Font.NORMAL, BaseColor.BLACK);

                           doc.Open();

                           doc.AddLanguage("ar");

                           DataTable dt = load_data();

                           if (dt.Rows.Count > 0)
                           {
                               DataRow lastRow = dt.Rows[dt.Rows.Count - 1];

                               ArabicLigaturizer al = new ArabicLigaturizer();

                               Paragraph codeParagraph = new Paragraph(al.Process("كود المريض: " + lastRow["sick_code"].ToString()), arabicFont);
                               Paragraph nameParagraph = new Paragraph(al.Process("اسم المريض: " + lastRow["sick_n"].ToString()), arabicFont);
                               Paragraph phoneParagraph = new Paragraph(al.Process("رقم الهاتف: " + lastRow["mob"].ToString()), arabicFont);

                               Paragraph clinic = new Paragraph(al.Process("العيادة: " + lastRow["eada_n"].ToString()), arabicFont);
                               Paragraph doctor = new Paragraph(al.Process("الدكتور: " + lastRow["doc_n"].ToString()), arabicFont);
                               Paragraph service = new Paragraph(al.Process("الخدمة: " + lastRow["spec_n"].ToString()), arabicFont);

                               Paragraph date = new Paragraph(al.Process("تاريخ اليوم: " + ((DateTime)lastRow["book_date"]).ToString("yyyy-MM-dd")), arabicFont);
                               Paragraph day = new Paragraph(al.Process("اليوم: " + lastRow["day"].ToString()), arabicFont);
                               Paragraph hour = new Paragraph(al.Process("الساعة: " + lastRow["book_time"].ToString()), arabicFont);

                               Paragraph company = new Paragraph(al.Process("الجهة المتعاقدة: " + lastRow["company"].ToString()), arabicFont);
                               Paragraph contract = new Paragraph(al.Process("تعاقد او نقدى: " + lastRow["contract_cash"].ToString()), arabicFont);
                               Paragraph notes = new Paragraph(al.Process("الملاحظات: " + lastRow["rem_"].ToString()), arabicFont);



                               codeParagraph.Alignment = Element.ALIGN_RIGHT;
                               nameParagraph.Alignment = Element.ALIGN_RIGHT;
                               phoneParagraph.Alignment = Element.ALIGN_RIGHT;

                               clinic.Alignment = Element.ALIGN_RIGHT;
                               doctor.Alignment = Element.ALIGN_RIGHT;
                               service.Alignment = Element.ALIGN_RIGHT;

                               date.Alignment = Element.ALIGN_RIGHT;
                               day.Alignment = Element.ALIGN_RIGHT;
                               hour.Alignment = Element.ALIGN_RIGHT;

                               company.Alignment = Element.ALIGN_RIGHT;
                               contract.Alignment = Element.ALIGN_RIGHT;
                               notes.Alignment = Element.ALIGN_RIGHT;



                               doc.Add(codeParagraph);
                               doc.Add(nameParagraph);
                               doc.Add(phoneParagraph);

                               doc.Add(clinic);
                               doc.Add(doctor);
                               doc.Add(service);

                               doc.Add(date);
                               doc.Add(day);
                               doc.Add(hour);

                               doc.Add(company);
                               doc.Add(contract);
                               doc.Add(notes);



                               doc.Add(new Paragraph(" ", arabicFont));

                           }
                       }

                       Response.BinaryWrite(ms.GetBuffer());
                       Response.Flush();
                       Response.End();
                   }
               }
               catch (Exception ex)
               {
                   Debug.WriteLine($"Error: {ex.Message}");
               }
           }*/
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "تقرير.pdf";
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", $"attachment;filename={fileName}");
                Response.ContentEncoding = Encoding.UTF8;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (Document doc = new Document(PageSize.A4, 50f, 50f, 30f, 30f))
                    {
                        PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                        writer.PageEvent = new PdfHeaderFooter();

                        BaseFont bf = BaseFont.CreateFont(Server.MapPath("Hacen Egypt.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        Font arabicFont = new Font(bf, 16, Font.NORMAL, BaseColor.BLACK);

                        doc.Open();

                        doc.AddLanguage("ar");

                        DataTable dt = load_data();

                        if (dt.Rows.Count > 0)
                        {
                            DataRow lastRow = dt.Rows[dt.Rows.Count - 1];

                            ArabicLigaturizer al = new ArabicLigaturizer();
                            //تعديل هنا ان الطباعه تكون على حسب كود الشخص اللى فى السيشن

                            Paragraph codeParagraph = new Paragraph(al.Process("كود المريض: " + lastRow["sick_code"].ToString()), arabicFont);
                            Paragraph nameParagraph = new Paragraph(al.Process("اسم المريض: " + lastRow["sick_n"].ToString()), arabicFont);
                            Paragraph phoneParagraph = new Paragraph(al.Process("رقم الهاتف: " + lastRow["mob"].ToString()), arabicFont);

                            Paragraph clinic = new Paragraph(al.Process("العيادة: " + lastRow["eada_n"].ToString()), arabicFont);
                            Paragraph doctor = new Paragraph(al.Process("الدكتور: " + lastRow["doc_n"].ToString()), arabicFont);
                            Paragraph service = new Paragraph(al.Process("الخدمة: " + lastRow["spec_n"].ToString()), arabicFont);

                            Paragraph date = new Paragraph(al.Process("تاريخ اليوم: " + ((DateTime)lastRow["book_date"]).ToString("yyyy-MM-dd")), arabicFont);
                            Paragraph day = new Paragraph(al.Process("اليوم: " + lastRow["day"].ToString()), arabicFont);
                            Paragraph hour = new Paragraph(al.Process("الساعة: " + lastRow["book_time"].ToString()), arabicFont);

                            Paragraph company = new Paragraph(al.Process("الجهة المتعاقدة: " + lastRow["company"].ToString()), arabicFont);
                            Paragraph contract = new Paragraph(al.Process("تعاقد او نقدى: " + lastRow["contract_cash"].ToString()), arabicFont);
                            Paragraph notes = new Paragraph(al.Process("الملاحظات: " + lastRow["rem_"].ToString()), arabicFont);



                            codeParagraph.Alignment = Element.ALIGN_RIGHT;
                            nameParagraph.Alignment = Element.ALIGN_RIGHT;
                            phoneParagraph.Alignment = Element.ALIGN_RIGHT;

                            clinic.Alignment = Element.ALIGN_RIGHT;
                            doctor.Alignment = Element.ALIGN_RIGHT;
                            service.Alignment = Element.ALIGN_RIGHT;

                            date.Alignment = Element.ALIGN_RIGHT;
                            day.Alignment = Element.ALIGN_RIGHT;
                            hour.Alignment = Element.ALIGN_RIGHT;

                            company.Alignment = Element.ALIGN_RIGHT;
                            contract.Alignment = Element.ALIGN_RIGHT;
                            notes.Alignment = Element.ALIGN_RIGHT;



                            doc.Add(codeParagraph);
                            doc.Add(nameParagraph);
                            doc.Add(phoneParagraph);

                            doc.Add(clinic);
                            doc.Add(doctor);
                            doc.Add(service);

                            doc.Add(date);
                            doc.Add(day);
                            doc.Add(hour);

                            doc.Add(company);
                            doc.Add(contract);
                            doc.Add(notes);

                            doc.Add(new Paragraph(" ", arabicFont));
                        }
                    }

                    Response.BinaryWrite(ms.GetBuffer());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        public class PdfHeaderFooter : PdfPageEventHelper
        {
            public override void OnStartPage(PdfWriter writer, Document document)
            {
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.TotalWidth = document.PageSize.Width;

                BaseFont bf = BaseFont.CreateFont(HttpContext.Current.Server.MapPath("Hacen Egypt.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                Font arabicFont = new Font(bf, 16, Font.NORMAL, BaseColor.BLACK);

                ArabicLigaturizer al = new ArabicLigaturizer();


                PdfPCell cell = new PdfPCell(new Phrase(al.Process("حجز ميعاد"), arabicFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_TOP;
                cell.Border = PdfPCell.NO_BORDER;

                headerTable.AddCell(cell);
                headerTable.WriteSelectedRows(0, -1, 0, document.Top + 10, writer.DirectContent);
            }
        }






 /**********************************************   load_data ********************************************************************/
        private DataTable load_data()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                sql = "select sick_n, mob, sick_code, eada_n, doc_n, spec_n, book_date, day, book_time, rem_ ,company,contract_cash from tem_esl_dis_book";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }

        }//يحمل الداتا بالسيشن
/**********************************************   GridView ********************************************************************/


        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }

   
    
        /*
        protected void ValidateDate(object sender, ServerValidateEventArgs e)
        {

            if (DateTime.TryParse(e.Value, out DateTime selectedDate))
            {
          
                if (selectedDate < DateTime.Today)
                {
         
                    e.IsValid = false;
                }
                else
                {
                   
                    e.IsValid = true;
                }
            }
            else
            {
                
                e.IsValid = false;
            }
        }
        */

    }

}
   
