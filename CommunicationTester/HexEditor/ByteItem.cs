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
        protected FormattedText FormattedText { get; private set; }

        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }
        public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(
            nameof(Padding), typeof(Thickness), typeof(ByteItem),
                new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsRender));

        public byte Value
        {
            get => (byte)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value), typeof(byte), typeof(ByteItem), new FrameworkPropertyMetadata(
                (byte)0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(
            nameof(IsSelected), typeof(bool), typeof(ByteItem), new FrameworkPropertyMetadata(
                false, FrameworkPropertyMetadataOptions.None));

        public Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }
        public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register(
            "Background", typeof(Brush), typeof(ByteItem), new FrameworkPropertyMetadata(
                null, FrameworkPropertyMetadataOptions.AffectsRender));

        public Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }
        public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(
            nameof(Foreground), typeof(Brush), typeof(ByteItem), new FrameworkPropertyMetadata(
                Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion


        public ByteItem()
        {
            Focusable = true;
            FormattedText = CreateFormattedText();
        }

        private FormattedText CreateFormattedText()
        {
            Typeface typeface = new Typeface(new FontFamily("arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal);
            return new FormattedText(Value.ToString("X2"), CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, 12, Foreground, VisualTreeHelper.GetDpi(this).PixelsPerDip);
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if (FormattedText == null)
            {
                return Size.Empty;
            }
            else
            {
                return new Size(
                    FormattedText.Width + (Padding != null ? Padding.Left + Padding.Right : 0),
                    FormattedText.Height + (Padding != null ? Padding.Top + Padding.Bottom : 0));
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (Background != null)
            {
                drawingContext.DrawRectangle(Background, null, new Rect(0, 0, RenderSize.Width, RenderSize.Height));
            }

            FormattedText = CreateFormattedText();
            drawingContext.DrawText(FormattedText, Padding != null ? new Point(Padding.Left, Padding.Top) : new Point(0, 0));
        }
    }
}
