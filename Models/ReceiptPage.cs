using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiptTemplateSkiaSharp.Models
{
    public class ReceiptPage
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public LabelCoordinations StoreName { get; set; }
        public LabelCoordinations StoreNameDivider { get; set; }

        public LabelCoordinations Date { get; set; }
        public LabelCoordinations RegisterName { get; set; }
        public LabelCoordinations StaffName { get; set; }
        public LabelCoordinations HeaderDivider { get; set; }

        public LabelCoordinations CustomerTitle { get; set; }
        public LabelCoordinations CustomerAddress { get; set; }
        public LabelCoordinations CustomerName { get; set; }
        public LabelCoordinations CustomerPhoneNumber { get; set; }
        public LabelCoordinations CustomerDivider { get; set; }

        public LabelCoordinations OrderDescriptionTitle { get; set; }
        public LabelCoordinations OrderQuantityTitle { get; set; }
        public LabelCoordinations OrderTotalTitle { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public LabelCoordinations OrderDivider { get; set; }

        public LabelCoordinations OrderNote { get; set; }
        public LabelCoordinations NoteDivider1 { get; set; }
        public LabelCoordinations NoteDivider2 { get; set; }

        public LabelCoordinations SubtotalTitle { get; set; }
        public LabelCoordinations SubtotalValue { get; set; }
        public LabelCoordinations TaxTitle { get; set; }
        public LabelCoordinations TaxValue { get; set; }
        public LabelCoordinations DiscountTitle { get; set; }
        public LabelCoordinations DiscountValue { get; set; }
        public LabelCoordinations SaleTotalTitle { get; set; }
        public LabelCoordinations SaleValue { get; set; }
        public LabelCoordinations PricingDivider1 { get; set; }
        public LabelCoordinations PricingDivider2 { get; set; }

        public LabelCoordinations PaymentSummaryTitle { get; set; }

        public List<PaymentTransaction> PaymentTransactions { get; set; }
        public LabelCoordinations PaymentDivider { get; set; }

        public LabelCoordinations ChangeTitle { get; set; }
        public LabelCoordinations ChangeValue { get; set; }
        public LabelCoordinations ChangeDivider { get; set; }

        public LabelCoordinations LocationName { get; set; }
        public LabelCoordinations LocationPhoneNumber { get; set; }
        public LabelCoordinations ThanksTitle { get; set; }
        public LabelCoordinations Barcode { get; set; }
        public LabelCoordinations BarcodeNumber { get; set; }
        public LabelCoordinations Logo { get; set; }
    }

    public class OrderItem
    {
        public float Top { get; set; }
        public float Left { get; set; }
        public LabelCoordinations Name { get; set; }
        public LabelCoordinations Quantity { get; set; }
        public LabelCoordinations TotalPrice { get; set; }
        public LabelCoordinations DiscountTitle { get; set; }
        public LabelCoordinations DiscountValue { get; set; }
        public LabelCoordinations MainPrice { get; set; }
        public LabelCoordinations Values { get; set; }
        public LabelCoordinations NoteTitle { get; set; }
        public LabelCoordinations NoteValue { get; set; }

    }

    public class PaymentTransaction
    {
        public float Top { get; set; }
        public float Left { get; set; }
        public LabelCoordinations Title { get; set; }
        public LabelCoordinations Value { get; set; }
    }

    public class LabelCoordinations
    {
        public string Title { get; set; }
        public float Top { get; set; }
        public float Left { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public string Color { get; set; }
        public float TextSize { get; set; }
        public int WidthInt => (int)Math.Ceiling(Width);
        public int HeightInt => (int)Math.Ceiling(Height);
    }
}
