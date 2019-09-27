using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PdfHandler.Models;

namespace PdfHandler.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ListPdf"] = new HandlerPdf().PdfNames();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Index(string pdfName)
        {
            if(!string.IsNullOrEmpty(pdfName))
            {
                byte[] pdf = new HandlerPdf().StartHandlerPdf(pdfName.Split(": ")[1]);
                HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=" + pdfName.Split(": ")[1].Replace(" ", "") + ".pdf");
                return File(pdf, "aplication/pdf");
            }

            return View();
        }
    }
}
