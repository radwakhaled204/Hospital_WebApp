using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Royal_Elshrouq
{
    public partial class save_room : System.Web.UI.Page
    {
        private string connectionString;
        public SqlDataReader r;
        public SqlCommand cmd;
        DataTable dt;
        public int v_code = 1;
        string sql = "";
        string roomValue = "";


        public save_room()
        {

            connectionString = ConfigurationManager.ConnectionStrings["ConData"].ConnectionString;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void trybedno_room(object sender, EventArgs e)
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

    }
}