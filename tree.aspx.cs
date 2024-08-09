using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Royal_Elshrouq
{
    public partial class tree : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader r;
        public SqlCommand cmd;
        public int v_code = 1;
        string sql = "";
        private string selectedRoomName;


        public tree()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public DataTable load_data()
        {

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Groups", con);

                try
                {
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                }
                finally
                {
                    con.Close();
                }
            }

            return dt;
        }




        protected void show1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Groups", con);

                try
                {
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            load_data();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void show2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Groups", con);

                try
                {
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            load_data();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void show3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Groups", con);

                try
                {
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            load_data();
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void show4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Groups", con);

                try
                {
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    GridView4.DataSource = dt;
                    GridView4.DataBind();
                }
                finally
                {
                    con.Close();
                }
            }
        }
        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView4.PageIndex = e.NewPageIndex;
            load_data();
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /* 
         protected void print1_Click(object sender, EventArgs e)
         {
             Response.ContentType = "Application/pdf";
             Response.AddHeader("Content-Disposition", "attachement , Filename=YourFileName.pdf");
             Response.Cache.SetCacheability(HttpCacheability.NoCache);
             StringWriter sw = new StringWriter();   
             HtmlTextWriter hw = new HtmlTextWriter(sw);
             Divtoprint.RenderControl(hw);
             Document doc = new Document(PageSize.A4, 50f, 50f, 100f, 30f);
             HTMLWorker htw = new HTMLWorker(doc);
             PdfWriter.GetInstance(doc, Response.OutputStream);
             doc.Open();
             StringReader sr = new StringReader(sw.ToString());
             htw.Parse(sr);
             doc.Close();
             Response.Write(doc);
             Response.End();
         }
        */
        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);
        }
        protected void insert1_Click(object sender, EventArgs e)
        {

        }

        protected void print1_Click(object sender, EventArgs e)
        {

        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }
    }
}