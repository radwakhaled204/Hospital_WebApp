using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using iText.StyledXmlParser.Jsoup.Nodes;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Net;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;



namespace Royal_Elshrouq
{
    public partial class signup : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader r;
        public SqlCommand cmd;
        public int v_code = 1;

        public signup()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }
        /********************************************** IsNumeric ********************************************************************/
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
        /********************************************** IsAdminSession ********************************************************************/

        private bool IsAdminSession()
        {
            return Session["admin_"] != null;
        }

        /********************************************** user_checkedchange ********************************************************************/
        protected void user_checkedchange(object sender, EventArgs e)
        {
            txtname.Visible = true;
            code.Visible = false;
            lblphone.Text = "الباسورد";
        }
        /********************************************** patient_checkedchange ********************************************************************/
        protected void patient_checkedchange(object sender, EventArgs e)
        {
            txtpass.Visible = false;
            sick_code.Visible = false;
            txtname.Visible = true;
            txtphone.Visible = true;
            lblphone.Text = "رقم الهاتف";
        }
        /********************************************** Sign_up_Click ********************************************************************/
        protected void Sign_up_Click(object sender, EventArgs e)
         {
            using (SqlConnection con = new SqlConnection(connectionString))
            {/*PHONE CHECK*/
                string sql = "";
                if (patient.Checked == true)
                {
                    string IfExist = "select count(*) from hos_sick where mob1 = @phone ";
                    SqlCommand check = new SqlCommand(IfExist, con);
                    check.Parameters.AddWithValue("@phone", txtphone.Text);

                    con.Open();
                    int count = (int)check.ExecuteScalar();
                    con.Close();

                    if (count > 0)
                    {

                        lbl_message.Text = "رقم الهاتف موجود بالفعل";
                        return;
                    }
                    string phoneno = txtphone.Text;

                    if (!IsNumeric(phoneno))
                    {
                        lbl_message.Text = "رقم الهاتف يجب ان يحتوى على ارقام من 0 الى 9 ";
                        return;
                    }


                    if (nat.SelectedValue == "اجنبى")
                    {
                        if (string.IsNullOrWhiteSpace(txtphone.Text))
                        {
                            lbl_message.Text = "يرجى إدخال رقم الهاتف ";
                            return;
                        }
                    }
                    else if (nat.SelectedValue == "مصرى")
                    {
                        string pattern = "^(011|012|010|015)";
                        bool isValidPrefix = Regex.IsMatch(phoneno, pattern);

                        if (!isValidPrefix)
                        {
                            lbl_message.Text = "رقم الهاتف يجب أن يبدأ بـ 011 أو 012 أو 010 أو 015";
                            return;
                        }


                        else if (phoneno.Length != 11)

                        {
                            lbl_message.Text = "رقم الهاتف يجب ان يكون 11 رقم ";
                            return;
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(nat.SelectedValue))
                    {
                        lbl_message.Text = "يرجى اختيار الجنسيه   ";
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

                    lbl_message.Text = "تم التخزين بنجاح";  

                    Session["sick_code"] = v_code;
                    Session["n1"] = txtname.Text;
                    Session["mob1"] = txtphone.Text;
                    Session["p_ppass"] = txtpass.Text;
                    Response.Redirect("patient_page.aspx");


                }
                if (user.Checked == true)
                { 
                    /*user CHECK */
                    if (IsAdminSession())
                    {
                        /*MAX CODE*/

                        sql = "select max(code) as code from user_";
                        cmd = new SqlCommand(sql, con);


                        con.Open();
                        r = cmd.ExecuteReader();
                        r.Read();
                        if (r.HasRows)
                        {
                            if (r["code"] != DBNull.Value)
                            {
                                v_code = Convert.ToInt32(r["code"]);
                                v_code = v_code + 1;
                            }
                        }

                        r.Close();
                        con.Close();

                        /*SIGN UP*/
                        sql = "insert into user_(name,pas,code) values (@name,@pas,@code)";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@name", txtname.Text);
                        cmd.Parameters.AddWithValue("@pas", txtphone.Text);
                        cmd.Parameters.AddWithValue("@code", v_code);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        lbl_message.Text = "تم التخزين بنجاح";

                        Session["code"] = v_code;
                        Session["name"] = txtname.Text;
                        Session["pas"] = txtphone.Text;
                        Response.Redirect("user_page.aspx");
                    }
                    else
                    {
                        lbl_message.Text = "لا يمكنك التسجيل كمستخدم";
                    }
                }
            

            }

        }

        /********************************************** Page_Load ********************************************************************/

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["userType"] != null)
                {
                    string userType = Session["userType"].ToString();


                    if (userType == "user")
                    {
                        user.Enabled = true;
                        user.Checked = true;
                        patient.Enabled = false;
                        employee.Enabled = false;
                        doctor.Enabled = false;
                    }
                    else if (userType == "patient")
                    {
                        user.Enabled = false;
                        patient.Enabled = true;
                        patient.Checked = true;
                        employee.Enabled = false;
                        doctor.Enabled = false;

                    }
                    else if (userType == "employee")
                    {
                        user.Enabled = false;
                        patient.Enabled = false;
                        employee.Enabled = true;
                        employee.Checked = true;
                        doctor.Enabled = false;

                    }
                    else if (userType == "doctor")
                    {
                        user.Enabled = false;
                        patient.Enabled = false;
                        employee.Enabled = false;
                        doctor.Enabled = true;
                        doctor.Checked = true;
                    }
                }
                txtphone.AutoCompleteType = AutoCompleteType.Disabled;
                txtname.AutoCompleteType = AutoCompleteType.Disabled;
            }
        }


        /*
                protected void SendSMS(string phoneNumber, string message)
                {
                    // Add the country code to the phone number
                    if (!phoneNumber.StartsWith("+2"))
                    {
                        phoneNumber = "+2" + phoneNumber;
                    }

                    // Your Twilio Account SID and Auth Token
                    const string accountSid = "ACce7fb7dd4d853142a7c9bafeabae5f25";
                    const string authToken = "4d8d7c433678e5f260cce8d469e2242b";

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    TwilioClient.Init(accountSid, authToken);

                    // Use your verified Twilio phone number as the 'from' number
                    var from = new PhoneNumber("+201060953781");

                    // Use the provided phone number as the 'to' number
                    var to = new PhoneNumber(phoneNumber);

                    var result = MessageResource.Create(
                        to: to,
                        from: from,
                        body: message);

                    Console.WriteLine(result.Sid);
                }
        */

        /*
        private void sendWhatsApp(string number, string message)
        {
            try
            {
                if (number == "")
                {
                    MessageBox.Show("No number added");
                }

                if (number.Length <= 10)
                {
                    MessageBox.Show("Indian Code added automatically");
                    number = "+91" + number;
                }

                number = number.Replace(" ", "");

                // Call the Twilio method to send WhatsApp message
                SendWhatsAppMessage(number, message);
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        /*private void btnSend_Click(object sender, EventArgs e)
        {
            sendWhatsApp(txtNumber.Text, txtMessage.Text);
        }

        protected void SendWhatsAppMessage(string phoneNumber, string message)
        {
            if (!phoneNumber.StartsWith("+2"))
            {
                phoneNumber = "+2" + phoneNumber;
            }

            const string accountSid = "ACce7fb7dd4d853142a7c9bafeabae5f25";
            const string authToken = "4d8d7c433678e5f260cce8d469e2242b";

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            TwilioClient.Init(accountSid, authToken);

            // Use a Twilio phone number enabled for WhatsApp as the 'from' number
            var from = new PhoneNumber("whatsapp:+14155238886");
            var to = new PhoneNumber($"whatsapp:{phoneNumber}");

            var result = MessageResource.Create(
                to: to,
                from: from,
                body: message);

            Console.WriteLine(result.Sid);
        }

*/

        /*

                DataTable dt = new DataTable();
                static int sentOtp = 0;


                protected void btnSend_Click(object sender, EventArgs e)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        Random rand = new Random();
                        string apikey = "your api key";
                        long numbers = Convert.ToInt64(txtphone.Text);
                        sentOtp = rand.Next(1000, 9999);
                        string senders = "TXTLCL";
                        SqlCommand cmd = new SqlCommand("select * from where phoneNumber ='" + numbers + "'", con);
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        if (dt.Rows.Count != 0)
                        {
                            String url = "" + apikey + "&numbers=" + numbers + "&message=" + sentOtp + "&sender=" + senders;

                            StreamWriter mywriter = null;
                            HttpWebRequest objrequest = (HttpWebRequest)WebRequest.Create(url);

                            objrequest.Method = "POST";
                            objrequest.ContentLength = Encoding.UTF8.GetByteCount(url);
                            objrequest.ContentType = "application/x-www-form-urlencoded";

                            try
                            {
                                mywriter = new StreamWriter(objrequest.GetRequestStream());
                                mywriter.Write(url);

                                lbl_message.Text = "OTP Sent Successfully";
                                lbl_message.ForeColor = System.Drawing.Color.Green;

                                txtOtp.Visible = true;
                                btnVerify.Visible = true;
                            }

                            catch (Exception)
                            {
                                lbl_message.Text = "OTP could not sent";
                                lbl_message.ForeColor = System.Drawing.Color.Red;
                            }

                            finally
                            {
                                mywriter.Close();
                            }
                        }
                        else
                        {
                            lbl_message.Text = "This Phone Number is not present in our database";
                            lbl_message.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }

                protected void btnVerify_Click(object sender, EventArgs e)
                {
                    if (sentOtp == Convert.ToInt32(txtOtp.Text))
                    {
                        Session["Result"] = "Successful";
                        Response.Redirect("~/Admin.aspx");
                    }
                    else
                    {
                        lbl_message.Text = "OTP does not matches";
                        lbl_message.ForeColor = System.Drawing.Color.Red;
                    }
                    Session["Result"] = "Successful";
                    Response.Redirect("~/Admin.aspx");
                }
            }



        */



        /*string[] validPrefixes = { "011", "012", "010", "015" };
        bool isValidPrefix = false;

        foreach (string prefix in validPrefixes)
        {
            if (phoneno.StartsWith(prefix))
            {
                isValidPrefix = true;
                break;
            }
        }

        if (!isValidPrefix)
        {
            lbl_message.Text = "رقم الهاتف يجب أن يبدأ بـ 011 أو 012 أو 010 أو 015";
            return;
        }*/




    }
}



























