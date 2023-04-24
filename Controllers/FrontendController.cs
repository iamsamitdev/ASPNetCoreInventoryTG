using ASPNetCoreInventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreInventory.Controllers;
public class FrontendController : Controller
{

    // ทดสอบเขียนฟังก์ชันเชื่อมต่อฐานข้อมูล
    [HttpGet]
    public string TestConnectDB()
    {
        // สร้าง object context
        InventoryDBContext dBContext = new InventoryDBContext();
        if(dBContext.Database.CanConnect())
        {
            return "Connect Database Success";
        }
        else
        {
            return "Connect Database Fail!";
        }
    }

    public IActionResult Home()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Webdev()
    {
        return View();
    }

    public IActionResult Mobiledev()
    {
        return View();
    }

    public IActionResult Graphic()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    // Submit ข้อมูลจากฟอร์ม Register
    [HttpPost]
    public IActionResult Register(User user)
    {
        string message;

        // ตรวจว่า validate ผ่านหรือไม่
        if(ModelState.IsValid)
        {

            // การบันทึกข้อมูลการลงทะเบียนลงตาราง user
           using (InventoryDBContext dBContext = new InventoryDBContext())
            {
                dBContext.Users.Add(user);
                dBContext.SaveChanges();

                // Clear ค่าในฟอร์ม
                ModelState.Clear();

                // แสดงข้อความแจ้งเตือน
                message = "<div class=\"alert alert-success text-center\">ลงทะเบียนเรียบร้อยแล้ว</div>";

                // ส่งไปหน้า login
                // return View("<meta http-equiv=\"refresh\" content=\"3;url=/Frontend/Login\" />");
                return RedirectToAction("Login", "Frontend");
            }

           
        }
        else
        {
            message = "<div class=\"alert alert-danger text-center\">ป้อนข้อมูลให้ครบก่อน</div>";
        }

        ViewBag.Message = message;

        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    // Submit ข้อมูลจากฟอร์ม Login
    [HttpPost]
    public IActionResult Login(User user)
    {

        string message;

        // ตรวจว่า validate ผ่านหรือไม่
        if (user.EmailID != null && user.Password != null)
        {
            // การตรวจสอบข้อมูลการ  login
            using (InventoryDBContext dBContext = new InventoryDBContext())
            {
                // ตรวจสอบว่ามีอีเมล์นี้ในฐานข้อมูลหรือไม่
                var query = dBContext.Users.Where(u => u.EmailID == user.EmailID).FirstOrDefault();
                if (query != null)
                {
                    // ตรวจสอบว่ารหัสผ่านนี้มีในฐานข้อมูลหรือไม่
                    if(string.Compare(user.Password, query.Password) == 0)
                    {

                        // เขียนข้อมูลลง session
                        HttpContext.Session.SetString("Email", query.EmailID);
                        HttpContext.Session.SetString("Firstname", query.FirstName);
                        HttpContext.Session.SetString("Lastname", query.Lastname);

                        // ส่งไปหน้า backend
                        return RedirectToAction("Dashboard", "Backend");
                    }
                    else
                    {
                        message = "<div class=\"alert alert-danger text-center\">ป้อนรหัสผ่านไม่ถูกต้อง</div>";
                    }
                }
                else
                {
                    message = "<div class=\"alert alert-danger text-center\">ไม่พบอีเมล์นี้</div>";
                }
            }
        }
        else
        {
            message = "<div class=\"alert alert-danger text-center\">ป้อนข้อมูลให้ครบก่อน</div>";
        }

        ViewBag.Message = message;
        return View();
    }


}
