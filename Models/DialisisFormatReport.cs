using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;

namespace PdfHandler.Models
{
    public class DialisisFormatReport
    {
        readonly PdfFont FontHelveticaNegrita = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        readonly PdfFont FontHelvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        int fontSize = 12;
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public DialisisFormatReport() { }

        // <summary>
        /// Geera el formato del pdf
        /// </summary>
        /// <returns>Retorna el pdf en un arreglo de byte</returns>
        public byte[] GenerateFormat()
        {
            MemoryStream pdfTem = new MemoryStream();
            PdfWriter writer = new PdfWriter(pdfTem);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            #region Header
            document.Add(GetHeader(TextAlignment.CENTER));
            #endregion

            #region Body
            //document.Add(GetBody(TextAlignment.JUSTIFIED));
            #endregion

            #region Table
            //document.Add(GetTable());
            #endregion

            document.Close();
            return pdfTem.ToArray();
        }

        #region Methods - Header
        private Paragraph GetHeader(TextAlignment alignment)
        {
            Paragraph title = new Paragraph();

            title.Add(new Text("PROGRAMA DIARIO DE DIALISIS").SetFont(FontHelveticaNegrita).SetFontSize(fontSize));
            title.SetTextAlignment(alignment);

            return title;
        }
        #endregion
    }
}
