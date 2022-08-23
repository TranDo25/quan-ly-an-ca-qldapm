﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models
{
    [Serializable]
    public class UserLoginModel
    {
        public string hoTen { get; set; }
        public int UserID { get; set; } 
        public int IDPhongBan { get; set; } 
        public string PhongBan { get; set; }
        public string username { get; set; }
        public string quyen { get; set; }
        public int IDRole { get; set; } 
    
    }
}