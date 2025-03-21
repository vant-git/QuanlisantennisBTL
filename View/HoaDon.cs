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
    public partial class HoaDon : Form
    {
        Control_SQL connect = new Control_SQL();
        DataColumn[] key = new DataColumn[1];
        Control_HoaDon hd = new Control_HoaDon();
        string table = "HOADON";
        public HoaDon()
        {
            InitializeComponent();
        }
        void addHeader()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("IdHoaDon", "Mã Hóa Đơn ");
            dataGridView1.Columns[0].DataPropertyName = "IdHoaDon";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns.Add("IdKH", "Mã Khách Hàng");
            dataGridView1.Columns[1].DataPropertyName = "IdKH";
            dataGridView1.Columns.Add("IdSan", "Mã Sân");
            dataGridView1.Columns[2].DataPropertyName = "IdSan";
            dataGridView1.Columns.Add("NgayDatSan", "Ngày Đặt Sân");
            dataGridView1.Columns[3].DataPropertyName = "NgayDatSan";
            dataGridView1.Columns.Add("TGNhanSan", "Thời gian nhận sân");
            dataGridView1.Columns[4].DataPropertyName = "TGNhanSan";
            dataGridView1.Columns.Add("TGTraSan", "Thời gian trả sân");
            dataGridView1.Columns[5].DataPropertyName = "TGTraSan";
            dataGridView1.Columns.Add("TongTien", "Tổng tiền");
            dataGridView1.Columns[6].DataPropertyName = "TongTien";
            dataGridView1.Columns.Add("NgayLap", "Ngày lập");
            dataGridView1.Columns[6].DataPropertyName = "NgayLap";

        }
        void loadcombobox_KH()
        {
            string table1 = "KHACHHANG";
            DataTable dt = hd.select(table1);
            cbb_kh.DataSource = dt;
            cbb_kh.DisplayMember = "Hoten";
            cbb_kh.ValueMember = "IdKH";

        }
        void loadbombobox_San()
        {
            string table1 = "SAN";
            DataTable dt = hd.select(table1);
            cbb_san.DataSource = dt;
            cbb_san.DisplayMember = "TenSan";
            cbb_san.ValueMember = "IdSan";
        }

        void loadDTG_San()
        {
            string ma = "IdSan";
            string change = cbb_san.SelectedValue.ToString();
            DataTable dtSV = hd.selectedChance(table, ma, change);
            dataGridView1.DataSource = dtSV;
            key[0] = dtSV.Columns[0];
            dtSV.PrimaryKey = key;

        }
        void loadDTG_KH()
        {
            string ma = "IdKH";

            string change = cbb_kh.SelectedValue.ToString();
            DataTable dtSV = hd.selectedChance(table, ma, change);
            dataGridView1.DataSource = dtSV;
            key[0] = dtSV.Columns[0];
            dtSV.PrimaryKey = key;

        }
        void loadDTG_Ngaylap()
        {

            string ma = "NgayLap";
            string change = dtp_ngaylap.Text;
            DataTable dtSV = hd.selectedChance(table, ma, change);
            dataGridView1.DataSource = dtSV;
            key[0] = dtSV.Columns[0];
            dtSV.PrimaryKey = key;
        }
        void loadDGT_ALL()
        {
            DataTable dtHD = hd.select(table);
            dataGridView1.DataSource = dtHD;
            key[0] = dtHD.Columns[0];
            dtHD.PrimaryKey = key;
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            addHeader();
            loadbombobox_San();
            loadcombobox_KH();
            loadDGT_ALL();

        }

        private void cbb_kh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //private void cbb_san_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    loadDTG_San();
        //}

        private void themToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Model_HoaDon newhd = new Model_HoaDon();
                newhd.IdHD = txt_mahd.Text;
                newhd.IdKH = cbb_kh.SelectedValue.ToString().Trim();
                newhd.IdSan = cbb_san.SelectedValue.ToString().Trim();
                newhd.Ngaydat = dtp_ngaydat.Text;
                newhd.TgNhan = dtp_tgnhan.Text;
                newhd.TgTra = dtp_tgtra.Text;
                newhd.TongTien = txt_tongtien.Text;
                dtp_ngaylap.Value = DateTime.Today;
                newhd.Ngaylap = dtp_ngaylap.Text;
                if (hd.checkTrungma(newhd.IdHD, table) == true)
                {
                    MessageBox.Show("Trùng mã rồi ");
                    return;
                }
                hd.insert(newhd, table);
                luuToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi");
            }
        }

        private void xoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Model_HoaDon newhd = new Model_HoaDon();
                newhd.IdHD = txt_mahd.Text;
                newhd.IdKH = cbb_kh.SelectedValue.ToString().Trim();
                newhd.IdSan = cbb_san.SelectedValue.ToString().Trim();
                newhd.Ngaydat = dtp_ngaydat.Text;
                newhd.TgNhan = dtp_tgnhan.Text;
                newhd.TgTra = dtp_tgtra.Text;
                newhd.TongTien = txt_tongtien.Text;
                newhd.Ngaylap = dtp_ngaylap.Text;
                if (hd.checkTrungma(newhd.IdHD, table) == false)
                {
                    MessageBox.Show("Trùng mã rồi ");
                    return;
                }
                hd.delete(newhd, table);
                luuToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi");
            }
        }

        private void suaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Model_HoaDon newhd = new Model_HoaDon();
                newhd.IdHD = txt_mahd.Text;
                newhd.IdKH = cbb_kh.SelectedValue.ToString().Trim();
                newhd.IdSan = cbb_san.SelectedValue.ToString().Trim();
                newhd.Ngaydat = dtp_ngaydat.Text;
                newhd.TgNhan = dtp_tgnhan.Text;
                newhd.TgTra = dtp_tgtra.Text;
                newhd.TongTien = txt_tongtien.Text;
                newhd.Ngaylap = dtp_ngaylap.Text;
                if (hd.checkTrungma(newhd.IdHD, table) == false)
                {

                    MessageBox.Show("Không tìm thấy!");
                    return;
                }
                hd.update(newhd, table);
                luuToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi");
            }
        }

        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                hd.luu(table);
                MessageBox.Show("Lưu Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rồi");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    txt_mahd.Text = dataGridView1.CurrentRow.Cells[0].Value?.ToString() ?? string.Empty;
                    cbb_kh.SelectedValue = dataGridView1.CurrentRow.Cells["Mã Khách Hàng"].Value?.ToString();
                    cbb_san.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value?.ToString();
                    dtp_ngaydat.Value = DateTime.TryParse(dataGridView1.CurrentRow.Cells[3].Value?.ToString(), out var ngayDat) ? ngayDat : DateTime.Now;
                    //dtp_tgnhan.Value = DateTime.TryParse(dataGridView1.CurrentRow.Cells[4].Value?.ToString(), out var tgNhan) ? tgNhan : DateTime.Now;
                    //dtp_tgtra.Value = DateTime.TryParse(dataGridView1.CurrentRow.Cells[5].Value?.ToString(), out var tgTra) ? tgTra : DateTime.Now;
                    txt_tongtien.Text = dataGridView1.CurrentRow.Cells[6].Value?.ToString() ?? string.Empty;
                    dtp_ngaylap.Value = DateTime.TryParse(dataGridView1.CurrentRow.Cells[7].Value?.ToString(), out var ngayLap) ? ngayLap : DateTime.Now;

                    suaToolStripMenuItem.Enabled = luuToolStripMenuItem.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi xử lý dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dtp_tgnhan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtp_ngaylap_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            loadDTG_KH();
            loadDTG_San();
            //loadDTG_Ngaylap();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    cbb_kh.SelectedValue = selectedRow.Cells["IdKH"].Value?.ToString() ?? "";
                    cbb_san.SelectedValue = selectedRow.Cells["IdSan"].Value?.ToString() ?? "";
                    txt_mahd.Text = selectedRow.Cells["IdHoaDon"].Value?.ToString().Trim() ?? "";
                    txt_tongtien.Text = selectedRow.Cells["Tongtien"].Value?.ToString().Trim() ?? "";
                    dtp_ngaydat.Value = DateTime.Parse(selectedRow.Cells["NgayDatSan"].Value?.ToString().Trim() ?? "");
                    dtp_ngaylap.Value = DateTime.Parse(selectedRow.Cells["NgayDatSan"].Value?.ToString().Trim() ?? "");
                    dtp_tgnhan.Value = DateTime.Parse(selectedRow.Cells["TGNhanSan"].Value?.ToString().Trim() ?? "");
                    dtp_tgtra.Value = DateTime.Parse(selectedRow.Cells["TGTraSan"].Value?.ToString().Trim() ?? "");

                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi xử lý dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbb_kh_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dtp_tgtra_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
