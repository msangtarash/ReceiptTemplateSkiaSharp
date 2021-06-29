using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiptTemplateSkiaSharp.Models
{
    public class LayoutTemplate
    {
        public float PageHeight { get; set; }
        public float PageWidth { get; set; }
        public float TopMargin { get; set; }
        public float LeftMargin { get; set; }

        public Dimensions StoreName { get; set; }
        public Dimensions StoreNameDivider { get; set; }

        public Dimensions Date { get; set; }
        public Dimensions RegisterName { get; set; }
        public Dimensions StaffName { get; set; }
        public Dimensions HeaderDivider { get; set; }

        public Dimensions CustomerTitle { get; set; }
        public Dimensions CustomerAddress { get; set; }
        public Dimensions CustomerName { get; set; }
        public Dimensions CustomerPhoneNumber { get; set; }
        public Dimensions CustomerDivider { get; set; }

        public Dimensions OrderDescriptionTitle { get; set; }
        public Dimensions OrderQuantityTitle { get; set; }
        public Dimensions OrderTotalTitle { get; set; }

        public Dimensions OrderItemName { get; set; }
        public Dimensions OrderItemQuantity { get; set; }
        public Dimensions OrderItemTotalPrice { get; set; }
        public Dimensions OrderItemDiscountTitle { get; set; }
        public Dimensions OrderItemDiscountValue { get; set; }
        public Dimensions OrderItemMainPrice { get; set; }
        public Dimensions OrderItemValues { get; set; }
        public Dimensions OrderItemNoteTitle { get; set; }
        public Dimensions OrderItemNoteValue { get; set; }
        public Dimensions OrderDivider { get; set; }

        public Dimensions OrderNote { get; set; }
        public Dimensions NoteDivider1 { get; set; }
        public Dimensions NoteDivider2 { get; set; }

        public Dimensions SubtotalTitle { get; set; }
        public Dimensions SubtotalValue { get; set; }
        public Dimensions TaxTitle { get; set; }
        public Dimensions TaxValue { get; set; }
        public Dimensions DiscountTitle { get; set; }
        public Dimensions DiscountValue { get; set; }
        public Dimensions SaleTotalTitle { get; set; }
        public Dimensions SaleValue { get; set; }
        public Dimensions PricingDivider1 { get; set; }
        public Dimensions PricingDivider2 { get; set; }

        public Dimensions PaymentSummaryTitle { get; set; }

        public Dimensions PaymentTransactionTitle { get; set; }
        public Dimensions PaymentTransactionValue { get; set; }
        public Dimensions PaymentDivider { get; set; }

        public Dimensions ChangeTitle { get; set; }
        public Dimensions ChangeValue { get; set; }
        public Dimensions ChangeDivider { get; set; }

        public Dimensions LocationName { get; set; }
        public Dimensions LocationPhoneNumber { get; set; }
        public Dimensions ThanksTitle { get; set; }
        public Dimensions Barcode { get; set; }
        public Dimensions BarcodeNumber { get; set; }
        public Dimensions Logo { get; set; }

    }

    public class Dimensions
    {
        public float Top { get; set; }
        public float Left { get; set; }
        public float TopPadding { get; set; }
        public float LeftPadding { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public string Color { get; set; } = "000000";
        public float TextSize { get; set; }

    }
}
