using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class NhanVien
    { 
        public int ID { get; set; }
        public PhongBan phongBan { get; set; }
        public string username { get; set; }
        public string upassword { get; set; }
        public Roles roles { get; set; }
        public string quyen { get; set; }
        public bool trangThai { get; set; }
        public string hoTen { get; set; }

    }
}