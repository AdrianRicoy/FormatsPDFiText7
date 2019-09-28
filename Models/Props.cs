using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdfHandler.Models
{
    public static class Props
    {
        /// <summary>
        /// Genera un número aleatorio en un rango especificado
        /// </summary>
        /// <param name="range">Arreglo que contendra el rango</param>
        /// <returns>El número aleatorio</returns>
        public static int RandomNumber(int[] range)
        {
            return new Random().Next(range[0], range[1]);
        }
    }
}
