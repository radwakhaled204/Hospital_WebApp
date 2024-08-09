using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Configuration;
using System.Drawing;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Text;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using System.Diagnostics;
using System.Web.UI.HtmlControls;
using Twilio.TwiML.Voice;


namespace Royal_Elshrouq
{
    public partial class room_detail : System.Web.UI.Page
    {

        private string connectionString;
        public SqlDataReader r;
        public SqlCommand cmd;
        DataTable dt;
        public int v_code = 1;
        string sql = "";

    
  
        public room_detail()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    fill_floor();
                }
            }
        protected void floor_SelectedIndexChanged(object sender, EventArgs e)
        {
            rooms.Visible = true;
            fill_rooms();
            load_data();
            fill_d_rooms();
        }

        protected void rooms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void inser_room(object sender, EventArgs e)
        {
            divroom.Visible = true;
            divfloor.Visible = false;
            divbed.Visible = false;
            divdelete_f.Visible = false;
            divdelete_r.Visible = false;
        }
        protected void update_bed_no(object sender, EventArgs e)
        {
            divbed.Visible = true;
            divroom.Visible = false;
            divfloor.Visible = false;
            divdelete_f.Visible = false;
            divdelete_r.Visible = false;

        }
        protected void inser_floor(object sender, EventArgs e)
        {
            divfloor.Visible = true;
            divroom.Visible = false;
            divbed.Visible = false;
            divdelete_f.Visible = false;
            divdelete_r.Visible = false;
        }
        protected void delete_floor(object sender, EventArgs e)
        {
            divdelete_f.Visible = true;
            divfloor.Visible = false;
            divroom.Visible = false;
            divbed.Visible = false;
            divdelete_r.Visible = false;
        }
        protected void delete_room(object sender, EventArgs e)
        {
            divdelete_r.Visible = true;
            divfloor.Visible = false;
            divroom.Visible = false;
            divbed.Visible = false;
            divdelete_f.Visible = false;
        }


        /**********************************************   fill ********************************************************************/

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
                        floor_r.DataSource = dt;
                        floor_b.DataSource = dt;
                        floor_d_r.DataSource = dt;
                        floor_d_f.DataSource = dt;

                        floor.DataTextField = "name";
                        floor_r.DataTextField = "name";
                        floor_b.DataTextField = "name";
                        floor_d_r.DataTextField = "name";
                        floor_d_f.DataTextField = "name";

                        floor.DataValueField = "name";
                        floor_r.DataValueField = "name";
                        floor_b.DataValueField = "name";
                        floor_d_r.DataValueField = "name";
                        floor_d_f.DataValueField = "name";

                        floor.DataBind();
                        floor_r.DataBind();
                        floor_b.DataBind();
                        floor_d_r.DataBind();
                        floor_d_f.DataBind();

                        floor.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- اختر دور --", string.Empty));
                        floor_r.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- اختر دور --", string.Empty));
                        floor_b.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- اختر دور --", string.Empty));
                        floor_d_r.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- اختر دور --", string.Empty));
                        floor_d_f.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- اختر دور --", string.Empty));

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
                    cmd.Parameters.AddWithValue("@floor", floor_b.SelectedValue.ToString());

                    cmd.Connection = con;
                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        rooms_fill.DataSource = dt;
                        rooms_fill.DataTextField = "name";
                        rooms_fill.DataValueField = "name";
                        rooms_fill.DataBind();                   
                        rooms_fill.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- اختر غرفة --", string.Empty));
                    }
                    else
                    {
                        rooms_fill.Items.Clear();
                        rooms_fill.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- لا توجد غرف --", string.Empty));
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('حدث خطأ: {ex.Message}');</script>");
            }
        }
        protected void fill_d_rooms()
        {
            try
            {
                dt = new DataTable();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    cmd = new SqlCommand();
                    cmd.Parameters.Clear();
                    sql = "SELECT name FROM hos_rom WHERE flo = @floor_d_r";
                    cmd.Parameters.AddWithValue("@floor_d_r", floor_d_r.SelectedValue.ToString());

                    cmd.Connection = con;
                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        rooms_delete.DataSource = dt;
                        rooms_delete.DataTextField = "name";
                        rooms_delete.DataValueField = "name";
                        rooms_delete.DataBind();
                        rooms_delete.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- اختر غرفة --", string.Empty));
                    }
                    else
                    {                  
                        rooms_delete.Items.Clear();
                        rooms_delete.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- لا توجد غرف --", string.Empty));
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('حدث خطأ: {ex.Message}');</script>");
            }
        }
        /**********************************************   save_Click ********************************************************************/
        /*
                protected void save_Click(object sender, EventArgs e)
                {
                    string up_text = "";

                    if (txtname.Text != null)
                    {

                        if (up_text == "")

                            up_text = " name = @name  ";

                        else
                            up_text = up_text + " , name = @name ";

                    }

                    if (txtbed.Text != null)
                    {

                        if (up_text == "")

                            up_text = " bed_no = @bed_no  ";


                        else
                            up_text = up_text + " , bed_no = @bed_no   ";

                    }
                    if (up_text != "")
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            sql = "update hos_rom set " + up_text + " where name = @name";
                            cmd = new SqlCommand(sql, con);
                            cmd.Parameters.AddWithValue("@name ", txtname.Text);
                            cmd.Parameters.AddWithValue("@bed_no", txtbed.Text);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            lbl_message.Text = "تم التخزين بنجاح";
                        }
                    }

                    else
                    {
                        lbl_message.Text = "يجب تسجيل بيان واحد على الاقل";
                        goto pp1;
                    }

                pp1:;

                }
                */

        /**********************************************   insert ********************************************************************/


        protected void save_floor(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    sql = "SELECT COUNT(*) FROM hos_floor WHERE name = @name";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@name", floor_name.Text);

                    int floorCount = (int)cmd.ExecuteScalar();

                    if (floorCount > 0)
                    {
                        lbl_2.Text = "الدور موجود بالفعل.";
                    }
                    else
                    {
                        sql = "select max(code) as code from hos_floor";
                        cmd = new SqlCommand(sql, con);

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read() && r["code"] != DBNull.Value)
                            {
                                v_code = Convert.ToInt32(r["code"]) + 1;
                            }
                        }

                        con.Close();

                        if (!string.IsNullOrWhiteSpace(floor_name.Text))
                        {
                            sql = "insert into hos_floor(name, code) values (@name,  @code)";
                            cmd = new SqlCommand(sql, con);
                            cmd.Parameters.AddWithValue("@name", floor_name.Text);

                            cmd.Parameters.AddWithValue("@code", v_code);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            lbl_2.Text = "تمت الاضافة بنجاح.";
                        }
                        else
                        {
                            lbl_2.Text = "يجب إدخال قيم صحيحة للدور ";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_2.Text = $"حدث خطأ: {ex.Message}";
            }
        }

        protected void save_room(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    sql = "SELECT COUNT(*) FROM hos_rom WHERE name = @room_name AND flo = @floor_r";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@room_name", r_name.Text);
                    cmd.Parameters.AddWithValue("@floor_r", floor_r.SelectedValue);
                    int roomCount = (int)cmd.ExecuteScalar();
                    if (roomCount > 0)
                    {
                        lbl_2.Text = "الغرفة موجودة بالفعل في نفس الدور.";
                    }
                    else
                    {
                        sql = "select max(code) as code from hos_rom";
                        cmd = new SqlCommand(sql, con);

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read() && r["code"] != DBNull.Value)
                            {
                                v_code = Convert.ToInt32(r["code"]) + 1;
                            }
                        }

                        con.Close();

                        if (!string.IsNullOrWhiteSpace(bed_r_no.Text) && !string.IsNullOrEmpty(r_name.Text))
                        {                        
                            sql = "insert into hos_rom(name, flo , code, bed_no) values (@room_name, @floor_r, @code,@bed_no)";
                            cmd = new SqlCommand(sql, con);
                            cmd.Parameters.AddWithValue("@bed_no", bed_r_no.Text);
                            cmd.Parameters.AddWithValue("@floor_r", floor_r.SelectedValue);
                            cmd.Parameters.AddWithValue("@room_name", r_name.Text);
                            cmd.Parameters.AddWithValue("@code", v_code);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            lbl_2.Text = "تمت الاضافة بنجاح.";
                        }
                        else
                        {
                            lbl_2.Text = "يجب إدخال قيم صحيحة.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_2.Text = $"حدث خطأ: {ex.Message}";
            }
        }

        protected void save_info(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    sql = "SELECT COUNT(*) FROM hos_stay_b WHERE name = @p_name AND flo = @floor_r";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@room_name", r_name.Text);
                    cmd.Parameters.AddWithValue("@floor_r", floor_r.SelectedValue);
                    int roomCount = (int)cmd.ExecuteScalar();
                    if (roomCount > 0)
                    {
                        lbl_2.Text = "الغرفة موجودة بالفعل في نفس الدور.";
                    }
                    else
                    {
                        sql = "select max(code) as code from hos_rom";
                        cmd = new SqlCommand(sql, con);

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read() && r["code"] != DBNull.Value)
                            {
                                v_code = Convert.ToInt32(r["code"]) + 1;
                            }
                        }

                        con.Close();

                        if (!string.IsNullOrWhiteSpace(bed_r_no.Text) && !string.IsNullOrEmpty(r_name.Text))
                        {
                            sql = "insert into hos_rom(name, flo , code, bed_no) values (@room_name, @floor_r, @code,@bed_no)";
                            cmd = new SqlCommand(sql, con);
                            cmd.Parameters.AddWithValue("@bed_no", bed_r_no.Text);
                            cmd.Parameters.AddWithValue("@floor_r", floor_r.SelectedValue);
                            cmd.Parameters.AddWithValue("@room_name", r_name.Text);
                            cmd.Parameters.AddWithValue("@code", v_code);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            lbl_2.Text = "تمت الاضافة بنجاح.";
                        }
                        else
                        {
                            lbl_2.Text = "يجب إدخال قيم صحيحة.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_2.Text = $"حدث خطأ: {ex.Message}";
            }
        }
    
        /**********************************************   delete ********************************************************************/

        protected void d_floor(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    if (!string.IsNullOrWhiteSpace(floor_d_f.SelectedValue) )
                    {
                        sql = "delete from hos_floor where name =@name";
                        cmd = new SqlCommand(sql, con);

                        cmd.Parameters.AddWithValue("@name", floor_d_f.SelectedValue);
                       
                   
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lbl_2.Text = "تم الحذف بنجاح";
                    }
                    else
                    {

                        lbl_2.Text = "يجب إدخال قيم ";
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_2.Text = $"حدث خطأ: {ex.Message}";
            }
        }



        protected void d_room(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    if (!string.IsNullOrWhiteSpace(bed_r_no.Text) && !string.IsNullOrEmpty(r_name.Text))
                    {
                        sql = "delete from hos_rom where name = @room_name AND flo = @floor_d_r";
                      
                        cmd = new SqlCommand(sql, con);
             
                        cmd.Parameters.AddWithValue("@floor_d_r", floor_d_r.SelectedValue);
                        cmd.Parameters.AddWithValue("@room_name", rooms_delete.SelectedValue);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lbl_2.Text = "تم الحذف بنجاح";
                    }
                    else
                    {

                        lbl_2.Text = "يجب إدخال قيم ";
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_2.Text = $"حدث خطأ: {ex.Message}";
            }
        }
        /**********************************************   upbed ********************************************************************/

        protected void upbed(object sender, EventArgs e)
        {
            string up_text = "";

            if (rooms_fill.SelectedValue != null)
            {

                if (up_text == "")

                    up_text = " name = @name  ";


                else
                    up_text = up_text + " , name = @name   ";

            }
            if (floor_b.SelectedValue != null)
            {

                if (up_text == "")

                    up_text = " flo = @floor ";


                else
                    up_text = up_text + " , flo = @floor   ";

            }

            if (b_bed_no.Text != null)
            {

                if (up_text == "")

                    up_text = " bed_no = @bed_no  ";


                else
                    up_text = up_text + " , bed_no = @bed_no   ";

            }
            if (up_text != "")
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    sql = "update hos_rom set " + up_text + " where name = @name and flo=@floor";
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@name ", rooms_fill.SelectedValue);
                    cmd.Parameters.AddWithValue("@floor ", floor_b.SelectedValue);
                    cmd.Parameters.AddWithValue("@bed_no", b_bed_no.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lbl_2.Text = "تم التعديل بنجاح";
                }
            }

            else
            {
                lbl_2.Text = "يجب تسجيل بيان واحد على الاقل";
                goto pp1;
            }

        pp1:;

        }
        /**********************************************   load_data ********************************************************************/
        /*
         public DataTable load_data()
         {
                    DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(floor.SelectedValue))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT bed_no, name, code , flo FROM hos_rom WHERE flo = @floor", con);
                    cmd.Parameters.AddWithValue("@floor", floor.SelectedValue);

                    try
                    {
                        con.Open();
                        dt.Load(cmd.ExecuteReader());
                        rooms.DataSource = dt;
                        rooms.DataBind();
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return dt;
         }*/




        public DataTable load_data()
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(floor.SelectedValue))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT bed_no, name, code , flo FROM hos_rom WHERE flo = @floor", con);
                    cmd.Parameters.AddWithValue("@floor", floor.SelectedValue);

                    try
                    {
                        con.Open();
                        dt.Load(cmd.ExecuteReader());
                        rooms.DataSource = dt;
                        rooms.DataBind();

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return dt;
        }





        /*
        public DataTable load_data()
        {
            DataTable dt = new DataTable();

            if (!string.IsNullOrEmpty(floor.SelectedValue))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT bed, room, code FROM hos_stay_b WHERE flo = @floor", con);
                    cmd.Parameters.AddWithValue("@floor", floor.SelectedValue);

                    try
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        dt.Columns.Add("room");
                        dt.Columns.Add("bed");
                        dt.Columns.Add("code");

                       
                        while (reader.Read())
                        {
                            DataRow row = dt.NewRow();
                            row["room"] = reader["room"];
                            row["bed"] = reader["bed"];
                            row["code"] = reader["code"];
                            currentCode = reader["code"].ToString();
                            dt.Rows.Add(row);
                            

                        }

                        rooms.DataSource = dt;
                        rooms.DataBind();
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return dt;
        }
         */
        public DataTable allload_data()
        {
            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT name, bed_no ,flo FROM hos_rom", con);


                try
                {
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    all.DataSource = dt;
                    all.DataBind();
                }
                finally
                {
                    con.Close();
                }
            }


            return dt;
        }

        /**********************************************   GridView ********************************************************************/
        /* protected void rooms_RowDataBound(object sender, GridViewRowEventArgs e)
         {
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 LinkButton lnkBedNo = (LinkButton)e.Row.FindControl("LinkButton1");
                 if (lnkBedNo != null)
                 {
                     int bedNo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "bed_no"));

                     lnkBedNo.Attributes["data-bed"] = bedNo.ToString();

                     lnkBedNo.CssClass = "bedNoLinkButton";
                     lnkBedNo.CommandArgument = bedNo.ToString();
                     lnkBedNo.CommandName = "SelectBed";


                 }
             }
         }


         protected void lnkBedNo_Command(object sender, CommandEventArgs e)
         {

             int bedNo = int.Parse(e.CommandArgument.ToString());
             GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
             AddRectangles(clickedRow, bedNo);
         }

         private void AddRectangles(GridViewRow row, int totalBeds)
         {
             Panel tableContainer = (Panel)row.FindControl("Panel1");
             if (tableContainer != null)
             {
                 tableContainer.Controls.Clear();

                 Table table = new Table();

                 TableRow tableRow = new TableRow();
                 for (int bedNo = 1; bedNo <= totalBeds; bedNo++)
                 {
                     using (SqlConnection con = new SqlConnection(connectionString))
                     {
                         sql = $"SELECT stat, name, code FROM hos_stay_b WHERE bed = {bedNo}";
                         using (SqlCommand cmd = new SqlCommand(sql, con))
                         {
                             con.Open();
                             r = cmd.ExecuteReader();

                             int? status = null;
                             string n = string.Empty;

                             if (r.Read() && !r.IsDBNull(0))
                             {
                                 status = r.GetInt32(0);
                                 n = r.GetString(1);
                             }

                             TableCell cell = new TableCell();
                             Literal square = new Literal();

                             string colorClass = GetColorClass(status);
                             square.Text = $"<div class='square' style='{colorClass}'>{n}</div>";

                             cell.Controls.Add(square);
                             tableRow.Cells.Add(cell);
                         }
                     }
                 }

                 table.Rows.Add(tableRow);
                 tableContainer.Controls.Add(table);
             }
         }*/

        /*
                protected void rooms_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        LinkButton lnkBedNo = (LinkButton)e.Row.FindControl("LinkButton1");
                        if (lnkBedNo != null)
                        {
                            int bedNo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "bed_no"));
                            lnkBedNo.Attributes["data-bed"] = bedNo.ToString();
                            lnkBedNo.CssClass = "bedNoLinkButton";
                            lnkBedNo.CommandArgument = bedNo.ToString();
                            lnkBedNo.CommandName = "SelectBed";


                            LinkButton lnkCode = (LinkButton)e.Row.FindControl("LinkButton2");
                            if (lnkCode != null)
                            {
                                string codeValue = DataBinder.Eval(e.Row.DataItem, "code").ToString();
                                lnkCode.Attributes["data-code"] = codeValue;
                                lnkCode.CssClass = "codeLinkButton";
                                lnkCode.CommandArgument = codeValue;
                                lnkCode.CommandName = "SelectCode";
                            }
                        }
                    }
                }
                protected void lnkBedNo_Command(object sender, CommandEventArgs e)
                {
                    int bedNo = int.Parse(e.CommandArgument.ToString());
                    GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                    AddRectangles(clickedRow, "bed", bedNo);
                }

                protected void lnkCode_Command(object sender, CommandEventArgs e)
                {
                    string codeValue = e.CommandArgument.ToString();
                    GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                    AddRectangles(clickedRow, "code", codeValue);
                }
                private void AddRectangles(GridViewRow row, string fieldName, object value)
                {
                    Panel tableContainer = (Panel)row.FindControl("Panel1");
                    if (tableContainer != null)
                    {
                        tableContainer.Controls.Clear();

                        Table table = new Table();

                        TableRow tableRow = new TableRow();

                        int totalBeds = GetTotalBeds(fieldName, value);

                        for (int bedNo = 1; bedNo <= totalBeds; bedNo++)
                        {
                            using (SqlConnection con = new SqlConnection(connectionString))
                            {
                                sql = $"SELECT stat, name FROM hos_stay_b WHERE {fieldName} = '{value}' AND bed = {bedNo}";
                                using (SqlCommand cmd = new SqlCommand(sql, con))
                                {
                                    con.Open();
                                    r = cmd.ExecuteReader();

                                    int? status = null;
                                    string name = string.Empty;

                                    if (r.Read() && !r.IsDBNull(0))
                                    {
                                        status = r.GetInt32(0);
                                        name = r.GetString(1);
                                    }

                                    TableCell cell = new TableCell();
                                    Literal square = new Literal();

                                    string colorClass = GetColorClass(status);
                                    square.Text = $"<div class='square' style='{colorClass}'>{name}</div>";

                                    cell.Controls.Add(square);
                                    tableRow.Cells.Add(cell);
                                }
                            }
                        }

                        table.Rows.Add(tableRow);
                        tableContainer.Controls.Add(table);
                    }
                }

                private int GetTotalBeds(string fieldName, object value)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        sql = $"SELECT COUNT(*) FROM hos_stay_b WHERE {fieldName} = '{value}'";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            con.Open();
                            return (int)cmd.ExecuteScalar();
                        }
                    }
                }*/



        protected void rooms_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkBedNo = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lnkBedNo != null)
                {
                    int bedNo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "bed_no"));

                    lnkBedNo.Attributes["data-bed"] = bedNo.ToString();
                    lnkBedNo.CssClass = "bedNoLinkButton";
                    lnkBedNo.CommandArgument = bedNo.ToString();
                    lnkBedNo.CommandName = "SelectBed";
                    string code = DataBinder.Eval(e.Row.DataItem, "code").ToString();
                    lnkBedNo.Attributes["data-code"] = code;
                }
            }
        }

        protected void lnkBedNo_Command(object sender, CommandEventArgs e)
        {
            int bedNo = int.Parse(e.CommandArgument.ToString());
            string code = ((LinkButton)sender).Attributes["data-code"];
            GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            AddRectangles(clickedRow, bedNo, code);
        }
        /*
                private void AddRectangles(GridViewRow row, int totalBeds, string code)
                {
                    Panel tableContainer = (Panel)row.FindControl("Panel1");
                    if (tableContainer != null)
                    {
                        tableContainer.Controls.Clear();

                        Table table = new Table();

                        TableRow tableRow = new TableRow();
                        if (!string.IsNullOrEmpty(floor.SelectedValue))
                        {
                            for (int bedNo = 1; bedNo <= totalBeds; bedNo++)
                            {
                                using (SqlConnection con = new SqlConnection(connectionString))
                                {
                                    sql = $"SELECT stat, name FROM hos_stay_b WHERE bed = {bedNo} AND code = '{code}'";
                                    using (SqlCommand cmd = new SqlCommand(sql, con))
                                    {
                                        con.Open();
                                        r = cmd.ExecuteReader();

                                        int? status = null;
                                        string name = string.Empty;

                                        if (r.Read() && !r.IsDBNull(0))
                                        {
                                            status = r.GetInt32(0);
                                            name = r.GetString(1);
                                        }

                                        TableCell cell = new TableCell();
                                        Literal square = new Literal();

                                        string colorClass = GetColorClass(status);
                                        square.Text = $"<div class='square' style='{colorClass}' onclick='toggleFormVisibility(\"frame\")'>{name}</div>";
                                        cell.Controls.Add(square);
                                        tableRow.Cells.Add(cell);
                                    }
                                }
                            }

                            table.Rows.Add(tableRow);
                            tableContainer.Controls.Add(table);


                        }
                    }
                }
                public void ToggleFormVisibility()
                {
                    frame.Visible = !frame.Visible;
                }*/



        private void AddRectangles(GridViewRow row, int totalBeds, string code)
        {
            Panel tableContainer = (Panel)row.FindControl("Panel1");
            if (tableContainer != null)
            {
                tableContainer.Controls.Clear();

                Table table = new Table();

                TableRow tableRow = new TableRow();
                if (!string.IsNullOrEmpty(floor.SelectedValue))
                {
                    for (int bedNo = 1; bedNo <= totalBeds; bedNo++)
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            sql = $"SELECT stat, name FROM hos_stay_b WHERE bed = {bedNo} AND code = '{code}'";
                            using (SqlCommand cmd = new SqlCommand(sql, con))
                            {
                                con.Open();
                                r = cmd.ExecuteReader();

                                int? status = null;
                                string name = string.Empty;

                                if (r.Read() && !r.IsDBNull(0))
                                {
                                    status = r.GetInt32(0);
                                    name = r.GetString(1);
                                }

                                TableCell cell = new TableCell();
                                Literal square = new Literal();

                                string colorClass = GetColorClass(status);
                                square.Text = $"<div class='square' style='{colorClass}' onclick='toggleFormVisibility(\"{frame.ClientID}\");'>{name}</div>";
                                cell.Controls.Add(square);
                                tableRow.Cells.Add(cell);
                            }
                        }
                    }

                    table.Rows.Add(tableRow);
                    tableContainer.Controls.Add(table);
                }
            }
        }


        private string GetColorClass(int? status)
        {
            if (status.HasValue)
            {
                switch (status.Value)
                {
                    case 1:
                        return "background-color: red;";
                    case 2:
                        return "background-color:yellow ;";
                    default:
                        return "background-color: #41AB88;";
                }
            }
            else
            {
                return "background-color: #41AB88;";
            }
        }

        /*  private void AddRectangles(GridViewRow row, int totalBeds)
         {
             Panel tableContainer = (Panel)row.FindControl("Panel1");
             if (tableContainer != null)
             {
                 tableContainer.Controls.Clear();

                 Table table = new Table();

                 TableRow tableRow = new TableRow();

                 for (int bedNo = 1; bedNo <= totalBeds; bedNo++)
                 {
                     if (!string.IsNullOrEmpty(floor.SelectedValue) )
                     {
                         using (SqlConnection con = new SqlConnection(connectionString))
                         {
                             sql = $"SELECT stat, name, room FROM hos_stay_b WHERE bed = {bedNo} AND flo=@floor and room=@rom  ";
                             using (SqlCommand cmd = new SqlCommand(sql, con))
                             {
                                 cmd.Parameters.AddWithValue("@floor", floor.SelectedValue);

                                 cmd.Parameters.AddWithValue("@rom", roomValue); 

                                 con.Open();
                                 r = cmd.ExecuteReader();
                                 int? status = null;
                                 string n = string.Empty;

                                 if (r.Read() && !r.IsDBNull(0))
                                 {
                                     status = r.GetInt32(0);
                                     n = r.GetString(1);
                                 }

                                 TableCell cell = new TableCell();
                                 Literal square = new Literal();

                                 string colorClass = GetColorClass(status);
                                 square.Text = $"<div class='square' style='{colorClass}'>{n}</div>";

                                 cell.Controls.Add(square);
                                 tableRow.Cells.Add(cell);
                             }
                         }
                     }
                 }

                 table.Rows.Add(tableRow);
                 tableContainer.Controls.Add(table);
             }
         }
       */

        /**********************************************   Print_Click ********************************************************************/


        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "تسجيل الغرف.pdf";
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", $"attachment;filename={fileName}");
                Response.ContentEncoding = Encoding.UTF8;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (Document doc = new Document(PageSize.A4, 50f, 50f, 30f, 30f))
                    {
                        PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                        BaseFont bf = BaseFont.CreateFont(Server.MapPath("Hacen Egypt.ttf"), iText.IO.Font.PdfEncodings.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font arabicFont = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                        doc.Open();
                        doc.AddLanguage("ar");

                        DataTable dt = load_data();

                        if (dt.Rows.Count > 0)
                        {
                            ArabicLigaturizer al = new ArabicLigaturizer();
                            string flo = al.Process("  الدور: " + dt.Rows[0]["flo"].ToString());

                        
                            iTextSharp.text.Paragraph titleParagraph = new iTextSharp.text.Paragraph(flo, arabicFont);
                            titleParagraph.Alignment = Element.ALIGN_CENTER;
                            doc.Add(titleParagraph);

                            doc.Add(new iTextSharp.text.Phrase(Environment.NewLine));

                            foreach (DataRow row in dt.Rows)
                            {
                                string bedNo = al.Process(" عدد الاسرة: " + row["bed_no"].ToString());
                                string name = al.Process("  الغرفه: " + row["name"].ToString());

                                iTextSharp.text.Paragraph customParagraph = new iTextSharp.text.Paragraph($"{bedNo}  {name}", arabicFont);
                                customParagraph.Alignment = Element.ALIGN_RIGHT;

                                doc.Add(customParagraph);
                                doc.Add(new iTextSharp.text.Phrase(Environment.NewLine));
                            }

                            doc.Close();
                        }
                    }

                    Response.BinaryWrite(ms.GetBuffer());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('حدث خطأ: {ex.Message}');</script>");
            }
        }

        protected void allprint_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "تسجيل الغرف.pdf";
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", $"attachment;filename={fileName}");
                Response.ContentEncoding = Encoding.UTF8;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (Document doc = new Document(PageSize.A4, 50f, 50f, 30f, 30f))
                    {
                        PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                        BaseFont bf = BaseFont.CreateFont(Server.MapPath("Hacen Egypt.ttf"), iText.IO.Font.PdfEncodings.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font arabicFont = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                        doc.Open();
                        doc.AddLanguage("ar");

                        DataTable dt = allload_data();

                        if (dt.Rows.Count > 0)
                        {
                            ArabicLigaturizer al = new ArabicLigaturizer();

                            foreach (DataRow row in dt.Rows)
                            {
                                string bedNo = al.Process(" عدد الاسرة: " + row["bed_no"].ToString());
                                string name = al.Process("  الغرفه: " + row["name"].ToString());
                                string flo = al.Process("  الدور: " + row["flo"].ToString());

                                iTextSharp.text.Paragraph customParagraph = new iTextSharp.text.Paragraph($"{bedNo}  {name}  {flo}", arabicFont);
                                customParagraph.Alignment = Element.ALIGN_RIGHT;

                                doc.Add(customParagraph);
                                doc.Add(new iTextSharp.text.Phrase(Environment.NewLine));
                    
                            }

                            doc.Close();
                        }
                    }

                    Response.BinaryWrite(ms.GetBuffer());
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('حدث خطأ: {ex.Message}');</script>");
            }
        }

        /* protected void btnPrint_Click(object sender, EventArgs e)
         {
             try
             {
                 string fileName = "تسجيل الغرف.pdf";
                 Response.ContentType = "application/pdf";
                 Response.AddHeader("content-disposition", $"attachment;filename={fileName}");
                 Response.ContentEncoding = Encoding.UTF8;
                 Response.Cache.SetCacheability(HttpCacheability.NoCache);

                 using (MemoryStream ms = new MemoryStream())
                 {
                     using (Document doc = new Document(PageSize.A4, 50f, 50f, 30f, 30f))
                     {
                         PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                         BaseFont bf = BaseFont.CreateFont(Server.MapPath("Hacen Egypt.ttf"), iText.IO.Font.PdfEncodings.IDENTITY_H, BaseFont.EMBEDDED);
                         iTextSharp.text.Font arabicFont = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                         doc.Open();
                         doc.AddLanguage("ar");

                         DataTable dt = load_data();
                         DataTable newDataTable = dt.Clone();
                         if (dt.Rows.Count > 0)
                         {
                             for (int i = dt.Rows.Count - 1; i >= 0; i--)
                             {
                                 newDataTable.ImportRow(dt.Rows[i]);
                             }

                             ArabicLigaturizer al = new ArabicLigaturizer();

                             // Start building a complete HTML content
                             StringBuilder htmlContent = new StringBuilder();

                             // Add HTML table
                             htmlContent.Append("<table border='1'>");

                             foreach (DataRow row in newDataTable.Rows)
                             {
                                 htmlContent.Append("<tr>");
                                 htmlContent.Append("<td style='font-family: " + arabicFont.Family + "; font-size: " + arabicFont.Size + ";'>" +
                                                    "رقم الغرفه: " + al.Process(row["name"].ToString()) + "</td>");
                                 htmlContent.Append("<td style='font-family: " + arabicFont.Family + "; font-size: " + arabicFont.Size + ";'>" +
                                                    "عدد الاسرة: " + al.Process(row["bed_no"].ToString()) + "</td>");
                                 htmlContent.Append("</tr>");
                             }

                             htmlContent.Append("</table>");

                             // Parse HTML content to PDF
                             using (StringReader sr = new StringReader(htmlContent.ToString()))
                             {
                                 HTMLWorker htmlWorker = new HTMLWorker(doc);
                                 htmlWorker.Parse(sr);
                             }

                             doc.Close();
                         }
                     }

                     Response.BinaryWrite(ms.GetBuffer());
                     Response.Flush();
                     Response.End();
                 }
             }
             catch (Exception ex)
             {
                 Response.Write($"<script>alert('حدث خطأ: {ex.Message}');</script>");
             }
         }

    */


        /*  protected void trybedno_room(object sender, EventArgs e)
          {
              try
              {
                  using (SqlConnection con = new SqlConnection(connectionString))
                  {

                      string selectRoomCodeQuery = "SELECT code FROM hos_rom WHERE name = @room_name";
                      using (SqlCommand selectRoomCodeCmd = new SqlCommand(selectRoomCodeQuery, con))
                      {
                          selectRoomCodeCmd.Parameters.AddWithValue("@room_name", tryroom.Text);
                          con.Open();
                          object roomCodeObj = selectRoomCodeCmd.ExecuteScalar();
                          con.Close();


                          if (roomCodeObj != null)
                          {
                              int roomCode = Convert.ToInt32(roomCodeObj);


                              sql = "INSERT INTO hos_stay_b(stat, flo, bed,code, name, room, sick_code) VALUES (@stat, @floo, @bedno, @code, @name, @room_name,@cosick)";
                              cmd = new SqlCommand(sql, con);
                              cmd.Parameters.AddWithValue("@bedno", trybedno.Text);
                              cmd.Parameters.AddWithValue("@floo", tryfloor.Text);
                              cmd.Parameters.AddWithValue("@room_name", tryroom.Text);
                              cmd.Parameters.AddWithValue("@code", roomCode); 
                              cmd.Parameters.AddWithValue("@name", tryname.Text);
                              cmd.Parameters.AddWithValue("@stat", trystat.Text);
                              cmd.Parameters.AddWithValue("@cosick", trysick.Text);

                              con.Open();
                              cmd.ExecuteNonQuery();
                              con.Close();

                              lbl_2.Text = "تمت الإضافة بنجاح.";
                          }
                          else
                          {
                              lbl_2.Text = "لا يوجد كود مرتبط بالغرفة المحددة في جدول hos_sroom.";
                          }
                      }
                  }
              }
              catch (Exception ex)
              {
                  lbl_2.Text = $"حدث خطأ: {ex.Message}";
              }
          }

          */



        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }

    }


}









