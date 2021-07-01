using ReceiptTemplateSkiaSharp.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

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

            receipt.StoreName.Top = _layoutTemplate.StoreName.Top;
            receipt.StoreName.Left = CalculateCenteredTextX(_layoutTemplate.StoreName.TextSize, receipt.StoreName.Title,0);
            receipt.StoreName.TextSize = _layoutTemplate.StoreName.TextSize;
            receipt.StoreName.Color = _layoutTemplate.StoreName.Color;
            currentTopSpace = receipt.StoreName.Top + CalculateTextHeight(receipt.StoreName.TextSize ,receipt.StoreName.Title);

            receipt.StoreNameDivider.Top = currentTopSpace + _layoutTemplate.StoreNameDivider.TopPadding;
            receipt.StoreNameDivider.Left = _layoutTemplate.StoreNameDivider.Left + _layoutTemplate.LeftMargin;
            receipt.StoreNameDivider.Color = _layoutTemplate.StoreNameDivider.Color;
            receipt.StoreNameDivider.Width = _layoutTemplate.StoreNameDivider.Width;
            currentTopSpace = receipt.StoreNameDivider.Top + CalculateTextHeight(receipt.StoreName.TextSize, receipt.StoreName.Title);

            receipt.Height = (int)Math.Ceiling(currentTopSpace);

            return receipt;
        }

        private float CalculateCenteredTextX(float textSize, string str, float boxLeft)
        {
            using (SKPaint textPaint = new SKPaint())
            {
                textPaint.TextSize = textSize;

                float textWidth = textPaint.MeasureText(str);

                float xText = boxLeft + _layoutTemplate.PageWidth / 2 - textWidth / 2;

                return xText;
            }
        }

        private float CalculateTextHeight(float textSize, string str)
        {
            using (SKPaint textPaint = new SKPaint())
            {
                textPaint.TextSize = textSize;

                SKRect textBounds = new SKRect();
                
                textPaint.MeasureText(str, ref textBounds);

                return textBounds.Size.Height;
            }
        }
    }
}
