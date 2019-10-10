using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdfHandler.Models
{
    public static class Message
    {
        /// <summary>
        /// Mensaje cuando el PDF no sea encontrado
        /// </summary>
        public static string pdfNotFound = "El pdf seleccionado de momento no esta disponible";
        /// <summary>
        /// Mensaje cuando se realice una busqueda sin mandar el nombre del pdf
        /// </summary>
        public static string pdfNotName = "Debe de seleccionar un pdf para realizar la consulta";
    }
}
