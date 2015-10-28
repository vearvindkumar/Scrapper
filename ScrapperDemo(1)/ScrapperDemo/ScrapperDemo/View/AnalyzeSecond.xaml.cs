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

using ScrapperDemo.Classes;

namespace ScrapperDemo.View
{
    /// <summary>
    /// Interaction logic for AnalyzeSecond.xaml
    /// </summary>
    public partial class AnalyzeSecond : System.Windows.Controls.UserControl
    {
        public AnalyzeSecond()
        {
            InitializeComponent();
        }
        public string folderpath;
        private void BtnDirPath_Click(object sender, RoutedEventArgs e)
        {
            string startupPath = System.Windows.Forms.Application.StartupPath;
            folderpath = startupPath + "\\DefaultScrap\\";
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Open a folder which want to store scrapped file";
                dialog.ShowNewFolderButton = true;
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    lblStatus.Content = "Status: Start the process of scrapping";
                    folderpath = dialog.SelectedPath;

                }
            }
        }

        private void BtnStartScrappingURL_Click(object sender, RoutedEventArgs e)
        {
            bool flgok = false;


            lblStatus.Content = "Status: Start the process of scrapping";

            Uri uriResult;
            bool result = Uri.TryCreate(txtbxenterurl.Text.ToString(), UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
            if (!result)
            {

                System.Windows.MessageBox.Show("Incorrect URL : Please Enter URL Format like  http://sudarshannews.com", "Scrapper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else if (result)
            {
                if (folderpath == null || folderpath == "")
                {

                    System.Windows.MessageBox.Show("Please Choose Directory Path", "Scrapper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        lblStatus.Content = "Status: Please wait scrapplin URL is in process";
                        flgok = Classes.SecondScrapperAnalyze.SecondAnalyze(txtbxenterurl.Text.ToString(), folderpath);
                        this.Dispatcher.Invoke(new Action(() => { }), null);
                        UpdateLayout();
                        InvalidateVisual();
                    });


                }


            }

            if (flgok)
            {
                lblStatus.Content = "Status: URL scrapping is finished";
                System.Windows.MessageBox.Show("URL scrapping is finished", "Scrapper Demo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!flgok)
            {
                lblStatus.Content = "Status: URL is scrapping is failed";
                System.Windows.MessageBox.Show("URL is scrapping is failed", "Scrapper Demo", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
