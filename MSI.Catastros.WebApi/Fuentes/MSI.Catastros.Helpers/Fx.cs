using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.Helpers
{
    public class Fx
    {
        public static string Right(string param, int lenght)
        {
            string result = param.Substring(param.Length - lenght, lenght);
            return result;
        }
        public static DateTime HoyHHmm()
        {
            DateTime dteResultado;
            string strFechaHHmm = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
            dteResultado = Convert.ToDateTime(strFechaHHmm);
            return dteResultado;
        }
        public static string Fecha(Nullable<DateTime> iFecha)
        {
            string strResultado = "";
            if (iFecha == null)
            {
                return strResultado;
            }

            DateTime dteFecha = Convert.ToDateTime(iFecha);
            strResultado = dteFecha.ToString("dd/MM/yyyy");
            return strResultado;
        }
        public static string FechaLgHHmm(Nullable<DateTime> iFecha)
        {
            string strResultado = "";
            string strMesName = "";

            if (iFecha == null)
            {
                return strResultado;
            }

            DateTime dteFecha = Convert.ToDateTime(iFecha);
            string strFecha = dteFecha.ToString("yyyy-MM-dd");
            string strHoy = DateTime.Now.ToString("yyyy-MM-dd");
            double dblDias = (Convert.ToDateTime(strHoy) - Convert.ToDateTime(strFecha)).TotalDays;

            int intMes = dteFecha.Month;
            string strDia = Right("00" + (dteFecha.Day).ToString(), 2);
            string strAno = (dteFecha.Year).ToString();
            string strHoraMinuto = (dteFecha).ToString("dd/MM/yyyy HH:mm").Substring(11, 5);
            switch (intMes)
            {
                case 1:
                    strMesName = "Ene";
                    break;
                case 2:
                    strMesName = "Feb";
                    break;
                case 3:
                    strMesName = "Mar";
                    break;
                case 4:
                    strMesName = "Abr";
                    break;
                case 5:
                    strMesName = "May";
                    break;
                case 6:
                    strMesName = "Jun";
                    break;
                case 7:
                    strMesName = "Jul";
                    break;
                case 8:
                    strMesName = "Ago";
                    break;
                case 9:
                    strMesName = "Sep";
                    break;
                case 10:
                    strMesName = "Oct";
                    break;
                case 11:
                    strMesName = "Nov";
                    break;
                case 12:
                    strMesName = "Dic";
                    break;
                default:
                    break;
            }
            strResultado = strMesName + " " + strDia + ", " + strAno + " - " + strHoraMinuto;
            if (strHoy == strFecha)
            {
                strResultado = "Hoy - " + strHoraMinuto;
            }
            if (dblDias == 1)
            {
                strResultado = "Ayer - " + strHoraMinuto;
            }
            return strResultado;
        }
    }
}
