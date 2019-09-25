using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PdfHandler.Models
{
    public class SimpleFormatReport
    {
        readonly PdfFont FontHelveticaNegrita = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        readonly PdfFont FontHelvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        int fontSize = 12;

        private byte[] Generateformat(Dictionary<string, int> headerMessage, Dictionary<string, int> bodyMessage, Dictionary<string, int> footerMessage)
        {
            MemoryStream pdfTem = new MemoryStream();
            PdfWriter writer = new PdfWriter(pdfTem);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            #region Header
            foreach(var text in headerMessage)
            {
                document.Add(GetHeader(text.Value, text.Key));
            }
            #endregion

            #region Body Message
            foreach (var text in bodyMessage)
            {
                document.Add(GetBody(text.Value, text.Key));
            }
            #endregion

            #region Footer
            foreach (var text in footerMessage)
            {
                document.Add(GetFooter(text.Value, text.Key));
            }
            #endregion

            document.Close();
            return pdfTem.ToArray();
        }

        #region Methods - Header
        private Paragraph GetHeader(int style, string text)
        {
            Paragraph paragraph = new Paragraph();

            switch(style)
            {
                case 0:
                    paragraph.Add(new Text(text).SetFont(FontHelveticaNegrita).SetFontSize(fontSize+2)).SetTextAlignment(TextAlignment.LEFT);
                    break;
                case 1:
                    paragraph.Add(new Text(text).SetFont(FontHelvetica).SetFontSize(fontSize - 3)).SetTextAlignment(TextAlignment.RIGHT);
                    break;
                case 2:
                    paragraph.Add(new Text(text).SetFont(FontHelveticaNegrita).SetFontSize(fontSize - 3)).SetTextAlignment(TextAlignment.RIGHT);
                    break;
            }

            return paragraph;
        }
        #endregion

        #region Methods - Body Message
        private Paragraph GetBody(int style, string text)
        {
            Paragraph paragraph = new Paragraph();

            switch(style)
            {
                case 0:
                    paragraph.Add(new Text(text).SetFont(FontHelveticaNegrita).SetFontSize(fontSize)).SetTextAlignment(TextAlignment.LEFT);
                    break;
                case 1:
                    paragraph.Add(new Text(text).SetFont(FontHelvetica).SetFontSize(fontSize)).SetTextAlignment(TextAlignment.LEFT);
                    break;
                case 2:
                    paragraph.Add(new Text(text).SetFont(FontHelveticaNegrita).SetFontSize(fontSize)).SetTextAlignment(TextAlignment.RIGHT);
                    break;
                case 3:
                    paragraph.Add(new Text(text).SetFont(FontHelveticaNegrita).SetFontSize(fontSize+2)).SetTextAlignment(TextAlignment.CENTER);
                    break;
            }

            return paragraph;
        }
        #endregion

        #region Methods - Footer
        private Paragraph GetFooter(int style, string text)
        {
            Paragraph paragraph = new Paragraph();

            switch (style)
            {
                case 0:
                    paragraph.Add(new Text(text).SetFont(FontHelveticaNegrita).SetFontSize(fontSize)).SetTextAlignment(TextAlignment.LEFT);
                    break;
                case 1:
                    paragraph.Add(new Text(text).SetFont(FontHelvetica).SetFontSize(fontSize)).SetTextAlignment(TextAlignment.LEFT);
                    break;
                case 2:
                    paragraph.Add(new Text(text).SetFont(FontHelveticaNegrita).SetFontSize(fontSize)).SetTextAlignment(TextAlignment.RIGHT);
                    break;
                case 3:
                    paragraph.Add(new Text(text).SetFont(FontHelveticaNegrita).SetFontSize(fontSize + 2)).SetTextAlignment(TextAlignment.CENTER);
                    break;
            }

            return paragraph;
        }
        #endregion

        #region Text
        public byte[] CreateMyPdf()
        {
            Dictionary<string, int> headerMessage = new Dictionary<string, int>();
            Dictionary<string, int> bodyMessage = new Dictionary<string, int>();
            Dictionary<string, int> footerMessage = new Dictionary<string, int>();

            string fecha = string.Format("\n\nDay {0} of {1} - {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

            headerMessage.Add(fecha, 1);
            headerMessage.Add("Asunto: Prueba del formato simple", 2);
            headerMessage.Add("Probando Formato", 0);

            bodyMessage.Add("\n\nEl universo tiene un principio, pero no un final. Infinito. Las estrellas también tienen un principio, pero su propio poder las conduce a su destrucción." +
                            "\nFinito.La historia nos ha enseñado que los más sabios son los más estúpidos." +
                            "\nEsto podría llamarse La última advertencia de Dios a aquellos que todavía resisten.", 1);
            bodyMessage.Add("- Okabe Rintaro", 2);

            bodyMessage.Add("\n\nSoy una científica, mis acciones se basan en la lógica y en los números, jamás me dejaría llevar por mis sentimientos.", 1);
            bodyMessage.Add("\n- Kurisu Makise", 2);

            footerMessage.Add("\n\nTexto al Azar", 3);


            return Generateformat(headerMessage, bodyMessage, footerMessage);
        }
        #endregion

    }
}
