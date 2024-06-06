using System.ComponentModel.DataAnnotations;

namespace KhanhPG_SE05335.Models
{
    public class Lophoc
    {
        [Key]
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int Khoa { get; set; }
        public virtual List<Sinhvien> Sinhviens { get;}
    }
}
