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
    public class FormatImgReport
    {
        readonly PdfFont FontHelveticaNegrita = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        readonly PdfFont FontHelvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        int fontSize = 12;
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FormatImgReport() { }
        /// <summary>
        /// Generar el formato PDF
        /// </summary>
        /// <returns></returns>
        public byte[] Generateformat()
        {
            MemoryStream pdfTem = new MemoryStream();
            PdfWriter writer = new PdfWriter(pdfTem);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            #region Header
            document.Add(GetDateAndAffair(TextAlignment.RIGHT));
            document.Add(GetTitle(TextAlignment.CENTER));
            #endregion

            #region Body
            document.Add(GetFirstImg(TextAlignment.LEFT));
            #endregion

            #region footer
            document.Add(GetFooter(TextAlignment.CENTER));
            #endregion

            document.Close();
            return pdfTem.ToArray();
        }

        #region Methods - Header
        /// <summary>
        /// Generar la fecha y el asunto del header del mensaje
        /// </summary>
        /// <param name="alignment">Alineación del texto</param>
        /// <returns>Parráfo</returns>
        private Paragraph GetDateAndAffair(TextAlignment alignment)
        {
            Paragraph paragraph = new Paragraph();

            string date = "Fecha: " + Props.GetDayByDate(DateTime.Now, true) + " " + DateTime.Now.Day + " de " + Props.GetMonthByDate(DateTime.Now, false)
                + " del " + DateTime.Now.Year;

            string affair = "\nAsunto: Generar un formato con algunas imágenes";

            paragraph.Add(date);
            paragraph.Add(affair);
            paragraph.SetFont(FontHelvetica).SetFontSize(fontSize - 3);

            return paragraph.SetTextAlignment(alignment);
        }
        /// <summary>
        /// Generar el title del documento
        /// </summary>
        /// <param name="alignment">Alineación del texto</param>
        /// <returns>Parráfo</returns>
        private Paragraph GetTitle(TextAlignment alignment)
        {
            Paragraph paragraph = new Paragraph();

            paragraph.Add("Formato con imágenes");
            paragraph.SetFont(FontHelveticaNegrita).SetFontSize(fontSize + 1);

            return paragraph.SetTextAlignment(alignment);
        }
        #endregion

        #region Methods - Body
        /// <summary>
        /// Genera el texto con una imágen
        /// </summary>
        /// <param name="alignment">Alineación del contendio</param>
        /// <returns>Parráfo</returns>
        private Paragraph GetFirstImg(TextAlignment alignment)
        {
            const string addressImg = "https://pm1.narvii.com/6949/f72aef9c718329f159e8fdd07fdb19d09ebba7d2r1-398-369v2_hq.jpg";
            Paragraph img = new Paragraph();

            img.Add("\nUna Web esta estructura de 3 partes principales Header - Body - Footer que es una forma en la que podemos llevar" +
                "una mejor estructura de la misma. Haciendo más fácil su desarrollo.\n\n");

            Image image = new Image(ImageDataFactory.Create(addressImg));
            image.SetWidth(150f);
            image.SetHeight(200f);
            img.Add(image);

            return img.SetTextAlignment(alignment);
        }
        #endregion

        #region Methods - Footer
        /// <summary>
        /// Generar el pie de página con una img
        /// </summary>
        /// <param name="alignment">Alineación del contenido</param>
        /// <returns>Parráfo</returns>
        private Paragraph GetFooter(TextAlignment alignment)
        {
            Paragraph paragraph = new Paragraph();

            paragraph.Add("\nATENTAMENTE\n\n");

            string addressImg = "http://www.vanguardia.cu/images/vanguardia_digital/personalidades/fidel/180612firma-fidel.jpg";

            Image image = new Image(ImageDataFactory.Create(addressImg));
            image.SetHeight(100f);
            image.SetWidth(120f);

            paragraph.Add(image);
            paragraph.Add("\n\nDirector General de lo que sea");

            paragraph.SetTextAlignment(alignment);
            paragraph.SetFont(FontHelveticaNegrita).SetFontSize(fontSize + 3);

            return paragraph;
        }

        private Paragraph GetQr(TextAlignment alignment)
        {
            Paragraph paragraph = new Paragraph();

            

            return paragraph;
        }
        #endregion
    }
}
