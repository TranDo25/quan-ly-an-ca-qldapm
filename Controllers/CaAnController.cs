using Quanlicaan.DataAccessLayer;
using Quanlicaan.Models;
using Quanlicaan.Models.ModelADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Quanlicaan.Controllers
{
    public class CaAnController : Controller
    {
        db dbLayer = new db();

        // GET: CaAn
        public ActionResult Index(string thongBao)
        {
            ViewData["message"] = thongBao;
            DangKyCaNhanModel model = new DangKyCaNhanModel();
            if (((UserLoginModel)Session["UserSession"]).Equals(null))
            {
                return Redirect("~/Login/Index");

            }
            UserLoginModel userLogin = (UserLoginModel)Session["UserSession"];
            model.hoTen = userLogin.hoTen;
            model.phongBan = userLogin.PhongBan;
            model.ngayDK = DateTime.Now;

            return View(model);

        }
        //public ActionResult ShowDonCaNhan()
        //{
        //    if (((UserLoginModel)Session["UserSession"]).Equals(null))
        //    {
        //        return Redirect("~/Login/Index");

        //    }
        //    UserLoginModel userLogin = (UserLoginModel)Session["UserSession"];
        //    int UserID = userLogin.UserID;
        //    DangKyCaNhanModel model = new DangKyCaNhanModel();
        //    SuatAn res = dbLayer.getSuatAnByIDUser(UserID);
        //    model.hoTen = res.nhanVien.hoTen;
        //    model.IDPhongBan = res.nhanVien.phongBan;
        //    return View(res);
        //}
        public ActionResult TapThe(string thongBao)
        {
            ViewData["message2"] = thongBao;
            if (((UserLoginModel)Session["UserSession"]).Equals(null))
            {
                return Redirect("~/Login/Index");

            }
            UserLoginModel userLogin = (UserLoginModel)Session["UserSession"];

            DangKyTapTheModel model = new DangKyTapTheModel();
            model.khoiTaoBanDau(userLogin.IDPhongBan);
            model.hoTenNDK = userLogin.hoTen;
            model.phongBan = userLogin.PhongBan;
            model.IDNguoiDK = userLogin.UserID;
            model.ngayDK = DateTime.Now;

            //model ở đây cần khởi tạo 4 thuộc tính có sẵn giá trị 
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XuLyDangKyTapThe(DangKyTapTheModel model)
        {
            UserLoginModel userLogin = (UserLoginModel)Session["UserSession"];
            if (userLogin == null)
            {
                Redirect("~/Login/Index");
            }
            DangKyTapTheModel model2 = new DangKyTapTheModel();
            model2.khoiTaoBanDau(userLogin.IDPhongBan);
            model2.hoTenNDK = userLogin.hoTen;
            model2.phongBan = userLogin.PhongBan;
            model2.IDNguoiDK = userLogin.UserID;
            model2.ngayDK = DateTime.Now;
            for (int i = 0; i < model.dsNV.Count; i++)
            {
                model2.dsNV[i].SLCa1 = model.dsNV[i].SLCa1;
                model2.dsNV[i].SLCa2 = model.dsNV[i].SLCa2;
                model2.dsNV[i].SLCa3 = model.dsNV[i].SLCa3;
            }
            String thongbao = "";
            try
            {
                dbLayer.Add_New_GroupRegister(model2);
                thongbao = "them moi dang ky tap the thanh cong";
            }
            catch (Exception ex)
            {
                thongbao = "them moi dang ky tap the that bai";

            }
            return RedirectToAction("TapThe", "CaAn", new { thongbao });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XuLyDangKyCaNhan(DangKyCaNhanModel model)
        {
            String thongbao = "";
            try
            {
                UserLoginModel userLogin = (UserLoginModel)Session["UserSession"];
                if (userLogin == null)
                {
                    Redirect("~/Login/Index");
                }
                model.IDPhongBan = userLogin.IDPhongBan;
                model.ID_NDK = userLogin.UserID;
                dbLayer.Add_New_PersonalRegister(model);
                thongbao = "them moi thanh cong";

            }
            catch (Exception ex)
            {
                thongbao = "them moi that bai";
            }
            return RedirectToAction("Index", "CaAn", new { thongbao });
        }




    }
}
