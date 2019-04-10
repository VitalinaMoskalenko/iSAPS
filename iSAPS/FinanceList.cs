using System;
using Xamarin.Forms;

namespace iSAPS
{
    public class FinanceList : ViewCell
    {
        public string finance_id { get; set; }
        public string student_id { get; set; }
        public string bank_account { get; set; }
        public string payment_date { get; set; }
        public string amount { get; set; }
        public string amount_of_posting { get; set; }
        public string remaining_payment { get; set; }
        public string amount_invoiced { get; set; }

        public string ShowFinanceTitle
        {
            get
            {
                return string.Format(
                                "Data (wymagana) płatności:\n" +
                                "Kwota: \n" +
                                "Kwota zaksięgowania: \n" +
                                "Kwona pozostałej należności: \n" +
                                "Kwota zafakturowania: \n" +
                                ""
                    );
            }
        }
        public string ShowFinanceValue
        {
            get
            {
                return string.Format(
                                "{0}\n" +
                                "{1}\n" +
                                "{2}\n" +
                                "{3}\n" +
                                "{4}" +
                                "", DateTime.Parse(payment_date).ToShortDateString(),
                                    amount,
                                    amount_of_posting,
                                    remaining_payment,
                                    amount_invoiced
                    );
            }
        }
    }
}
