using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace HexEditor
{
    public class ByteItem : FrameworkElement
    {
        #region Properties
        private FormattedText formattedText;
        protected FormattedText FormattedText
        {
            get => formattedText;
            private set
            {
                formattedText = value;
                InvalidateMeasure();
            }
        }
        #endregion


        public ByteItem()
        {
            Focusable = true;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if(FormattedText == null)
            {
                return Size.Empty;
            }
            else
            {
                return new Size(FormattedText.Width, FormattedText.Height);
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var typeface = new Typeface(new FontFamily("arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal);
            FormattedText = new FormattedText("00", CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, 12, Brushes.Black, VisualTreeHelper.GetDpi(this).PixelsPerDip);

            drawingContext.DrawText(FormattedText, new Point(0, 0));
        }

    }
}
