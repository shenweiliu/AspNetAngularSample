using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using AspNet.Angular.Mod.Areas.Mdp.Controllers.Base;
using AspNet.Angular.Contracts;

namespace AspNet.Angular.Mod.Areas.Views
{
    public class PortalHelpers
    {
        private System.Web.Mvc.WebViewPage View { get; set; }
        private WebControllerBase WebController { get { return this.View.ViewContext.Controller as WebControllerBase; } }        

        public IFramework Framework { get { return this.WebController.Framework; } }

        //private IDomainHelper _domainHelper = null;
        //public IDomainHelper DomainHelper
        //{
        //    get { return _domainHelper ?? (_domainHelper = new DomainHelper(this.View.Context.Request)); }
        //}

        public PortalHelpers(System.Web.Mvc.WebViewPage view)
        {
            this.View = view;
        }

        public string FormatPrice(Decimal? price)
        {
            return price.HasValue ? Math.Abs(price.Value).ToString("c") : "—";
        }

        public string FormatPriceTruncate(Decimal? price)
        {
            return price.HasValue ? decimal.Truncate(price.Value).ToString("C0") : "-";
        }

        public string FormatWhole(Decimal? number)
        {
            return number.HasValue ? number.Value.ToString("#") : "—";
        }

        public string FormatPriceToEmdashIfZero(Decimal? number)
        {
            return number == 0 ? "—" : FormatPrice(number);
        }

        public string FormatStringToProperCase(string str)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(str);
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

        public int CalcPercentPaid(string TotalTerms, string PaidTerm)
        {
            int totalterm = 0, paidterm = 0;
            Int32.TryParse(TotalTerms, out totalterm);
            Int32.TryParse(PaidTerm, out paidterm);
            int percentPaid = 0;

            if (paidterm > 0)
                percentPaid = (totalterm / paidterm) * 100;

            return percentPaid;
        }

        public string GetLabelForContractType(int contractType)
        {
            switch (contractType)
            {
                case 1: return "Lease";
                case 2: return "Loan";
                default: return "Unknown";
            }
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

        public int CalcPercentPaid(decimal TotalPayments, decimal PaymentsMade)
        {
            var percentPaid = (TotalPayments / PaymentsMade) * 100;

            return decimal.ToInt32(percentPaid);
        }

        public int GetExpireDays(DateTime? expiryDate)
        {
            if (expiryDate != null && DateTime.Today < expiryDate)
            {
                return ((DateTime)expiryDate - DateTime.Today).Days;
            }
            return 0;
        }
        
        public string GetExpirationMessage(DateTime? expiryDate)
        {
            if (expiryDate != null && DateTime.Today < expiryDate)
            {
                var daysRemaining = ((DateTime)expiryDate - DateTime.Today).Days;
                if (daysRemaining == 0)
                {
                    return " Expires today. ";
                }
                else
                {
                    return string.Format(" Expires in {0} days. ", daysRemaining);
                }

            }
            return "?";
        }
    }

    public abstract class ViewBase : System.Web.Mvc.WebViewPage
    {
        public PortalHelpers PortalHelpers { get; set; }

        protected ViewBase()
        {
            this.PortalHelpers = new PortalHelpers(this);
        }
    }

    public abstract class ViewBase<T> : System.Web.Mvc.WebViewPage<T>
    {
        public PortalHelpers PortalHelpers { get; set; }

        protected ViewBase()
        {
            this.PortalHelpers = new PortalHelpers(this);
        }
    }
}