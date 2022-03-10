using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WindowsFormsMySQL
{
    class Geral
    {
        public static string id_user = "";
        public static string TirarEspacos(string mensagem)
        {
            mensagem = mensagem.Trim();
            mensagem = Regex.Replace(mensagem, @"\s+", " ");
            return mensagem;
        }

        public static bool CheckDate(string date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
