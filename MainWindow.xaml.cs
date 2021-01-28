using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Printing;

namespace PrintAndPaginatorFlow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var visualHost = new MyVisualHost();
            //MyCanvas.Children.Add(visualHost);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintTicket.PageScalingFactor = 1;
            printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA0);
            printDialog.PrintTicket.PageMediaType = new PageMediaType();

                // Save all the existing settings.                                
                double pageHeight = docReader.Document.PageHeight;
                double pageWidth = docReader.Document.PageWidth;

                PageMediaSize pageSize = new PageMediaSize(PageMediaSizeName.ISOA0);

                //// Make the FlowDocument page match the printed page.
                docReader.Document.PageHeight = printDialog.PrintableAreaHeight;
                docReader.Document.PageWidth = printDialog.PrintableAreaWidth;
                //printDialog.UserPageRangeEnabled = true;



                FlowDocument document = docReader.Document;
                docReader.Document = null;
                printDialog.PrintQueue.DefaultPrintTicket.PageMediaSize = pageSize;
                printDialog.PrintTicket.PageScalingFactor = 1;


                HeaderedFlowDocumentPaginator paginator = new HeaderedFlowDocumentPaginator(document);
               
                printDialog.ShowDialog();
                printDialog.PrintDocument(paginator, "Obermasters. Results");

                docReader.Document = document;

                // Reapply the old settings.
                docReader.Document.PageHeight = pageHeight;
                docReader.Document.PageWidth = pageWidth;

            
        }
    }
}
