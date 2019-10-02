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
        public static string GetDayByDate(DateTime date, bool firstCapitalLetter)
        {
            CultureInfo culture = new CultureInfo("Es-Es");
            string day = culture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);

            if (firstCapitalLetter) day = GetFirstCapitalLetter(day);

            return day;
        }
        /// <summary>
        /// Obtiene el nombre del mes de una fecha específica
        /// </summary>
        /// <param name="date"></param>
        /// <returns>El nombre del mes</returns>
        public static string GetMonthByDate(DateTime date, bool firstCapitalLetter)
        {
            DateTimeFormatInfo formatDate = CultureInfo.CurrentCulture.DateTimeFormat;
            string month = formatDate.GetMonthName(date.Day);
            
            if(firstCapitalLetter) month = GetFirstCapitalLetter(month);
            
            return month;
        }
        /// <summary>
        /// Genera el mismo texto que recibe pero con la primera letra en mayúscula
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Texto con la primera letra mayúscula</returns>
        public static string GetFirstCapitalLetter(string text)
        {
            TextInfo textInfo = new CultureInfo("Es-Es").TextInfo;
            return textInfo.ToTitleCase(text);
        }
    }
}
