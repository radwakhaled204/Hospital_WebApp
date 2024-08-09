using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using PdfSharp.Pdf.IO;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Label = System.Web.UI.WebControls.Label;

namespace Royal_Elshrouq
{
    public partial class show_video : System.Web.UI.Page
    {

        private string connectionString;
        public SqlDataReader r;
        public DataTable dt;
        public show_video()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string selectedDoctor = Session["SelectedDoctor"] as string;
  
            DataTable doctorData = Getdt(selectedDoctor);

            if (doctorData != null && doctorData.Rows.Count > 0)
            {
                FillLabelsFromData(doctorData);
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (Session["SelectedDoctor"] != null)
                {
 
                    lbl_pic.Text = " دكتور  " + selectedDoctor;
                    lbl_vid.Text = " دكتور  " + selectedDoctor;
                }

                else
                {
                    if (Session["SelectedDoctor"] != null)
                    {

                        lbl_pic.Text = " دكتور  " + selectedDoctor;
                        lbl_vid.Text = " دكتور  " + selectedDoctor;
                    }

                }
            }








            if (!IsPostBack)
            {

                show_vid();



                if (!string.IsNullOrEmpty(selectedDoctor))
                {
                    DataTable dt = Getdt(selectedDoctor);

                    if (dt.Rows.Count > 0)
                    {
                        img.Visible = true;
                        vid.Visible = true;
                        /*string[] dayColumns = { "day1_1", "day1_2", "day1_3", "day1_4", "day1_5", "day1_6", "day1_7" };

                        for (int i = 0; i < dayColumns.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[0][dayColumns[i]].ToString()))
                            {
                                switch (i)
                                {
                                    case 0:
                                        day_1.Text = dt.Rows[0][dayColumns[i]].ToString();
                                        break;
                                    case 1:
                                        day_2.Text = dt.Rows[0][dayColumns[i]].ToString();
                                        break;
                                    case 2:
                                        day_3.Text = dt.Rows[0][dayColumns[i]].ToString();
                                        break;
                                    case 3:
                                        day_4.Text = dt.Rows[0][dayColumns[i]].ToString();
                                        break;
                                    case 4:
                                        day_5.Text = dt.Rows[0][dayColumns[i]].ToString();
                                        break;
                                    case 5:
                                        day_6.Text = dt.Rows[0][dayColumns[i]].ToString();
                                        break;
                                    case 6:
                                        day_7.Text = dt.Rows[0][dayColumns[i]].ToString();
                                        break;
                                }
                            }
                        }*/
                        byte[] imageData = (byte[])dt.Rows[0]["pic"];
                        if (imageData != null && imageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                img.Src = "data:image/jpeg;base64," + Convert.ToBase64String(ms.ToArray());
                            }
                        }


                        else
                        {

                            //lbl_message.Text = "لم يتم العثور على نتائج.";
                        }
                        lbl_doc_info.Text = dt.Rows[0]["doc_info"].ToString();
                    
                    }
                }

            }
        }







        protected void FillLabelsFromData(DataTable doctorData)
        {
            List<string> labels = new List<string>
    {
        "n_day1", "n_day2", "n_day3", "n_day4", "n_day5", "n_day6", "n_day7"
    };

            for (int colIndex = 0; colIndex < labels.Count; colIndex++)
            {
                string labelID = "day" + (colIndex + 1);
                Label label = FindControl(labelID) as Label;

                if (label != null)
                {
                    string columnName = "day" + (colIndex + 1);

                    if (doctorData.Columns.Contains(columnName))
                    {
                        object columnValue = doctorData.Rows[0][columnName];

                        if (columnValue != DBNull.Value)
                        {
                            label.Text = columnValue.ToString();
                        }
                        else
                        {
                            // If the current column has no data, fill the label from the next column
                            int nextColIndex = colIndex + 1;
                            while (nextColIndex < labels.Count)
                            {
                                string nextColumnName = "day" + (nextColIndex + 1);
                                object nextColumnValue = doctorData.Rows[0][nextColumnName];

                                if (nextColumnValue != DBNull.Value)
                                {
                                    label.Text = nextColumnValue.ToString();
                                    break;
                                }

                                nextColIndex++;
                            }
                        }
                    }
                }
            }
        }





        private DataTable Getdt(string selectedDoctor)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT day1,day2 , day3, day4, day5,day6,day7 ,pic ,video_link,doc_info FROM hos_doctor WHERE name = @DoctorName";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@DoctorName", selectedDoctor);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        protected void show_vid()
        {
            string selectedDoctor = Session["SelectedDoctor"] as string;
            string query = "SELECT video_link FROM hos_doctor WHERE name = @DoctorName";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DoctorName", selectedDoctor);

                    con.Open();


                    string videoLink = cmd.ExecuteScalar()?.ToString();

                    if (!string.IsNullOrEmpty(videoLink))
                    {

                        vid.Attributes["src"] = videoLink;
                        vid.Controls.Add(new LiteralControl($"<track label='English' kind='subtitles' srclang='en' src='{videoLink.Replace("mp4", "vtt")}' default></track>"));
                    }
                }
            }
        }
    }
}



