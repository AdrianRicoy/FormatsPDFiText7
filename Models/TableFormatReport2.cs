using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.IO;

namespace PdfHandler.Models
{
    public class TableFormatReport2
    {
        readonly PdfFont FontHelveticaNegrita = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        readonly PdfFont FontHelvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        int fontSize = 10;
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public TableFormatReport2() { }
        /// <summary>
        /// Genera el formato PDF
        /// </summary>
        /// <returns>Un arreglo de byte con la estructura PDF</returns>
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
            document.Add(GetTableDateEnrollment());
            document.Add(GetTableData());
            document.Add(new Paragraph("\n"));
            document.Add(GetTableAdd());
            #endregion

            #region Footer

            #endregion

            document.Close();
            return pdfTem.ToArray();
        }

        #region Methods - Header
        /// <summary>
        /// Genera el mensaje del header
        /// </summary>
        /// <param name="alignment">Alineación del contenido</param>
        /// <returns>Párrafo</returns>
        private Paragraph GetHeader(TextAlignment alignment)
        {
            Paragraph paragraph = new Paragraph();

            paragraph.Add(new Text("SECRETARÁA DE EDUCACIÓN"));
            paragraph.Add(new Text("\nDEPARTAMENTO SECRETO DE TI"));
            paragraph.Add(new Text("\nSOLICITUD DE INGRESO"));

            paragraph.SetFont(FontHelveticaNegrita).SetFontSize(fontSize + 1);

            return paragraph.SetTextAlignment(alignment);
        }
        #endregion

        #region Methods - Body
        /// <summary>
        /// Genera la tabla con la matrícula y la fecha actual
        /// </summary>
        /// <returns>Objeto Table</returns>
        private Table GetTableDateEnrollment()
        {
            Table table = new Table(new float[] { 20, 50, 15, 15}, true);

            string enrollment = "15A35B0544";
            string dateFormat = string.Format("{0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

            Cell cellEnrollment = new Cell(1,1);
            table.AddCell(cellEnrollment.Add(new Paragraph("MATRÍCULA ")).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT));

            cellEnrollment = new Cell(1,1);
            cellEnrollment.Add(new Paragraph(enrollment).SetBorderBottom(new SolidBorder(1f)));
            cellEnrollment.SetBorderTop(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
            table.AddCell(cellEnrollment.SetTextAlignment(TextAlignment.LEFT));

            cellEnrollment = new Cell(1, 1);
            table.AddCell(cellEnrollment.Add(new Paragraph("FECHA ")).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT));

            cellEnrollment = new Cell(1, 1);
            cellEnrollment.Add(new Paragraph(dateFormat).SetBorderBottom(new SolidBorder(1f)));
            cellEnrollment.SetBorderTop(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER).SetBorderLeft(Border.NO_BORDER);
            table.AddCell(cellEnrollment.SetTextAlignment(TextAlignment.LEFT));

            return table.SetFontSize(8);
        }
        /// <summary>
        /// Genera la tabla de Datos de la persona
        /// </summary>
        /// <returns>Objeto Tabla</returns>
        private Table GetTableData()
        {
            Table table = new Table(new float[] { 25, 41, 17, 17 }, true);

            table.AddCell(GetCell(4, "DATOS GENERALES", TextAlignment.CENTER, true, false));

            table.AddCell(GetCell(1, "NOMBRE ", TextAlignment.RIGHT, false, false).SetBorderRight(Border.NO_BORDER));
            string nombre = string.Format("{0}                    {1}                    {2}", "NOMBRE", "APELLIDO", "APELLIDO");
            table.AddCell(GetCell(3, nombre, TextAlignment.LEFT, false, true).SetBorderLeft(Border.NO_BORDER));

            nombre = string.Format("{0}          {1}                 {2}", "APELLIDO PATERNO", "APELLIDO MATERNO", "NOMBRE");
            table.AddCell(GetCell(1, "", TextAlignment.CENTER, false, false).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(3, nombre, TextAlignment.LEFT, false, false).SetBorderLeft(Border.NO_BORDER).SetFontSize(8));

            table.AddCell(GetCell(1, "ESTADO CIVIL ", TextAlignment.RIGHT, false, false).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, "Soltero(a)", TextAlignment.LEFT, false, true).SetBorderLeft(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, " EDAD ", TextAlignment.RIGHT, false, false).SetBorderLeft(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, "21", TextAlignment.LEFT, false, true).SetBorderLeft(Border.NO_BORDER));

            table.AddCell(GetCell(1, "COLONIA O LOCALIDAD", TextAlignment.RIGHT, false, false).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, "Ciudad inventada por mí y nada más", TextAlignment.LEFT, false, true).SetBorderLeft(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, " C.P. ", TextAlignment.RIGHT, false, false).SetBorderLeft(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, "12345", TextAlignment.LEFT, false, true).SetBorderLeft(Border.NO_BORDER));

            table.AddCell(GetCell(1, "NÚMERO TELEFÓNICO", TextAlignment.RIGHT, false, false).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, "55 1234 1234", TextAlignment.LEFT, false, true).SetBorderLeft(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, " MUNICIPIO. ", TextAlignment.RIGHT, false, false).SetBorderLeft(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, "Inventado", TextAlignment.LEFT, false, true).SetBorderLeft(Border.NO_BORDER));

            table.AddCell(new Cell(1, 4));

            return table;
        }
        /// <summary>
        /// Generar segunda tabla de ejemplo
        /// </summary>
        /// <returns></returns>
        private Table GetTableAdd()
        {
            Table table = new Table(new float[] { 20, 30, 25, 25 }, true);

            table.AddCell(GetCell(4, "ME INSCRIBO COMO CANDIDATO A:", TextAlignment.CENTER, true, false));

            table.AddCell(GetCell(1, "Puesto ", TextAlignment.RIGHT, false, false).SetBorderRight(Border.NO_BORDER));
            string puesto = "Puesto inventado por mí´, porque así lo he querido";
            table.AddCell(GetCell(1, puesto, TextAlignment.LEFT, false, true).SetBorderLeft(Border.NO_BORDER));
            table.AddCell(GetCell(1, "PERIODO ", TextAlignment.RIGHT, false, false).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, "72", TextAlignment.LEFT, false, true).SetBorderLeft(Border.NO_BORDER));

            table.AddCell(GetCell(1, "SEGURO SOCIAL ", TextAlignment.RIGHT, false, false).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, "Nada", TextAlignment.LEFT, false, true).SetBorderLeft(Border.NO_BORDER));
            table.AddCell(GetCell(1, "PERIODO ", TextAlignment.RIGHT, false, false).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, "32", TextAlignment.LEFT, false, true).SetBorderLeft(Border.NO_BORDER));

            table.AddCell(new Cell(1, 4));

            return table;
        }
        #endregion

        #region Methods - Footer

        #endregion

        #region Props
        /// <summary>
        /// Crea la celda que irá en la tabla
        /// </summary>
        /// <param name="row">Número de filas</param>
        /// <param name="col">Número de columnas</param>
        /// <param name="text">Texto que mostrará</param>
        /// <param name="alignment">Alineación del mensaje</param>
        /// <param name="color">Color de fonto</param>
        /// <returns>Celda construida</returns>
        private Cell GetCell(int col, string text, TextAlignment alignment, bool color, bool borderBottom)
        {
            Cell cell = new Cell(1, col);

            if (borderBottom) cell.Add(new Paragraph(text).SetBorderBottom(new SolidBorder(1f)));
            else cell.Add(new Paragraph(text));

            if (color)
            {
                cell.SetBackgroundColor(new DeviceRgb(222, 222, 222));
                cell.SetBorder(new SolidBorder(1f));
            }
            else
            {
                cell.SetBorderTop(Border.NO_BORDER);
                cell.SetBorderBottom(Border.NO_BORDER);
            }

            cell.SetTextAlignment(alignment);
            cell.SetFontSize(fontSize);
            return cell;
        }
        #endregion
    }
}
