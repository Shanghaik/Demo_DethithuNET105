using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhanhPG_SE05335.Models
{
    public class Sinhvien
    {
        [Key]
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public string Nganh { get; set; }
        [ForeignKey("MaLop")]
        public string MaLop { get; set; }
        public virtual Lophoc Lophoc {get; set;}
    }
}
