using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.DTO
{
    public class ThongKeTheoThangModel
    {
        public int ID { get; set; }
        public int IDCaAn { get; set; }
        public string TenPhongBan { get; set; }
        public int IDNhanvien { get; set; }
        public int IDNguoiAn { get; set; }
        public string TenNhanVien { get; set; }
        public int SoLuong { get; set; }
    }
}