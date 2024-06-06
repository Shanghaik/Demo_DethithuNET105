using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData
{
    public class Nhanvien
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(30, ErrorMessage = "Độ dài không quá 30 kí tự")]
        public string Ten { get; set; }
        [Range(18, 50, ErrorMessage = "Tổi chỉ từ 18 đến 50")]
        public int Tuoi { get; set; }
        [EmailAddress(ErrorMessage = "Email phải đúng định dạng")]
        public string Email { get; set; }
        [Range(5000000, 30000000, ErrorMessage = "Lương từ Jack đến 6 Jack")]
        public long Luong { get; set; }
        public bool Trangthai { get; set; }

    }
}
