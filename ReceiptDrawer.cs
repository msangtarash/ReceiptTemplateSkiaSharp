﻿using ReceiptTemplateSkiaSharp.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZXing;

namespace ReceiptTemplateSkiaSharp
{
    public class LabelDrawer
    {
        private ReceiptPage _receiptPage;

        public LabelDrawer(ReceiptPage receiptPage)
        {
            _receiptPage = receiptPage;
        }

        public void CreateImage()
        {
            SKImageInfo imageInfo = new SKImageInfo(_receiptPage.Width, _receiptPage.Height);
            using SKSurface surface = SKSurface.Create(imageInfo);
            SKCanvas canvas = surface.Canvas;
            DrawOnCanvas(canvas, _receiptPage);
            using SKImage image = surface.Snapshot();
            using SKData data = image.Encode(SKEncodedImageFormat.Png, 80);
            using FileStream stream = File.OpenWrite(Path.Combine(AppContext.BaseDirectory, $"receiptImage.png"));
            data.SaveTo(stream);
        }

        public void CreatePdf(int dpi)
        {
            using SKFileWStream stream = new SKFileWStream(Path.Combine(AppContext.BaseDirectory, "doc.pdf"));
            using SKDocument document = SKDocument.CreatePdf(stream, dpi);
            using SKCanvas pdfCanvas = document.BeginPage(_receiptPage.Width, _receiptPage.Height);
            DrawOnCanvas(pdfCanvas, _receiptPage);
            document.Close();
        }

        public void DrawOnCanvas(SKCanvas canvas, ReceiptPage page)
        {
            canvas.Clear(SKColors.White);

            using (SKPaint storeName = new SKPaint())
            {
                SKColor.TryParse(page.StoreName.Color, out SKColor color);

                storeName.Color = color;

                storeName.TextSize = page.StoreName.TextSize;

                storeName.FakeBoldText = true;

                canvas.DrawText(page.StoreName.Title, page.StoreName.Left, page.StoreName.Top, storeName);
            }

            using (SKPaint storeNameDivider = new SKPaint())
            {
                SKColor.TryParse(page.StoreNameDivider.Color, out SKColor color);

                storeNameDivider.Color = color;
                var pointA = new SKPoint(page.StoreNameDivider.Left, page.StoreNameDivider.Top);
                var pointB = new SKPoint(page.StoreNameDivider.Left + page.StoreNameDivider.Width, page.StoreNameDivider.Top);

                canvas.DrawLine(pointA, pointB, storeNameDivider);
            }

            using (SKPaint dateTime = new SKPaint())
            {
                SKColor.TryParse(page.Date.Color, out SKColor color);

                dateTime.Color = color;

                dateTime.TextSize = page.Date.TextSize;

                canvas.DrawText(page.Date.Title, page.Date.Left, page.Date.Top, dateTime);
            }

            using (SKPaint registerName = new SKPaint())
            {
                SKColor.TryParse(page.RegisterName.Color, out SKColor color);

                registerName.Color = color;

                registerName.TextSize = page.RegisterName.TextSize;

                canvas.DrawText(page.RegisterName.Title, page.RegisterName.Left, page.RegisterName.Top, registerName);
            }

            using (SKPaint staffName = new SKPaint())
            {
                SKColor.TryParse(page.StaffName.Color, out SKColor color);

                staffName.Color = color;

                staffName.TextSize = page.StaffName.TextSize;

                canvas.DrawText(page.StaffName.Title, page.StaffName.Left, page.StaffName.Top, staffName);
            }

            using (SKPaint headerDivider = new SKPaint())
            {
                SKColor.TryParse(page.HeaderDivider.Color, out SKColor color);

                headerDivider.Color = color;

                var pointA = new SKPoint(page.HeaderDivider.Left, page.HeaderDivider.Top);
                var pointB = new SKPoint(page.HeaderDivider.Left + page.HeaderDivider.Width, page.HeaderDivider.Top);

                canvas.DrawLine(pointA, pointB, headerDivider);
            }

            using (SKPaint customerTitle = new SKPaint())
            {
                SKColor.TryParse(page.CustomerTitle.Color, out SKColor color);

                customerTitle.Color = color;

                customerTitle.TextSize = page.CustomerTitle.TextSize;

                customerTitle.FakeBoldText = true;

                canvas.DrawText(page.CustomerTitle.Title, page.CustomerTitle.Left, page.CustomerTitle.Top, customerTitle);
            }

            if (string.IsNullOrEmpty(page.CustomerAddress.Title) is false)
            {
                using (SKPaint customerAddress = new SKPaint())
                {
                    SKColor.TryParse(page.CustomerAddress.Color, out SKColor color);

                    customerAddress.Color = color;

                    customerAddress.TextSize = page.CustomerAddress.TextSize;

                    canvas.DrawText(page.CustomerAddress.Title, page.CustomerAddress.Left, page.CustomerAddress.Top, customerAddress);
                }
            }

            using (SKPaint customerName = new SKPaint())
            {
                SKColor.TryParse(page.CustomerName.Color, out SKColor color);

                customerName.Color = color;

                customerName.TextSize = page.CustomerName.TextSize;

                canvas.DrawText(page.CustomerName.Title, page.CustomerName.Left, page.CustomerName.Top, customerName);
            }

            if (string.IsNullOrEmpty(page.CustomerPhoneNumber.Title) is false)
            {
                using (SKPaint customerPhoneNumber = new SKPaint())
                {
                    SKColor.TryParse(page.CustomerPhoneNumber.Color, out SKColor color);

                    customerPhoneNumber.Color = color;

                    customerPhoneNumber.TextSize = page.CustomerPhoneNumber.TextSize;

                    canvas.DrawText(page.CustomerPhoneNumber.Title, page.CustomerPhoneNumber.Left, page.CustomerPhoneNumber.Top, customerPhoneNumber);
                }
            }

            using (SKPaint customerDivider = new SKPaint())
            {
                SKColor.TryParse(page.CustomerDivider.Color, out SKColor color);

                customerDivider.Color = color;

                var pointA = new SKPoint(page.CustomerDivider.Left, page.CustomerDivider.Top);
                var pointB = new SKPoint(page.CustomerDivider.Left + page.CustomerDivider.Width, page.CustomerDivider.Top);

                canvas.DrawLine(pointA, pointB, customerDivider);
            }

            using (SKPaint orderDescriptionTitle = new SKPaint())
            {
                SKColor.TryParse(page.OrderDescriptionTitle.Color, out SKColor color);

                orderDescriptionTitle.Color = color;

                orderDescriptionTitle.TextSize = page.OrderDescriptionTitle.TextSize;

                orderDescriptionTitle.FakeBoldText = true;

                canvas.DrawText(page.OrderDescriptionTitle.Title, page.OrderDescriptionTitle.Left, page.OrderDescriptionTitle.Top, orderDescriptionTitle);
            }

            using (SKPaint orderQuantityTitle = new SKPaint())
            {
                SKColor.TryParse(page.OrderQuantityTitle.Color, out SKColor color);

                orderQuantityTitle.Color = color;

                orderQuantityTitle.TextSize = page.OrderQuantityTitle.TextSize;

                orderQuantityTitle.FakeBoldText = true;

                canvas.DrawText(page.OrderQuantityTitle.Title, page.OrderQuantityTitle.Left, page.OrderQuantityTitle.Top, orderQuantityTitle);
            }

            using (SKPaint orderTotalTitle = new SKPaint())
            {
                SKColor.TryParse(page.OrderTotalTitle.Color, out SKColor color);

                orderTotalTitle.Color = color;

                orderTotalTitle.TextSize = page.OrderTotalTitle.TextSize;

                orderTotalTitle.FakeBoldText = true;

                canvas.DrawText(page.OrderTotalTitle.Title, page.OrderTotalTitle.Left, page.OrderTotalTitle.Top, orderTotalTitle);
            }

            foreach (var orderItem in page.OrderItems)
            {
                using (SKPaint orderItemName = new SKPaint())
                {
                    SKColor.TryParse(orderItem.Name.Color, out SKColor color);

                    orderItemName.Color = color;

                    orderItemName.TextSize = orderItem.Name.TextSize;

                    canvas.DrawText(orderItem.Name.Title, orderItem.Name.Left, orderItem.Name.Top, orderItemName);
                }

                using (SKPaint orderItemQuantity = new SKPaint())
                {
                    SKColor.TryParse(orderItem.Quantity.Color, out SKColor color);

                    orderItemQuantity.Color = color;

                    orderItemQuantity.TextSize = orderItem.Quantity.TextSize;

                    canvas.DrawText(orderItem.Quantity.Title, orderItem.Quantity.Left, orderItem.Quantity.Top, orderItemQuantity);
                }

                using (SKPaint totalPrice = new SKPaint())
                {
                    SKColor.TryParse(orderItem.TotalPrice.Color, out SKColor color);

                    totalPrice.Color = color;

                    totalPrice.TextSize = orderItem.TotalPrice.TextSize;

                    canvas.DrawText(orderItem.TotalPrice.Title, orderItem.TotalPrice.Left, orderItem.TotalPrice.Top, totalPrice);
                }

                if (string.IsNullOrEmpty(orderItem.DiscountValue.Title) is false)
                {
                    using (SKPaint discountTitle = new SKPaint())
                    {
                        SKColor.TryParse(orderItem.DiscountTitle.Color, out SKColor color);

                        discountTitle.Color = color;

                        discountTitle.TextSize = orderItem.DiscountTitle.TextSize;

                        canvas.DrawText(orderItem.DiscountTitle.Title, orderItem.DiscountTitle.Left, orderItem.DiscountTitle.Top, discountTitle);
                    }

                    using (SKPaint discountValue = new SKPaint())
                    {
                        SKColor.TryParse(orderItem.DiscountValue.Color, out SKColor color);

                        discountValue.Color = color;

                        discountValue.TextSize = orderItem.DiscountValue.TextSize;

                        canvas.DrawText(orderItem.DiscountValue.Title, orderItem.DiscountValue.Left, orderItem.DiscountValue.Top, discountValue);
                    }

                    using (SKPaint mainPrice = new SKPaint())
                    {
                        SKColor.TryParse(orderItem.MainPrice.Color, out SKColor color);

                        mainPrice.Color = color;

                        mainPrice.TextSize = orderItem.MainPrice.TextSize;

                        canvas.DrawText(orderItem.MainPrice.Title, orderItem.MainPrice.Left, orderItem.MainPrice.Top, mainPrice);
                    }
                }

                if (string.IsNullOrEmpty(orderItem.Values.Title) is false)
                {
                    using (SKPaint values = new SKPaint())
                    {
                        SKColor.TryParse(orderItem.Values.Color, out SKColor color);

                        values.Color = color;

                        values.TextSize = orderItem.Values.TextSize;

                        canvas.DrawText(orderItem.Values.Title, orderItem.Values.Left, orderItem.Values.Top, values);
                    }
                }

                if (string.IsNullOrEmpty(orderItem.NoteValue.Title) is false)
                {
                    using (SKPaint noteTitle = new SKPaint())
                    {
                        SKColor.TryParse(orderItem.NoteTitle.Color, out SKColor color);

                        noteTitle.Color = color;

                        noteTitle.TextSize = orderItem.NoteTitle.TextSize;

                        canvas.DrawText(orderItem.NoteTitle.Title, orderItem.NoteTitle.Left, orderItem.NoteTitle.Top, noteTitle);
                    }

                    using (SKPaint noteValue = new SKPaint())
                    {
                        SKColor.TryParse(orderItem.NoteValue.Color, out SKColor color);

                        noteValue.Color = color;

                        noteValue.TextSize = orderItem.NoteValue.TextSize;

                        canvas.DrawText(orderItem.NoteValue.Title, orderItem.NoteValue.Left, orderItem.NoteValue.Top, noteValue);
                    }
                }
            }

            if (string.IsNullOrEmpty(page.OrderNote.Title) is false)
            {
                using (SKPaint orderDivider = new SKPaint())
                {
                    SKColor.TryParse(page.OrderDivider.Color, out SKColor color);

                    orderDivider.Color = color;

                    var pointA = new SKPoint(page.OrderDivider.Left, page.OrderDivider.Top);
                    var pointB = new SKPoint(page.OrderDivider.Left + page.OrderDivider.Width, page.OrderDivider.Top);

                    canvas.DrawLine(pointA, pointB, orderDivider);
                }

                using (SKPaint orderNote = new SKPaint())
                {
                    SKColor.TryParse(page.OrderNote.Color, out SKColor color);

                    orderNote.Color = color;

                    orderNote.TextSize = page.OrderNote.TextSize;

                    canvas.DrawText(page.OrderNote.Title, page.OrderNote.Left, page.OrderNote.Top, orderNote);
                }
            }

            using (SKPaint noteDivider1 = new SKPaint())
            {
                SKColor.TryParse(page.NoteDivider1.Color, out SKColor color);

                noteDivider1.Color = color;

                var pointA = new SKPoint(page.NoteDivider1.Left, page.NoteDivider1.Top);
                var pointB = new SKPoint(page.NoteDivider1.Left + page.NoteDivider1.Width, page.NoteDivider1.Top);

                canvas.DrawLine(pointA, pointB, noteDivider1);
            }

            using (SKPaint noteDivider2 = new SKPaint())
            {
                SKColor.TryParse(page.NoteDivider2.Color, out SKColor color);

                noteDivider2.Color = color;

                var pointA = new SKPoint(page.NoteDivider2.Left, page.NoteDivider2.Top);
                var pointB = new SKPoint(page.NoteDivider2.Left + page.NoteDivider2.Width, page.NoteDivider2.Top);

                canvas.DrawLine(pointA, pointB, noteDivider2);
            }

            using (SKPaint subtotalTitle = new SKPaint())
            {
                SKColor.TryParse(page.SubtotalTitle.Color, out SKColor color);

                subtotalTitle.Color = color;

                subtotalTitle.TextSize = page.SubtotalTitle.TextSize;

                canvas.DrawText(page.SubtotalTitle.Title, page.SubtotalTitle.Left, page.SubtotalTitle.Top, subtotalTitle);
            }

            using (SKPaint subtotalValue = new SKPaint())
            {
                SKColor.TryParse(page.SubtotalValue.Color, out SKColor color);

                subtotalValue.Color = color;

                subtotalValue.TextSize = page.SubtotalValue.TextSize;

                canvas.DrawText(page.SubtotalValue.Title, page.SubtotalValue.Left, page.SubtotalValue.Top, subtotalValue);
            }

            using (SKPaint taxTitle = new SKPaint())
            {
                SKColor.TryParse(page.TaxTitle.Color, out SKColor color);

                taxTitle.Color = color;

                taxTitle.TextSize = page.TaxTitle.TextSize;

                canvas.DrawText(page.TaxTitle.Title, page.TaxTitle.Left, page.TaxTitle.Top, taxTitle);
            }

            using (SKPaint taxValue = new SKPaint())
            {
                SKColor.TryParse(page.TaxValue.Color, out SKColor color);

                taxValue.Color = color;

                taxValue.TextSize = page.TaxValue.TextSize;

                canvas.DrawText(page.TaxValue.Title, page.TaxValue.Left, page.TaxValue.Top, taxValue);
            }

            using (SKPaint discountTitle = new SKPaint())
            {
                SKColor.TryParse(page.DiscountTitle.Color, out SKColor color);

                discountTitle.Color = color;

                discountTitle.TextSize = page.DiscountTitle.TextSize;

                canvas.DrawText(page.DiscountTitle.Title, page.DiscountTitle.Left, page.DiscountTitle.Top, discountTitle);
            }

            using (SKPaint discountValue = new SKPaint())
            {
                SKColor.TryParse(page.DiscountValue.Color, out SKColor color);

                discountValue.Color = color;

                discountValue.TextSize = page.DiscountValue.TextSize;

                canvas.DrawText(page.DiscountValue.Title, page.DiscountValue.Left, page.DiscountValue.Top, discountValue);
            }

            using (SKPaint saleTotalTitle = new SKPaint())
            {
                SKColor.TryParse(page.SaleTotalTitle.Color, out SKColor color);

                saleTotalTitle.Color = color;

                saleTotalTitle.TextSize = page.SaleTotalTitle.TextSize;

                canvas.DrawText(page.SaleTotalTitle.Title, page.SaleTotalTitle.Left, page.SaleTotalTitle.Top, saleTotalTitle);
            }

            using (SKPaint saleValue = new SKPaint())
            {
                SKColor.TryParse(page.SaleValue.Color, out SKColor color);

                saleValue.Color = color;

                saleValue.TextSize = page.SaleValue.TextSize;

                canvas.DrawText(page.SaleValue.Title, page.SaleValue.Left, page.SaleValue.Top, saleValue);
            }

            using (SKPaint pricingDivider1 = new SKPaint())
            {
                SKColor.TryParse(page.PricingDivider1.Color, out SKColor color);

                pricingDivider1.Color = color;

                var pointA = new SKPoint(page.PricingDivider1.Left, page.PricingDivider1.Top);
                var pointB = new SKPoint(page.PricingDivider1.Left + page.PricingDivider1.Width, page.PricingDivider1.Top);

                canvas.DrawLine(pointA, pointB, pricingDivider1);
            }

            using (SKPaint pricingDivider2 = new SKPaint())
            {
                SKColor.TryParse(page.PricingDivider2.Color, out SKColor color);

                pricingDivider2.Color = color;

                var pointA = new SKPoint(page.PricingDivider2.Left, page.PricingDivider2.Top);
                var pointB = new SKPoint(page.PricingDivider2.Left + page.PricingDivider2.Width, page.PricingDivider2.Top);

                canvas.DrawLine(pointA, pointB, pricingDivider2);
            }

            using (SKPaint paymentSummaryTitle = new SKPaint())
            {
                SKColor.TryParse(page.PaymentSummaryTitle.Color, out SKColor color);

                paymentSummaryTitle.Color = color;

                paymentSummaryTitle.TextSize = page.PaymentSummaryTitle.TextSize;

                paymentSummaryTitle.FakeBoldText = true;

                canvas.DrawText(page.PaymentSummaryTitle.Title, page.PaymentSummaryTitle.Left, page.PaymentSummaryTitle.Top, paymentSummaryTitle);
            }

            foreach (var paymentTransaction in page.PaymentTransactions)
            {
                using (SKPaint paymentTransactionTitle = new SKPaint())
                {
                    SKColor.TryParse(paymentTransaction.Title.Color, out SKColor color);

                    paymentTransactionTitle.Color = color;

                    paymentTransactionTitle.TextSize = paymentTransaction.Title.TextSize;

                    canvas.DrawText(paymentTransaction.Title.Title, paymentTransaction.Title.Left, paymentTransaction.Title.Top, paymentTransactionTitle);
                }

                using (SKPaint paymentTransactionValue = new SKPaint())
                {
                    SKColor.TryParse(paymentTransaction.Value.Color, out SKColor color);

                    paymentTransactionValue.Color = color;

                    paymentTransactionValue.TextSize = paymentTransaction.Value.TextSize;

                    canvas.DrawText(paymentTransaction.Value.Title, paymentTransaction.Value.Left, paymentTransaction.Value.Top, paymentTransactionValue);
                }
            }

            using (SKPaint paymentDivider = new SKPaint())
            {
                SKColor.TryParse(page.PaymentDivider.Color, out SKColor color);

                paymentDivider.Color = color;

                var pointA = new SKPoint(page.PaymentDivider.Left, page.PaymentDivider.Top);
                var pointB = new SKPoint(page.PaymentDivider.Left + page.PaymentDivider.Width, page.PaymentDivider.Top);

                canvas.DrawLine(pointA, pointB, paymentDivider);
            }

            using (SKPaint changeTitle = new SKPaint())
            {
                SKColor.TryParse(page.ChangeTitle.Color, out SKColor color);

                changeTitle.Color = color;

                changeTitle.TextSize = page.ChangeTitle.TextSize;

                canvas.DrawText(page.ChangeTitle.Title, page.ChangeTitle.Left, page.ChangeTitle.Top, changeTitle);
            }

            using (SKPaint changeValue = new SKPaint())
            {
                SKColor.TryParse(page.ChangeValue.Color, out SKColor color);

                changeValue.Color = color;

                changeValue.TextSize = page.ChangeValue.TextSize;

                canvas.DrawText(page.ChangeValue.Title, page.ChangeValue.Left, page.ChangeValue.Top, changeValue);
            }

            using (SKPaint changeDivider = new SKPaint())
            {
                SKColor.TryParse(page.ChangeDivider.Color, out SKColor color);

                changeDivider.Color = color;

                var pointA = new SKPoint(page.ChangeDivider.Left, page.ChangeDivider.Top);
                var pointB = new SKPoint(page.ChangeDivider.Left + page.ChangeDivider.Width, page.ChangeDivider.Top);

                canvas.DrawLine(pointA, pointB, changeDivider);
            }

            using (SKPaint locationName = new SKPaint())
            {
                SKColor.TryParse(page.LocationName.Color, out SKColor color);

                locationName.Color = color;

                locationName.TextSize = page.LocationName.TextSize;

                canvas.DrawText(page.LocationName.Title, page.LocationName.Left, page.LocationName.Top, locationName);
            }

            using (SKPaint locationPhoneNumber = new SKPaint())
            {
                SKColor.TryParse(page.LocationPhoneNumber.Color, out SKColor color);

                locationPhoneNumber.Color = color;

                locationPhoneNumber.TextSize = page.LocationPhoneNumber.TextSize;

                canvas.DrawText(page.LocationPhoneNumber.Title, page.LocationPhoneNumber.Left, page.LocationPhoneNumber.Top, locationPhoneNumber);
            }

            using (SKPaint thanksTitle = new SKPaint())
            {
                SKColor.TryParse(page.ThanksTitle.Color, out SKColor color);

                thanksTitle.Color = color;

                thanksTitle.TextSize = page.ThanksTitle.TextSize;

                canvas.DrawText(page.ThanksTitle.Title, page.ThanksTitle.Left, page.ThanksTitle.Top, thanksTitle);
            }

            var barcodeWriter = new ZXing.SkiaSharp.BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_128,

                Options = new ZXing.Common.EncodingOptions
                {
                    Height = page.Barcode.HeightInt,
                    Width = page.Barcode.WidthInt,
                },
            };

            SKBitmap bitmap = barcodeWriter.Write(page.Barcode.Title);

            canvas.DrawBitmap(bitmap, new SKPoint { X = page.Barcode.Left, Y = page.Barcode.Top });
        }
    }
}
