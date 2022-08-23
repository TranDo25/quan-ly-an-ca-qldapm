using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using System.Configuration;
using Quanlicaan.Models;
using System.Data;
using Quanlicaan.Models.ModelADO;
using Quanlicaan.Models.DTO;

namespace Quanlicaan.DataAccessLayer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public void Add_Record(NhanVienModel nv)
        {
            SqlCommand com = new SqlCommand("Sp_NhanVien_Add", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@hoTen", nv.hoTen);
            com.Parameters.AddWithValue("@IDPhongBan", nv.IDPhongBan);
            com.Parameters.AddWithValue("@username", nv.username);
            com.Parameters.AddWithValue("@password", nv.password);
            com.Parameters.AddWithValue("@IDRole", nv.IDRole);
            com.Parameters.AddWithValue("@quyen", nv.quyen);
            com.Parameters.AddWithValue("@trangThai", nv.trangThai);
            com.Parameters.AddWithValue("@gioiTinh", nv.gioiTinh);
            com.Parameters.AddWithValue("@diaChi", nv.address);
            com.Parameters.AddWithValue("@phone", nv.phone);
            com.Parameters.AddWithValue("@email", nv.email);
            com.Parameters.AddWithValue("@birthday", nv.birthday);
         
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        //public SuatAn getSuatAnByIDUser(int IDUser)
        //{
        //    SqlCommand com = new SqlCommand("getSuatAnByIDUser", con);
        //    com.CommandType = CommandType.StoredProcedure;
      
        //    com.Parameters.AddWithValue("@today", DateTime.Today);  
        //    com.Parameters.AddWithValue("@IDUser", IDUser);
        //    SqlDataAdapter adapter = new SqlDataAdapter(com);
        //    DataTable dataTable = new DataTable();
        //    adapter.Fill(dataTable);
        //    SuatAn suatAn = new SuatAn();
        //    int count = 0;
        //    for (int i = 0; i < dataTable.Rows.Count; i++)
        //    {
        //        ChiTietSuatAn tmp = new ChiTietSuatAn();
        //        suatAn.ds.Add(tmp);
        //        suatAn.ID = Convert.ToInt32(dataTable.Rows[i]["IDSuatAn"]);
        //        suatAn.nhanVien.ID = Convert.ToInt32(dataTable.Rows[i]["IDUser"]);
        //        suatAn.Thoigiandat = Convert.ToDateTime(dataTable.Rows[i]["Thoigiandat"]);
        //        suatAn.ds[i].ID = Convert.ToInt32(dataTable.Rows[i]["IDChiTietSuatAn"]);
        //        suatAn.ds[i].Soluong = Convert.ToInt32(dataTable.Rows[i]["SoLuong"]);
        //        suatAn.nhanVien.IDPhongBan = Convert.ToInt32(dataTable.Rows[i]["IDSuatAn"]);
        //        suatAn.ds[i].caAn.ID = Convert.ToInt32(dataTable.Rows[i]["IDCaAn"]);
        //    }
        //    return suatAn;
        //}
      

        public void Add_Record(PhongBan pb)
        {
            SqlCommand com = new SqlCommand("Sp_PhongBan_Add", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TenPB", pb.TenPB);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Get_User_Session(string username, string password)
        {
            SqlCommand com = new SqlCommand("Sp_Login_Session", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            com.Parameters.AddWithValue("@username", username);
            com.Parameters.AddWithValue("@password", password);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Get_Employee_By_IDPhongBan(int IDPhongBan)
        {
            SqlCommand com = new SqlCommand("Sp_Get_Employee_By_IDPhongBan", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            com.Parameters.AddWithValue("@IDPhongBan", IDPhongBan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void Add_New_PersonalRegister(DangKyCaNhanModel model)
        {
            SqlCommand com = new SqlCommand("Sp_DangKyCaNhan", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IDNhanVien", model.ID_NDK);
            com.Parameters.AddWithValue("@ngayDK", model.ngayDK);
            com.Parameters.AddWithValue("@SLCa1", model.SLCa1);
            com.Parameters.AddWithValue("@SLCa2", model.SLCa2);
            com.Parameters.AddWithValue("@SLCa3", model.SLCa3);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void Add_New_GroupRegister(DangKyTapTheModel model)
        {

            SqlCommand com = new SqlCommand("Sp_TapThe_Add_New_SuatAn", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IDUser", model.IDNguoiDK);
            com.Parameters.AddWithValue("@ThoiGianDat", model.ngayDK);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            for (int i = 0; i < model.dsNV.Count; i++)
            {
                SqlCommand com2 = new SqlCommand("Sp_TapThe_Add_New_ChiTietSuatAn", con);
                com2.CommandType = System.Data.CommandType.StoredProcedure;
                com2.Parameters.AddWithValue("@IDUser", model.dsNV[i].ID);
                com2.Parameters.AddWithValue("@SLCa1", model.dsNV[i].SLCa1);
                com2.Parameters.AddWithValue("@SLCa2", model.dsNV[i].SLCa2);
                com2.Parameters.AddWithValue("@SLCa3", model.dsNV[i].SLCa3);
                con.Open();
                com2.ExecuteNonQuery();
                con.Close();
            }


        }
        public void Update_Record(NhanVienModel nv)
        {
            SqlCommand com = new SqlCommand("Sp_NhanVien_Update", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", nv.ID);
            com.Parameters.AddWithValue("@hoTen", nv.hoTen);
            com.Parameters.AddWithValue("@IDPhongBan", nv.IDPhongBan);
            com.Parameters.AddWithValue("@username", nv.username);
            com.Parameters.AddWithValue("@password", nv.password);
            com.Parameters.AddWithValue("@IDRole", nv.IDRole);
            com.Parameters.AddWithValue("@quyen", nv.quyen);
            com.Parameters.AddWithValue("@gioiTinh", nv.gioiTinh);
            com.Parameters.AddWithValue("@phone", nv.phone);
            com.Parameters.AddWithValue("@email", nv.email);
            com.Parameters.AddWithValue("@diaChi", nv.address);
            com.Parameters.AddWithValue("@ngaySinh", nv.birthday);
            com.Parameters.AddWithValue("@trangThai", nv.trangThai);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Update_Record(PhongBan pb)
        {
            SqlCommand com = new SqlCommand("Sp_PhongBan_Update", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", pb.ID);
            com.Parameters.AddWithValue("@TenPB", pb.TenPB);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Show_Record_ById(int id)
        {
            SqlCommand com = new SqlCommand("Sp_NhanVien_Id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public List<ThongKeTheoNgayModel> GetListRegisterByDay(DateTime currrentDate)
        {
            List<ThongKeTheoNgayModel> ds = new List<ThongKeTheoNgayModel>();
            SqlCommand com = new SqlCommand("Sp_ThongKeCaAnNgay", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Date", currrentDate);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ThongKeTheoNgayModel x = new ThongKeTheoNgayModel();
                x.ID = i;
                x.IDNhanvien = Convert.ToInt32(dataTable.Rows[i]["IDNhanVien"]);
                x.TenPhongBan = Convert.ToString(dataTable.Rows[i]["TenPB"]);
                x.IDCaAn = Convert.ToInt32(dataTable.Rows[i]["IDCaan"]);
                x.SoLuong = Convert.ToInt32(dataTable.Rows[i]["Soluong"]);
                x.TenNhanVien = Convert.ToString(dataTable.Rows[i]["hoTenNguoiAn"]);
                ds.Add(x);
            }
            return ds;
        }
        public List<ThongKeTheoThangModel> GetListRegisterByMonth(int month, int year)
        {
            List<ThongKeTheoThangModel> ds = new List<ThongKeTheoThangModel>();
            SqlCommand com = new SqlCommand("Sp_ThongKeAnCaThang", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Month", month);
            com.Parameters.AddWithValue("@Year", year);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ThongKeTheoThangModel x = new ThongKeTheoThangModel();
                x.ID = i;
                x.IDNhanvien = Convert.ToInt32(dataTable.Rows[i]["IDNhanVien"]);
                x.TenPhongBan = Convert.ToString(dataTable.Rows[i]["TenPB"]);
                x.IDCaAn = Convert.ToInt32(dataTable.Rows[i]["IDCaan"]);
                x.SoLuong = Convert.ToInt32(dataTable.Rows[i]["Soluong"]);
                x.TenNhanVien = Convert.ToString(dataTable.Rows[i]["hoTenNguoiAn"]);
                x.IDNguoiAn = Convert.ToInt32(dataTable.Rows[i]["IDNguoiAn"]);
                ds.Add(x);
            }
            return ds;
        }
        public int Get_IDPhongBan_ById(int id)
        {
            Int32 IDPhongBan = 0;
            string sql = "SELECT IDPhongBan from NhanVien where ID = @ID";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.Add("@ID", SqlDbType.Int);
            com.Parameters["@ID"].Value = id;

            try
            {
                con.Open();
                IDPhongBan = (Int32)com.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return (int)IDPhongBan;
        }

        public DataSet Show_PhongBan_Record_ById(int id)
        {
            SqlCommand com = new SqlCommand("Sp_PhongBan_Id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_All_Data()
        {
            SqlCommand com = new SqlCommand("Sp_NhanVien_All", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public List<ThongKeCaNhanModel> GetListPersonalRegister(DateTime currrentDate, DateTime firstDayOfMonth, int UserID)
        {
            List<ThongKeCaNhanModel> ds = new List<ThongKeCaNhanModel>();
            SqlCommand com = new SqlCommand("Sp_ThongKeSuatAnCaNhan", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@currentDate", currrentDate);
            com.Parameters.AddWithValue("@firstDayOfMonth", firstDayOfMonth);
            com.Parameters.AddWithValue("@UserID", UserID);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            List<DateTime> thoiGian = new List<DateTime>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ThongKeCaNhanModel x = new ThongKeCaNhanModel();
                x.ngayDK = Convert.ToDateTime(dataTable.Rows[i]["Thoigiandat"]);

                for (int j = 0; j < dataTable.Rows.Count; j++)
                {

                    if (thoiGian.Contains(Convert.ToDateTime(dataTable.Rows[j]["Thoigiandat"])) == false)
                    {
                        if (Convert.ToDateTime(dataTable.Rows[j]["Thoigiandat"]) == x.ngayDK)
                        {

                            if (Convert.ToInt32(dataTable.Rows[j]["IDCaan"]) == 1)
                                x.SLCa1 = Convert.ToInt32(dataTable.Rows[j]["SoLuong"]);
                            else if (Convert.ToInt32(dataTable.Rows[j]["IDCaan"]) == 2)
                                x.SLCa2 = Convert.ToInt32(dataTable.Rows[j]["SoLuong"]);
                            else if (Convert.ToInt32(dataTable.Rows[j]["IDCaan"]) == 3)
                                x.SLCa3 = Convert.ToInt32(dataTable.Rows[j]["SoLuong"]);
                        }

                    }
                }
                int flag = 0;
                thoiGian.Add(x.ngayDK);
                if (x.SLCa1 == 0 && x.SLCa2 == 0 && x.SLCa3 == 0)
                {
                    flag = 1;
                }
                if (flag == 0) ds.Add(x);

            }
            return ds;
        }
        public DataSet Show_All_PhongBan_Data()
        {
            SqlCommand com = new SqlCommand("Sp_PhongBan_All", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void Delete_Record(int id)
        {
            SqlCommand com = new SqlCommand("Sp_NhanVien_Delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Delete_PhongBan_Record(int id)
        {
            SqlCommand com = new SqlCommand("Sp_PhongBan_Delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

    }
}