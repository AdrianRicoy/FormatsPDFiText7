using System;
using System.Collections.Generic;
using System.Globalization;
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
        /// <summary>
        /// Obtener nombre del día de la semana por una fecha
        /// </summary>
        /// <param name="date">Fecha con la que se obtendrá el día</param>
        /// <returns>Día</returns>
        public static string GetDayByDate(DateTime date)
        {
            CultureInfo culture = new CultureInfo("Es-Es");
            return culture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
        }
    }
}
