using ReceiptTemplateSkiaSharp.Models;
using System;
using System.Collections.Generic;

namespace ReceiptTemplateSkiaSharp
{
    class Program
    {
        private static int _dpi = 203;
        static void Main(string[] args)
        {
            ReceiptPage receiptModels = GetListOfLayoutModelsToPrint();

            var template = new TemplateProvider(_dpi);

            var receiptTemlate = template.GetTemplate21();

            LayoutCalculator calculator = new LayoutCalculator(receiptTemlate);

            var pages = calculator.Calculate(receiptModels);

            LabelDrawer labelDrawer = new LabelDrawer(pages);

            labelDrawer.CreateImage();

            labelDrawer.CreatePdf(_dpi);
        }

        private static ReceiptPage GetListOfLayoutModelsToPrint()
        {
            return new ReceiptPage
            {
                StoreName = new LabelCoordinations { Title = "Store Name" },
                Date = new LabelCoordinations { Title = "12 /5 /1252" },
                RegisterName = new LabelCoordinations { Title = "Register Name" },
                StaffName = new LabelCoordinations { Title = "Staff Name" },
                CustomerTitle = new LabelCoordinations { Title = "CUSTOMER Details:" },
                CustomerAddress = new LabelCoordinations { Title = "Tehran -24 Alay -55 unit" },
                CustomerName = new LabelCoordinations { Title = "Sam som" },
                CustomerPhoneNumber = new LabelCoordinations { Title = "555 - 555 - 444" },
                OrderDescriptionTitle = new LabelCoordinations { Title = "Description" },
                OrderQuantityTitle = new LabelCoordinations { Title = "Qty" },
                OrderTotalTitle = new LabelCoordinations { Title = "Total" },
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Name = new LabelCoordinations{ Title = "T-shirt"},
                        Quantity = new LabelCoordinations{ Title = "3"},
                        TotalPrice = new LabelCoordinations{ Title = "250$"},
                        DiscountTitle = new LabelCoordinations{ Title = "Dis:"},
                        DiscountValue = new LabelCoordinations{ Title = "20%"},
                        MainPrice = new LabelCoordinations{ Title = "350$"},
                        Values = new LabelCoordinations{ Title = "Red-Small"},
                        NoteTitle = new LabelCoordinations{ Title = "Note:"},
                        NoteValue = new LabelCoordinations{ Title = "this is a note"},
                    },

                    new OrderItem
                    {
                        Name = new LabelCoordinations{ Title = "T-shirt"},
                        Quantity = new LabelCoordinations{ Title = "3"},
                        TotalPrice = new LabelCoordinations{ Title = "250$"},
                        DiscountTitle = new LabelCoordinations{ Title = "Dis:"},
                        DiscountValue = new LabelCoordinations{ Title = "20%"},
                        MainPrice = new LabelCoordinations{ Title = "350$"},
                        Values = new LabelCoordinations{ Title = "Red-Small"},
                        NoteTitle = new LabelCoordinations{ Title = "Note:"},
                        NoteValue = new LabelCoordinations{ Title = "this is a note"},
                    },

                    new OrderItem
                    {
                        Name = new LabelCoordinations{ Title = "T-shirt"},
                        Quantity = new LabelCoordinations{ Title = "3"},
                        TotalPrice = new LabelCoordinations{ Title = "250$"},
                        NoteTitle = new LabelCoordinations{ Title = "Note:"},
                        NoteValue = new LabelCoordinations{ Title = "this is a note"},
                    }
                },
                OrderNote = new LabelCoordinations { Title = "Note: This is an Order item Note." },
                SubtotalTitle = new LabelCoordinations { Title = "Subtotal" },
                SubtotalValue = new LabelCoordinations { Title = "$50.97" },
                TaxTitle = new LabelCoordinations { Title = "Tax" },
                TaxValue = new LabelCoordinations { Title = "$50.97" },
                DiscountTitle = new LabelCoordinations { Title = "Discount" },
                DiscountValue = new LabelCoordinations { Title = "$50.97" },
                SaleTotalTitle = new LabelCoordinations { Title = "Sale Total" },
                SaleValue = new LabelCoordinations { Title = "$50.97" },
                PaymentSummaryTitle = new LabelCoordinations { Title = "Payment Summary:" },
                PaymentTransactions = new List<PaymentTransaction>
                {
                    new PaymentTransaction
                    {
                         Title = new LabelCoordinations{ Title = "Cash"},
                         Value = new LabelCoordinations{ Title = "$50.97"},
                    },

                    new PaymentTransaction
                    {
                         Title = new LabelCoordinations{ Title = "Customer Account"},
                         Value = new LabelCoordinations{ Title = "$50.97"},
                    },
                },
                ChangeTitle = new LabelCoordinations { Title = "Change" },
                ChangeValue = new LabelCoordinations { Title = "$50.97" },
                LocationName = new LabelCoordinations { Title = "Location Name" },
                LocationPhoneNumber = new LabelCoordinations { Title = "555-4215-552:" },
                ThanksTitle = new LabelCoordinations { Title = "Thanks for Shoping" },
                Barcode = new LabelCoordinations { Title = "1452256" },
            };
        }
    }
}
