using iText.IO.Font.Constants;
using iText.Kernel.Colors;
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
    public class TableFormatReport1
    {
        readonly PdfFont FontHelveticaNegrita = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        readonly PdfFont FontHelvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        int fontSize = 12;

        public byte[] GenerateFormat()
        {
            MemoryStream pdfTem = new MemoryStream();
            PdfWriter writer = new PdfWriter(pdfTem);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            #region Table
            GetTable(document);
            #endregion

            document.Close();
            return pdfTem.ToArray();
        }

        private void GetTable(Document document)
        {
            Table table = new Table(1, true);
            Table table2 = new Table(1, true);

            Paragraph cell = new Paragraph();
            Paragraph cell2 = new Paragraph();

            cell.Add(new Text("Title").SetFont(FontHelveticaNegrita).SetFontSize(fontSize));

            cell2.Add(new Text("\nRow 1: ||||||||||||||||||||||||| ").SetFont(FontHelvetica));
            cell2.Add(new Text("\nRow 2: |||||||||||||||||||||||||||||").SetFont(FontHelvetica));

            table.AddCell(cell).SetBackgroundColor(new DeviceRgb(84, 84, 84));
            table2.AddCell(cell2.SetFontSize(fontSize - 2));

            document.Add(table);
            document.Add(table2);

        }
    }
}
