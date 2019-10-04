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
    public class TableFormatReport1
    {
        readonly PdfFont FontHelveticaNegrita = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        readonly PdfFont FontHelvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        int fontSize = 12;
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public TableFormatReport1() { }
        /// <summary>
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
            document.Add(GetHeader(TextAlignment.RIGHT));
            #endregion

            #region Body
            document.Add(GetBody(TextAlignment.JUSTIFIED));
            #endregion

            #region Table
            document.Add(GetTable());
            #endregion

            document.Close();
            return pdfTem.ToArray();
        }

        #region Methods - Header
        private Paragraph GetHeader(TextAlignment alignment)
        {
            Paragraph paragraph = new Paragraph();

            paragraph.Add("Formato Table 1\n");

            paragraph.SetFont(FontHelveticaNegrita).SetFontSize(fontSize).SetTextAlignment(alignment);

            return paragraph;
        }
        #endregion

        #region Methods - Body
        /// <summary>
        /// Genera le cuerpo del mensaje
        /// </summary>
        /// <param name="alignment">Alineación del contenido</param>
        /// <returns>Párrafo</returns>
        private Paragraph GetBody(TextAlignment alignment)
        {
            Paragraph paragraph = new Paragraph();

            paragraph.Add("Mira ese punto. Eso es aquí. Eso es nuestro hogar. Eso somos nosotros. En el, todos los que amas," +
                " todos los que conoces, todos de los que alguna vez escuchaste, cada ser humano que ha existido, vivió su vida." +
                " La suma de todas nuestras alegrías y sufrimientos, miles de religiones seguras de sí mismas, ideologías y " +
                "doctrinas económicas, cada cazador y recolector, cada héroe y cobarde, cada creador y destructor de " +
                "civilizaciones, cada rey y campesino, cada joven pareja enamorada, cada madre y padre, niño esperanzado, " +
                "inventor y explorador, cada maestro de la moral, cada político corrupto, cada “superestrella”, cada " +
                "“líder supremo”, cada santo y pecador en la historia de nuestra especie, vivió ahí – en una mota de polvo " +
                "suspendida en un rayo de sol.");

            paragraph.Add("\nLa Tierra es un escenario muy pequeño en la vasta arena cósmica.Piensa en los ríos de sangre vertida" +
                " por todos esos generales y emperadores, para que en su gloria y triunfo, pudieran convertirse en amos momentáneos" +
                " de una fracción de un punto.Piensa en las interminables crueldades cometidas por los habitantes de una esquina " +
                "del punto sobre los apenas distinguibles habitantes de alguna otra esquina.Cuán frecuentes sus malentendidos, " +
                "cuán ávidos están de matarse los unos a los otros, cómo de fervientes son sus odios.Nuestras posturas, nuestra " +
                "importancia imaginaria, la ilusión de que ocupamos una posición privilegiada en el Universo... es desafiada por " +
                "este punto de luz pálida." +
                "\nNuestro planeta es una solitaria mancha en la gran y envolvente penumbra cósmica.En nuestra oscuridad " +
                "—en toda esta vastedad—, no hay ni un indicio de que vaya a llegar ayuda desde algún otro lugar para salvarnos " +
                "de nosotros mismos.La Tierra es el único mundo conocido hasta ahora que alberga vida.No hay ningún otro lugar, " +
                "al menos en el futuro próximo, al cual nuestra especie pudiera migrar.Visitar, sí.Asentarnos, aún no.Nos guste " +
                "o no, por el momento la Tierra es donde tenemos que quedarnos.Se ha dicho que la astronomía es una formadora de " +
                "humildad y carácter.Tal vez no hay mejor demostración de la locura de los conceptos humanos que esta distante " +
                "imagen de nuestro minúsculo mundo.Para mí, subraya nuestra responsabilidad de tratarnos mejor los unos a los " +
                "otros, y de preservar y querer ese punto azul pálido, el único hogar que siempre hemos conocido.1\n\n");

            paragraph.SetFont(FontHelvetica).SetFontSize(fontSize - 2).SetTextAlignment(alignment);

            return paragraph;
        }
        #endregion

        #region Methods - Table
        /// <summary>
        /// Genera la estructura de la tabla con su informacion
        /// </summary>
        /// <returns>La tabla construida</returns>
        private Table GetTable()
        {
            Table table = new Table(4, true);

            Paragraph title = new Paragraph("Title").SetFont(FontHelveticaNegrita).SetFontSize(fontSize + 3);
            table.AddCell(GetCell(1, 4, title, TextAlignment.CENTER, new DeviceRgb(80, 80, 80)));

            Paragraph celda = new Paragraph("Nombre: ").SetFont(FontHelvetica).SetFontSize(fontSize);
            table.AddCell(GetCell(1, 2, celda, TextAlignment.RIGHT, new DeviceRgb(255, 255, 255)));

            celda = new Paragraph(new Text("Stephen     Hawking\n").SetBorderBottom(new SolidBorder(1f)).SetFontSize(fontSize)).SetFont(FontHelvetica);
            celda.Add(new Paragraph(new Text("NOM     APELLIDO1")).SetFont(FontHelvetica).SetFontSize(fontSize - 4));
            table.AddCell(GetCell(1, 2, celda, TextAlignment.LEFT, new DeviceRgb(255, 255, 255)));

            celda = new Paragraph("Prueba de otro texto").SetFont(FontHelvetica).SetFontSize(fontSize);
            table.AddCell(GetCell(1, 4, celda, TextAlignment.CENTER, new DeviceRgb(255, 255, 255)));

            celda = new Paragraph("Grado: 7mo de Ingeniería").SetFont(FontHelvetica).SetFontSize(fontSize);
            table.AddCell(GetCell(1, 1, new Paragraph(""), TextAlignment.CENTER, new DeviceRgb(255, 255, 255)));
            table.AddCell(GetCell(1, 3, celda, TextAlignment.CENTER, new DeviceRgb(23, 193, 180)));

            table.AddCell(GetCell(1, 1, new Paragraph("1"), TextAlignment.CENTER, new DeviceRgb(255, 255, 255)));
            table.AddCell(GetCell(1, 1, new Paragraph("2"), TextAlignment.CENTER, new DeviceRgb(255, 255, 255)).SetBorderRight(Border.NO_BORDER));
            table.AddCell(GetCell(1, 1, new Paragraph("3"), TextAlignment.CENTER, new DeviceRgb(255, 255, 255)).SetBorderLeft(Border.NO_BORDER));
            table.AddCell(GetCell(1, 1, new Paragraph("4"), TextAlignment.CENTER, new DeviceRgb(255, 255, 255)));

            table.AddCell(GetCell(1, 4, new Paragraph(""), TextAlignment.CENTER, new DeviceRgb(123, 55, 135)));

            return table;
        }
        /// <summary>
        /// Crea la celda que irá en la tabla
        /// </summary>
        /// <param name="row">Número de filas</param>
        /// <param name="col">Número de columnas</param>
        /// <param name="text">Texto que mostrará</param>
        /// <param name="alignment">Alineación del mensaje</param>
        /// <param name="color">Color de fonto</param>
        /// <returns>Celda construida</returns>
        private Cell GetCell(int row, int col, Paragraph text, TextAlignment alignment, DeviceRgb color)
        {
            Cell cell = new Cell(row, col);

            cell.Add(text);
            cell.SetTextAlignment(alignment);
            cell.SetBackgroundColor(color);

            return cell;
        }
        #endregion

    }
}