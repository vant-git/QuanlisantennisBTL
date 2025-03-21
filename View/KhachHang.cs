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
using System.Security.Cryptography;
namespace QuanLySanBong.View
{
    public partial class KhachHang : Form
    {
        SqlConnection connsql;
        Control_SQL connect = new Control_SQL();
        ConTrol_KhachHang kh = new ConTrol_KhachHang();
        string table = "KHACHHANG";
        DataColumn[] key = new DataColumn[1];
        public KhachHang()
        {
            string sv = @".";
            string dtb = "QuanLySanBong";
            string con = "Data Source=" + sv + ";Initial Catalog=" + dtb + ";Integrated Security=True ";
            connsql = new SqlConnection(con);
            InitializeComponent();
        }
        void addHead()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("idKH", "Mã Khách Hàng");
            dataGridView1.Columns[0].DataPropertyName = "idKH";
            dataGridView1.Columns.Add("HoTen", "Họ Tên");
            dataGridView1.Columns[1].DataPropertyName = "HoTen";
            dataGridView1.Columns.Add("GioiTinh", "Giới Tính");
            dataGridView1.Columns[2].DataPropertyName = "GioiTinh";
            dataGridView1.Columns.Add("SDT", "SDT");
            dataGridView1.Columns[3].DataPropertyName = "SDT";
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns[4].DataPropertyName = "Email";
            dataGridView1.Columns.Add("DiaChi", "Địa chỉ");
            dataGridView1.Columns[5].DataPropertyName = "DiaChi";
        }

        void loadDGT()
        {
            DataTable dskh = kh.select(table);
            dataGridView1.DataSource = dskh;
            key[0] = dskh.Columns[0];
            dskh.PrimaryKey = key;


        }




        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void themToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Model_KhachHang newkh = new Model_KhachHang();
                newkh.IdKH = txt_makh.Text;
                newkh.HoTen = txt_tenkh.Text;
                newkh.GioiTinh = cbb_gioitinh.Text;
                newkh.SDT = txt_sdt.Text;
                newkh.Email = txt_email.Text;
                newkh.DiaChi = txt_diachi.Text;
                if (kh.checkTrungma(table, newkh.IdKH) == true)
                {
                    MessageBox.Show("Trùng mã rồi");
                    return;
                }
                kh.insert(newkh, table);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi!");
            }
        }


        private void KhachHang_Load(object sender, EventArgs e)
        {
            addHead();
            loadDGT();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txt_makh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_tenkh.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cbb_gioitinh.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_sdt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_email.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txt_diachi.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                suaToolStripMenuItem.Enabled = true;

            }

        }

        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                kh.save(table);
                MessageBox.Show("Lưu Thành công");
                loadDGT();
            }
            catch
            {
                MessageBox.Show("Lưu thất bại");
            }
        }

        void deleteTKKH()
        {
            try
            {
                connsql.Open();

                string deleteTKKH = "delete TAIKHOAN where SDT='" + txt_sdt.Text + "'";
                SqlCommand cmd = new SqlCommand(deleteTKKH, connsql);
                cmd.ExecuteNonQuery();
                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
            }
        }
        private void xoaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Model_KhachHang dlkh = new Model_KhachHang();
                dlkh.IdKH = txt_makh.Text;

                if (kh.checkTrungma(table, dlkh.IdKH) == false)
                {
                    MessageBox.Show("Mã không trùng khớp!");
                    return;
                }
                deleteTKKH();
                kh.delete(dlkh, table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi!");
            }

        }

        private void suaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(errorProvider1.GetError(txt_email)))
                {
                    MessageBox.Show("Email chưa được nhập đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
                Model_KhachHang udkh = new Model_KhachHang
                {
                    IdKH = txt_makh.Text,
                    HoTen = txt_tenkh.Text,
                    GioiTinh = cbb_gioitinh.Text,
                    SDT = txt_sdt.Text,
                    Email = txt_email.Text,
                    DiaChi = txt_diachi.Text
                };
                if (!kh.checkTrungma(table, udkh.IdKH))
                {
                    MessageBox.Show("Không đúng mã!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                kh.update(udkh, table);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dba = kh.SearchCustomers(txt_timkiem.Text.Trim());
                if (dba == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng!!");
                }
                else
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dba;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xảy ra!!!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) 
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string hoten = selectedRow.Cells["hoten"].Value?.ToString() ?? ""; 
                string sodienthoai = selectedRow.Cells["SDT"].Value?.ToString() ?? ""; 
                string email = selectedRow.Cells["email"].Value?.ToString() ?? ""; 
                string diachi = selectedRow.Cells["diachi"].Value?.ToString() ?? "";

                txt_tenkh.Text = hoten;
                txt_sdt.Text = sodienthoai;
                txt_email.Text = email;
                txt_diachi.Text = diachi;

            }
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            string email = txt_email.Text.Trim();
            bool chk = kh.IsValidEmail(txt_email.Text.Trim());
            if (!chk && email.Length > 0)
            {
                errorProvider1.SetError(txt_email, "Email không đúng định dạng. Vui lòng nhập lại!");
            }
            else
            {
                errorProvider1.SetError(txt_email, "");
            }
        }
    }
}
