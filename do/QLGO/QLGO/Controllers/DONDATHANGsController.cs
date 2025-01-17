﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLGO.Models;

namespace QLGO.Controllers
{
    public class DONDATHANGsController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();
        string LayMaDDH()
        {
            // Lấy danh sách mã đơn đặt hàng
            var listMaDDH = db.DONDATHANGs.Select(n => n.IDDDH).ToList();

            // Kiểm tra nếu không có đơn đặt hàng nào
            if (listMaDDH.Count == 0)
            {
                return "DH001";
            }

            // Lấy mã lớn nhất hiện tại
            var maMax = listMaDDH.Max();
            int maDH = int.Parse(maMax.Substring(2)) + 1;
            string NV = String.Concat("00", maDH.ToString());
            return "DH" + NV.Substring(NV.Length - 3);
        }

        // GET: DONDATHANGs
        public ActionResult Index()
        {
            var dONDATHANG = db.DONDATHANGs.Include(d => d.LOAITHANHTOAN).Include(d => d.NGUOIDUNG).Include(d => d.TINHTRANG);
            return View(dONDATHANG.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.IDDH = LayMaDDH();

            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT");
            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenDN");
            ViewBag.IDTT = new SelectList(db.TINHTRANGs, "IDTT", "TenTT");
            return View();
        }

        // POST: DONDATHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDDH,IDKH,IDLTT,IDTT,NgayDatHang,NgayGiaoHang,DiaChi,TenNguoiDH")] DONDATHANG dONDATHANG)
        {
            if (ModelState.IsValid)
            {
                //db.DONDATHANG.Add(dONDATHANG);
                //db.SaveChanges();
                //return RedirectToAction("Index");
                var lstCTHD = (List<GioHangModel>)Session["cart"];
                dONDATHANG.IDDDH = LayMaDDH();
                dONDATHANG.IDTT = '1'.ToString();
                dONDATHANG.NgayDatHang = DateTime.Now; // Gán thời gian hiện tại
                dONDATHANG.NgayGiaoHang = DateTime.Now;
                dONDATHANG.IDKH = Session["user"].ToString();
                db.DONDATHANGs.Add(dONDATHANG);
                db.SaveChanges();
                String MaHD = dONDATHANG.IDDDH;
                List<CTDONDATHANG> CTHD = new List<CTDONDATHANG>();
                foreach (var item in lstCTHD)
                {
                    CTDONDATHANG cTHoaDon = new CTDONDATHANG();
                    cTHoaDon.IDDDH = MaHD;
                    cTHoaDon.IDSP = item.sp.IDSP;
                    cTHoaDon.SLDat = item.SL;
                    CTHD.Add(cTHoaDon);
                }
                db.CTDONDATHANGs.AddRange(CTHD);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT", dONDATHANG.IDLTT);
            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenDN", dONDATHANG.IDKH);
            ViewBag.IDTT = new SelectList(db.TINHTRANGs, "IDTT", "TenTT", dONDATHANG.IDTT);
            return View(dONDATHANG);
        }

        // GET: DONDATHANGs/Edit/5
     

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
