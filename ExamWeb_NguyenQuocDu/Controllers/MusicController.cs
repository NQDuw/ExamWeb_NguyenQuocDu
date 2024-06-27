using ExamWeb_NguyenQuocDu.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWeb_NguyenQuocDu.Controllers
{
    public class MusicController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MusicController(ApplicationDbContext db)
        {
            _db = db;
        }
      
        public IActionResult Index()
        {
            var dsDiaNhac = _db.DiaNhacs.ToList();
            var tongSoLuong = _db.DiaNhacs.Sum(x => x.SoLuong);
            var tongSoLuongId = _db.DiaNhacs.Sum(x => x.Id);
            var listDiaNhac = _db.DiaNhacs.ToList();
            ViewBag.Sum = tongSoLuong;
            ViewBag.SumId = tongSoLuongId;
            return View(listDiaNhac);
        }
  
        public IActionResult Add()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Add(DiaNhac diaNhac)
        {
            if (ModelState.IsValid) 
            {
                
                _db.DiaNhacs.Add(diaNhac);
                _db.SaveChanges();
                TempData["success"] = "Thêm Thành Công";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            var category = _db.DiaNhacs.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
     
        [HttpPost]
        public IActionResult Update(DiaNhac diaNhac)
        {
            if (ModelState.IsValid) 
            {
                
                _db.DiaNhacs.Update(diaNhac);
                _db.SaveChanges();
                TempData["success"] = "Sửa Thành Công";
                return RedirectToAction("Index");
            }
            return View();
        }
      
        public IActionResult Delete(int id)
        {
            var category = _db.DiaNhacs.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        
        public IActionResult DeleteConfirmed(int id)
        {
            var diaNhac = _db.DiaNhacs.Find(id);
            if (diaNhac == null)
            {
                return NotFound();
            }
            _db.DiaNhacs.Remove(diaNhac);
            _db.SaveChanges();
            TempData["success"] = "Xóa Thành Công";
            return RedirectToAction("Index");
        }
    }
}
