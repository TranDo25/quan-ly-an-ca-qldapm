using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.ModelADO
{
    public class PhongBan
    {
        [Required]
        public int ID { get; set; }
        [Required(ErrorMessage ="thiếu tên phòng ban")]
     
        public string TenPB { get; set; }

    }
}