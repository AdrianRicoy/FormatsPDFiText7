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

        [HttpPost]
        public ActionResult Index(string pdfName, string initialDate, string finalDate)
        {
            if(!string.IsNullOrEmpty(pdfName))
            {
                if(pdfName.Split(": ")[1] == "Format Dialisis")
                {
                    ViewData["ListPdf"] = new HandlerPdf().PdfNames();
                    ViewData["Dialisis"] = true;
                    return View();
                }
                byte[] pdf = new HandlerPdf().StartHandlerPdf(pdfName.Split(": ")[1]);

                if (pdf == null)
                {
                    SendsError(Message.pdfNotFound);
                    return View();
                }

                HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=" + pdfName.Split(": ")[1].Replace(" ", "") + ".pdf");
                return File(pdf, "aplication/pdf");
            } else
            {
                SendsError(Message.pdfNotName);
            }

            return View();
        }

        /// <summary>
        /// Mandar un mensaje de error a la vista con la lista de los nombres PDF
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        private void SendsError(string message)
        {
            ViewData["Error"] = message;
            ViewData["ListPdf"] = new HandlerPdf().PdfNames();
        }
    }
}
