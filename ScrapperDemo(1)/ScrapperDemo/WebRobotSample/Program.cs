using System;
using Zeta.WebSpider.Spider;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace WebSpiderTest
{
	public class Program
	{


        public static bool RunTheFirstAnalyze(string url, string folderpath)
        {

            WebSiteDownloaderOptions options =
                new WebSiteDownloaderOptions();

            options.DownloadUri =
                new Uri(url);
            options.DestinationFolderPath =
                new DirectoryInfo(folderpath);

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
                Thread.Sleep(1000);
                Console.WriteLine(@".");

                lock (typeof(Program))
                {
                    if (finished)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(@"finished.");

            return finished;
        }

		private static void Main( string[] args )
		{
			WebSiteDownloaderOptions options =
				new WebSiteDownloaderOptions();

			options.DownloadUri =
                new Uri(@"http://www.cadfolks.com");  
			options.DestinationFolderPath =
                new DirectoryInfo(@"F:\demo");

			WebSiteDownloader downloader =
				new WebSiteDownloader( options );

			downloader.ProcessingUrl +=
				new WebSiteDownloader.ProcessingUrlEventHandler(
				downloader_ProcessingUrl );

			downloader.ProcessCompleted +=
				new WebSiteDownloader.ProcessCompletedEventHandler(
				downloader_ProcessCompleted );

			downloader.ProcessAsync();

			while ( true )
			{
				Thread.Sleep( 1000 );
				Console.WriteLine( @"." );

				lock ( typeof( Program ) )
				{
					if ( finished )
					{
						break;
					}
				}
			}

			Console.WriteLine( @"finished." );
		}



		private static void downloader_ProcessingUrl(
			object sender,
			WebSiteDownloader.ProcessingUrlEventArgs e )
		{
			Console.WriteLine( 
				string.Format(
				@"Processing URL '{0}'.", e.UriInfo.AbsoluteUri ) );
		}

		private static bool finished;

		private static void downloader_ProcessCompleted(
			object sender,
			RunWorkerCompletedEventArgs e )
		{
			if ( e.Error != null )
			{
				Console.WriteLine( @"Error: " + e.Error.Message );
			}
			else if ( e.Cancelled )
			{
				Console.WriteLine( @"Canceled" );
			}
			else
			{
				Console.WriteLine( @"Success" );
			}

			lock ( typeof( Program ) )
			{
				finished = true;
			}
		}
	}
}
