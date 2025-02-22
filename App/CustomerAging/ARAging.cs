using System.Collections.Generic;
using System.Drawing;

namespace DeliveryTakeOrder.App.CustomerAging
{
    public  class ARAging
    {

        public string CusNum { get; set; }
        public string CusName { get; set; }
        public decimal Terms { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal Current { get; set; }
        public decimal AA { get; set; }
        public decimal AB { get; set; }
        public decimal A { get; set; }
        public decimal B { get; set; }
        public decimal C { get; set; }
        public decimal D { get; set; }
        public decimal E { get; set; }
        public decimal Total { get; set; }
        public int AA_Max { get; set; }
        public int AB_Max { get; set; }
        public int A_Max { get; set; }
        public int B_Max { get; set; }
        public int C_Max { get; set; }
        public int D_Max { get; set; }
        public int E_Max { get; set; }
        public int Total_Max { get; set; }

        public Color AB_Color
        {
            get
            {
                if (AB_Max >= Terms && AB > CreditLimit) return ColorTranslator.FromHtml("#9A0089");
                if (AB_Max >= Terms) return ColorTranslator.FromHtml("#0099BC");
                if (AB > CreditLimit) return ColorTranslator.FromHtml("#E81123");
                return Color.Black;
            }
        }

        public Color AA_Color
        {
            get
            {
                if (AA_Max >= Terms && AA > CreditLimit) return ColorTranslator.FromHtml("#9A0089");
                if (AA_Max >= Terms) return ColorTranslator.FromHtml("#0099BC");
                if (AA > CreditLimit) return ColorTranslator.FromHtml("#E81123");
                return Color.Black;
            }
        }

        public Color A_Color
        {
            get
            {
                if (A_Max >= Terms && A > CreditLimit) return ColorTranslator.FromHtml("#9A0089");
                if (A_Max >= Terms) return ColorTranslator.FromHtml("#0099BC");
                if (A > CreditLimit) return ColorTranslator.FromHtml("#E81123");
                return Color.Black;
            }
        }

        public Color B_Color
        {
            get
            {
                if (B_Max >= Terms && B > CreditLimit) return ColorTranslator.FromHtml("#9A0089");
                if (B_Max >= Terms) return ColorTranslator.FromHtml("#0099BC");
                if (B > CreditLimit) return ColorTranslator.FromHtml("#E81123");
                return Color.Black;
            }
        }

        public Color C_Color
        {
            get
            {
                if (C_Max >= Terms && C > CreditLimit) return ColorTranslator.FromHtml("#9A0089");
                if (C_Max >= Terms) return ColorTranslator.FromHtml("#0099BC");
                if (C > CreditLimit) return ColorTranslator.FromHtml("#E81123");
                return Color.Black;
            }
        }

        public Color D_Color
        {
            get
            {
                if (D_Max >= Terms && D > CreditLimit) return ColorTranslator.FromHtml("#9A0089");
                if (D_Max >= Terms) return ColorTranslator.FromHtml("#0099BC");
                if (D > CreditLimit) return ColorTranslator.FromHtml("#E81123");
                return Color.Black;
            }
        }

        public Color E_Color
        {
            get
            {
                if (E_Max >= Terms && E > CreditLimit) return ColorTranslator.FromHtml("#9A0089");
                if (E_Max >= Terms) return ColorTranslator.FromHtml("#0099BC");
                if (E > CreditLimit) return ColorTranslator.FromHtml("#E81123");
                return Color.Black;
            }
        }

        public Color Total_Color
        {
            get
            {
                if (Total_Max >= Terms && Total > CreditLimit) return ColorTranslator.FromHtml("#9A0089");
                if (Total_Max >= Terms) return ColorTranslator.FromHtml("#0099BC");
                if (Total > CreditLimit) return ColorTranslator.FromHtml("#E81123");
                return Color.Black;
            }
        }

        public List<ARAgingRemark> Remarks { get; set; }
    }
}

