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

using ScrapperDemo.Model;
using ScrapperDemo.Classes;
using WatiN.MsHtmlBrowser;
using System.Threading;
using DiffCalc;

namespace ScrapperDemo.View
{
    /// <summary>
    /// Interaction logic for SearchData.xaml
    /// </summary>
    public partial class SearchData : UserControl
    {
        public SearchData()
        {
            InitializeComponent();

            LoadAnalyzeNumberToComboBx();
        }

        private void BtnLoadSearchContent_Click(object sender, RoutedEventArgs e)
        {
            txtbxSearchHTMLContent.Text = RecordData.ShownHTMLPlainTextContent.ToString();

            System.Windows.MessageBox.Show("HTML Content Load For Searching", "Scraper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoadAnalyzeNumberToComboBx()
        {
            this.cmbbxLoadplaintextfromdb.Items.Add("Select Analyze Number To Load Content For Search");
            List<int> analyzeno = new List<int>();
            ScrapperRecordMain scrm = new ScrapperRecordMain();
           analyzeno = scrm.LoaadAnalyzeNumber();

           foreach (var filenamesofHTMLn5 in analyzeno)
           {
               this.cmbbxLoadplaintextfromdb.Items.Add(filenamesofHTMLn5);
           }
           if (this.cmbbxLoadplaintextfromdb.Items.Count > 0)
               this.cmbbxLoadplaintextfromdb.SelectedIndex = 0;         


        }

        private void cmbbxLoadplaintextfromdb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string pageContent = "Load Search HTML Content";
            try
            {
                ScrapperRecordMain scrm = new ScrapperRecordMain();
                int analyzeno = 0;
                analyzeno = Convert.ToInt16(cmbbxLoadplaintextfromdb.SelectedItem.ToString());
                pageContent = scrm.getThePlainHTMLContentTextFromDB(analyzeno);

                if (pageContent == "" || pageContent == null)
                {
                    System.Windows.MessageBox.Show("Empty Data, Please Select Other Analyze Number", "Scraper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                txtbxSearchHTMLContent.Text = pageContent.Replace("System.Windows.Controls.TextBox:", "");
                System.Windows.MessageBox.Show("HTML Content Load For Searching", "Scraper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
       
            }
            catch { }
        }

        private void ShowDiff_Click(object sender, RoutedEventArgs e)
        {
            if (RecordData.mainRecords.web1URL == null || RecordData.mainRecords.web1URL == "")
            {
                System.Windows.MessageBox.Show("Analyze The URL First", "Scraper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (RecordData.mainRecords.web2URL == null || RecordData.mainRecords.web1URL == "")
            {
                System.Windows.MessageBox.Show("Analyze The URL First", "Scraper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                string strFirst = "";
                string strSecond = "";

                var browserFirst = new MsHtmlBrowser();

                Task t1 = Task.Run(() =>
                {
                    browserFirst.GoTo(RecordData.mainRecords.web1URL);
                    strFirst = browserFirst.Text.ToString();
                });
                t1.Wait();

                var browserSecond = new MsHtmlBrowser();

                Task t2 = Task.Run(() =>
                {
                    browserFirst.GoTo(RecordData.mainRecords.web2URL);
                    strSecond = browserFirst.Text.ToString();
                });
                t2.Wait();

                Task t3 = Task.Run(() =>
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(@"C:\Scrpaer\");
                    file.Directory.Create();                    
                    System.IO.File.WriteAllText(@"C:\Scrpaer\First.txt", strFirst);
                    System.IO.File.WriteAllText(@"C:\Scrpaer\Second.txt", strSecond);
                });
                t3.Wait();             

                DiffCalc.MainForm openDiff = new MainForm();
                openDiff.ShowDialog();

                
            }
            catch
            {
                System.Windows.MessageBox.Show("Analyze The URL First", "Scraper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
           
        }
    }
}
