using ReceiptTemplateSkiaSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiptTemplateSkiaSharp
{
    public class TemplateProvider
    {
        private readonly int _dpi;
        private readonly float _toPixel;

        public TemplateProvider(int dpi)
        {
            _dpi = dpi;
            _toPixel = _dpi / 25.4f;
        }

        public LayoutTemplate GetTemplate21()
        {
            return new LayoutTemplate
            {
                StoreName = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 22,
                    Top = 39
                },

                StoreNameDivider = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 238,
                    Top = 89
                },

                Date = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                    Top = 105
                },


                RegisterName = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    Top = 128
                },

                StaffName = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    Top = 151,
                },

                HeaderDivider = new Dimensions
                {
                    Color = "#0F0F13",
                    Top = 184,
                    Left = 10,
                    Width = 238,
                },

                CustomerTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    Top = 200,
                },

                CustomerAddress = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                },

                CustomerName = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                },

                CustomerPhoneNumber = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                },

                CustomerDivider = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 238,
                    TopPadding = 16
                },

                OrderDescriptionTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                },

                OrderQuantityTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                    Left = 148,
                },

                OrderTotalTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                    Left = 222,
                },

                OrderItemName = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 8,
                    Width = 120
                },

                OrderItemQuantity = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 8,
                    Left = 120,
                    Width = 40
                },

                OrderItemTotalPrice = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 8,
                    Left = 177,
                    Width = 77
                },

                OrderItemDiscountTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 10,
                    TopPadding = 6,
                    Width = 30
                },

                OrderItemDiscountValue = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 10,
                    TopPadding = 6,
                    Left = 30,
                    Width = 139
                },

                OrderItemMainPrice = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 12,
                    TopPadding = 4,
                    Left = 178,
                    Width = 77
                },

                OrderItemValues = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 12,
                    TopPadding = 4,
                    Width = 170
                },

                OrderItemNoteTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 12,
                    TopPadding = 6,
                },

                OrderItemNoteValue = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 12,
                    TopPadding = 6,
                    Width = 214,
                    Height = 38,
                },

                OrderDivider = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 238,
                    TopPadding = 16
                },

                OrderNote = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 8,
                    Width = 254,
                },

                NoteDivider1 = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 238,
                    TopPadding = 16
                },

                NoteDivider2 = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 238,
                    TopPadding = 16
                },

                SubtotalTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 19,
                    Width = 165,
                },

                SubtotalValue = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 19,
                    Left = 175,
                    Width = 77
                },

                TaxTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                },

                TaxValue = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                    Left = 175,
                    Width = 77
                },

                DiscountTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                },

                DiscountValue = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                    Left = 175,
                    Width = 77
                },

                SaleTotalTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                },

                SaleValue = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                    Left = 175,
                    Width = 77
                },

                PricingDivider1 = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 238,
                    TopPadding = 16
                },

                PricingDivider2 = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 238,
                    TopPadding = 16
                },

                PaymentSummaryTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                },

                PaymentTransactionTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                    Width = 175
                },

                PaymentTransactionValue = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                    Left = 175,
                    Width = 77
                },

                PaymentDivider = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 238,
                    TopPadding = 16
                },

                ChangeTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,                    
                },

                ChangeValue = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                    Left = 175,
                    Width = 77
                },

                ChangeDivider = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 238,
                    TopPadding = 16
                },

                LocationName = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 24,
                },

                LocationPhoneNumber = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 3,
                },

                ThanksTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 3,
                },
            };
        }
    }
}
