using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdfHandler.Models
{
    public class HandlerPdf
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public HandlerPdf() { }
        /// <summary>
        /// Llamará al método correspondiente dependiendo del nombre del pdf
        /// </summary>
        /// <param name="pdfName">Nombre del PDF seleccionado</param>
        /// <returns>Arreglo de byte con la información del PDF</returns>
        public byte[] StartHandlerPdf(string pdfName)
        {
            byte[] report = null;
            switch(pdfName)
            {
                case "Simple format":
                    report = new SimpleFormatReport().CreateMyPdf();
                    break;
                case "Format Alignment":
                    report = new SimpleFormatReport().CreateMyPdf2();
                    break;
                case "Format Img":
                    report = new FormatImgReport().Generateformat();
                    break;
                case "Format Table 1":
                    report = new TableFormatReport1().GenerateFormat();
                    break;
                case "Format Table 2":
                    report = new TableFormatReport2().GenerateFormat();
                    break;
            }

            return report;
        }
        /// <summary>
        /// Lista con el nombre y descripción de cada formato PDF
        /// </summary>
        /// <returns></returns>
        public List<String> PdfNames()
        {
            List<String> name = new List<String>();

            name.Add("Simple format;Crea un pdf con un formato simple");
            name.Add("Format Alignment;Crea un pdf con formato de diferente alineación");
            name.Add("Format Img;Crea un pdf con formato simple con imagenes");
            name.Add("Format Table 1;Crea un pdf con formato de una tabla");
            name.Add("Format Table 2;Crea un pdf con formato de tablas más complejo");
            name.Add("Format Table Image;Crea un pdf con un formato simple");
            name.Add("Format Form;Crea un pdf con un formulario de inputs");
            name.Add("Format Img;Crea un pdf con formato simple con imagenes");
            name.Add("Format Button;Crea un pdf con formato de diferente alineación");
            name.Add("Format None;Crea un pdf con formato de una tabla");
            name.Add("Format None;Crea un pdf con formato de tablas");
            name.Add("Format None;Crea un pdf con un formulario de inputs");

            return name;
        }
    }
}
