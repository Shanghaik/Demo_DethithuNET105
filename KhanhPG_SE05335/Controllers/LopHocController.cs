using KhanhPG_SE05335.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KhanhPG_SE05335.Controllers
{
    public class LopHocController : Controller
    {
        AppDbContext context;
        public LopHocController()
        {
            context = new AppDbContext();
        }
        // GET: LopHocController
        public ActionResult Index() // Show lên danh sách tất cả các lớp học
        {
            var listLH = context.Lophocs.ToList();
            return View(listLH);
        }

        // GET: LopHocController/Details/5
        public ActionResult Details(string malop)
        {
            var lop = context.Lophocs.Find(malop);
            return View(lop);
        }

        // GET: LopHocController/Create
        public ActionResult Create() // Hiển thị View Create rỗng
        {
            return View();
        }

        // POST: LopHocController/Create
        [HttpPost]
        public ActionResult Create(Lophoc lophoc) // Create thật
        {
            try
            {
                context.Lophocs.Add(lophoc);
                context.SaveChanges();
                return RedirectToAction("Index");   
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: LopHocController/Edit/5
        public ActionResult Edit(string malop) // Mở form truyền data cũ sang
        {
            var editItem = context.Lophocs.Find(malop);
            return View(editItem);
        }

        // POST: LopHocController/Edit/5
        [HttpPost]
        public ActionResult Edit(Lophoc lophoc) //ACtion xử lý thật
        {
            try
            {
                var editItem = context.Lophocs.Find(lophoc.MaLop);
                editItem.TenLop = lophoc.TenLop;
                editItem.Khoa = lophoc.Khoa;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: LopHocController/Delete/5
        public ActionResult Delete(string malop)
        {
            var deleteItem = context.Lophocs.Find(malop);
            // Thực hiện bước thêm dữ liệu cần xóa vào trong Session
            var jsonData = JsonConvert.SerializeObject(deleteItem);  // Mã hóa sang string Json
            HttpContext.Session.SetString("deleted", jsonData); // thêm vào session
            context.Lophocs.Remove(deleteItem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult RollBack() // RollBack lại phần tử đã xóa 
        {
            // Logic ở đây đơn giản là thêm mới 1 thành phần ý hệt như thành phần đã bị xóa đã được
            // lưu trong Session
            // Lấy dữ liệu ra
            string jsonData = HttpContext.Session.GetString("deleted");
            // Chuyển đổi về dạng Object 
            var deleteItem = JsonConvert.DeserializeObject<Lophoc>(jsonData);
            return Create(deleteItem); // trỏ tới Action Create
            //return RedirectToAction("Index");
        }

       
    }
}
