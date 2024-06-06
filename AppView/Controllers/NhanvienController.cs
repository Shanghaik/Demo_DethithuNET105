using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppView.Controllers
{
    public class NhanvienController : Controller
    {
        HttpClient client = new HttpClient();
        public NhanvienController()
        {
            client = new HttpClient();
        }
        // GET: NhanvienController
        public ActionResult Index()
        {
            // lấy request URL
            string requestURL = "https://localhost:7107/api/NhanVien/get-all";
            var response = client.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<List<Nhanvien>>(response);
            return View(data);
        }

        // GET: NhanvienController/Details/5
        public ActionResult Details(Guid id)
        {
            string requestURL = $"https://localhost:7107/api/NhanVien/get-by-id?id={id}";
            var response = client.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<Nhanvien>(response);
            return View(data);
        }

        // GET: NhanvienController/Create
        public ActionResult Create()
        {
            Nhanvien nv = new Nhanvien() // Fake dữ liệu lên form
            {
                Id = Guid.NewGuid(),
                Ten = "Khánh mặt thâm",
                Email = "khanhmt@gmail.com",
                Luong = new Random().Next(10000000, 30000000),
                Trangthai = true
            };
            return View(nv);
        }

        // POST: NhanvienController/Create
        [HttpPost]
        public ActionResult Create(Nhanvien nv)
        {
            string requestURL = $"https://localhost:7107/api/NhanVien/create-nhanvien";
            var response = client.PostAsJsonAsync(requestURL, nv).Result;
            return RedirectToAction("Index");
        }

        // GET: NhanvienController/Edit/5
        public ActionResult Edit(Guid id)
        {
            string requestURL = $"https://localhost:7107/api/NhanVien/get-by-id?id={id}";
            var response = client.GetStringAsync(requestURL).Result;
            var data = JsonConvert.DeserializeObject<Nhanvien>(response);
            return View(data);
        }

        // POST: NhanvienController/Edit/5
        [HttpPost]
        public ActionResult Edit(Nhanvien nv)
        {
            string requestURL = $"https://localhost:7107/api/NhanVien/update-nhanvien";
            var response = client.PutAsJsonAsync(requestURL, nv).Result;
            return RedirectToAction("Index");
        }

        // GET: NhanvienController/Delete/5
        public ActionResult Delete(Guid id)
        {
            string requestURL = $"https://localhost:7107/api/NhanVien/delete-by-id?id={id}";
            var response = client.DeleteAsync(requestURL).Result;
            return RedirectToAction("Index");
        }
    }
}


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

