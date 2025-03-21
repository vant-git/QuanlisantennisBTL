using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySanBong.View
{
    public partial class SanBong : Form
    {
        Control_SQL connect = new Control_SQL();
        DataColumn[] key = new DataColumn[1];
        Control_San san = new Control_San();
        Control_LoaiSan loaisan = new Control_LoaiSan();
        string table = "SAN";
        public SanBong()
        {
            InitializeComponent();
        }
        void addHeader()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("IdSan", "Mã Sân");
            dataGridView1.Columns[0].DataPropertyName = "IdSan";
            dataGridView1.Columns.Add("IdLoaiSan", "Mã Loại Sân");
            dataGridView1.Columns[1].DataPropertyName = "IdLoaiSan";
            dataGridView1.Columns.Add("TenSan", "Tên Sân");
            dataGridView1.Columns[2].DataPropertyName = "TenSan";
            dataGridView1.Columns.Add("Gia", "Giá");
            dataGridView1.Columns[3].DataPropertyName = "Gia";
            dataGridView1.Columns.Add("TrangThai", "Trạng thái");
            dataGridView1.Columns[4].DataPropertyName = "TrangThai";
            dataGridView1.Columns.Add("MoTa", "Mô tả");
            dataGridView1.Columns[5].DataPropertyName = "MoTa";
        }
        void loadDTG()
        {
            DataTable dtls = san.select_San(table);
            dataGridView1.DataSource = dtls;
            key[0] = dtls.Columns[0];
            dtls.PrimaryKey = key;
        }
        void loadCBBLoai()
        {
            string table1 = "LOAISAN";
            DataTable dt = loaisan.select(table1);
            cboloai.DataSource = dt;
            cboloai.DisplayMember = "TenLoaiSan";
            cboloai.ValueMember = "IdLoaiSan";
        }
        void loadDTG_theoloai()
        {
            if (cboloai.SelectedValue != null)
            {
                string ma = "IdLoaiSan"; 
                string change = cboloai.SelectedValue.ToString(); 

                DataTable dtls = san.selectedChance(table, ma, change);
                if (dtls != null && dtls.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dtls;
                    DataColumn[] key = new DataColumn[1];
                    key[0] = dtls.Columns[0]; 
                    dtls.PrimaryKey = key;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu cho loại sản phẩm này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
  
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txt_masan.Text = dataGridView1.CurrentRow.Cells[0].Value?.ToString() ?? string.Empty;
                cboloai.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value?.ToString() ?? string.Empty;
                txtxten.Text = dataGridView1.CurrentRow.Cells[2].Value?.ToString() ?? string.Empty;
                txtgia.Text = dataGridView1.CurrentRow.Cells[3].Value?.ToString() ?? string.Empty;
                txttrangthai.Text = dataGridView1.CurrentRow.Cells[4].Value?.ToString() ?? string.Empty;
                txtmota.Text = dataGridView1.CurrentRow.Cells[5].Value?.ToString() ?? string.Empty;

                sửaToolStripMenuItem.Enabled = true;
                lưuToolStripMenuItem.Enabled = true;
                xóaToolStripMenuItem.Enabled = true;
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Model_San news = new Model_San();
                news.IdSan = txt_masan.Text;
                news.IdLoaiSan = cboloai.SelectedValue.ToString().Trim();
                news.TenSan = txtxten.Text;
                news.Gia = txtgia.Text;
                news.TrangThai = txttrangthai.Text;
                news.MoTa = txtmota.Text;
                if (san.checkTrungID(news.IdSan, table) == true)
                {
                    MessageBox.Show("Trùng id rồi ");
                    return;
                }
                san.insert(news, table);
                lưuToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi");
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                Model_San news = new Model_San();
                news.IdSan = txt_masan.Text;
                news.IdLoaiSan = cboloai.SelectedValue.ToString().Trim();
                news.TenSan = txtxten.Text;
                news.Gia = txtgia.Text;
                news.TrangThai = txttrangthai.Text;
                news.MoTa = txtmota.Text;
                if (san.checkTrungID(news.IdSan, table) == false)
                {
                    MessageBox.Show("Id cần xóa không Khớp");
                    return;
                }

                san.delete(news, table);
                lưuToolStripMenuItem.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi");
            }
        }
        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

               
                Model_San news = new Model_San();
                news.IdSan = txt_masan.Text;
                news.IdLoaiSan = cboloai.SelectedValue.ToString().Trim();
                news.TenSan = txtxten.Text;
                news.Gia = txtgia.Text;
                news.TrangThai = txttrangthai.Text;
                news.MoTa = txtmota.Text;
                if (san.checkTrungID(news.IdSan, table) == false)
                {
                    MessageBox.Show("Id cần sửa không Khớp");
                    return;
                }

                san.update(news, table);
                lưuToolStripMenuItem.Enabled = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi");
            }
        }

        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                san.luu(table);
                MessageBox.Show("Lưu Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi");
            }
        }

   

        private void SanBong_Load(object sender, EventArgs e)
        {
            loadCBBLoai();
            addHeader();
            //loadDTG();
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            loadDTG_theoloai();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Kiểm tra nếu các ô dữ liệu không null trước khi gán vào các textbox và combobox
                txt_masan.Text = dataGridView1.CurrentRow.Cells[0].Value?.ToString() ?? string.Empty;
                cboloai.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value?.ToString() ?? string.Empty;
                txtxten.Text = dataGridView1.CurrentRow.Cells[2].Value?.ToString() ?? string.Empty;
                txtgia.Text = dataGridView1.CurrentRow.Cells[3].Value?.ToString() ?? string.Empty;
                txttrangthai.Text = dataGridView1.CurrentRow.Cells[4].Value?.ToString() ?? string.Empty;
                txtmota.Text = dataGridView1.CurrentRow.Cells[5].Value?.ToString() ?? string.Empty;

                // Kích hoạt các nút khi đã có dữ liệu
                sửaToolStripMenuItem.Enabled = true;
                lưuToolStripMenuItem.Enabled = true;
                xóaToolStripMenuItem.Enabled = true;
            }
        }

        private void đóngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
