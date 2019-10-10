using iText.Barcodes;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;

namespace PdfHandler.Models
{
    public class FormatQrBarCode
    {
        readonly PdfFont FontHelveticaNegrita = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        readonly PdfFont FontHelvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        int fontSize = 14;
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FormatQrBarCode() { }

        public byte[] GenerateFormat()
        {
            MemoryStream pdfTem = new MemoryStream();
            PdfWriter writer = new PdfWriter(pdfTem);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            #region Header
            document.Add(GetHeader(TextAlignment.CENTER));
            #endregion

            #region QR
            document.Add(GetQr(GetMenssageForQr()));
            #endregion

            #region Barcode

            #endregion

            document.Close();
            return pdfTem.ToArray();
        }

        #region Methods - Header
        private Paragraph GetHeader(TextAlignment alignment)
        {
            Paragraph paragraph = new Paragraph();

            paragraph.Add(new Text("QR and Barcode"));
            paragraph.SetFont(FontHelveticaNegrita);
            paragraph.SetFontSize(fontSize);

            return paragraph.SetTextAlignment(alignment);
        }
        #endregion

        #region Methods - Qr
        private string GetMenssageForQr()
        {
            string message = "Solamente son letras al azar dsjaklsdjaldkjskasdjla";

            return message;
        }
        private Image GetQr(string text)
        {
            BarcodeQRCode qrCode = new BarcodeQRCode(text.ToString());

            Image qr = new Image(qrCode.CreateFormXObject(null, null));
            qr.Scale(2, 2);
            qr.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            qr.SetMarginLeft(20);
            qr.SetMarginTop(10);

            return qr;
        }
        #endregion
    }
}
