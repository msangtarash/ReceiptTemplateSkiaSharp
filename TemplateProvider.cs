using ReceiptTemplateSkiaSharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiptTemplateSkiaSharp
{
    public class TemplateProvider
    {
        public LayoutTemplate GetTemplate21()
        {
            return new LayoutTemplate
            {
                PageWidth = 302,
                LeftPadding = 24,

                StoreName = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 22,
                    TopPadding = 39,
                    Width = 244
                },

                StoreNameDivider = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 234,
                    TopPadding = 24
                },

                Date = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                    Width = 244
                },


                RegisterName = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                    Width = 244
                },

                StaffName = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                    Width = 244
                },

                HeaderDivider = new Dimensions
                {
                    Color = "#0F0F13",
                    TopPadding = 16,
                    Left = 10,
                    Width = 234,
                },

                CustomerTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                    Width = 244
                },

                CustomerAddress = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                    Width = 244
                },

                CustomerName = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                    Width = 244
                },

                CustomerPhoneNumber = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 6,
                    Width = 244
                },

                CustomerDivider = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 234,
                    TopPadding = 16
                },

                OrderDescriptionTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                    Width = 120
                },

                OrderQuantityTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                    Left = 130,
                    Width = 40
                },

                OrderTotalTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                    Left = 177,
                    Width =77
                },

                OrderItemName = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 9,
                    Width = 120
                },

                OrderItemQuantity = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 9,
                    Left = 130,
                    Width = 40
                },

                OrderItemTotalPrice = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 9,
                    Left = 177,
                    Width = 77
                },

                OrderItemDiscountTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 10,
                    TopPadding = 0,
                    Width = 30
                },

                OrderItemDiscountValue = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 10,
                    TopPadding = 0,
                    Left = 30,
                    Width = 139
                },

                OrderItemMainPrice = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 12,
                    TopPadding = 0,
                    Left = 178,
                    Width = 77
                },

                OrderItemValues = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 12,
                    TopPadding = 0,
                    Width = 170
                },

                OrderItemNoteTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 12,
                    TopPadding = 0,
                    Width = 35
                },

                OrderItemNoteValue = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 12,
                    TopPadding = 0,
                    Width = 214,
                    Left = 35
                },

                OrderDivider = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 234,
                    TopPadding = 16
                },

                OrderNote = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 8,
                    Width = 244,
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
                    TopPadding = 3
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
                    Width = 165
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
                    Width =165
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
                    Width = 165
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
                    TopPadding = 3
                },

                PaymentSummaryTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                    Width =244
                },

                PaymentTransactionTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 8,
                    Width = 165 ,
                },

                PaymentTransactionValue = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 8,
                    Left = 175,
                    Width = 77
                },

                PaymentDivider = new Dimensions
                {
                    Color = "#0F0F13",
                    Left = 10,
                    Width = 234,
                    TopPadding = 16
                },

                ChangeTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 16,
                    Width =165
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
                    Width = 234,
                    TopPadding = 16
                },

                LocationName = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 24,
                    Width = 244
                },

                LocationPhoneNumber = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 3,
                    Width = 244
                },

                ThanksTitle = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 14,
                    TopPadding = 3,
                    Width = 244
                },

                Barcode = new Dimensions
                {
                    Color = "#0F0F13",
                    TextSize = 12,
                    Left = 100,
                    TopPadding = 21,
                    Height = 50,
                    Width = 105,
                }
            };
        }
    }
}
