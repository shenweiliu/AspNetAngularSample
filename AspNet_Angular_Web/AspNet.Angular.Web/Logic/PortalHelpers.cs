using System.Text.RegularExpressions;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNet.Angular.Contracts;

namespace AspNet.Angular.Web.Logic
{
    public class PortalHelpers
    {
        private System.Web.Mvc.WebViewPage View { get; set; }
        private IModuleController WebController { get { return this.View.ViewContext.Controller as IModuleController; } }

        public DivisionContext Division { get { return this.WebController.Division; } }

        /// <summary>
        /// For when you absolutely
        /// </summary>
        /// <returns></returns>

        public PortalHelpers(System.Web.Mvc.WebViewPage view)
        {
            this.View = view;
        }

        public string FormatPrice(Decimal? price)
        {
            return price.HasValue ? Math.Abs(price.Value).ToString("c") : "—";
        }

        public string FormatWhole(Decimal? number)
        {
            return number.HasValue ? number.Value.ToString("#") : "—";
        }

        public string FormatPriceToEmdashIfZero(Decimal? number)
        {
            return number == 0 ? "—" : FormatPrice(number);
        }

        public string FormatWholeZeroIfNull(Decimal? number)
        {
            return number.HasValue ? number.Value.ToString("0") : "0";
        }

        public string FormatDate(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("MMMM d, yyyy") : "—";
        }

        public string FormatShortDate(DateTime? date)
        {
            return date.HasValue ? date.Value.ToShortDateString() : "—";
        }

        public string FormatTime(DateTime? date)
        {
            return date.HasValue ? date.Value.ToLocalTime().ToShortTimeString() : "—";
        }

        public string FormatDateTime(DateTime? date)
        {
            return date.HasValue ? date.Value.ToLocalTime().ToString("MMMM d, yyyy hh:mm tt \"EST\"") : "—";
        }

        public string FormatInteger(int? payments)
        {
            return payments.HasValue ? payments.Value.ToString() : "—";
        }

        public string FormatPhoneNumber(string str)
        {
            if (string.IsNullOrEmpty(str)) { return string.Empty; }

            if (str.Count(Char.IsDigit) == 10)
            {
                return Regex.Replace(Regex.Replace(str, @"[^0-9]", @""), @"(\w{3})(\w{3})(\w{4})", @"$1.$2.$3");
            }
            return str;
        }

        public string GetFormattedTermForLoanContract(int? term)
        {
            var formattedTerm = "—";

            if (term.HasValue)
            {
                var months = Math.Round((term.Value / 21.66));

                formattedTerm = string.Format("{0} payments(~ {1} months)", term.Value, months);
            }
            return formattedTerm;
        }

        public string Coalesce(params string[] strings)
        {
            foreach (var s in strings)
            {
                if (!String.IsNullOrEmpty(s)) { return s; }
            }
            return String.Empty;
        } 
    }
}