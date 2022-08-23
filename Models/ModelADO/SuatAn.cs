using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class SuatAn
    {

        public int ID { get; set; }

        public NhanVien nhanVien = new NhanVien();
        public int IDPhongBan { get; set; }
        public DateTime Thoigiandat { get; set; }
        public List<ChiTietSuatAn> ds = new List<ChiTietSuatAn>();



    }

}