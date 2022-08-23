using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using Quanlicaan.Models;
using System.Linq;
using System.Data.Entity;
using System.Data;
using Quanlicaan.DataAccessLayer;
using Quanlicaan.Models.ModelADO;
using PagedList;
namespace Quanlicaan.Controllers
{
    public class NhanVienController : Controller
    {
        db dbLayer = new db();

        public ActionResult Show(int? page, string SearchString = "")
        {
            if (((UserLoginModel)Session["UserSession"]).Equals(null))
            {
                return Redirect("~/Login/Index");

            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (SearchString != "")
            {
                if (page == null) page = 1;
                DataSet ds2 = dbLayer.Show_All_Data();
                ViewBag.nv = ds2.Tables[0];
                List<NhanVienModel> dsNhanVien2 = new List<NhanVienModel>();
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    NhanVienModel x = new NhanVienModel();
                    x.ID = Convert.ToInt32(ds2.Tables[0].Rows[i]["ID"]);
                    x.hoTen = Convert.ToString(ds2.Tables[0].Rows[i]["hoTen"]);

                    x.TenPhongBan = Convert.ToString(ds2.Tables[0].Rows[i]["TenPB"]);
                    x.IDRole = Convert.ToInt32(ds2.Tables[0].Rows[i]["quyenHeThong"]);

                    x.quyen = Convert.ToString(ds2.Tables[0].Rows[i]["quyen"]);
                    x.gioiTinh = Convert.ToBoolean(ds2.Tables[0].Rows[i]["gioiTinh"]);

                    x.email = Convert.ToString(ds2.Tables[0].Rows[i]["email"]);
                    x.address = Convert.ToString(ds2.Tables[0].Rows[i]["diaChi"]);

                    x.phone = Convert.ToString(ds2.Tables[0].Rows[i]["phone"]);
                    x.birthday = Convert.ToDateTime(ds2.Tables[0].Rows[i]["ngaySinh"]);
                    if (x.hoTen.ToLower().Contains(SearchString.ToLower()))
                    {
                        dsNhanVien2.Add(x);
                    }

                }

                return View(dsNhanVien2.ToPagedList(pageNumber, pageSize));
            }
            if (page == null) page = 1;
            DataSet ds = dbLayer.Show_All_Data();
            ViewBag.nv = ds.Tables[0];
            List<NhanVienModel> dsNhanVien = new List<NhanVienModel>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                NhanVienModel x = new NhanVienModel();
                x.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"]);
                x.hoTen = Convert.ToString(ds.Tables[0].Rows[i]["hoTen"]);

                x.TenPhongBan = Convert.ToString(ds.Tables[0].Rows[i]["TenPB"]);
                x.IDRole = Convert.ToInt32(ds.Tables[0].Rows[i]["quyenHeThong"]);

                x.quyen = Convert.ToString(ds.Tables[0].Rows[i]["quyen"]);
                x.gioiTinh = Convert.ToBoolean(ds.Tables[0].Rows[i]["gioiTinh"]);

                x.email = Convert.ToString(ds.Tables[0].Rows[i]["email"]);
                x.address = Convert.ToString(ds.Tables[0].Rows[i]["diaChi"]);

                x.phone = Convert.ToString(ds.Tables[0].Rows[i]["phone"]);
                x.birthday = Convert.ToDateTime(ds.Tables[0].Rows[i]["ngaySinh"]);
                dsNhanVien.Add(x);
            }

            return View(dsNhanVien.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Add_Record()
        {
            if (((UserLoginModel)Session["UserSession"]).Equals(null))
            {
                return Redirect("~/Login/Index");

            }
            NhanVienModel model = new NhanVienModel();
            model.birthday = DateTime.Now;
            ViewBag.ListPhongBan = DSPhongBanDropDown();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add_Record(NhanVienModel fc)
        {
            if (ModelState.IsValid)
            {
                NhanVienModel nv = new NhanVienModel();
                nv.hoTen = fc.hoTen;
                nv.gioiTinh = fc.gioiTinh;
                nv.address = fc.address;
                nv.email = fc.email;
                nv.phone = fc.phone;
                nv.IDPhongBan = fc.IDPhongBan;
                nv.username = fc.username;
                nv.password = fc.password;
                nv.IDRole = fc.IDRole;
                nv.quyen = fc.quyen;
                nv.trangThai = fc.trangThai;
                if (fc.birthday != null)
                {
                    nv.birthday = fc.birthday;
                }

                dbLayer.Add_Record(nv);
                TempData["msg2"] = "inserted!";
                return RedirectToAction("Show");
            }

            ViewBag.ListPhongBan = DSPhongBanDropDown();
            return View(fc);
        }
        public ActionResult Update_Record(int ID)
        {
            if (((UserLoginModel)Session["UserSession"]).Equals(null))
            {
                return Redirect("~/Login/Index");

            }
            DataSet ds = dbLayer.Show_Record_ById(ID);
            ViewBag.ListPhongBan = DSPhongBanDropDown();
            NhanVienModel x = new NhanVienModel();
            x.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
            x.hoTen = Convert.ToString(ds.Tables[0].Rows[0]["hoTen"]);
            x.username = Convert.ToString(ds.Tables[0].Rows[0]["username"]);
            x.password = Convert.ToString(ds.Tables[0].Rows[0]["upassword"]);
            x.IDRole = Convert.ToInt32(ds.Tables[0].Rows[0]["IDRole"]);
            x.quyen = Convert.ToString(ds.Tables[0].Rows[0]["quyen"]);
            x.trangThai = Convert.ToBoolean(ds.Tables[0].Rows[0]["trangThai"]);
            x.TenPhongBan = Convert.ToString(ds.Tables[0].Rows[0]["TenPB"]);
            x.IDPhongBan = Convert.ToInt32(ds.Tables[0].Rows[0]["IDPhongBan"]);
            x.address = Convert.ToString(ds.Tables[0].Rows[0]["diaChi"]);
            x.phone = Convert.ToString(ds.Tables[0].Rows[0]["phone"]);
            x.gioiTinh = Convert.ToBoolean(ds.Tables[0].Rows[0]["gioiTinh"]);
            x.email = Convert.ToString(ds.Tables[0].Rows[0]["email"]);
            x.birthday = Convert.ToDateTime(ds.Tables[0].Rows[0]["ngaySinh"]);
            return View(x);
        }
        [NonAction]
        public SelectList DSPhongBanDropDown()
        {
            DataSet ListPhongBanTmp = dbLayer.Show_All_PhongBan_Data();
            List<PhongBan> listPhongBan = new List<PhongBan>();
            PhongBan tmp1 = new PhongBan();
            tmp1.ID = 1;
            tmp1.TenPB = "--chọn phòng ban--";
            listPhongBan.Add(tmp1);
            for (int i = 0; i < ListPhongBanTmp.Tables[0].Rows.Count; i++)
            {
                PhongBan tmp = new PhongBan();
                tmp.ID = Convert.ToInt32(ListPhongBanTmp.Tables[0].Rows[i]["ID"]);
                tmp.TenPB = Convert.ToString(ListPhongBanTmp.Tables[0].Rows[i]["TenPB"]);
                listPhongBan.Add(tmp);
            }

            List<SelectListItem> list = new List<SelectListItem>();

            foreach (PhongBan item in listPhongBan)
            {
                list.Add(new SelectListItem()
                {
                    Text = item.TenPB,
                    Value = Convert.ToString((int)item.ID),
                });
            }

            return new SelectList(list, "Value", "Text");
        }
        [HttpPost]
        public ActionResult Update_Record(NhanVienModel fc)
        {

            if (ModelState.IsValid)
            {
                NhanVienModel nv = new NhanVienModel();
                nv.ID = fc.ID;
                nv.hoTen = fc.hoTen;
                nv.IDPhongBan = fc.IDPhongBan;
                nv.username = fc.username;
                nv.password = fc.password;
                nv.IDRole = fc.IDRole;
                nv.quyen = fc.quyen;
                nv.trangThai = fc.trangThai;
                nv.gioiTinh = fc.gioiTinh;
                nv.phone = fc.phone;
                nv.email = fc.email;
                nv.address = fc.address;
                nv.birthday = fc.birthday;
                dbLayer.Update_Record(nv);
                TempData["msg"] = "đã update dữ liệu !";
                return RedirectToAction("Show");
            }
            ViewBag.ListPhongBan = DSPhongBanDropDown();
            return View(fc);
        }
        public ActionResult Delete_Record(int ID)
        {
            dbLayer.Delete_Record(ID);
            TempData["msg"] = "deleted!";
            return RedirectToAction("Show");

        }
    }
}