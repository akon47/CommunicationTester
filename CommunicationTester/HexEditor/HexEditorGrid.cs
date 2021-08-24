using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HexEditor
{
    // Base code is UniformGrid.cs
    public class HexEditorGrid : Panel
    {
        #region Constructors
        public HexEditorGrid() : base() { }
        #endregion

        #region Public Properties
        #endregion

        #region Protected Methods

        protected override Size MeasureOverride(Size constraint)
        {
            UpdateComputedValues();

            Size childConstraint = new Size(constraint.Width / _columns, constraint.Height / _rows);
            double maxChildDesiredWidth = 0.0d;
            double maxChildDesiredHeight = 0.0d;

            for (int i = 0, count = InternalChildren.Count; i < count; ++i)
            {
                UIElement child = InternalChildren[i];

                child.Measure(childConstraint);
                Size childDesiredSize = child.DesiredSize;

                if (maxChildDesiredWidth < childDesiredSize.Width)
                {
                    maxChildDesiredWidth = childDesiredSize.Width;
                }

                if (maxChildDesiredHeight < childDesiredSize.Height)
                {
                    maxChildDesiredHeight = childDesiredSize.Height;
                }
            }

            return new Size((maxChildDesiredWidth * _columns) + 5, (maxChildDesiredHeight * _rows));
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            Rect childBounds = new Rect(0, 0, (arrangeSize.Width - 5) / _columns, arrangeSize.Height / _rows);
            double xStep = childBounds.Width;
            double xBound = arrangeSize.Width - 1.0d;

            int xCount = 0;
            foreach (UIElement child in InternalChildren)
            {
                child.Arrange(childBounds);

                if (child.Visibility != Visibility.Collapsed)
                {
                    childBounds.X += xStep;
                    if (childBounds.X >= xBound)
                    {
                        childBounds.Y += childBounds.Height;
                        childBounds.X = 0;
                        xCount = 0;
                    }
                    else
                    {
                        xCount++;
                        if (xCount == 8)
                        {
                            childBounds.X += 5;
                        }
                    }
                }
            }

            return arrangeSize;
        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            dc.DrawLine(new Pen(Brushes.Black, 1.5d) { DashStyle = DashStyles.Dot },
                new Point(RenderSize.Width / 2.0d, 5),
                new Point(RenderSize.Width / 2.0d, RenderSize.Height - 5));
        }

        #endregion

        #region Private Methods

        private void UpdateComputedValues()
        {
            _columns = 16;
            _rows = 0;

            if ((_rows == 0) || (_columns == 0))
            {
                int nonCollapsedCount = 0;

                for (int i = 0, count = InternalChildren.Count; i < count; ++i)
                {
                    UIElement child = InternalChildren[i];
                    if (child.Visibility != Visibility.Collapsed)
                    {
                        nonCollapsedCount++;
                    }
                }

                if (nonCollapsedCount == 0)
                {
                    nonCollapsedCount = 1;
                }

                if (_rows == 0)
                {
                    if (_columns > 0)
                    {
                        _rows = (nonCollapsedCount + (_columns - 1)) / _columns;
                    }
                    else
                    {
                        _rows = (int)Math.Sqrt(nonCollapsedCount);
                        if ((_rows * _rows) < nonCollapsedCount)
                        {
                            _rows++;
                        }
                        _columns = _rows;
                    }
                }
                else if (_columns == 0)
                {
                    _columns = (nonCollapsedCount + (_rows - 1)) / _rows;
                }
            }
        }

        #endregion

        private int _rows;
        private int _columns;
    }
}
