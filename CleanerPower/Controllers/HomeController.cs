using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CleanerPower.Models;
using CleanerPower.Data.Abstract;
using CleanerPower.Entity;
using System.Data;
using System.IO;
using OfficeOpenXml;
using Microsoft.AspNetCore.Authorization;

namespace CleanerPower.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IOrderRepository _orderRepository;
        private IMessageRepository _messageRepository;
        private ICompountRepository _compountRepository;
        public HomeController(ILogger<HomeController> logger, IOrderRepository orderRepo, IMessageRepository messagerepo, ICompountRepository compountrepo)
        {
            _orderRepository = orderRepo;
            _messageRepository = messagerepo;
            _compountRepository = compountrepo;

        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(Compount model)
        {
            _compountRepository.SaveCompount(model);
            return View("Onay",model);
        }
        public IActionResult List()
        {
             return View(_orderRepository.GetAll());
        }
        public IActionResult Excel()
        {
            var data = _orderRepository.GetAll();
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(stream))
            {
                var sheet = package.Workbook.Worksheets.Add("Anil");
                sheet.Cells.LoadFromCollection(data, true);
                package.Save();
            }
            stream.Position = 0;
            var fileName = $"Demo_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

        }
        public IActionResult Message()
        {
            return View(_messageRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_orderRepository.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int OrderId)
        {
            _orderRepository.DeleteOrder(OrderId);
            return RedirectToAction("List");
        }
        public IActionResult Delete2(int id)
        {
            return View(_messageRepository.GetById(id));
        }
        [HttpPost, ActionName("Delete3")]
        public IActionResult DeleteConfirmed2(int MessageId)
        {
            _messageRepository.DeleteMessage(MessageId);
            return RedirectToAction("Message");
        }

    }
}
