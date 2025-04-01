using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace QuanLySanBong
{
    public class ConTrol_KhachHang
    {
        Control_SQL connect = new Control_SQL();
        DataSet ds;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommandBuilder cB;
        public DataTable select(string table)
        {
            ds = new DataSet();
            string selectkh = "select* from " +table;
            SqlCommand cmd = new SqlCommand(selectkh,connect.KetNoi());
            da = new SqlDataAdapter(cmd);
            da.Fill(ds,table);
            dt = ds.Tables[table];
            return dt;

        }
        public DataTable selectchage(string table,string ma,string change)
        {
            ds = new DataSet();
            string selcectkh = "select *from " + table + "where " + ma + "='" + change+"'";
            SqlCommand cmd = new SqlCommand(selcectkh, connect.KetNoi());
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, table);
            dt = ds.Tables[table];
            return dt;
        }
        public bool checkTrungma(string table, string ma)
        {
            DataRow check=ds.Tables[table].Rows.Find(ma);

            if(check!=null)
            {
                return true;
            }
            return false;
        }
        public void insert(Model_KhachHang kh,string table)
        {
            DataRow dr=ds.Tables[table].NewRow();
            dr[0]=kh.IdKH;
            dr[1]=kh.HoTen;
            dr[2]=kh.GioiTinh;
            dr[4]=kh.Email;
            dr[3]=kh.SDT;
            dr[5]=kh.DiaChi;
            ds.Tables[table].Rows.Add(dr);
            cB = new SqlCommandBuilder(da);
            da.Update(ds, table);
        }
        public void update(Model_KhachHang kh,string table)
        {
            DataRow dr = ds.Tables[table].Rows.Find(kh.IdKH);
            if (dr != null)
            {
                bool isUpdated = false;
                if (dr[1].ToString() != kh.HoTen) { dr[1] = kh.HoTen; isUpdated = true; }
                if (dr[2].ToString() != kh.GioiTinh) { dr[2] = kh.GioiTinh; isUpdated = true; }
                if (dr[4].ToString() != kh.Email) { dr[4] = kh.Email; isUpdated = true; }
                if (dr[3].ToString() != kh.SDT) { dr[3] = kh.SDT; isUpdated = true; }
                if (dr[5].ToString() != kh.DiaChi) { dr[5] = kh.DiaChi; isUpdated = true; }
                if (isUpdated)
                {
                    new SqlCommandBuilder(da); 
                    da.Update(ds, table);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Dữ liệu không thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Mã khách hàng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void delete(Model_KhachHang kh,string table)
        {
            DataRow dr = ds.Tables[table].Rows.Find(kh.IdKH);
            if(dr!=null)
            {
                dr.Delete();
            }
            cB = new SqlCommandBuilder(da);
            da.Update(ds, table);
        }
        public void save(string table)
        {
            string select = "select*from " + table;
            da = new SqlDataAdapter(select, connect.KetNoi());
            cB = new SqlCommandBuilder(da);
            da.Update(ds, table);
        }

        public DataTable SearchCustomers( string keyword)
        {
            DataTable result = new DataTable();

            try
            {
                SqlConnection conn = connect.KetNoi();
                conn.Open();

                string query = @"
            SELECT *
            FROM KHACHHANG
            WHERE 
                Hoten LIKE @keyword OR
                GioiTinh LIKE @keyword OR
                SDT LIKE @keyword OR
                Email LIKE @keyword OR
                DiaChi LIKE @keyword";
                da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                cB = new SqlCommandBuilder(da);
                da.Fill(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            return result;
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
