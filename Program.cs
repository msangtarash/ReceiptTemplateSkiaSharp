using ReceiptTemplateSkiaSharp.Models;
using System;

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
            throw new NotImplementedException();
        }
    }
}
