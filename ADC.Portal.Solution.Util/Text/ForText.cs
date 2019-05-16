using ADC.Portal.Solution.Util.Extensions;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace ADC.Portal.Solution.Util.Text
{
    public static class ForText
    {
        public static string BreakText(string value, int limit)
        {
            return object.Equals(value, null) || value.Length <= limit
                ? value : string.Format("{0}...", value.Substring(0, limit));
        }

        public static string Clear(object value)
        {
            return object.Equals(value, null) ? null
                : Convert.ToString(value).Trim();
        }

        public static string OwnName(string value)
        {
            StringBuilder retorno = new StringBuilder();
            string[] lista;

            value = Regex.Replace(value, @"[\s ]+", " ", RegexOptions.IgnoreCase).Trim().ToLower();
            if (value == string.Empty)
                return value;

            lista = value.Split(' ');

            foreach (string item in lista)
            {
                if (!Regex.IsMatch(item, "^(da|de|do|das|dos)$", RegexOptions.IgnoreCase))
                    retorno.Append(" " + item[0].ToString().ToUpper() + item.Substring(1));
                else
                    retorno.Append(" " + item);
            }

            return retorno.ToString().Trim();
        }

        public static string PropertyName<Tipo>(Expression<Func<Tipo, object>> expressao)
        {
            string name = expressao.Body.ToString();

            if (Regex.IsMatch(name, @"^[^\.]+.+"))
            {
                name = Regex.Replace(name, @"^[\w].", "");
            }
            else
            {
                return expressao.PropExtenso();
            }

            if (Regex.IsMatch(name, @"^[^\.]+.+"))
            {
                return Regex.Replace(name, @"(\.[\w]+)+$", "");
            }

            return expressao.PropExtenso();
        }

        public static String RemoveSpecialCharacters(String value)
        {
            value = value.Trim().ToLower();
            value = Regex.Replace(value, @"[áàäâã]", "a");
            value = Regex.Replace(value, @"[éèëê]", "e");
            value = Regex.Replace(value, @"[íìïî]", "i");
            value = Regex.Replace(value, @"[óòöôõ]", "o");
            value = Regex.Replace(value, @"[úùüû]", "u");
            value = Regex.Replace(value, @"[ç]", "c");
            value = Regex.Replace(value, @"[ñ]", "n");
            value = Regex.Replace(value, @"[^0-9a-z ]", " ");
            value = Regex.Replace(value, @"[\ ]+", "-");
            return value;
        }

        public static String CodeHtml(String value)
        {
            value = Regex.Replace(value, @"á", "&aacute;");
            value = Regex.Replace(value, @"Á", "&Aacute;");
            value = Regex.Replace(value, @"é", "&eacute;");
            value = Regex.Replace(value, @"É", "&Eacute;");
            value = Regex.Replace(value, @"í", "&iacute;");
            value = Regex.Replace(value, @"Í", "&Iacute;");
            value = Regex.Replace(value, @"ó", "&oacute;");
            value = Regex.Replace(value, @"Ó", "&Oacute;");
            value = Regex.Replace(value, @"ú", "&uacute;");
            value = Regex.Replace(value, @"Ú", "&Uacute;");
            // ------------------------------------------
            value = Regex.Replace(value, @"à", "&agrave;");
            value = Regex.Replace(value, @"À", "&Agrave;");
            value = Regex.Replace(value, @"è", "&egrave;");
            value = Regex.Replace(value, @"È", "&Egrave;");
            value = Regex.Replace(value, @"ì", "&igrave;");
            value = Regex.Replace(value, @"Ì", "&Igrave;");
            value = Regex.Replace(value, @"ò", "&ograve;");
            value = Regex.Replace(value, @"Ò", "&Ograve;");
            value = Regex.Replace(value, @"ù", "&ugrave;");
            value = Regex.Replace(value, @"Ù", "&Ugrave;");
            // ------------------------------------------
            value = Regex.Replace(value, @"â", "&acirc;");
            value = Regex.Replace(value, @"Â", "&Acirc;");
            value = Regex.Replace(value, @"ê", "&ecirc;");
            value = Regex.Replace(value, @"Ê", "&Ecirc;");
            value = Regex.Replace(value, @"î", "&icirc;");
            value = Regex.Replace(value, @"Î", "&Icirc;");
            value = Regex.Replace(value, @"ô", "&ocirc;");
            value = Regex.Replace(value, @"Ô", "&Ocirc;");
            value = Regex.Replace(value, @"û", "&ucirc;");
            value = Regex.Replace(value, @"Û", "&Ucirc;");
            // ------------------------------------------
            value = Regex.Replace(value, @"ä", "&auml;");
            value = Regex.Replace(value, @"Ä", "&Auml;");
            value = Regex.Replace(value, @"ë", "&euml;");
            value = Regex.Replace(value, @"Ë", "&Euml;");
            value = Regex.Replace(value, @"ï", "&iuml;");
            value = Regex.Replace(value, @"Ï", "&Iuml;");
            value = Regex.Replace(value, @"ö", "&ouml;");
            value = Regex.Replace(value, @"Ö", "&Ouml;");
            value = Regex.Replace(value, @"ü", "&uuml;");
            value = Regex.Replace(value, @"Ü", "&Uuml;");
            // ------------------------------------------
            value = Regex.Replace(value, @"ã", "&atilde;");
            value = Regex.Replace(value, @"Ã", "&Atilde;");
            value = Regex.Replace(value, @"õ", "&otilde;");
            value = Regex.Replace(value, @"Õ", "&Otilde;");
            value = Regex.Replace(value, @"ñ", "&ntilde;");
            value = Regex.Replace(value, @"Ñ", "&Ntilde;");
            // ------------------------------------------
            value = Regex.Replace(value, @"ç", "&ccedil;");
            value = Regex.Replace(value, @"Ç", "&Ccedil;");
            // ------------------------------------------
            value = Regex.Replace(value, @"ª", "&ordf;");
            value = Regex.Replace(value, @"º", "&ordm;");
            value = Regex.Replace(value, @"°", "&deg;");
            value = Regex.Replace(value, @"°", "&deg;");
            value = Regex.Replace(value, @"¿", "&iquest;");

            return value;
        }

        public static string Uri(object value)
        {
            return Uri(value, "-");
        }

        public static string Uri(object value, string delemiter)
        {
            string result = value.ToString().Trim();
            result = Regex.Replace(result, @"[áàäâã]", "a");
            result = Regex.Replace(result, @"[ÀÀÄÂÃ]", "A");
            result = Regex.Replace(result, @"[éèëê]", "e");
            result = Regex.Replace(result, @"[ÉÈËÊ]", "E");
            result = Regex.Replace(result, @"[íìïî]", "i");
            result = Regex.Replace(result, @"[ÍÌÏÎ]", "I");
            result = Regex.Replace(result, @"[óòöôõ]", "o");
            result = Regex.Replace(result, @"[ÓÒÖÔÕ]", "O");
            result = Regex.Replace(result, @"[úùüû]", "u");
            result = Regex.Replace(result, @"[ÚÙÜÛ]", "U");
            result = Regex.Replace(result, @"[ç]", "c");
            result = Regex.Replace(result, @"[Ç]", "C");
            result = Regex.Replace(result, @"[ñ]", "n");
            result = Regex.Replace(result, @"[Ñ]", "N");
            result = Regex.Replace(result, @"[^0-9a-zA-Z_\- ]", " ");
            result = Regex.Replace(result, @"[\ ]+", " ");
            result = result.Trim();
            result = Regex.Replace(result, @"[\ ]+", "-");
            return result;
        }
    }
}
