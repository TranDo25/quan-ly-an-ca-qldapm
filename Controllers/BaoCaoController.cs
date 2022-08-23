using Quanlicaan.DataAccessLayer;
using Quanlicaan.Models;
using Quanlicaan.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{

    public class BaoCaoController : Controller
    {
        // GET: BaoCao

        public ActionResult BCCaNhan()
        {
            db dbLayer = new db();
            if (((UserLoginModel)Session["UserSession"]).Equals(null))
            {
                return Redirect("~/Login/Index");

            }
            UserLoginModel userLogin = (UserLoginModel)Session["UserSession"];
         

            int UserID = userLogin.UserID;
            DateTime currrentDate = DateTime.Now;
            var firstDayOfMonth = new DateTime(currrentDate.Year, currrentDate.Month, 1);
            List<ThongKeCaNhanModel> ds = dbLayer.GetListPersonalRegister(currrentDate, firstDayOfMonth, UserID);
            return View(ds.ToList());
        }
        public ActionResult ThongKeTheoNgay(DateTime? date = null)
        {
            if (((UserLoginModel)Session["UserSession"]).Equals(null))
            {
                return Redirect("~/Login/Index");

            }
            db dbLayer = new db();
            List<ThongKeTheoNgayModel> ds = new List<ThongKeTheoNgayModel>();
            if (!date.HasValue)
            {
                date = DateTime.Now;
                ds = dbLayer.GetListRegisterByDay((DateTime)date);
                TempData["displayDate"] = date;
                return View(ds.ToList());
            }
            ds = dbLayer.GetListRegisterByDay((DateTime)date);
            return View(ds.ToList()); 
        }
      
        public ActionResult ThongKeTheoThang(DateTime? month = null)
        {
            if (((UserLoginModel)Session["UserSession"]).Equals(null))
            {
                return Redirect("~/Login/Index");

            }
            db dbLayer = new db();
            List<ThongKeTheoThangModel> ds = new List<ThongKeTheoThangModel>();
            if (month == null)
            {
                int monthTmp = DateTime.Now.Month;
                int yearTmp = DateTime.Now.Year;    
                ds = dbLayer.GetListRegisterByMonth(monthTmp, yearTmp);
                return View(ds.ToList());
            }
          
            int monthTmp2 = month.Value.Month;
            int yearTmp2 = month.Value.Year;
            ds = dbLayer.GetListRegisterByMonth(monthTmp2, yearTmp2);
            return View(ds.ToList());
          
        }
    }
}