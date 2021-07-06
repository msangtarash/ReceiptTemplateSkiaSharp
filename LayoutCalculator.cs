using ReceiptTemplateSkiaSharp.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Topten.RichTextKit;

namespace ReceiptTemplateSkiaSharp
{
    public class LayoutCalculator
    {
        readonly LayoutTemplate _layoutTemplate;
        public LayoutCalculator(LayoutTemplate layoutTemplate)
        {
            _layoutTemplate = layoutTemplate;
        }

        public ReceiptPage Calculate(ReceiptPage receipt)
        {
            float currentTopSpace = 0;

            receipt.Width = _layoutTemplate.PageWidthInt;

            receipt.StoreName.Color = _layoutTemplate.StoreName.Color;
            receipt.StoreName.TextSize = _layoutTemplate.StoreName.TextSize;
            receipt.StoreName.Width = _layoutTemplate.StoreName.Width;
            receipt.StoreName.Height = CalculateTextHeight(receipt.StoreName.TextSize, receipt.StoreName.Title, receipt.StoreName.Width);
            receipt.StoreName.Top = currentTopSpace + _layoutTemplate.StoreName.TopPadding;
            receipt.StoreName.Left = _layoutTemplate.StoreName.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.StoreName.Top + receipt.StoreName.Height;

            receipt.StoreNameDivider.Color = _layoutTemplate.StoreNameDivider.Color;
            receipt.StoreNameDivider.Top = currentTopSpace + _layoutTemplate.StoreNameDivider.TopPadding;
            receipt.StoreNameDivider.Left = _layoutTemplate.StoreNameDivider.Left + _layoutTemplate.LeftPadding;
            receipt.StoreNameDivider.Width = _layoutTemplate.StoreNameDivider.Width;
            currentTopSpace = receipt.StoreNameDivider.Top;

            receipt.Date.Color = _layoutTemplate.Date.Color;
            receipt.Date.TextSize = _layoutTemplate.Date.TextSize;
            receipt.Date.Width = _layoutTemplate.Date.Width;
            receipt.Date.Height = CalculateTextHeight(receipt.Date.TextSize, receipt.Date.Title, receipt.Date.Width);
            receipt.Date.Top = currentTopSpace + _layoutTemplate.Date.TopPadding;
            receipt.Date.Left = _layoutTemplate.Date.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.Date.Top + receipt.Date.Height;

            receipt.RegisterName.Color = _layoutTemplate.RegisterName.Color;
            receipt.RegisterName.TextSize = _layoutTemplate.RegisterName.TextSize;
            receipt.RegisterName.Width = _layoutTemplate.RegisterName.Width;
            receipt.RegisterName.Height = CalculateTextHeight(receipt.RegisterName.TextSize, receipt.RegisterName.Title, receipt.RegisterName.Width);
            receipt.RegisterName.Top = currentTopSpace + _layoutTemplate.RegisterName.TopPadding;
            receipt.RegisterName.Left = _layoutTemplate.RegisterName.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.RegisterName.Top + receipt.RegisterName.Height;

            receipt.StaffName.Color = _layoutTemplate.StaffName.Color;
            receipt.StaffName.TextSize = _layoutTemplate.StaffName.TextSize;
            receipt.StaffName.Width = _layoutTemplate.StaffName.Width;
            receipt.StaffName.Height = CalculateTextHeight(receipt.StaffName.TextSize, receipt.StaffName.Title, receipt.StaffName.Width);
            receipt.StaffName.Top = currentTopSpace + _layoutTemplate.StaffName.TopPadding;
            receipt.StaffName.Left = _layoutTemplate.StaffName.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.StaffName.Top + receipt.StaffName.Height;


            receipt.HeaderDivider.Color = _layoutTemplate.HeaderDivider.Color;
            receipt.HeaderDivider.Top = currentTopSpace + _layoutTemplate.HeaderDivider.TopPadding;
            receipt.HeaderDivider.Left = _layoutTemplate.HeaderDivider.Left + _layoutTemplate.LeftPadding;
            receipt.HeaderDivider.Width = _layoutTemplate.HeaderDivider.Width;
            currentTopSpace = receipt.HeaderDivider.Top;

            receipt.CustomerTitle.Color = _layoutTemplate.CustomerTitle.Color;
            receipt.CustomerTitle.TextSize = _layoutTemplate.CustomerTitle.TextSize;
            receipt.CustomerTitle.Width = _layoutTemplate.CustomerTitle.Width;
            receipt.CustomerTitle.Height = CalculateTextHeight(receipt.CustomerTitle.TextSize, receipt.CustomerTitle.Title, receipt.CustomerTitle.Width);
            receipt.CustomerTitle.Top = currentTopSpace + _layoutTemplate.CustomerTitle.TopPadding;
            receipt.CustomerTitle.Left = _layoutTemplate.CustomerTitle.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.CustomerTitle.Top + receipt.CustomerTitle.Height;

            if (string.IsNullOrEmpty(receipt.CustomerAddress.Title) is false)
            {
                receipt.CustomerAddress.Color = _layoutTemplate.CustomerAddress.Color;
                receipt.CustomerAddress.TextSize = _layoutTemplate.CustomerAddress.TextSize;
                receipt.CustomerAddress.Width = _layoutTemplate.CustomerAddress.Width;
                receipt.CustomerAddress.Height = CalculateTextHeight(receipt.CustomerAddress.TextSize, receipt.CustomerAddress.Title, receipt.CustomerAddress.Width, 2);
                receipt.CustomerAddress.Top = currentTopSpace + _layoutTemplate.CustomerAddress.TopPadding;
                receipt.CustomerAddress.Left = _layoutTemplate.CustomerAddress.Left + _layoutTemplate.LeftPadding;
                currentTopSpace = receipt.CustomerAddress.Top + receipt.CustomerAddress.Height;
            }

            receipt.CustomerName.Color = _layoutTemplate.CustomerName.Color;
            receipt.CustomerName.TextSize = _layoutTemplate.CustomerName.TextSize;
            receipt.CustomerName.Width = _layoutTemplate.CustomerName.Width;
            receipt.CustomerName.Height = CalculateTextHeight(receipt.CustomerName.TextSize, receipt.CustomerName.Title, receipt.CustomerName.Width);
            receipt.CustomerName.Top = currentTopSpace + _layoutTemplate.CustomerName.TopPadding;
            receipt.CustomerName.Left = _layoutTemplate.CustomerName.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.CustomerName.Top + receipt.CustomerName.Height;

            if (string.IsNullOrEmpty(receipt.CustomerPhoneNumber.Title) is false)
            {
                receipt.CustomerPhoneNumber.Color = _layoutTemplate.CustomerPhoneNumber.Color;
                receipt.CustomerPhoneNumber.TextSize = _layoutTemplate.CustomerPhoneNumber.TextSize;
                receipt.CustomerPhoneNumber.Width = _layoutTemplate.CustomerPhoneNumber.Width;
                receipt.CustomerPhoneNumber.Height = CalculateTextHeight(receipt.CustomerPhoneNumber.TextSize, receipt.CustomerPhoneNumber.Title, receipt.CustomerPhoneNumber.Width);
                receipt.CustomerPhoneNumber.Top = currentTopSpace + _layoutTemplate.CustomerPhoneNumber.TopPadding;
                receipt.CustomerPhoneNumber.Left = _layoutTemplate.CustomerPhoneNumber.Left + _layoutTemplate.LeftPadding;
                currentTopSpace = receipt.CustomerPhoneNumber.Top + receipt.CustomerPhoneNumber.Height;
            }

            receipt.CustomerDivider.Color = _layoutTemplate.CustomerDivider.Color;
            receipt.CustomerDivider.Top = currentTopSpace + _layoutTemplate.CustomerDivider.TopPadding;
            receipt.CustomerDivider.Left = _layoutTemplate.CustomerDivider.Left + _layoutTemplate.LeftPadding;
            receipt.CustomerDivider.Width = _layoutTemplate.CustomerDivider.Width;
            currentTopSpace = receipt.CustomerDivider.Top;

            receipt.OrderDescriptionTitle.Color = _layoutTemplate.OrderDescriptionTitle.Color;
            receipt.OrderDescriptionTitle.TextSize = _layoutTemplate.OrderDescriptionTitle.TextSize;
            receipt.OrderDescriptionTitle.Width = _layoutTemplate.OrderDescriptionTitle.Width;
            receipt.OrderDescriptionTitle.Height = CalculateTextHeight(receipt.OrderDescriptionTitle.TextSize, receipt.OrderDescriptionTitle.Title, receipt.OrderDescriptionTitle.Width);
            receipt.OrderDescriptionTitle.Top = currentTopSpace + _layoutTemplate.OrderDescriptionTitle.TopPadding;
            receipt.OrderDescriptionTitle.Left = _layoutTemplate.OrderDescriptionTitle.Left + _layoutTemplate.LeftPadding;

            receipt.OrderQuantityTitle.Color = _layoutTemplate.OrderQuantityTitle.Color;
            receipt.OrderQuantityTitle.TextSize = _layoutTemplate.OrderQuantityTitle.TextSize;
            receipt.OrderQuantityTitle.Width = _layoutTemplate.OrderQuantityTitle.Width;
            receipt.OrderQuantityTitle.Height = CalculateTextHeight(receipt.OrderQuantityTitle.TextSize, receipt.OrderQuantityTitle.Title, receipt.OrderQuantityTitle.Width);
            receipt.OrderQuantityTitle.Top = currentTopSpace + _layoutTemplate.OrderQuantityTitle.TopPadding;
            receipt.OrderQuantityTitle.Left = _layoutTemplate.OrderQuantityTitle.Left + _layoutTemplate.LeftPadding;

            receipt.OrderTotalTitle.Color = _layoutTemplate.OrderTotalTitle.Color;
            receipt.OrderTotalTitle.TextSize = _layoutTemplate.OrderTotalTitle.TextSize;
            receipt.OrderTotalTitle.Width = _layoutTemplate.OrderTotalTitle.Width;
            receipt.OrderTotalTitle.Height = CalculateTextHeight(receipt.OrderTotalTitle.TextSize, receipt.OrderTotalTitle.Title, receipt.OrderTotalTitle.Width);
            receipt.OrderTotalTitle.Top = currentTopSpace + _layoutTemplate.OrderTotalTitle.TopPadding;
            receipt.OrderTotalTitle.Left = _layoutTemplate.OrderTotalTitle.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.OrderTotalTitle.Top + receipt.OrderTotalTitle.Height;

            foreach (var orderItem in receipt.OrderItems)
            {
                orderItem.Name.Color = _layoutTemplate.OrderItemName.Color;
                orderItem.Name.TextSize = _layoutTemplate.OrderItemName.TextSize;
                orderItem.Name.Width = _layoutTemplate.OrderItemName.Width;
                orderItem.Name.Height = CalculateTextHeight(orderItem.Name.TextSize, orderItem.Name.Title, orderItem.Name.Width);
                orderItem.Name.Top = currentTopSpace + _layoutTemplate.OrderItemName.TopPadding;
                orderItem.Name.Left = _layoutTemplate.OrderItemName.Left + _layoutTemplate.LeftPadding;

                orderItem.Quantity.Color = _layoutTemplate.OrderItemQuantity.Color;
                orderItem.Quantity.TextSize = _layoutTemplate.OrderItemQuantity.TextSize;
                orderItem.Quantity.Width = _layoutTemplate.OrderItemQuantity.Width;
                orderItem.Quantity.Height = CalculateTextHeight(orderItem.Quantity.TextSize, orderItem.Quantity.Title, orderItem.Quantity.Width);
                orderItem.Quantity.Top = currentTopSpace + _layoutTemplate.OrderItemQuantity.TopPadding;
                orderItem.Quantity.Left = _layoutTemplate.OrderItemQuantity.Left + _layoutTemplate.LeftPadding;

                orderItem.TotalPrice.Color = _layoutTemplate.OrderItemTotalPrice.Color;
                orderItem.TotalPrice.TextSize = _layoutTemplate.OrderItemTotalPrice.TextSize;
                orderItem.TotalPrice.Width = _layoutTemplate.OrderItemTotalPrice.Width;
                orderItem.TotalPrice.Height = CalculateTextHeight(orderItem.TotalPrice.TextSize, orderItem.TotalPrice.Title, orderItem.TotalPrice.Width);
                orderItem.TotalPrice.Top = currentTopSpace + _layoutTemplate.OrderItemTotalPrice.TopPadding;
                orderItem.TotalPrice.Left = _layoutTemplate.OrderItemTotalPrice.Left + _layoutTemplate.LeftPadding;
                currentTopSpace = orderItem.TotalPrice.Top + orderItem.TotalPrice.Height;

                if (string.IsNullOrEmpty(orderItem.DiscountValue.Title) is false)
                {
                    orderItem.DiscountTitle.Color = _layoutTemplate.OrderItemDiscountTitle.Color;
                    orderItem.DiscountTitle.TextSize = _layoutTemplate.OrderItemDiscountTitle.TextSize;
                    orderItem.DiscountTitle.Width = _layoutTemplate.OrderItemDiscountTitle.Width;
                    orderItem.DiscountTitle.Height = CalculateTextHeight(orderItem.DiscountTitle.TextSize, orderItem.DiscountTitle.Title, orderItem.DiscountTitle.Width);
                    orderItem.DiscountTitle.Top = currentTopSpace + _layoutTemplate.OrderItemDiscountTitle.TopPadding;
                    orderItem.DiscountTitle.Left = _layoutTemplate.OrderItemDiscountTitle.Left + _layoutTemplate.LeftPadding;


                    orderItem.DiscountValue.Color = _layoutTemplate.OrderItemDiscountValue.Color;
                    orderItem.DiscountValue.TextSize = _layoutTemplate.OrderItemDiscountValue.TextSize;
                    orderItem.DiscountValue.Width = _layoutTemplate.OrderItemDiscountValue.Width;
                    orderItem.DiscountValue.Height = CalculateTextHeight(orderItem.DiscountValue.TextSize, orderItem.DiscountValue.Title, orderItem.DiscountValue.Width);
                    orderItem.DiscountValue.Top = currentTopSpace + _layoutTemplate.OrderItemDiscountValue.TopPadding;
                    orderItem.DiscountValue.Left = _layoutTemplate.OrderItemDiscountValue.Left + _layoutTemplate.LeftPadding;

                    orderItem.MainPrice.Color = _layoutTemplate.OrderItemMainPrice.Color;
                    orderItem.MainPrice.TextSize = _layoutTemplate.OrderItemMainPrice.TextSize;
                    orderItem.MainPrice.Width = _layoutTemplate.OrderItemMainPrice.Width;
                    orderItem.MainPrice.Height = CalculateTextHeight(orderItem.MainPrice.TextSize, orderItem.MainPrice.Title, orderItem.MainPrice.Width);
                    orderItem.MainPrice.Top = currentTopSpace + _layoutTemplate.OrderItemMainPrice.TopPadding;
                    orderItem.MainPrice.Left = _layoutTemplate.OrderItemMainPrice.Left + _layoutTemplate.LeftPadding;
                    currentTopSpace = orderItem.MainPrice.Top + orderItem.MainPrice.Height;
                }

                if (string.IsNullOrEmpty(orderItem.Values.Title) is false)
                {
                    orderItem.Values.Color = _layoutTemplate.OrderItemValues.Color;
                    orderItem.Values.TextSize = _layoutTemplate.OrderItemValues.TextSize;
                    orderItem.Values.Width = _layoutTemplate.OrderItemValues.Width;
                    orderItem.Values.Height = CalculateTextHeight(orderItem.Values.TextSize, orderItem.Values.Title, orderItem.Values.Width);
                    orderItem.Values.Top = currentTopSpace + _layoutTemplate.OrderItemValues.TopPadding;
                    orderItem.Values.Left = _layoutTemplate.OrderItemValues.Left + _layoutTemplate.LeftPadding;
                    currentTopSpace = orderItem.Values.Top + orderItem.Values.Height;
                }

                if (string.IsNullOrEmpty(orderItem.NoteValue.Title) is false)
                {
                    orderItem.NoteTitle.Color = _layoutTemplate.OrderItemNoteTitle.Color;
                    orderItem.NoteTitle.TextSize = _layoutTemplate.OrderItemNoteTitle.TextSize;
                    orderItem.NoteTitle.Width = _layoutTemplate.OrderItemNoteTitle.Width;
                    orderItem.NoteTitle.Height = CalculateTextHeight(orderItem.NoteTitle.TextSize, orderItem.NoteTitle.Title, orderItem.NoteTitle.Width);
                    orderItem.NoteTitle.Top = currentTopSpace + _layoutTemplate.OrderItemNoteTitle.TopPadding;
                    orderItem.NoteTitle.Left = _layoutTemplate.OrderItemNoteTitle.Left + _layoutTemplate.LeftPadding;

                    orderItem.NoteValue.Color = _layoutTemplate.OrderItemNoteValue.Color;
                    orderItem.NoteValue.TextSize = _layoutTemplate.OrderItemNoteValue.TextSize;
                    orderItem.NoteValue.Width = _layoutTemplate.OrderItemNoteValue.Width;
                    orderItem.NoteValue.Height = CalculateTextHeight(orderItem.NoteValue.TextSize, orderItem.NoteValue.Title, orderItem.NoteValue.Width);
                    orderItem.NoteValue.Top = currentTopSpace + _layoutTemplate.OrderItemNoteValue.TopPadding;
                    orderItem.NoteValue.Left = _layoutTemplate.OrderItemNoteValue.Left + _layoutTemplate.LeftPadding;
                    currentTopSpace = orderItem.NoteValue.Top + orderItem.NoteValue.Height;
                }
            }

            if (string.IsNullOrEmpty(receipt.OrderNote.Title) is false)
            {
                receipt.OrderDivider.Color = _layoutTemplate.OrderDivider.Color;
                receipt.OrderDivider.Top = currentTopSpace + _layoutTemplate.OrderDivider.TopPadding;
                receipt.OrderDivider.Left = _layoutTemplate.OrderDivider.Left + _layoutTemplate.LeftPadding;
                receipt.OrderDivider.Width = _layoutTemplate.OrderDivider.Width;
                currentTopSpace = receipt.OrderDivider.Top;

                receipt.OrderNote.Color = _layoutTemplate.OrderNote.Color;
                receipt.OrderNote.TextSize = _layoutTemplate.OrderNote.TextSize;
                receipt.OrderNote.Width = _layoutTemplate.OrderNote.Width;
                receipt.OrderNote.Height = CalculateTextHeight(receipt.OrderNote.TextSize, receipt.OrderNote.Title, receipt.OrderNote.Width, 2);
                receipt.OrderNote.Top = currentTopSpace + _layoutTemplate.OrderNote.TopPadding;
                receipt.OrderNote.Left = _layoutTemplate.OrderNote.Left + _layoutTemplate.LeftPadding;
                currentTopSpace = receipt.OrderNote.Top + receipt.OrderNote.Height;
            }

            receipt.NoteDivider1.Color = _layoutTemplate.NoteDivider1.Color;
            receipt.NoteDivider1.Top = currentTopSpace + _layoutTemplate.NoteDivider1.TopPadding;
            receipt.NoteDivider1.Left = _layoutTemplate.NoteDivider1.Left + _layoutTemplate.LeftPadding;
            receipt.NoteDivider1.Width = _layoutTemplate.NoteDivider1.Width;
            currentTopSpace = receipt.NoteDivider1.Top;

            receipt.NoteDivider2.Color = _layoutTemplate.NoteDivider2.Color;
            receipt.NoteDivider2.Top = currentTopSpace + _layoutTemplate.NoteDivider2.TopPadding;
            receipt.NoteDivider2.Left = _layoutTemplate.NoteDivider2.Left + _layoutTemplate.LeftPadding;
            receipt.NoteDivider2.Width = _layoutTemplate.NoteDivider2.Width;
            currentTopSpace = receipt.NoteDivider2.Top;

            receipt.SubtotalTitle.Color = _layoutTemplate.SubtotalTitle.Color;
            receipt.SubtotalTitle.TextSize = _layoutTemplate.SubtotalTitle.TextSize;
            receipt.SubtotalTitle.Width = _layoutTemplate.SubtotalTitle.Width;
            receipt.SubtotalTitle.Height = CalculateTextHeight(receipt.SubtotalTitle.TextSize, receipt.SubtotalTitle.Title, receipt.SubtotalTitle.Width);
            receipt.SubtotalTitle.Top = currentTopSpace + _layoutTemplate.SubtotalTitle.TopPadding;
            receipt.SubtotalTitle.Left = _layoutTemplate.SubtotalTitle.Left + _layoutTemplate.LeftPadding;

            receipt.SubtotalValue.Color = _layoutTemplate.SubtotalValue.Color;
            receipt.SubtotalValue.TextSize = _layoutTemplate.SubtotalValue.TextSize;
            receipt.SubtotalValue.Width = _layoutTemplate.SubtotalValue.Width;
            receipt.SubtotalValue.Height = CalculateTextHeight(receipt.SubtotalValue.TextSize, receipt.SubtotalValue.Title, receipt.SubtotalValue.Width);
            receipt.SubtotalValue.Top = currentTopSpace + _layoutTemplate.SubtotalValue.TopPadding;
            receipt.SubtotalValue.Left = _layoutTemplate.SubtotalValue.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.SubtotalValue.Top + receipt.SubtotalValue.Height;

            receipt.TaxTitle.Color = _layoutTemplate.TaxTitle.Color;
            receipt.TaxTitle.TextSize = _layoutTemplate.TaxTitle.TextSize;
            receipt.TaxTitle.Width = _layoutTemplate.TaxTitle.Width;
            receipt.TaxTitle.Height = CalculateTextHeight(receipt.TaxTitle.TextSize, receipt.TaxTitle.Title, receipt.TaxTitle.Width);
            receipt.TaxTitle.Top = currentTopSpace + _layoutTemplate.TaxTitle.TopPadding;
            receipt.TaxTitle.Left = _layoutTemplate.TaxTitle.Left + _layoutTemplate.LeftPadding;

            receipt.TaxValue.Color = _layoutTemplate.TaxValue.Color;
            receipt.TaxValue.TextSize = _layoutTemplate.TaxValue.TextSize;
            receipt.TaxValue.Width = _layoutTemplate.TaxValue.Width;
            receipt.TaxValue.Height = CalculateTextHeight(receipt.TaxValue.TextSize, receipt.TaxValue.Title, receipt.TaxValue.Width);
            receipt.TaxValue.Top = currentTopSpace + _layoutTemplate.TaxValue.TopPadding;
            receipt.TaxValue.Left = _layoutTemplate.TaxValue.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.TaxValue.Top + receipt.TaxValue.Height;

            receipt.DiscountTitle.Color = _layoutTemplate.DiscountTitle.Color;
            receipt.DiscountTitle.TextSize = _layoutTemplate.DiscountTitle.TextSize;
            receipt.DiscountTitle.Width = _layoutTemplate.DiscountTitle.Width;
            receipt.DiscountTitle.Height = CalculateTextHeight(receipt.DiscountTitle.TextSize, receipt.DiscountTitle.Title, receipt.DiscountTitle.Width);
            receipt.DiscountTitle.Top = currentTopSpace + _layoutTemplate.DiscountTitle.TopPadding;
            receipt.DiscountTitle.Left = _layoutTemplate.DiscountTitle.Left + _layoutTemplate.LeftPadding;

            receipt.DiscountValue.Color = _layoutTemplate.DiscountValue.Color;
            receipt.DiscountValue.TextSize = _layoutTemplate.DiscountValue.TextSize;
            receipt.DiscountValue.Width = _layoutTemplate.DiscountValue.Width;
            receipt.DiscountValue.Height = CalculateTextHeight(receipt.DiscountValue.TextSize, receipt.DiscountValue.Title, receipt.DiscountValue.Width);
            receipt.DiscountValue.Top = currentTopSpace + _layoutTemplate.DiscountValue.TopPadding;
            receipt.DiscountValue.Left = _layoutTemplate.DiscountValue.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.DiscountValue.Top + receipt.DiscountValue.Height;

            receipt.SaleTotalTitle.Color = _layoutTemplate.SaleTotalTitle.Color;
            receipt.SaleTotalTitle.TextSize = _layoutTemplate.SaleTotalTitle.TextSize;
            receipt.SaleTotalTitle.Width = _layoutTemplate.SaleTotalTitle.Width;
            receipt.SaleTotalTitle.Height = CalculateTextHeight(receipt.SaleTotalTitle.TextSize, receipt.SaleTotalTitle.Title, receipt.SaleTotalTitle.Width);
            receipt.SaleTotalTitle.Top = currentTopSpace + _layoutTemplate.SaleTotalTitle.TopPadding;
            receipt.SaleTotalTitle.Left = _layoutTemplate.SaleTotalTitle.Left + _layoutTemplate.LeftPadding;

            receipt.SaleValue.Color = _layoutTemplate.SaleValue.Color;
            receipt.SaleValue.TextSize = _layoutTemplate.SaleValue.TextSize;
            receipt.SaleValue.Width = _layoutTemplate.SaleValue.Width;
            receipt.SaleValue.Height = CalculateTextHeight(receipt.SaleValue.TextSize, receipt.SaleValue.Title, receipt.SaleValue.Width);
            receipt.SaleValue.Top = currentTopSpace + _layoutTemplate.SaleValue.TopPadding;
            receipt.SaleValue.Left = _layoutTemplate.SaleValue.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.SaleValue.Top + receipt.SaleValue.Height;

            receipt.PricingDivider1.Color = _layoutTemplate.PricingDivider1.Color;
            receipt.PricingDivider1.Top = currentTopSpace + _layoutTemplate.PricingDivider1.TopPadding;
            receipt.PricingDivider1.Left = _layoutTemplate.PricingDivider1.Left + _layoutTemplate.LeftPadding;
            receipt.PricingDivider1.Width = _layoutTemplate.PricingDivider1.Width;
            currentTopSpace = receipt.PricingDivider1.Top;

            receipt.PricingDivider2.Color = _layoutTemplate.PricingDivider2.Color;
            receipt.PricingDivider2.Top = currentTopSpace + _layoutTemplate.PricingDivider2.TopPadding;
            receipt.PricingDivider2.Left = _layoutTemplate.PricingDivider2.Left + _layoutTemplate.LeftPadding;
            receipt.PricingDivider2.Width = _layoutTemplate.PricingDivider2.Width;
            currentTopSpace = receipt.PricingDivider2.Top;


            receipt.PaymentSummaryTitle.Color = _layoutTemplate.PaymentSummaryTitle.Color;
            receipt.PaymentSummaryTitle.TextSize = _layoutTemplate.PaymentSummaryTitle.TextSize;
            receipt.PaymentSummaryTitle.Width = _layoutTemplate.PaymentSummaryTitle.Width;
            receipt.PaymentSummaryTitle.Height = CalculateTextHeight(receipt.PaymentSummaryTitle.TextSize, receipt.PaymentSummaryTitle.Title, receipt.PaymentSummaryTitle.Width);
            receipt.PaymentSummaryTitle.Top = currentTopSpace + _layoutTemplate.PaymentSummaryTitle.TopPadding;
            receipt.PaymentSummaryTitle.Left = _layoutTemplate.PaymentSummaryTitle.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.PaymentSummaryTitle.Top + receipt.PaymentSummaryTitle.Height;

            foreach (var paymentTransaction in receipt.PaymentTransactions)
            {
                paymentTransaction.Title.Color = _layoutTemplate.PaymentTransactionTitle.Color;
                paymentTransaction.Title.TextSize = _layoutTemplate.PaymentTransactionTitle.TextSize;
                paymentTransaction.Title.Width = _layoutTemplate.PaymentTransactionTitle.Width;
                paymentTransaction.Title.Height = CalculateTextHeight(paymentTransaction.Title.TextSize, paymentTransaction.Title.Title, paymentTransaction.Title.Width);
                paymentTransaction.Title.Top = currentTopSpace + _layoutTemplate.PaymentTransactionTitle.TopPadding;
                paymentTransaction.Title.Left = _layoutTemplate.PaymentTransactionTitle.Left + _layoutTemplate.LeftPadding;

                paymentTransaction.Value.Color = _layoutTemplate.PaymentTransactionValue.Color;
                paymentTransaction.Value.TextSize = _layoutTemplate.PaymentTransactionValue.TextSize;
                paymentTransaction.Value.Width = _layoutTemplate.PaymentTransactionValue.Width;
                paymentTransaction.Value.Height = CalculateTextHeight(paymentTransaction.Value.TextSize, paymentTransaction.Value.Title, paymentTransaction.Value.Width);
                paymentTransaction.Value.Top = currentTopSpace + _layoutTemplate.PaymentTransactionValue.TopPadding;
                paymentTransaction.Value.Left = _layoutTemplate.PaymentTransactionValue.Left + _layoutTemplate.LeftPadding;
                currentTopSpace = paymentTransaction.Value.Top + paymentTransaction.Value.Height;
            }

            receipt.PaymentDivider.Color = _layoutTemplate.PaymentDivider.Color;
            receipt.PaymentDivider.Top = currentTopSpace + _layoutTemplate.PaymentDivider.TopPadding;
            receipt.PaymentDivider.Left = _layoutTemplate.PaymentDivider.Left + _layoutTemplate.LeftPadding;
            receipt.PaymentDivider.Width = _layoutTemplate.PaymentDivider.Width;
            currentTopSpace = receipt.PaymentDivider.Top;

            receipt.ChangeTitle.Color = _layoutTemplate.ChangeTitle.Color;
            receipt.ChangeTitle.TextSize = _layoutTemplate.ChangeTitle.TextSize;
            receipt.ChangeTitle.Width = _layoutTemplate.ChangeTitle.Width;
            receipt.ChangeTitle.Height = CalculateTextHeight(receipt.ChangeTitle.TextSize, receipt.ChangeTitle.Title, receipt.ChangeTitle.Width);
            receipt.ChangeTitle.Top = currentTopSpace + _layoutTemplate.ChangeTitle.TopPadding;
            receipt.ChangeTitle.Left = _layoutTemplate.ChangeTitle.Left + _layoutTemplate.LeftPadding;

            receipt.ChangeValue.Color = _layoutTemplate.ChangeValue.Color;
            receipt.ChangeValue.TextSize = _layoutTemplate.ChangeValue.TextSize;
            receipt.ChangeValue.Width = _layoutTemplate.ChangeValue.Width;
            receipt.ChangeValue.Height = CalculateTextHeight(receipt.ChangeValue.TextSize, receipt.ChangeValue.Title, receipt.ChangeValue.Width);
            receipt.ChangeValue.Top = currentTopSpace + _layoutTemplate.ChangeValue.TopPadding;
            receipt.ChangeValue.Left = _layoutTemplate.ChangeValue.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.ChangeValue.Top + receipt.ChangeValue.Height;

            receipt.ChangeDivider.Color = _layoutTemplate.ChangeDivider.Color;
            receipt.ChangeDivider.Top = currentTopSpace + _layoutTemplate.ChangeDivider.TopPadding;
            receipt.ChangeDivider.Left = _layoutTemplate.ChangeDivider.Left + _layoutTemplate.LeftPadding;
            receipt.ChangeDivider.Width = _layoutTemplate.ChangeDivider.Width;
            currentTopSpace = receipt.ChangeDivider.Top;

            receipt.LocationName.Color = _layoutTemplate.LocationName.Color;
            receipt.LocationName.TextSize = _layoutTemplate.LocationName.TextSize;
            receipt.LocationName.Width = _layoutTemplate.LocationName.Width;
            receipt.LocationName.Height = CalculateTextHeight(receipt.LocationName.TextSize, receipt.LocationName.Title, receipt.LocationName.Width);
            receipt.LocationName.Top = currentTopSpace + _layoutTemplate.LocationName.TopPadding;
            receipt.LocationName.Left = _layoutTemplate.LocationName.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.LocationName.Top + receipt.LocationName.Height;

            receipt.LocationPhoneNumber.Color = _layoutTemplate.LocationPhoneNumber.Color;
            receipt.LocationPhoneNumber.TextSize = _layoutTemplate.LocationPhoneNumber.TextSize;
            receipt.LocationPhoneNumber.Width = _layoutTemplate.LocationPhoneNumber.Width;
            receipt.LocationPhoneNumber.Height = CalculateTextHeight(receipt.LocationPhoneNumber.TextSize, receipt.LocationPhoneNumber.Title, receipt.LocationPhoneNumber.Width);
            receipt.LocationPhoneNumber.Top = currentTopSpace + _layoutTemplate.LocationPhoneNumber.TopPadding;
            receipt.LocationPhoneNumber.Left = _layoutTemplate.LocationPhoneNumber.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.LocationPhoneNumber.Top + receipt.LocationPhoneNumber.Height;

            receipt.ThanksTitle.Color = _layoutTemplate.ThanksTitle.Color;
            receipt.ThanksTitle.TextSize = _layoutTemplate.ThanksTitle.TextSize;
            receipt.ThanksTitle.Width = _layoutTemplate.ThanksTitle.Width;
            receipt.ThanksTitle.Height = CalculateTextHeight(receipt.ThanksTitle.TextSize, receipt.ThanksTitle.Title, receipt.ThanksTitle.Width);
            receipt.ThanksTitle.Top = currentTopSpace + _layoutTemplate.ThanksTitle.TopPadding;
            receipt.ThanksTitle.Left = _layoutTemplate.ThanksTitle.Left + _layoutTemplate.LeftPadding;
            currentTopSpace = receipt.ThanksTitle.Top + receipt.ThanksTitle.Height;

            receipt.Barcode.Color = _layoutTemplate.Barcode.Color;
            receipt.Barcode.TextSize = _layoutTemplate.Barcode.TextSize;
            receipt.Barcode.Width = _layoutTemplate.Barcode.Width;
            receipt.Barcode.Height = _layoutTemplate.Barcode.Height;
            receipt.Barcode.Top = currentTopSpace + _layoutTemplate.Barcode.TopPadding;
            receipt.Barcode.Left = _layoutTemplate.Barcode.Left;
            currentTopSpace = receipt.Barcode.Top + receipt.Barcode.Height;

            receipt.Height = (int)Math.Ceiling(currentTopSpace) + 25;

            return receipt;
        }

        private float CalculateTextHeight(float textSize, string str, float maxWidth, int maxLine = 1)
        {
            var storeName = new RichString()
                                        .FontFamily("Segoe UI")
                                        .FontSize(textSize)
                                        .FontWeight(700)
                                        .Add(str);
            storeName.MaxWidth = maxWidth;
            storeName.MaxLines = maxLine;
            return storeName.MeasuredHeight;
        }
    }
}
