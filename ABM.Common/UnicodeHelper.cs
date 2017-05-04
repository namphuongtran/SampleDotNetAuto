using System;

namespace ABM.Common
{
    public class UnicodeHelper
    {
        #region Unicode
                
        public const string UniChars =
            "àáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệđìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵÀÁẢÃẠÂẦẤẨẪẬĂẰẮẲẴẶÈÉẺẼẸÊỀẾỂỄỆĐÌÍỈĨỊÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢÙÚỦŨỤƯỪỨỬỮỰỲÝỶỸỴÂĂĐÔƠƯ";

        public const string UnsignChars =
            "aaaaaaaaaaaaaaaaaeeeeeeeeeeediiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEDIIIOOOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYAADOOU";

        public static string Unsign(string s)
        {
            var retVal = String.Empty;
            for (var i = 0; i < s.Length; i++)
            {
                var pos = UniChars.IndexOf(s[i].ToString());
                if (pos >= 0)
                    retVal += UnsignChars[pos];
                else
                    retVal += s[i];
            }
            return retVal;
        }

        public static string UnsignAndDash(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                var retVal = String.Empty;
                for (int i = 0; i < s.Length; i++)
                {
                    var pos = UniChars.IndexOf(s[i].ToString());
                    if (pos >= 0)
                        retVal += UnsignChars[pos];
                    else
                        retVal += s[i];
                }
                retVal = retVal.Replace("-", "");
                retVal = retVal.Replace("  ", "");
                retVal = retVal.Replace(" ", "-");
                retVal = retVal.Replace("--", "-");
                retVal = retVal.Replace(":", "");
                retVal = retVal.Replace(";", "");
                retVal = retVal.Replace("+", "");
                retVal = retVal.Replace("@", "");
                retVal = retVal.Replace(">", "");
                retVal = retVal.Replace("<", "");
                retVal = retVal.Replace("*", "");
                retVal = retVal.Replace("{", "");
                retVal = retVal.Replace("}", "");
                retVal = retVal.Replace("|", "");
                retVal = retVal.Replace("^", "");
                retVal = retVal.Replace("~", "");
                retVal = retVal.Replace("]", "");
                retVal = retVal.Replace("[", "");
                retVal = retVal.Replace("`", "");
                retVal = retVal.Replace(".", "");
                retVal = retVal.Replace("'", "");
                retVal = retVal.Replace("(", "");
                retVal = retVal.Replace(")", "");
                retVal = retVal.Replace(",", "");
                retVal = retVal.Replace("”", "");
                retVal = retVal.Replace("“", "");
                retVal = retVal.Replace("?", "");
                retVal = retVal.Replace("\"", "");
                retVal = retVal.Replace("&", "");
                retVal = retVal.Replace("$", "");
                retVal = retVal.Replace("#", "");
                retVal = retVal.Replace("_", "");
                retVal = retVal.Replace("=", "");
                retVal = retVal.Replace("%", "");
                retVal = retVal.Replace("…", "");
                retVal = retVal.Replace("/", "");
                retVal = retVal.Replace("\\", "");
                return retVal.ToLower();
            }
            return string.Empty;
        }

        #endregion
    }
}
