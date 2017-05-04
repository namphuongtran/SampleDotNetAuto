using System;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace ABM.Common
{
    public class Utils
    {
        public static string EncodePassword(string password)
        {
            //Instantiate MD5CryptoServiceProvider, get bytes for user's original password and encode      password in MD5 format.
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] originalPwdBytes = Encoding.Default.GetBytes(password);
            byte[] encodedPwdBytes = md5.ComputeHash(originalPwdBytes);
            //Convert encoded user password in 'readable" format.
            return BitConverter.ToString(encodedPwdBytes).ToLower().Replace("-", "");
        }

        public static bool HasOtp
        {
            get { return ToInt32(ConfigurationManager.AppSettings["OTP_VERIFY"]).Equals(Constants.OtpVerify); }
        }

        public static string GetConfigPathXml(string filePath, int report, string typeOfReport)
        {            
            var pathFilter = string.Empty;
            var xmlFilter = XDocument.Load(filePath);
            var lstFilter = xmlFilter.Descendants("item").Where(sp => (int)sp.Attribute("report") == report && (string)sp.Attribute("type") == typeOfReport);

            foreach (var itemSp in lstFilter)
                pathFilter = (string)itemSp;

            return pathFilter;
        }

        public static int ItemIndex(int dataItemIndex, int pageIndex, int pageSize)
        {
            return (pageSize * (pageIndex - 1) + dataItemIndex + 1);
        }

        /***************************************
        = Convert
        -------------------------------------- */
        public static long ToLong(object obj)
        {
            long retVal;

            try
            {
                retVal = Convert.ToInt64(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static int ToInt32(object obj)
        {
            int retVal;

            try
            {
                retVal = Convert.ToInt32(obj);
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        public static int ToInt32(object obj, int defaultValue)
        {
            int retVal;

            try
            {
                retVal = Convert.ToInt32(obj);
            }
            catch
            {
                retVal = defaultValue;
            }
            return retVal;
        }

        public static string ToString(object obj)
        {
            string retVal;

            try
            {
                retVal = Convert.ToString(obj);
            }
            catch
            {
                retVal = String.Empty;
            }

            return retVal;
        }

        public static DateTime ToDateTime(object obj)
        {
            DateTime retVal;
            try
            {
                retVal = Convert.ToDateTime(obj);
            }
            catch
            {
                retVal = DateTime.Now;
            }
            if (retVal == new DateTime(1, 1, 1)) return DateTime.Now;

            return retVal;
        }

        public static DateTime ToDateTime(object obj, DateTime defaultValue)
        {
            DateTime retVal;
            try
            {
                retVal = Convert.ToDateTime(obj);
            }
            catch
            {
                retVal = DateTime.Now;
            }
            if (retVal == new DateTime(1, 1, 1)) return defaultValue;

            return retVal;
        }

        public static DateTime ValidDateTime(string dt)
        {
            try
            {
                var isCheck = dt.Contains("/");
                var splitDateTime = dt.Split(isCheck ? '/' : '-');

                var validDateTime = string.Format("{0}/{1}/{2}", splitDateTime[2], splitDateTime[1], splitDateTime[0]);
                return ToDateTime(validDateTime);
            }
            catch
            {
                return DateTime.MaxValue;
            }
        }

        public static string FormatIn_HHMM_DDMMYYYY(DateTime dt)
        {
            string sDay;
            string sMonth;
            string sHour;
            string sMin;

            if (dt.Hour < 10)
            {
                sHour = "0" + dt.Hour;
            }
            else
                sHour = dt.Hour.ToString();
            if (dt.Minute < 10)
            {
                sMin = "0" + dt.Minute;
            }
            else
                sMin = dt.Minute.ToString();
            if (dt.Month < 10)
            {
                sMonth = "0" + dt.Month;
            }
            else
                sMonth = dt.Month + "";
            if (dt.Day < 10)
            {
                sDay = "0" + dt.Day;
            }
            else
                sDay = dt.Day + "";

            return sHour + ":" + sMin + " - " + sDay + "/" + sMonth + "/" + dt.Year;
        }

        public static string FormatIn_DDMMYYYY(DateTime dt)
        {
            string sDay;
            string sMonth;           
           
            if (dt.Month < 10)
            {
                sMonth = "0" + dt.Month;
            }
            else
                sMonth = dt.Month + "";
            if (dt.Day < 10)
            {
                sDay = "0" + dt.Day;
            }
            else
                sDay = dt.Day + "";

            return sDay + "/" + sMonth + "/" + dt.Year;
        }

        public static string FormatIn_HHMM(DateTime dt)
        {
            string sHour;
            string sMin;

            if (dt.Hour < 10)
            {
                sHour = "0" + dt.Hour;
            }
            else
                sHour = dt.Hour.ToString();
            if (dt.Minute < 10)
            {
                sMin = "0" + dt.Minute;
            }
            else
                sMin = dt.Minute.ToString();            

            return sHour + ":" + sMin;
        }
    }
}
