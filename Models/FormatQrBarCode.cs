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
            document.Add(GetQr(GetMenssageForBarcodes()));
            #endregion

            #region Barcodes
            document.Add(GetBarcode25(pdf));
            document.Add(GetBarcodeEan(pdf));
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

        #region Methods - Barcodes
        /// <summary>
        /// Obtener mensaje que será convertido en los distintos Barcodes disponibles
        /// </summary>
        /// <returns>Mensaje</returns>
        private string GetMenssageForBarcodes()
        {
            string message = "Solamente son letras al azar dsjaklsdjaldkjskasdjla";

            return message;
        }
        /// <summary>
        /// Obtener el Barcore QR
        /// </summary>
        /// <param name="text">Mensaje que será pasado a QR</param>
        /// <returns>Imágen QR</returns>
        private Image GetQr(string text)
        {
            BarcodeQRCode qrCode = new BarcodeQRCode(text);

            Image qr = new Image(qrCode.CreateFormXObject(null, null));
            qr.Scale(2, 2);
            qr.SetHorizontalAlignment(HorizontalAlignment.LEFT);
            qr.SetMarginLeft(20);
            qr.SetMarginTop(10);

            return qr;
        }
        /// <summary>
        /// Generar el Barcode 25
        /// </summary>
        /// <param name="text">Mensaje que será pasado a 25</param>
        /// <param name="pdfDoc">PdfDocument del documento original</param>
        /// <returns>Retornar el barcode en una imágen</returns>
        private Image GetBarcode25(PdfDocument pdfDoc)
        {
            BarcodeInter25 barcode25 = new BarcodeInter25(pdfDoc);
            barcode25.SetCode("0600123456");

            Image barcode = new Image(barcode25.CreateFormXObject(pdfDoc));
            barcode.Scale(2, 2);
            barcode.SetHorizontalAlignment(HorizontalAlignment.LEFT);
            barcode.SetMarginLeft(20);
            barcode.SetMarginTop(10);

            return barcode;
        }

        /// <summary>
        /// Generar el Barcode EAN
        /// </summary>
        /// <param name="text">Mensaje que será pasado a 25</param>
        /// <param name="pdfDoc">PdfDocument del documento original</param>
        /// <returns>Retornar el EAN en una imágen</returns>
        private Image GetBarcodeEan(PdfDocument pdfDoc)
        {
            BarcodeEAN barcodeEan = new BarcodeEAN(pdfDoc);
            barcodeEan.SetCode("0123456789012");

            Image barcode = new Image(barcodeEan.CreateFormXObject(null, null, pdfDoc));
            barcode.Scale(2, 2);
            barcode.SetHorizontalAlignment(HorizontalAlignment.LEFT);
            barcode.SetMarginLeft(20);
            barcode.SetMarginTop(10);

            return barcode;
        }
        #endregion
    }
}
