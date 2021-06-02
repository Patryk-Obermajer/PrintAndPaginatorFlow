using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Globalization;
using System.Windows.Input;
using System.Windows.Media;
namespace PrintAndPaginatorFlow
{
    class MyVisualHost : FrameworkElement
    {
        // Create a collection of child visual objects.
        private readonly VisualCollection _children;
        public static double cm = 37.795275591; //this is how many pixels are in a cm...
        public static Size _a4PageSize = new Size(21*cm, 29.7*cm);
        public double _pageMarigin = 2*cm;
        public static double headerHeight = 2.4*cm;
        public Pen _framePen = new Pen(Brushes.Black, 2);
        public static Size logoDims = new Size (2 * headerHeight , headerHeight); ///wtf 2 refers to ratio of width/height for our logo box... not sure if this is cool...
        public int _headerFontSize = 16;
        
        public MyVisualHost()
        {
            _children = new VisualCollection(this)
            {
                CreateDrawingVisualRectangle(),
                CreateDrawingVisualText(),
                CreateDrawingVisualEllipses(),
                CreateDrawingVisualLine(),
            };
        }
        // Create a DrawingVisual that contains a rectangle.
        private System.Windows.Media.DrawingVisual CreateDrawingVisualRectangle()
        {
            System.Windows.Media.DrawingVisual drawingVisual = new System.Windows.Media.DrawingVisual();


            // Retrieve the DrawingContext in order to create new drawing content.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            Rect frame = new Rect(new Point(_pageMarigin, _pageMarigin), new Size((_a4PageSize.Width-2*_pageMarigin), (_a4PageSize.Height - 2 * _pageMarigin)));
            drawingContext.DrawRectangle(null, _framePen, frame);

            // Persist the drawing content.
            drawingContext.Close();

            return drawingVisual;
        }
        // Create a DrawingVisual that contains text.
        private System.Windows.Media.DrawingVisual CreateDrawingVisualLine()
        {
            // Create an instance of a DrawingVisual.
            System.Windows.Media.DrawingVisual drawingVisual = new System.Windows.Media.DrawingVisual();

            // Retrieve the DrawingContext from the DrawingVisual.
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            
            //horizontal line for header
            drawingContext.DrawLine(_framePen, new Point(_pageMarigin, _pageMarigin+headerHeight), new Point(-_pageMarigin + _a4PageSize.Width, _pageMarigin + headerHeight)
                 );
            //vertical first line left middle header

            drawingContext.DrawLine(_framePen, new Point(_pageMarigin + 6.4*cm, _pageMarigin), new Point(_pageMarigin + 6.4 * cm, _pageMarigin + headerHeight)
                );
            //vertical first line left middle header

            drawingContext.DrawLine(_framePen, new Point(_pageMarigin + 12.8 * cm, _pageMarigin), new Point(_pageMarigin + 12.8 * cm, _pageMarigin + headerHeight)
                );

            // Close the DrawingContext to persist changes to the DrawingVisual.
            drawingContext.Close();

            return drawingVisual;
        }
        // Create a DrawingVisual that contains text.
        private System.Windows.Media.DrawingVisual CreateDrawingVisualText()
        {
            // Create an instance of a DrawingVisual.
            System.Windows.Media.DrawingVisual drawingVisual = new System.Windows.Media.DrawingVisual();

            // Retrieve the DrawingContext from the DrawingVisual.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

#pragma warning disable CS0618 // 'FormattedText.FormattedText(string, CultureInfo, FlowDirection, Typeface, double, Brush)' is obsolete: 'Use the PixelsPerDip override'
            // Draw a formatted text string into the DrawingContext.
            drawingContext.DrawText(
                new FormattedText(DateTime.Today.Date.ToShortDateString(),
                    CultureInfo.GetCultureInfo("en-GB"),
                    FlowDirection.LeftToRight,
                    new Typeface("Roboto"),
                    _headerFontSize, Brushes.Black),
                new Point(_pageMarigin, _pageMarigin));
            
            drawingContext.DrawText(
                new FormattedText("Click Me!",
                    CultureInfo.GetCultureInfo("en-GB"),
                    FlowDirection.LeftToRight,
                    new Typeface("Roboto"),
                    _headerFontSize, Brushes.Black),
                new Point(_pageMarigin , _pageMarigin + headerHeight / 3));

            drawingContext.DrawText(
               new FormattedText(DateTime.Now.ToShortTimeString(),
                   CultureInfo.GetCultureInfo("en-GB"),
                   FlowDirection.LeftToRight,
                   new Typeface("Roboto"),
                   _headerFontSize, Brushes.Black),
               new Point(_pageMarigin, _pageMarigin + headerHeight * 2 / 3));

#pragma warning enable CS0618 // 'FormattedText.FormattedText(string, CultureInfo, FlowDirection, Typeface, double, Brush)' is obsolete: 'Use the PixelsPerDip override'

            // Close the DrawingContext to persist changes to the DrawingVisual.
            drawingContext.Close();

            return drawingVisual;
        }

        // Create a DrawingVisual that contains an ellipse.
        private System.Windows.Media.DrawingVisual CreateDrawingVisualEllipses()
        {
            System.Windows.Media.DrawingVisual drawingVisual = new System.Windows.Media.DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            drawingContext.DrawEllipse(Brushes.Maroon, null, new Point(430, 136), 20, 20);
            drawingContext.Close();

            return drawingVisual;
        }

        // Provide a required override for the VisualChildrenCount property.
        protected override int VisualChildrenCount => _children.Count;

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _children[index];
        }
    }
}