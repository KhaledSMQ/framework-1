// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using System;
using Framework.Core.Patterns;

namespace Framework.Core.Extensions
{
    public class XslDateExtension : IXsltExtensionObject
    {
        //
        // SINGLETON
        //

        public static IXsltExtensionObject Instance
        {
            get { return (_Instance = (_Instance == null) ? new XslDateExtension() : _Instance); }
        }

        //
        // PROPERTIES
        //

        public string NamespaceUri { get { return Lib.DEFAULT_XML_NAMESPACE + "/xsl/date"; } }

        //
        // CONSTRCUTORS
        //

        private XslDateExtension() { }

        //
        // EXPOSED METHODS
        //

        public string GetCurrentDate()
        {
            return DateTime.Now.ToString();
        }

        public string GetCurrentYear()
        {
            return DateTime.Now.Year.ToString();
        }

        public string GetCurrentMonth()
        {
            return DateTime.Now.Month.ToString();
        }

        public string GetCurrentDay()
        {
            return DateTime.Now.Day.ToString();
        }

        public string GetCurrentHour()
        {
            return DateTime.Now.Hour.ToString();
        }

        public string GetCurrentMinute()
        {
            return DateTime.Now.Minute.ToString();
        }

        public string GetCurrentSecond()
        {
            return DateTime.Now.Second.ToString();
        }

        public string GetCurrentMillisecond()
        {
            return DateTime.Now.Millisecond.ToString();
        }

        public DateTime GetTodaysDate()
        {
            return DateTime.Now;
        }

        public int GetNumberOfDays(string from, string to)
        {
            DateTime fromDate = DateTime.Parse(from);
            DateTime toDate = DateTime.Parse(to);
            return toDate.Subtract(fromDate).Days;
        }

        public int GetNumberOfHours(string from, string to)
        {
            DateTime fromDate = DateTime.Parse(from);
            DateTime toDate = DateTime.Parse(to);
            return toDate.Subtract(fromDate).Hours;
        }

        public int GetNumberOfMinutes(string from, string to)
        {
            DateTime fromDate = DateTime.Parse(from);
            DateTime toDate = DateTime.Parse(to);
            return toDate.Subtract(fromDate).Minutes;
        }

        public int GetNumberOfSeconds(string from, string to)
        {
            DateTime fromDate = DateTime.Parse(from);
            DateTime toDate = DateTime.Parse(to);
            return toDate.Subtract(fromDate).Seconds;
        }

        public int GetNumberOfMilliseconds(string from, string to)
        {
            DateTime fromDate = DateTime.Parse(from);
            DateTime toDate = DateTime.Parse(to);
            return toDate.Subtract(fromDate).Milliseconds;
        }

        public string GetFormatedDate(string date, int option)
        {
            DateTime dateValue = DateTime.Parse(date);
            return string.Empty;
        }

        //
        // PRIVATE FIELDS
        //

        private static XslDateExtension _Instance = null;
    }
}
