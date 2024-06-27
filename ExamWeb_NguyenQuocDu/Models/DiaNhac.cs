using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWeb_NguyenQuocDu.Models
{
    public class DiaNhac
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Chưa nhập dữ liệu"), StringLength(250)]
        public string TuaCD { get; set; }
        [Required(ErrorMessage = "Chưa nhập dữ liệu"), StringLength(50)]
        public string NgheSi { get; set; }
        [Required(ErrorMessage = "Chưa chọn dữ liệu")]
        public bool TrongNuoc { get; set; }
        [Range(1, 100)]
        [Required(ErrorMessage = "Chưa nhập dữ liệu")]
        public double GiaBan { get; set; }
        [Range(0, double.MaxValue)]
        [Required(ErrorMessage = "Chưa nhập dữ liệu")]
        public int SoLuong { get; set; }

    }
}
