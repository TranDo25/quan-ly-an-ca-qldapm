using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models
{
    public class NhanVienModel
    {
        [Required]
        public int ID { get; set; }
        [Required(ErrorMessage ="thiếu họ tên")]
        [StringLength(50,ErrorMessage ="độ dài không quá 50 kí tự")]
        public string hoTen { get; set; }
        [Required]
        public Boolean gioiTinh { get; set; }
        [Required]
        public int IDPhongBan { get; set; }
        [Required(ErrorMessage = "thiếu username")]
        public DateTime birthday  { get; set; }
        [Required(ErrorMessage = "thiếu username")]
        public string username { get; set; }
        [Required(ErrorMessage = "thiếu password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$",
            ErrorMessage = "Tối thiểu tám và tối đa 10 ký tự, ít nhất một chữ cái viết hoa, một chữ cái viết thường, một số và một ký tự đặc biệt:") ]
        public string password { get; set; }
        [Required(ErrorMessage = "thiếu email")]
        [DataType(DataType.EmailAddress, ErrorMessage ="email không hợp lệ")]
        public string email { get; set; }
        [Required(ErrorMessage = "thiếu địa chỉ")]
        public string address
        {
            get; set;
        }
        [Required(ErrorMessage = "thiếu số điện thoại")]
        [DataType(DataType.PhoneNumber, ErrorMessage ="số điện thoại không hợp lệ")]
        public string phone { get; set; }
        [Required]
        public int IDRole { get; set; }
        [Required]
        public string quyen { get; set; }
        [Required]
        public Boolean trangThai { get; set; }
        public String TenPhongBan { get; set; }
        public int SLCa1 { get; set; }
        public int SLCa2 { get; set; }
        public int SLCa3 { get; set; }



    }
}