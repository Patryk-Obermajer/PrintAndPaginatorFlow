//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Windows;
//using System.Globalization;
//using System.Windows.Input;
//using System.Windows.Media;
//namespace PrintAndPaginatorFlow
//{
//    class MyVisualHost : FrameworkElement
//    {
//        // Create a collection of child visual objects.
//        private readonly VisualCollection _children;
//        public Pen _framePen = new Pen(Brushes.Black, 2);
//        public MyVisualHost()
//        {
//            _children = new VisualCollection(this)
//            {
//                CreateDrawingVisualRectangle(),
//                CreateDrawingVisualText(),
//                CreateDrawingVisualEllipses(),
//                CreateDrawingVisualLine(),
//            };
//        }
//        // Create a DrawingVisual that contains a rectangle.
//        private System.Windows.Media.DrawingVisual CreateDrawingVisualRectangle()
//        {
//            System.Windows.Media.DrawingVisual drawingVisual = new System.Windows.Media.DrawingVisual();


//            // Retrieve the DrawingContext in order to create new drawing content.
//            DrawingContext drawingContext = drawingVisual.RenderOpen();


//            // Create a rectangle and draw it in the DrawingContext.
//            Rect frame = new Rect(new Point(56.692913, 56.692913), new Size(680.314960, 1009.13385));
//            drawingContext.DrawRectangle(null, _framePen, frame);

//            Rect rectug = new Rect(new Point(189, 189), new Size(250, 120));
//            drawingContext.DrawRectangle(Brushes.Yellow, null, rectug);


//            // Persist the drawing content.
//            drawingContext.Close();

//            return drawingVisual;
//        }
//        // Create a DrawingVisual that contains text.
//        private System.Windows.Media.DrawingVisual CreateDrawingVisualLine()
//        {
//            // Create an instance of a DrawingVisual.
//            System.Windows.Media.DrawingVisual drawingVisual = new System.Windows.Media.DrawingVisual();

//            // Retrieve the DrawingContext from the DrawingVisual.
//            DrawingContext drawingContext = drawingVisual.RenderOpen();

//            drawingContext.DrawLine(_framePen, new Point(56.692913, 156.692913), new Point(737.007873, 156.692913)
//                 );


//            // Close the DrawingContext to persist changes to the DrawingVisual.
//            drawingContext.Close();

//            return drawingVisual;
//        }
//        // Create a DrawingVisual that contains text.
//        private System.Windows.Media.DrawingVisual CreateDrawingVisualText()
//        {
//            // Create an instance of a DrawingVisual.
//            System.Windows.Media.DrawingVisual drawingVisual = new System.Windows.Media.DrawingVisual();

//            // Retrieve the DrawingContext from the DrawingVisual.
//            DrawingContext drawingContext = drawingVisual.RenderOpen();

//#pragma warning disable CS0618 // 'FormattedText.FormattedText(string, CultureInfo, FlowDirection, Typeface, double, Brush)' is obsolete: 'Use the PixelsPerDip override'
//            // Draw a formatted text string into the DrawingContext.
//            drawingContext.DrawText(
//                new FormattedText("Click Me!",
//                    CultureInfo.GetCultureInfo("en-us"),
//                    FlowDirection.LeftToRight,
//                    new Typeface("Verdana"),
//                    36, Brushes.Black),
//                new Point(200, 116));
//#pragma warning enable CS0618 // 'FormattedText.FormattedText(string, CultureInfo, FlowDirection, Typeface, double, Brush)' is obsolete: 'Use the PixelsPerDip override'

//            // Close the DrawingContext to persist changes to the DrawingVisual.
//            drawingContext.Close();

//            return drawingVisual;
//        }

//        // Create a DrawingVisual that contains an ellipse.
//        private System.Windows.Media.DrawingVisual CreateDrawingVisualEllipses()
//        {
//            System.Windows.Media.DrawingVisual drawingVisual = new System.Windows.Media.DrawingVisual();
//            DrawingContext drawingContext = drawingVisual.RenderOpen();

//            drawingContext.DrawEllipse(Brushes.Maroon, null, new Point(430, 136), 20, 20);
//            drawingContext.Close();

//            return drawingVisual;
//        }


//        // Provide a required override for the VisualChildrenCount property.
//        protected override int VisualChildrenCount => _children.Count;

//        // Provide a required override for the GetVisualChild method.
//        protected override Visual GetVisualChild(int index)
//        {
//            if (index < 0 || index >= _children.Count)
//            {
//                throw new ArgumentOutOfRangeException();
//            }

//            return _children[index];
//        }
//    }
//}