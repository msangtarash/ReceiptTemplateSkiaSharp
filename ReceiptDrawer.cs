using ReceiptTemplateSkiaSharp.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Topten.RichTextKit;
using ZXing;

namespace ReceiptTemplateSkiaSharp
{
    public class ReceiptDrawer
    {
        private ReceiptPage _receiptPage;

        public ReceiptDrawer(ReceiptPage receiptPage)
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

            {
                RichString storeName = new RichString()
                                            .Alignment(TextAlignment.Center)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.StoreName.TextSize)
                                            .FontWeight(700)
                                            .Add(page.StoreName.Title);

                SKColor.TryParse(page.StoreName.Color, out SKColor color);

                storeName.MaxWidth = page.StoreName.Width;
                storeName.MaxHeight = page.StoreName.Height;
                storeName.TextColor(color);
                storeName.Paint(canvas, new SKPoint(page.StoreName.Left, page.StoreName.Top));
            }

            DrowDashLine(canvas, page.StoreNameDivider.Color, page.StoreNameDivider.Left, page.StoreNameDivider.Top, page.StoreNameDivider.Width);

            {
                RichString dateTime = new RichString()
                                            .Alignment(TextAlignment.Left)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.Date.TextSize)
                                            .FontWeight(400)
                                            .Add(page.Date.Title);

                SKColor.TryParse(page.Date.Color, out SKColor color);

                dateTime.MaxWidth = page.Date.Width;
                dateTime.MaxHeight = page.Date.Height;
                dateTime.TextColor(color);
                dateTime.Paint(canvas, new SKPoint(page.Date.Left, page.Date.Top));
            }

            {
                RichString registerName = new RichString()
                                            .Alignment(TextAlignment.Left)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.RegisterName.TextSize)
                                            .FontWeight(400)
                                            .Add(page.RegisterName.Title);

                SKColor.TryParse(page.RegisterName.Color, out SKColor color);

                registerName.MaxWidth = page.RegisterName.Width;
                registerName.MaxHeight = page.RegisterName.Height;
                registerName.TextColor(color);
                registerName.Paint(canvas, new SKPoint(page.RegisterName.Left, page.RegisterName.Top));
            }

            {
                RichString staffName = new RichString()
                                            .Alignment(TextAlignment.Left)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.StaffName.TextSize)
                                            .FontWeight(400)
                                            .Add(page.StaffName.Title);

                SKColor.TryParse(page.StaffName.Color, out SKColor color);

                staffName.MaxWidth = page.StaffName.Width;
                staffName.MaxHeight = page.StaffName.Height;
                staffName.TextColor(color);
                staffName.Paint(canvas, new SKPoint(page.StaffName.Left, page.StaffName.Top));
            }

            DrowDashLine(canvas, page.HeaderDivider.Color, page.HeaderDivider.Left, page.HeaderDivider.Top, page.HeaderDivider.Width);

            {
                RichString customerTitle = new RichString()
                                            .Alignment(TextAlignment.Left)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.CustomerTitle.TextSize)
                                            .FontWeight(700)
                                            .Add(page.CustomerTitle.Title);

                SKColor.TryParse(page.CustomerTitle.Color, out SKColor color);

                customerTitle.MaxWidth = page.CustomerTitle.Width;
                customerTitle.MaxHeight = page.CustomerTitle.Height;
                customerTitle.TextColor(color);
                customerTitle.Paint(canvas, new SKPoint(page.CustomerTitle.Left, page.CustomerTitle.Top));
            }

            if (string.IsNullOrEmpty(page.CustomerAddress.Title) is false)
            {
                {
                    RichString customerAddress = new RichString()
                                                .Alignment(TextAlignment.Left)
                                                .FontFamily("Segoe UI")
                                                .FontSize(page.CustomerAddress.TextSize)
                                                .FontWeight(400)
                                                .Add(page.CustomerAddress.Title);

                    SKColor.TryParse(page.CustomerAddress.Color, out SKColor color);

                    customerAddress.MaxWidth = page.CustomerAddress.Width;
                    customerAddress.MaxHeight = page.CustomerAddress.Height;
                    customerAddress.TextColor(color);
                    customerAddress.Paint(canvas, new SKPoint(page.CustomerAddress.Left, page.CustomerAddress.Top));
                }
            }

            {
                RichString customerName = new RichString()
                                            .Alignment(TextAlignment.Left)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.CustomerName.TextSize)
                                            .FontWeight(400)
                                            .Add(page.CustomerName.Title);

                SKColor.TryParse(page.CustomerName.Color, out SKColor color);

                customerName.MaxWidth = page.CustomerName.Width;
                customerName.MaxHeight = page.CustomerName.Height;
                customerName.TextColor(color);
                customerName.Paint(canvas, new SKPoint(page.CustomerName.Left, page.CustomerName.Top));
            }

            if (string.IsNullOrEmpty(page.CustomerPhoneNumber.Title) is false)
            {
                {
                    RichString customerPhoneNumber = new RichString()
                                                .Alignment(TextAlignment.Left)
                                                .FontFamily("Segoe UI")
                                                .FontSize(page.CustomerPhoneNumber.TextSize)
                                                .FontWeight(400)
                                                .Add(page.CustomerPhoneNumber.Title);

                    SKColor.TryParse(page.CustomerPhoneNumber.Color, out SKColor color);

                    customerPhoneNumber.MaxWidth = page.CustomerPhoneNumber.Width;
                    customerPhoneNumber.MaxHeight = page.CustomerPhoneNumber.Height;
                    customerPhoneNumber.TextColor(color);
                    customerPhoneNumber.Paint(canvas, new SKPoint(page.CustomerPhoneNumber.Left, page.CustomerPhoneNumber.Top));
                }
            }

            DrowDashLine(canvas, page.CustomerDivider.Color, page.CustomerDivider.Left, page.CustomerDivider.Top, page.CustomerDivider.Width);

            {
                RichString orderDescriptionTitle = new RichString()
                                            .Alignment(TextAlignment.Left)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.OrderDescriptionTitle.TextSize)
                                            .FontWeight(700)
                                            .Add(page.OrderDescriptionTitle.Title);

                SKColor.TryParse(page.OrderDescriptionTitle.Color, out SKColor color);

                orderDescriptionTitle.MaxWidth = page.OrderDescriptionTitle.Width;
                orderDescriptionTitle.MaxHeight = page.OrderDescriptionTitle.Height;
                orderDescriptionTitle.TextColor(color);
                orderDescriptionTitle.Paint(canvas, new SKPoint(page.OrderDescriptionTitle.Left, page.OrderDescriptionTitle.Top));
            }

            {
                RichString orderQuantityTitle = new RichString()
                                            .Alignment(TextAlignment.Right)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.OrderQuantityTitle.TextSize)
                                            .FontWeight(700)
                                            .Add(page.OrderQuantityTitle.Title);

                SKColor.TryParse(page.OrderQuantityTitle.Color, out SKColor color);

                orderQuantityTitle.MaxWidth = page.OrderQuantityTitle.Width;
                orderQuantityTitle.MaxHeight = page.OrderQuantityTitle.Height;
                orderQuantityTitle.TextColor(color);
                orderQuantityTitle.Paint(canvas, new SKPoint(page.OrderQuantityTitle.Left, page.OrderQuantityTitle.Top));
            }

            {
                RichString orderTotalTitle = new RichString()
                                            .Alignment(TextAlignment.Right)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.OrderTotalTitle.TextSize)
                                            .FontWeight(700)
                                            .Add(page.OrderTotalTitle.Title);

                SKColor.TryParse(page.OrderTotalTitle.Color, out SKColor color);

                orderTotalTitle.MaxWidth = page.OrderTotalTitle.Width;
                orderTotalTitle.MaxHeight = page.OrderTotalTitle.Height;
                orderTotalTitle.TextColor(color);
                orderTotalTitle.Paint(canvas, new SKPoint(page.OrderTotalTitle.Left, page.OrderTotalTitle.Top));
            }


            foreach (var orderItem in page.OrderItems)
            {
                {
                    RichString orderItemName = new RichString()
                                                .Alignment(TextAlignment.Left)
                                                .FontFamily("Segoe UI")
                                                .FontSize(orderItem.Name.TextSize)
                                                .FontWeight(400)
                                                .Add(orderItem.Name.Title);

                    SKColor.TryParse(orderItem.Name.Color, out SKColor color);

                    orderItemName.MaxWidth = orderItem.Name.Width;
                    orderItemName.MaxHeight = orderItem.Name.Height;
                    orderItemName.TextColor(color);
                    orderItemName.Paint(canvas, new SKPoint(orderItem.Name.Left, orderItem.Name.Top));
                }

                {
                    RichString orderItemQuantity = new RichString()
                                                .Alignment(TextAlignment.Right)
                                                .FontFamily("Segoe UI")
                                                .FontSize(orderItem.Quantity.TextSize)
                                                .FontWeight(500)
                                                .Add(orderItem.Quantity.Title);

                    SKColor.TryParse(orderItem.Quantity.Color, out SKColor color);

                    orderItemQuantity.MaxWidth = orderItem.Quantity.Width;
                    orderItemQuantity.MaxHeight = orderItem.Quantity.Height;
                    orderItemQuantity.TextColor(color);
                    orderItemQuantity.Paint(canvas, new SKPoint(orderItem.Quantity.Left, orderItem.Quantity.Top));
                }

                {
                    RichString totalPrice = new RichString()
                                                .Alignment(TextAlignment.Right)
                                                .FontFamily("Segoe UI")
                                                .FontSize(orderItem.TotalPrice.TextSize)
                                                .FontWeight(500)
                                                .Add(orderItem.TotalPrice.Title);

                    SKColor.TryParse(orderItem.TotalPrice.Color, out SKColor color);

                    totalPrice.MaxWidth = orderItem.TotalPrice.Width;
                    totalPrice.MaxHeight = orderItem.TotalPrice.Height;
                    totalPrice.TextColor(color);
                    totalPrice.Paint(canvas, new SKPoint(orderItem.TotalPrice.Left, orderItem.TotalPrice.Top));
                }


                if (string.IsNullOrEmpty(orderItem.DiscountValue.Title) is false)
                {

                    {
                        RichString discountTitle = new RichString()
                                                    .Alignment(TextAlignment.Left)
                                                    .FontFamily("Segoe UI")
                                                    .FontSize(orderItem.DiscountTitle.TextSize)
                                                    .FontWeight(500)
                                                    .Add(orderItem.DiscountTitle.Title);

                        SKColor.TryParse(orderItem.DiscountTitle.Color, out SKColor color);

                        discountTitle.MaxWidth = orderItem.DiscountTitle.Width;
                        discountTitle.MaxHeight = orderItem.DiscountTitle.Height;
                        discountTitle.TextColor(color);
                        discountTitle.Paint(canvas, new SKPoint(orderItem.DiscountTitle.Left, orderItem.DiscountTitle.Top));
                    }

                    {
                        RichString discountValue = new RichString()
                                                    .Alignment(TextAlignment.Left)
                                                    .FontFamily("Segoe UI")
                                                    .FontSize(orderItem.DiscountValue.TextSize)
                                                    .FontWeight(400)
                                                    .Add(orderItem.DiscountValue.Title);

                        SKColor.TryParse(orderItem.DiscountValue.Color, out SKColor color);

                        discountValue.MaxWidth = orderItem.DiscountValue.Width;
                        discountValue.MaxHeight = orderItem.DiscountValue.Height;
                        discountValue.TextColor(color);
                        discountValue.Paint(canvas, new SKPoint(orderItem.DiscountValue.Left, orderItem.DiscountValue.Top));
                    }

                    {
                        RichString mainPrice = new RichString()
                                                    .Alignment(TextAlignment.Right)
                                                    .FontFamily("Segoe UI")
                                                    .FontSize(orderItem.MainPrice.TextSize)
                                                    .FontWeight(400)
                                                    .StrikeThrough(StrikeThroughStyle.Solid)
                                                    .Add(orderItem.MainPrice.Title);

                        SKColor.TryParse(orderItem.MainPrice.Color, out SKColor color);

                        mainPrice.MaxWidth = orderItem.MainPrice.Width;
                        mainPrice.MaxHeight = orderItem.MainPrice.Height;
                        mainPrice.TextColor(color);
                        mainPrice.Paint(canvas, new SKPoint(orderItem.MainPrice.Left, orderItem.MainPrice.Top));
                    }
                }

                if (string.IsNullOrEmpty(orderItem.Values.Title) is false)
                {
                    {
                        RichString values = new RichString()
                                                    .Alignment(TextAlignment.Left)
                                                    .FontFamily("Segoe UI")
                                                    .FontSize(orderItem.Values.TextSize)
                                                    .FontWeight(400)
                                                    .Add(orderItem.Values.Title);

                        SKColor.TryParse(orderItem.Values.Color, out SKColor color);

                        values.MaxWidth = orderItem.Values.Width;
                        values.MaxHeight = orderItem.Values.Height;
                        values.TextColor(color);
                        values.Paint(canvas, new SKPoint(orderItem.Values.Left, orderItem.Values.Top));
                    }
                }

                if (string.IsNullOrEmpty(orderItem.NoteValue.Title) is false)
                {
                    {
                        RichString noteTitle = new RichString()
                                                    .Alignment(TextAlignment.Left)
                                                    .FontFamily("Segoe UI")
                                                    .FontSize(orderItem.NoteTitle.TextSize)
                                                    .FontWeight(700)
                                                    .Add(orderItem.NoteTitle.Title);

                        SKColor.TryParse(orderItem.NoteTitle.Color, out SKColor color);

                        noteTitle.MaxWidth = orderItem.NoteTitle.Width;
                        noteTitle.MaxHeight = orderItem.NoteTitle.Height;
                        noteTitle.TextColor(color);
                        noteTitle.Paint(canvas, new SKPoint(orderItem.NoteTitle.Left, orderItem.NoteTitle.Top));
                    }

                    {
                        RichString noteValue = new RichString()
                                                    .Alignment(TextAlignment.Left)
                                                    .FontFamily("Segoe UI")
                                                    .FontSize(orderItem.NoteValue.TextSize)
                                                    .FontWeight(400)
                                                    .Add(orderItem.NoteValue.Title);

                        SKColor.TryParse(orderItem.NoteValue.Color, out SKColor color);

                        noteValue.MaxWidth = orderItem.NoteValue.Width;
                        noteValue.MaxHeight = orderItem.NoteValue.Height;
                        noteValue.TextColor(color);
                        noteValue.Paint(canvas, new SKPoint(orderItem.NoteValue.Left, orderItem.NoteValue.Top));
                    }
                }
            }

            if (string.IsNullOrEmpty(page.OrderNote.Title) is false)
            {
                DrowLine(canvas, page.OrderDivider.Color, page.OrderDivider.Left, page.OrderDivider.Top, page.OrderDivider.Width);

                {
                    RichString orderNote = new RichString()
                                                .Alignment(TextAlignment.Left)
                                                .FontFamily("Segoe UI")
                                                .FontSize(page.OrderNote.TextSize)
                                                .FontWeight(400)
                                                .Add(page.OrderNote.Title);

                    SKColor.TryParse(page.OrderNote.Color, out SKColor color);

                    orderNote.MaxWidth = page.OrderNote.Width;
                    orderNote.MaxHeight = page.OrderNote.Height;
                    orderNote.TextColor(color);
                    orderNote.Paint(canvas, new SKPoint(page.OrderNote.Left, page.OrderNote.Top));
                }

            }

            DrowDashLine(canvas, page.NoteDivider1.Color, page.NoteDivider1.Left, page.NoteDivider1.Top, page.NoteDivider1.Width);
            DrowDashLine(canvas, page.NoteDivider2.Color, page.NoteDivider2.Left, page.NoteDivider2.Top, page.NoteDivider2.Width);

            {
                RichString subtotalTitle = new RichString()
                                            .Alignment(TextAlignment.Left)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.SubtotalTitle.TextSize)
                                            .FontWeight(400)
                                            .Add(page.SubtotalTitle.Title);

                SKColor.TryParse(page.SubtotalTitle.Color, out SKColor color);

                subtotalTitle.MaxWidth = page.SubtotalTitle.Width;
                subtotalTitle.MaxHeight = page.SubtotalTitle.Height;
                subtotalTitle.TextColor(color);
                subtotalTitle.Paint(canvas, new SKPoint(page.SubtotalTitle.Left, page.SubtotalTitle.Top));
            }

            {
                RichString subtotalValue = new RichString()
                                            .Alignment(TextAlignment.Right)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.SubtotalValue.TextSize)
                                            .FontWeight(400)
                                            .Add(page.SubtotalValue.Title);

                SKColor.TryParse(page.SubtotalValue.Color, out SKColor color);

                subtotalValue.MaxWidth = page.SubtotalValue.Width;
                subtotalValue.MaxHeight = page.SubtotalValue.Height;
                subtotalValue.TextColor(color);
                subtotalValue.Paint(canvas, new SKPoint(page.SubtotalValue.Left, page.SubtotalValue.Top));
            }

            {
                RichString taxTitle = new RichString()
                                            .Alignment(TextAlignment.Left)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.TaxTitle.TextSize)
                                            .FontWeight(400)
                                            .Add(page.TaxTitle.Title);

                SKColor.TryParse(page.TaxTitle.Color, out SKColor color);

                taxTitle.MaxWidth = page.TaxTitle.Width;
                taxTitle.MaxHeight = page.TaxTitle.Height;
                taxTitle.TextColor(color);
                taxTitle.Paint(canvas, new SKPoint(page.TaxTitle.Left, page.TaxTitle.Top));
            }

            {
                RichString taxValue = new RichString()
                                            .Alignment(TextAlignment.Right)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.TaxValue.TextSize)
                                            .FontWeight(400)
                                            .Add(page.TaxValue.Title);

                SKColor.TryParse(page.TaxValue.Color, out SKColor color);

                taxValue.MaxWidth = page.TaxValue.Width;
                taxValue.MaxHeight = page.TaxValue.Height;
                taxValue.TextColor(color);
                taxValue.Paint(canvas, new SKPoint(page.TaxValue.Left, page.TaxValue.Top));
            }

            {
                RichString discountTitle = new RichString()
                                            .Alignment(TextAlignment.Left)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.DiscountTitle.TextSize)
                                            .FontWeight(400)
                                            .Add(page.DiscountTitle.Title);

                SKColor.TryParse(page.DiscountTitle.Color, out SKColor color);

                discountTitle.MaxWidth = page.DiscountTitle.Width;
                discountTitle.MaxHeight = page.DiscountTitle.Height;
                discountTitle.TextColor(color);
                discountTitle.Paint(canvas, new SKPoint(page.DiscountTitle.Left, page.DiscountTitle.Top));
            }

            {
                RichString discountValue = new RichString()
                                            .Alignment(TextAlignment.Right)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.DiscountValue.TextSize)
                                            .FontWeight(400)
                                            .Add(page.DiscountValue.Title);

                SKColor.TryParse(page.DiscountValue.Color, out SKColor color);

                discountValue.MaxWidth = page.DiscountValue.Width;
                discountValue.MaxHeight = page.DiscountValue.Height;
                discountValue.TextColor(color);
                discountValue.Paint(canvas, new SKPoint(page.DiscountValue.Left, page.DiscountValue.Top));
            }

            {
                RichString saleTotalTitle = new RichString()
                                            .Alignment(TextAlignment.Left)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.SaleTotalTitle.TextSize)
                                            .FontWeight(400)
                                            .Add(page.SaleTotalTitle.Title);

                SKColor.TryParse(page.SaleTotalTitle.Color, out SKColor color);

                saleTotalTitle.MaxWidth = page.SaleTotalTitle.Width;
                saleTotalTitle.MaxHeight = page.SaleTotalTitle.Height;
                saleTotalTitle.TextColor(color);
                saleTotalTitle.Paint(canvas, new SKPoint(page.SaleTotalTitle.Left, page.SaleTotalTitle.Top));
            }

            {
                RichString saleValue = new RichString()
                                            .Alignment(TextAlignment.Right)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.SaleValue.TextSize)
                                            .FontWeight(400)
                                            .Add(page.SaleValue.Title);

                SKColor.TryParse(page.SaleValue.Color, out SKColor color);

                saleValue.MaxWidth = page.SaleValue.Width;
                saleValue.MaxHeight = page.SaleValue.Height;
                saleValue.TextColor(color);
                saleValue.Paint(canvas, new SKPoint(page.SaleValue.Left, page.SaleValue.Top));
            }

            DrowDashLine(canvas, page.PricingDivider1.Color, page.PricingDivider1.Left, page.PricingDivider1.Top, page.PricingDivider1.Width);
            DrowDashLine(canvas, page.PricingDivider2.Color, page.PricingDivider2.Left, page.PricingDivider2.Top, page.PricingDivider2.Width);

            {
                RichString paymentSummaryTitle = new RichString()
                                            .Alignment(TextAlignment.Left)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.PaymentSummaryTitle.TextSize)
                                            .FontWeight(700)
                                            .Add(page.PaymentSummaryTitle.Title);

                SKColor.TryParse(page.PaymentSummaryTitle.Color, out SKColor color);

                paymentSummaryTitle.MaxWidth = page.PaymentSummaryTitle.Width;
                paymentSummaryTitle.MaxHeight = page.PaymentSummaryTitle.Height;
                paymentSummaryTitle.TextColor(color);
                paymentSummaryTitle.Paint(canvas, new SKPoint(page.PaymentSummaryTitle.Left, page.PaymentSummaryTitle.Top));
            }

            foreach (var paymentTransaction in page.PaymentTransactions)
            {
                {
                    RichString paymentTransactionTitle = new RichString()
                                                .Alignment(TextAlignment.Left)
                                                .FontFamily("Segoe UI")
                                                .FontSize(paymentTransaction.Title.TextSize)
                                                .FontWeight(400)
                                                .Add(paymentTransaction.Title.Title);

                    SKColor.TryParse(paymentTransaction.Title.Color, out SKColor color);

                    paymentTransactionTitle.MaxWidth = paymentTransaction.Title.Width;
                    paymentTransactionTitle.MaxHeight = paymentTransaction.Title.Height;
                    paymentTransactionTitle.TextColor(color);
                    paymentTransactionTitle.Paint(canvas, new SKPoint(paymentTransaction.Title.Left, paymentTransaction.Title.Top));
                }

                {
                    RichString paymentTransactionValue = new RichString()
                                                .Alignment(TextAlignment.Right)
                                                .FontFamily("Segoe UI")
                                                .FontSize(paymentTransaction.Value.TextSize)
                                                .FontWeight(400)
                                                .Add(paymentTransaction.Value.Title);

                    SKColor.TryParse(paymentTransaction.Title.Color, out SKColor color);

                    paymentTransactionValue.MaxWidth = paymentTransaction.Value.Width;
                    paymentTransactionValue.MaxHeight = paymentTransaction.Value.Height;
                    paymentTransactionValue.TextColor(color);
                    paymentTransactionValue.Paint(canvas, new SKPoint(paymentTransaction.Value.Left, paymentTransaction.Value.Top));
                }
            }

            DrowLine(canvas, page.PaymentDivider.Color, page.PaymentDivider.Left, page.PaymentDivider.Top, page.PaymentDivider.Width);

            {
                RichString changeTitle = new RichString()
                                            .Alignment(TextAlignment.Left)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.ChangeTitle.TextSize)
                                            .FontWeight(400)
                                            .Add(page.ChangeTitle.Title);

                SKColor.TryParse(page.ChangeTitle.Color, out SKColor color);

                changeTitle.MaxWidth = page.ChangeTitle.Width;
                changeTitle.MaxHeight = page.ChangeTitle.Height;
                changeTitle.TextColor(color);
                changeTitle.Paint(canvas, new SKPoint(page.ChangeTitle.Left, page.ChangeTitle.Top));
            }

            {
                RichString changeValue = new RichString()
                                            .Alignment(TextAlignment.Right)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.ChangeValue.TextSize)
                                            .FontWeight(400)
                                            .Add(page.ChangeValue.Title);

                SKColor.TryParse(page.ChangeValue.Color, out SKColor color);

                changeValue.MaxWidth = page.ChangeValue.Width;
                changeValue.MaxHeight = page.ChangeValue.Height;
                changeValue.TextColor(color);
                changeValue.Paint(canvas, new SKPoint(page.ChangeValue.Left, page.ChangeValue.Top));
            }

            DrowDashLine(canvas, page.ChangeDivider.Color, page.ChangeDivider.Left, page.ChangeDivider.Top, page.ChangeDivider.Width);

            {
                RichString locationName = new RichString()
                                            .Alignment(TextAlignment.Center)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.LocationName.TextSize)
                                            .FontWeight(400)
                                            .Add(page.LocationName.Title);

                SKColor.TryParse(page.LocationName.Color, out SKColor color);

                locationName.MaxWidth = page.LocationName.Width;
                locationName.MaxHeight = page.LocationName.Height;
                locationName.TextColor(color);
                locationName.Paint(canvas, new SKPoint(page.LocationName.Left, page.LocationName.Top));
            }

            {
                RichString locationPhoneNumber = new RichString()
                                            .Alignment(TextAlignment.Center)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.LocationPhoneNumber.TextSize)
                                            .FontWeight(400)
                                            .Add(page.LocationPhoneNumber.Title);

                SKColor.TryParse(page.LocationPhoneNumber.Color, out SKColor color);

                locationPhoneNumber.MaxWidth = page.LocationPhoneNumber.Width;
                locationPhoneNumber.MaxHeight = page.LocationPhoneNumber.Height;
                locationPhoneNumber.TextColor(color);
                locationPhoneNumber.Paint(canvas, new SKPoint(page.LocationPhoneNumber.Left, page.LocationPhoneNumber.Top));
            }

            {
                RichString thanksTitle = new RichString()
                                            .Alignment(TextAlignment.Center)
                                            .FontFamily("Segoe UI")
                                            .FontSize(page.ThanksTitle.TextSize)
                                            .FontWeight(400)
                                            .Add(page.ThanksTitle.Title);

                SKColor.TryParse(page.ThanksTitle.Color, out SKColor color);

                thanksTitle.MaxWidth = page.ThanksTitle.Width;
                thanksTitle.MaxHeight = page.ThanksTitle.Height;
                thanksTitle.TextColor(color);
                thanksTitle.Paint(canvas, new SKPoint(page.ThanksTitle.Left, page.ThanksTitle.Top));
            }


            {
                var barcodeWriter = new ZXing.SkiaSharp.BarcodeWriter();

                barcodeWriter.Format = BarcodeFormat.CODE_128;
                barcodeWriter.Options = new ZXing.Common.EncodingOptions
                {
                    Height = page.Barcode.HeightInt,
                    Width = page.Barcode.WidthInt,
                };


                SKBitmap bitmap = barcodeWriter.Write(page.Barcode.Title);

                canvas.DrawBitmap(bitmap, new SKPoint { X = page.Barcode.Left, Y = page.Barcode.Top });
            }
        }

        private void DrowDashLine(SKCanvas canvas, string colorLine, float left, float top, float width)
        {

            using (SKPaint dashLine = new SKPaint())
            {
                SKColor.TryParse(colorLine, out SKColor color);

                dashLine.Color = color;
                dashLine.Style = SKPaintStyle.Stroke;
                dashLine.IsAntialias = true;
                dashLine.StrokeWidth = 0.5f;
                dashLine.PathEffect = SKPathEffect.CreateDash(new[] { 3f, 2f }, 20);

                var pointA = new SKPoint(left, top);
                var pointB = new SKPoint(left + width, top);

                canvas.DrawLine(pointA, pointB, dashLine);
            }
        }

        private void DrowLine(SKCanvas canvas, string colorLine, float left, float top, float width)
        {
            using (SKPaint line = new SKPaint())
            {
                SKColor.TryParse(colorLine, out SKColor color);

                line.Color = color;

                var pointA = new SKPoint(left, top);
                var pointB = new SKPoint(left + width, top);

                canvas.DrawLine(pointA, pointB, line);
            }
        }
    }
}
