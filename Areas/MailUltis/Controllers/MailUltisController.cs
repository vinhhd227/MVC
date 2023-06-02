using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas_MailUltis_Controllers
{
    [Area("MailUltis")]
    [Route("/send-mail/[action]")]
    public class MailUltisController : Controller
    {


        private SendMailService _sendMailService;

        public MailUltisController(SendMailService sendMailService)
        {
            _sendMailService = sendMailService;
        }
        public IActionResult Index()
        {
            return View();
            //return RedirectToAction("Index", "DbManage", new { area = "Database" });
        }
        [TempData]
        public string StatusMessage { set; get; }
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SendGmail()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SendMailKit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMailAsync()
        {
            var success = await MailUltis.MailUltis.SendMail("vinh.200057@gmail.com", "vinhhd227@gmail.com", "TEST", "Xin chào ahihi");
            StatusMessage = success;
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> SendGmailAsync()
        {
            var success = await MailUltis.MailUltis.SendGmail("vinh.200057@gmail.com", "vinhhd227@gmail.com", "TEST", "Xin chào ahihi", "vinh.200057@gmail.com", "Vinh99722");
            StatusMessage = success;
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> SendMailKitAsync(string to = "vinhhd227@gmail.com", string subject = "test", string body = "<p><strong>Xin chào :))</strong></p>")
        {
            // Lấy dịch vụ sendmailservice
            MailContent content = new MailContent
            {
                To  = Request.Form["to"],
                Subject = Request.Form["subject"],
                Body = Request.Form["body"]
            };
            var success = await _sendMailService.SendMail(content);
            StatusMessage = success;
            return RedirectToAction(nameof(Index));
        }
    }
}
