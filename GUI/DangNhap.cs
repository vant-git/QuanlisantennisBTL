using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLySanBong.View
{
    public partial class DangNhap : Form
    {

        SqlConnection connsql;
        string tenkh;
        public DangNhap()
        {
            string con = @"Data Source=.;Initial Catalog=QuanLySanBong;Integrated Security=True";
            connsql = new SqlConnection(con);
            InitializeComponent();

        }
        void loadTen()
        {
            
            connsql.Open();
            string selectmaKH = "select * from KHACHHANG where SDT='"+ txt_sdt.Text +"'";
            SqlCommand cmd = new SqlCommand(selectmaKH, connsql);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                tenkh = rd["HoTen"].ToString().Trim();
            }
            connsql.Close();

        }

        void KTDC()
        {
            try
            {
                connsql.Open();
                string s = "select * from TAIKHOAN where SDT = @sdt and MatKhau = @matkhau";
                SqlCommand cmd = new SqlCommand(s, connsql);
                cmd.Parameters.AddWithValue("@sdt", txt_sdt.Text.Trim());
                cmd.Parameters.AddWithValue("@matkhau", txt_mk.Text.Trim());

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows) // Kiểm tra nếu có dữ liệu
                {
                    while (dr.Read())
                    {
                        if (dr["vaitro"].ToString().Trim() == "addmin") // Sửa "addmin" thành "admin"
                        {
                            this.Hide();
                            MenuQL Child = new MenuQL { SDT = txt_sdt.Text.Trim() };
                            Child.Show();
                        }
                        else
                        {
                            MenuKH Child = new MenuKH { SDT = txt_sdt.Text.Trim() };
                            Child.TenKH = tenkh;
                            this.Hide();
                            Child.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void btn_dn_Click(object sender, EventArgs e)
        {
            loadTen();
            KTDC();

        }
        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy DK = new DangKy();
            DK.Show();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txt_sdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
