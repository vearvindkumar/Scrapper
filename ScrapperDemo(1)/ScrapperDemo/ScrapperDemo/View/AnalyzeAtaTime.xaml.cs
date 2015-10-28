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
using System.Threading;
using ScrapperDemo.Classes;

using WatiN.MsHtmlBrowser;
using ScrapperDemo.Classes;

namespace ScrapperDemo.View
{
    /// <summary>
    /// Interaction logic for AnalyzeAtaTime.xaml
    /// </summary>
    public partial class AnalyzeAtaTime : UserControl
    {
        public AnalyzeAtaTime()
        {
            InitializeComponent();
        }

      

        private void Btnatatimeanalyze_Click(object sender, RoutedEventArgs e)
        {
            string folderpathfirst = "\\firstanalyze\\";
            string folderpathsecond = "\\secondanalyze\\";

            string startupPath = System.Windows.Forms.Application.StartupPath;
            folderpathfirst = startupPath + folderpathfirst;
            folderpathsecond = startupPath + folderpathsecond;

            
            

            Uri uriResult;
            bool resultfirst = Uri.TryCreate(txtbxfirsturl.Text.ToString(), UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
            bool resultsecond = Uri.TryCreate(txtbxsecondurl.Text.ToString(), UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
            if (!resultfirst)
            {                
                    MessageBox.Show("Enter first URL", "Scrapper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;               
            }
            if (!resultsecond)
            {            
                    MessageBox.Show("Enter second URL", "Scrapper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
            }


            if (System.IO.Directory.Exists(folderpathfirst))//if folder exists
            {
                System.IO.Directory.Delete(folderpathfirst, true);//recursive delete (all subdirs, files)
            }

            if (System.IO.Directory.Exists(folderpathsecond))//if folder exists
            {
                System.IO.Directory.Delete(folderpathsecond, true);//recursive delete (all subdirs, files)
            }

            RecordData.secondanalyzeFlg = true;
            RecordData.mainRecords.webURL = "n/a";
            RecordData.mainRecords.web1URL = txtbxfirsturl.Text;
            RecordData.mainRecords.web2URL = txtbxsecondurl.Text;

            bool flgok1 = false;
            bool flgok2 = false;
           flgok1 =  ScrapperDemoStart.FirstAnalyze(txtbxfirsturl.Text, folderpathfirst);
           flgok2 = SecondScrapperAnalyze.SecondAnalyze(txtbxsecondurl.Text, folderpathsecond);

          

            if (flgok1 && flgok2)
            {               
                System.Windows.MessageBox.Show("URL scrapping is finished", "Scrapper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else 
            {
                System.Windows.MessageBox.Show("URL is scrapping is failed", "Scrapper Demo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //Task t = methodcall(folderpathfirst, folderpathsecond);

            //t.Wait();
            // return;
        }


        //private async Task methodcall(string p1, string p2)
        //{

        //   await Task.Run(() => AtaTimeAnalyzefirst.FirstAnalyzed(txtbxfirsturl.Text, folderpathfirst));
        //   await Task.Run(() => AtaTimeAnalyzeSecond.SecondAnalyzed(txtbxsecondurl.Text, folderpathsecond));         
        //}

        private void Btnwebpagecontentloadtodatabase_Click(object sender, RoutedEventArgs e)
        {
            var browser = new MsHtmlBrowser();
            browser.GoTo(@"E:\ScrapperDemo\index.html");


           string str =  browser.Text.ToString();
          


        }

        private void BtnwebpagecontentDiff_Click(object sender, RoutedEventArgs e)
        {

            Uri uriResult;
            bool resultfirst = Uri.TryCreate(txtbxfirsturl.Text.ToString(), UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
            bool resultsecond = Uri.TryCreate(txtbxsecondurl.Text.ToString(), UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
            if (!resultfirst)
            {
                MessageBox.Show("Enter first URL", "Scrapper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!resultsecond)
            {
                MessageBox.Show("Enter second URL", "Scrapper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            RecordData.mainRecords.web1URL = txtbxfirsturl.Text;
            RecordData.mainRecords.web2URL = txtbxsecondurl.Text;

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

                MsHtmlBrowser browserFirst = new MsHtmlBrowser();

                Task t1 = Task.Run(() =>
                {
                    browserFirst.GoTo(RecordData.mainRecords.web1URL);
                    strFirst = browserFirst.Text.ToString();
                });
                t1.Wait();

                MsHtmlBrowser browserSecond = new MsHtmlBrowser();

                Task t2 = Task.Run(() =>
                {
                    browserSecond.GoTo(RecordData.mainRecords.web2URL);
                    strSecond = browserSecond.Text.ToString();
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

                DiffCalc.MainForm openDiff = new DiffCalc.MainForm();
                openDiff.ShowDialog();


            }
            catch
            {
                System.Windows.MessageBox.Show("Analyze The URL", "Scraper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
