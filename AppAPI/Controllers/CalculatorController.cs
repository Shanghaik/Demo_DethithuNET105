using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("tinh-bmi")]
        public string BMI(double can, double cao)
        {
            return "Chỉ số BMI của bạn là: " + can / cao / cao;
        }
        // API tìm ra số lớn thứ 2 trong 1 mảng, nếu ko có in ra là không có
        [HttpPost("find-2nd")]
        public string Second(int[] arr) { 
            Array.Sort(arr); // Rự động sắp xếp array từ bé đến lớn
            int second = arr[arr.Length - 1]; // gán giá trị lớn thứ 2 = thằng cuối cùng
            // Thuật toán sẽ là: Duyệt từ cuối mảng về đầu, gặp thằng nào nhỏ hơn
            // thằng cuối thì dừng luôn vòng lặp và trả về kết quả
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] < second)
                {
                    second = arr[i]; break;
                }
            }
            if (second == arr[arr.Length - 1]) return "Không có phần tử lớn thứ 2";
            else return "Phần tử lớn thứ 2 trong mảng là: " + second; 
        }
    }
}
