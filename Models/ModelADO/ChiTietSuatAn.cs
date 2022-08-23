using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class ChiTietSuatAn
    {
        public int ID { get; set; }
        public int Soluong { get; set; }
        public CaAn caAn = new CaAn();
    }
}