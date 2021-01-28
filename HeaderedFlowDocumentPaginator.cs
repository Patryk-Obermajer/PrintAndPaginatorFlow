﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;
using System.Globalization;

namespace PrintAndPaginatorFlow
{
    public partial class HeaderedFlowDocumentPaginator : DocumentPaginator
    {
        private DocumentPaginator flowDocumentPaginator;
        

        public HeaderedFlowDocumentPaginator(FlowDocument document)
        {
            flowDocumentPaginator = ((IDocumentPaginatorSource)document).DocumentPaginator;
            flowDocumentPaginator.Source.DocumentPaginator.PageSize = new Size(234, 454);
        }

        public override DocumentPage GetPage(int pageNumber)
        {
            // Get the requested page.
            DocumentPage page = flowDocumentPaginator.GetPage(pageNumber);
            
            //// Wrap the page in a Visual. You can then add a transformation and extras.
          
            ContainerVisual newVisual = new ContainerVisual();
            
            newVisual.Children.Add(page.Visual);
            
            // Create a header. 
            DrawingVisual header = new DrawingVisual();
            using (DrawingContext context = header.RenderOpen())
            {
                Typeface typeface = new Typeface("Roboto");
                FormattedText text = new FormattedText("Page " + (pageNumber + 1).ToString(),
                  CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                  typeface, 14, Brushes.Black);

                // Leave a quarter-inch of space between the page edge and this text.
                context.DrawText(text, new Point(96 * 1, 96 * 1));

            }
            // Add the title to the visual.
            newVisual.Children.Add(header);

            Size pageSize = new Size(793.7007874, 1122.519685);
            Rect bleedBox = new Rect(pageSize);
            
            // Wrap the visual in a new page.
            DocumentPage newPage = new DocumentPage(newVisual, pageSize, bleedBox, bleedBox);
                //Set SIZE

            return newPage;
        }

        public override bool IsPageCountValid
        {
            get { return flowDocumentPaginator.IsPageCountValid; }
        }

        public override int PageCount
        {
            get { return flowDocumentPaginator.PageCount; }
        }

        //protected void SetSize(System.Windows.Size size)
        //{

        //}

        public override System.Windows.Size PageSize
        {
            get { return flowDocumentPaginator.PageSize = new Size(23, 34);
        }
            set { flowDocumentPaginator.PageSize = value; }
        }

        public override IDocumentPaginatorSource Source
        {
            get { return flowDocumentPaginator.Source; }
        }
        
    }
}