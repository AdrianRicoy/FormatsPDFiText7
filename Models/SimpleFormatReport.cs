using iText.IO.Font.Constants;
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
    public class SimpleFormatReport
    {
        readonly PdfFont FontHelveticaNegrita = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        readonly PdfFont FontHelvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        int fontSize = 12;
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public SimpleFormatReport() { }
        /// <summary>
        /// Genere todo el formato del PDF llamando a los métodos correspondientes
        /// </summary>
        /// <param name="headerMessage">Texto del encabezado</param>
        /// <param name="bodyMessage">Texto del cuerpo del mensaje</param>
        /// <param name="footerMessage">Texto del pie de página</param>
        /// <returns>Arreglo de byte donde estará la información del PDF</returns>
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
        /// <summary>
        /// Obtner el mensaje del header
        /// </summary>
        /// <param name="style">El tipo de estilo que tendrá el texto</param>
        /// <param name="text">El mensaje</param>
        /// <returns>Un párrafo</returns>
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
        /// <summary>
        /// Obtener el cuerpo del mensaje
        /// </summary>
        /// <param name="style">Estilo que tendrá el texto</param>
        /// <param name="text">El mensaje</param>
        /// <returns>Párrafo con el mensaje</returns>
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
                case 4:
                    paragraph.Add(new Text(text).SetFont(FontHelvetica).SetFontSize(fontSize)).SetTextAlignment(TextAlignment.CENTER);
                    break;
                case 5:
                    paragraph.Add(new Text(text).SetFont(FontHelvetica).SetFontSize(fontSize)).SetTextAlignment(TextAlignment.RIGHT);
                    break;
            }

            return paragraph;
        }
        #endregion

        #region Methods - Footer
        /// <summary>
        /// Obtener el pie de página
        /// </summary>
        /// <param name="style">El estilo que va a recibir</param>
        /// <param name="text">El mensaje</param>
        /// <returns>Párrafo</returns>
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
                case 4:
                    paragraph.Add(new Text(text).SetFont(FontHelvetica).SetFontSize(fontSize)).SetTextAlignment(TextAlignment.CENTER);
                    break;
                case 5:
                    paragraph.Add(new Text(text).SetFont(FontHelvetica).SetFontSize(fontSize)).SetTextAlignment(TextAlignment.RIGHT);
                    break;
            }

            return paragraph;
        }
        #endregion

        #region Text
        /// <summary>
        /// Genera todos los textos para el pdf
        /// </summary>
        /// <returns>El pdf en un arreglo de byte</returns>
        public byte[] CreateMyPdf()
        {
            Dictionary<string, int> headerMessage = new Dictionary<string, int>();
            Dictionary<string, int> bodyMessage = new Dictionary<string, int>();
            Dictionary<string, int> footerMessage = new Dictionary<string, int>();

            string fecha = string.Format("\n\nDay {0} of {1} - {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

            #region header
            headerMessage.Add(fecha, 1);
            headerMessage.Add("Asunto: Prueba del formato simple", 2);
            headerMessage.Add("Probando Formato", 0);
            #endregion

            #region body
            bodyMessage.Add("\n\nEl universo tiene un principio, pero no un final. Infinito. Las estrellas también tienen un principio, pero su propio poder las conduce a su destrucción." +
                            "\nFinito.La historia nos ha enseñado que los más sabios son los más estúpidos." +
                            "\nEsto podría llamarse La última advertencia de Dios a aquellos que todavía resisten.", 1);
            bodyMessage.Add("- Okabe Rintaro", 2);

            bodyMessage.Add("\n\nSoy una científica, mis acciones se basan en la lógica y en los números, jamás me dejaría llevar por mis sentimientos.", 1);
            bodyMessage.Add("\n- Kurisu Makise", 2);
            #endregion

            #region footer
            footerMessage.Add("\n\nTexto al Azar", 3);
            #endregion


            return Generateformat(headerMessage, bodyMessage, footerMessage);
        }
        /// <summary>
        /// Generar el formato simple PDF con distintas alineaciones
        /// </summary>
        /// <returns>Un arreglo en byte con la información del PDF</returns>
        public byte[] CreateMyPdf2()
        {
            Dictionary<string, int> headerMessage = new Dictionary<string, int>();
            Dictionary<string, int> bodyMessage = new Dictionary<string, int>();
            Dictionary<string, int> footerMessage = new Dictionary<string, int>();

            string fecha = string.Format("\n\nDay {0} of {1} - {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

            #region header
            headerMessage.Add(fecha, 1);
            headerMessage.Add("Asunto: Prueba del formato simple", 2);
            headerMessage.Add("Probando Formato", 0);
            #endregion

            #region body
            bodyMessage.Add("\n\nEl universo tiene un principio, pero no un final. Infinito. Las estrellas también tienen un principio, pero su propio poder las conduce a su destrucción." , 1);
            bodyMessage.Add("\nFinito.La historia nos ha enseñado que los más sabios son los más estúpidos.", 2);

            bodyMessage.Add("\nEsto podría llamarse La última advertencia de Dios a aquellos que todavía resisten.", 5);

            bodyMessage.Add("- Okabe Rintaro", 4);

            bodyMessage.Add("\n\nSoy una científica, mis acciones se basan en la lógica y en los números, jamás me dejaría llevar por mis sentimientos.", 0);
            bodyMessage.Add("\n- Kurisu Makise", 3);
            #endregion

            #region footer
            footerMessage.Add("________________________________________________________________", 3);
            footerMessage.Add("Texto al Azar 0", 0);
            footerMessage.Add("Texto al Azar 1", 1);
            footerMessage.Add("Texto al Azar 2", 2);
            footerMessage.Add("Texto al Azar 3", 3);
            footerMessage.Add("Texto al Azar 4", 4);
            footerMessage.Add("Texto al Azar 5", 5);
            #endregion

            return Generateformat(headerMessage, bodyMessage, footerMessage);
        }
        #endregion

    }
}
