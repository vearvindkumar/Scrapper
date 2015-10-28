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
using System.Windows.Forms;

using WatiN.MsHtmlBrowser;
using ScrapperDemo.Model;
using ScrapperDemo.Classes;

namespace ScrapperDemo.View
{
    /// <summary>
    /// Interaction logic for LoadHTMLContentToSQL.xaml
    /// </summary>
    public partial class LoadHTMLContentToSQL : System.Windows.Controls.UserControl
    {
        public LoadHTMLContentToSQL()
        {
            InitializeComponent();
        }

        string folderpath;
        private void BtnLoadFolder_Click(object sender, RoutedEventArgs e)
        {
            CombxHTMLfilenames.Items.Clear();
            folderpath = "";
            string startupPath = System.Windows.Forms.Application.StartupPath;
            folderpath = startupPath + "\\DefaultScrap\\";
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Open a folder which want to store scrapped file";
                dialog.ShowNewFolderButton = true;
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                if (dialog.ShowDialog() == DialogResult.OK)
                {                    
                    folderpath = dialog.SelectedPath;
                }
            }
            
            string[] htmlfiles = System.IO.Directory.GetFiles(folderpath, "*.html");
            string[] html5files = System.IO.Directory.GetFiles(folderpath, "*.html5");

            List<string> filenamesHTMLn5 = new List<string>();

            for (int i = 0; htmlfiles.Length > i; i++)
            {
                filenamesHTMLn5.Add(htmlfiles[i].ToString());
            }

            for (int j = 0; html5files.Length > j; j++)
            {
                filenamesHTMLn5.Add(html5files[j].ToString());
            }

            foreach (var filenamesofHTMLn5 in filenamesHTMLn5)
            {
                this.CombxHTMLfilenames.Items.Add(filenamesofHTMLn5);              
            }
            if (this.CombxHTMLfilenames.Items.Count > 0)
                this.CombxHTMLfilenames.SelectedIndex = 0;

        }

        private void BtnShowHTMLContent_Click(object sender, RoutedEventArgs e)
        {
            var browser = new MsHtmlBrowser();
            browser.GoTo(this.CombxHTMLfilenames.SelectedItem.ToString());
            if (browser.Text.ToString() == null)
            {
                txtbxShowhtmlcontent.Text = "n/a";
            }
            else
            {
                txtbxShowhtmlcontent.Text = browser.Text.ToString();
                string PlainHTML = txtbxShowhtmlcontent.Text.ToString();
                RecordData.ShownHTMLPlainTextContent = PlainHTML;
            }
            RecordData.firstanalyzeFlg = true;
            System.Windows.MessageBox.Show("HTML Content Shown Sucessfully ", "Scraper Demo", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void BtnDefaultLoadFolder_Click(object sender, RoutedEventArgs e)
        {    
             string folderpathfirst = "\\firstanalyze\\";
             string folderpathsecond = "\\secondanalyze\\";

             List<string> filenamesHTMLn5 = new List<string>();


            string startupPath = System.Windows.Forms.Application.StartupPath;
            folderpathfirst = startupPath + folderpathfirst;
            folderpathsecond = startupPath + folderpathsecond;

            string[] htmlfiles = System.IO.Directory.GetFiles(folderpathfirst, "*.html");
            string[] html5files = System.IO.Directory.GetFiles(folderpathfirst, "*.html5");

            

            for (int i = 0; htmlfiles.Length > i; i++)
            {
                filenamesHTMLn5.Add(htmlfiles[i].ToString());
            }

            for (int j = 0; html5files.Length > j; j++)
            {
                filenamesHTMLn5.Add(html5files[j].ToString());
            }

            htmlfiles = null;
            html5files = null;

            htmlfiles = System.IO.Directory.GetFiles(folderpathsecond, "*.html");
            html5files = System.IO.Directory.GetFiles(folderpathsecond, "*.html5");



            for (int i = 0; htmlfiles.Length > i; i++)
            {
                filenamesHTMLn5.Add(htmlfiles[i].ToString());
            }

            for (int j = 0; html5files.Length > j; j++)
            {
                filenamesHTMLn5.Add(html5files[j].ToString());
            }

            foreach (var filenamesofHTMLn5 in filenamesHTMLn5)
            {
                this.CombxHTMLfilenames.Items.Add(filenamesofHTMLn5);
            }
            if (this.CombxHTMLfilenames.Items.Count > 0)
                this.CombxHTMLfilenames.SelectedIndex = 0;

            RecordData.firstanalyzeFlg = true;

        }

        private void BtnLoadHTMLContentToDB_Click(object sender, RoutedEventArgs e)
        {
            mainRecords records = new mainRecords();
            sqlConnection sqlconn = new sqlConnection();
            ScrapperRecordMain scrpMainRecord = new ScrapperRecordMain();
            

            if (RecordData.firstanalyzeFlg)
            {
                records.awNo = sqlconn.getAWNO();
                records.webURL = RecordData.mainRecords.webURL;
                records.web1URL = "n/a";
                records.web2URL = "n/a";
                records.scrapDT = DateTime.UtcNow;
                records.AnalyzeNo = sqlconn.getAnalyzeNo();
                        
                records.isURLsimilar = "false";
                if (this.txtbxShowhtmlcontent.Text == null)
                {
                    records.pageContentText = "";
                }
                else
                {
                    records.pageContentText = this.txtbxShowhtmlcontent.ToString();
                }

                records.searchContentText = "";
                records.searchCtxtDT = DateTime.UtcNow;

                scrpMainRecord.insertDatatoMainRecords(records);
                scrpMainRecord.insertDatatoScraperPageTextData(records);

                RecordData.firstanalyzeFlg = false;
                System.Windows.MessageBox.Show("HTML Content Loaded To Database Sucessfully At : " + DateTime.UtcNow.ToString(), "Scraper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else if (RecordData.secondanalyzeFlg)
            {
                records.awNo = sqlconn.getAWNO();
                records.webURL = RecordData.mainRecords.webURL;
                records.web1URL = RecordData.mainRecords.web1URL;
                records.web2URL = RecordData.mainRecords.web2URL;
                records.scrapDT = DateTime.UtcNow;
                records.AnalyzeNo = sqlconn.getAnalyzeNo();

                if (records.web1URL == records.web2URL)
                {
                    records.isURLsimilar = "true";
                }
                else
                {
                    records.isURLsimilar = "false";
                }

                if (this.txtbxShowhtmlcontent.Text == null)
                {
                    records.pageContentText = "";
                }
                else
                {
                    records.pageContentText = this.txtbxShowhtmlcontent.ToString();
                }

                records.searchContentText = "";
                records.searchCtxtDT = DateTime.UtcNow;



                scrpMainRecord.insertDatatoMainRecords(records);
                scrpMainRecord.insertDatatoScraperPageTextData(records);

                RecordData.secondanalyzeFlg = false;
                System.Windows.MessageBox.Show("HTML Content Loaded To Database Sucessfully At : " + DateTime.UtcNow.ToString() , "Scraper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else 
            {
                RecordData.firstanalyzeFlg = false;
                RecordData.secondanalyzeFlg = false;
                System.Windows.MessageBox.Show("Please analyze first, then load","Scraper Demo",MessageBoxButton.OK,MessageBoxImage.Information);                

            }

        }

       
    }
}
