using Gma.QrCodeNet.Encoding;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;

namespace PdfHandler.Models
{
    public class FormatQrBarCode
    {

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FormatQrBarCode() { }

        public byte[] GenerarFormato()
        {
            MemoryStream pdfTem = new MemoryStream();
            PdfWriter writer = new PdfWriter(pdfTem);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            #region Header

            #endregion

            #region Body

            #endregion

            #region footer

            #endregion

            document.Close();
            return pdfTem.ToArray();
        }

        #region Qr
        private void GetQr()
        {
            QrEncoder qr = new QrEncoder(); 
        }
        #endregion
    }
}
