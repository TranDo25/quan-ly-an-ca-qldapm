
using Quanlicaan.DataAccessLayer;
using Quanlicaan.Models;
using Quanlicaan.Models.ModelADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class PhongBanController : Controller

    {
        db dbLayer = new db();
        public ActionResult Show()
        {
            if (((UserLoginModel)Session["UserSession"]).Equals(null))
            {
                return Redirect("~/Login/Index");

            }
            DataSet ds = dbLayer.Show_All_PhongBan_Data();
            ViewBag.pb = ds.Tables[0];
            return View();

        }
        public ActionResult Add_PhongBan_Record()
        {
            if (((UserLoginModel)Session["UserSession"]).Equals(null))
            {
                return Redirect("~/Login/Index");

            }
            PhongBan model = new PhongBan();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add_PhongBan_Record(PhongBan pb)
        {
            if (!ModelState.IsValid)
            {
                return View(pb);
            }
            PhongBan pb2 = new PhongBan();
            pb2.TenPB = pb.TenPB;
            dbLayer.Add_Record(pb2);
            return RedirectToAction("Show");
        }
        public ActionResult Update_PhongBan_Record(int ID)
        {
            if (((UserLoginModel)Session["UserSession"]).Equals(null))
            {
                return Redirect("~/Login/Index");

            }
          
            DataSet ds = dbLayer.Show_PhongBan_Record_ById(ID);
            ViewBag.PhongBanRecord = ds.Tables[0];
            PhongBan pb2 = new PhongBan();
            pb2.TenPB = (string)ds.Tables[0].Rows[0]["TenPB"];
            pb2.ID = (int)ds.Tables[0].Rows[0]["ID"];

            return View(pb2);
        }
        [HttpPost]
        public ActionResult Update_PhongBan_Record(int ID, PhongBan pb)
        {
            if (!ModelState.IsValid)
            {
                return View(pb);
            }
            PhongBan pb2 = new PhongBan();
            pb2.ID = pb.ID;
            pb2.TenPB = pb.TenPB;
            dbLayer.Update_Record(pb2);
            return RedirectToAction("Show");

        }
        public ActionResult Delete_PhongBan_Record(int ID)
        {
            if (((UserLoginModel)Session["UserSession"]).Equals(null))
            {
                return Redirect("~/Login/Index");

            }
            try
            {
                dbLayer.Delete_PhongBan_Record(ID);
                return RedirectToAction("Show");
            }   
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        

        }

    }


}
