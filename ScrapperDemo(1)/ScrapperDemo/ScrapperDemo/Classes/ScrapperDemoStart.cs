using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Zeta.WebSpider.Spider;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace ScrapperDemo.Classes
{
    public class ScrapperDemoStart
    {

       static int urlfinishedcount = 0;
        public static void FirstAnalyzed(String WebUri, String DirPath)
        {
            urlfinishedcount = 0;
            finished = false;

            WebSiteDownloaderOptions options =
                new WebSiteDownloaderOptions();

            //options.DownloadUri =
            //    new Uri(@"http://sudarshannews.com/");
            //options.DestinationFolderPath =
            //    new DirectoryInfo(@"C:\Users\SATWADHIR PAWAR\Desktop\scrap");


            options.DownloadUri =
               new Uri(WebUri);
            options.DestinationFolderPath =
                new DirectoryInfo(DirPath);

            WebSiteDownloader downloader =
                new WebSiteDownloader(options);

            downloader.ProcessingUrl +=
                new WebSiteDownloader.ProcessingUrlEventHandler(
                downloader_ProcessingUrl);

            downloader.ProcessCompleted +=
                new WebSiteDownloader.ProcessCompletedEventHandler(
                downloader_ProcessCompleted);

            downloader.ProcessAsync();

            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine(@".");

                urlfinishedcount += 1;

                if (urlfinishedcount == 200)
                {
                    urlfinishedcount = 0;
                    finished = true;
                }

                lock (typeof(ScrapperDemoStart))
                {
                    if (finished)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(@"finished.");

        
        }//End FirstAnalyze

        public static bool FirstAnalyze(String WebUri, String DirPath)
        {
            urlfinishedcount = 0;
            finished = false;

            WebSiteDownloaderOptions options =
                new WebSiteDownloaderOptions();

            //options.DownloadUri =
            //    new Uri(@"http://sudarshannews.com/");
            //options.DestinationFolderPath =
            //    new DirectoryInfo(@"C:\Users\SATWADHIR PAWAR\Desktop\scrap");


            options.DownloadUri =
               new Uri(WebUri);
            options.DestinationFolderPath =
                new DirectoryInfo(DirPath);

            WebSiteDownloader downloader =
                new WebSiteDownloader(options);

            downloader.ProcessingUrl +=
                new WebSiteDownloader.ProcessingUrlEventHandler(
                downloader_ProcessingUrl);

            downloader.ProcessCompleted +=
                new WebSiteDownloader.ProcessCompletedEventHandler(
                downloader_ProcessCompleted);

            downloader.ProcessAsync();

            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine(@".");
                
                    urlfinishedcount += 1;

                if (urlfinishedcount == 200)
                {
                    urlfinishedcount = 0;
                    finished = true;
                }

                lock (typeof(ScrapperDemoStart))
                {
                    if (finished)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(@"finished.");

            return finished;
        }//End FirstAnalyze


        private static void downloader_ProcessingUrl(
            object sender,
            WebSiteDownloader.ProcessingUrlEventArgs e)
        {
            Console.WriteLine(
                string.Format(
                @"Processing URL '{0}'.", e.UriInfo.AbsoluteUri));            
        }


        public static bool finished;

        private static void downloader_ProcessCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine(@"Error: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                Console.WriteLine(@"Canceled");
            }
            else
            {
                Console.WriteLine(@"Success");
            }

            lock (typeof(ScrapperDemoStart))
            {
                finished = true;
            }
        }

    }



    public class SecondScrapperAnalyze
    {

        static int urlfinishedcount = 0;
       
        public static void SecondAnalyzed(String WebUri, String DirPath)
        {
            urlfinishedcount = 0;
            finished = false;
            WebSiteDownloaderOptions options =
                new WebSiteDownloaderOptions();

            //options.DownloadUri =
            //    new Uri(@"http://sudarshannews.com/");
            //options.DestinationFolderPath =
            //    new DirectoryInfo(@"C:\Users\SATWADHIR PAWAR\Desktop\scrap");


            options.DownloadUri =
               new Uri(WebUri);
            options.DestinationFolderPath =
                new DirectoryInfo(DirPath);

            WebSiteDownloader downloader =
                new WebSiteDownloader(options);

            downloader.ProcessingUrl +=
                new WebSiteDownloader.ProcessingUrlEventHandler(
                downloader_ProcessingUrl);

            downloader.ProcessCompleted +=
                new WebSiteDownloader.ProcessCompletedEventHandler(
                downloader_ProcessCompleted);

            downloader.ProcessAsync();

            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine(@".");

                urlfinishedcount += 1;

                if (urlfinishedcount == 200)
                {
                    urlfinishedcount = 0;
                    finished = true;
                }

                lock (typeof(ScrapperDemoStart))
                {
                    if (finished)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(@"finished.");

          
        }//End FirstAnalyze

        public static bool SecondAnalyze(String WebUri, String DirPath)
        {
            urlfinishedcount = 0;
            finished = false;
            WebSiteDownloaderOptions options =
                new WebSiteDownloaderOptions();

            //options.DownloadUri =
            //    new Uri(@"http://sudarshannews.com/");
            //options.DestinationFolderPath =
            //    new DirectoryInfo(@"C:\Users\SATWADHIR PAWAR\Desktop\scrap");


            options.DownloadUri =
               new Uri(WebUri);
            options.DestinationFolderPath =
                new DirectoryInfo(DirPath);

            WebSiteDownloader downloader =
                new WebSiteDownloader(options);

            downloader.ProcessingUrl +=
                new WebSiteDownloader.ProcessingUrlEventHandler(
                downloader_ProcessingUrl);

            downloader.ProcessCompleted +=
                new WebSiteDownloader.ProcessCompletedEventHandler(
                downloader_ProcessCompleted);

            downloader.ProcessAsync();

            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine(@".");

                urlfinishedcount += 1;

                if (urlfinishedcount == 200)
                {
                    urlfinishedcount = 0;
                    finished = true;
                }

                lock (typeof(ScrapperDemoStart))
                {
                    if (finished)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(@"finished.");

            return finished;
        }//End FirstAnalyze


        private static void downloader_ProcessingUrl(
            object sender,
            WebSiteDownloader.ProcessingUrlEventArgs e)
        {
            Console.WriteLine(
                string.Format(
                @"Processing URL '{0}'.", e.UriInfo.AbsoluteUri));
        }


        public static bool finished;

        private static void downloader_ProcessCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine(@"Error: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                Console.WriteLine(@"Canceled");
            }
            else
            {
                Console.WriteLine(@"Success");
            }

            lock (typeof(ScrapperDemoStart))
            {
                finished = true;
            }
        }

    }



}
