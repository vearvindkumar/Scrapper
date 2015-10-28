using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;

using Scheduler;
using CPArticleScraper;

namespace CPAM
{
	public partial class Form1 : Form
	{
		private List<ArticleUpdate> m_articles			= new List<ArticleUpdate>();
		private BackgroundWorker	m_scraperThread		= null;
		private ArticleScraper		m_articleScraper	= null;
		private string				m_windowTitle		= "";
		private string				m_currentUserID		= "7741";
		private int					m_articlesDisplayed	= 0;

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Constructor
		/// </summary>
		public Form1()
		{
			InitializeComponent();

			this.textboxUserID.Text = this.m_currentUserID;

			ExtractResourceImages();

			ToggleScraperThread();
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Form initialization
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			// by default, show the newest articles
			this.comboBox1.SelectedIndex		= 2; // Last Updated
			this.checkboxSortDescending.Checked = true;  

			this.checkAutoRefresh.Checked		= true;
			this.checkShowIcons.Checked			= true;
			this.checkNewInfo.Checked			= false;
			m_windowTitle						= this.Text;
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// The m_scraper background worker is finised
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void m_scraper_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// The m_scraper background worker is reporting progress - it's time to get 
		/// new data and refresh the display.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void m_scraper_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			UpdateDisplay();
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// The m_scraper background worker is starting its work.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void m_scraper_DoWork(object sender, DoWorkEventArgs e)
		{
			Scheduler.DateCompareState compareState;
			BackgroundWorker		worker		= sender as BackgroundWorker;
			Scheduler.ScheduleMode	mode		= ScheduleMode.Hourly;
			TimeSpan				span		= new TimeSpan(0,0,0,0,0);
			DateTime				nextTime	= DateTime.Now;
			bool					virginStart	= true;
			int						tick		= 0;
			int						sleepTime	= 250;
			int						checkAt		= 1000;

			while (!worker.CancellationPending)
			{
				if (!virginStart)
				{
					nextTime = Scheduler.DateScheduler.CalculateNextTriggerTime(nextTime, span, mode);
					tick = 0;
					while (!worker.CancellationPending)
					{
						// if it's time to compare the times
						if (tick % checkAt == 0)
						{
							// compare the time
							compareState =  DateScheduler.CompareDates(DateTime.Now, nextTime);

							// set our tick monitor to 0
							tick = 0;

							// if the dates are equal, break out of this while loop
							if (compareState == DateCompareState.Equal)
							{
								break;
							}
						}

						// sleep
						Thread.Sleep(sleepTime);

						// and keep track of how long we slept
						tick += sleepTime;
					}
				}

				// we're no longer a virgin
				virginStart = false;

				// update the display
				if (!worker.CancellationPending)
				{
					worker.ReportProgress(0);
				}
			}

		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// User clicked the refresh button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			UpdateDisplay();
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// The user clicked the Sort button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonSort_Click(object sender, EventArgs e)
		{
			SortList();
			this.webBrowser1.Navigate("about:blank");
			HtmlDocument doc = this.webBrowser1.Document;
			doc.Write(string.Empty);
			this.webBrowser1.DocumentText = BuildHtml();
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// The form's size has changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_SizeChanged(object sender, EventArgs e)
		{
			//int formHeight = this.ClientRectangle.Height;
			//int formWidth = this.ClientRectangle.Width; 
			//panel1.Width = formWidth - 24;
			//panel1.Height = formHeight - 42;
		}

		private void checkAutoRefresh_CheckedChanged(object sender, EventArgs e)
		{
			ToggleScraperThread();
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Extracts the icon images from the resources into the current folder.
		/// </summary>
		private void ExtractResourceImages()
		{
			//ResourceManager rm = new ResourceManager("CPAM.Properties.Resources", Assembly.GetExecutingAssembly());
			ResourceManager rm = new ResourceManager("CPAM.Resource1", Assembly.GetExecutingAssembly());
			ExtractBinaryFile(rm, "up.png");
			ExtractBinaryFile(rm, "down.png");
			ExtractBinaryFile(rm, "mostvotes.png");
			ExtractBinaryFile(rm, "mostpopular.png");
			ExtractBinaryFile(rm, "mostviews.png");
			ExtractBinaryFile(rm, "mostbookmarks.png");
			ExtractBinaryFile(rm, "bestrating.png");
			ExtractBinaryFile(rm, "worstrating.png");
			ExtractBinaryFile(rm, "new.png");
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Extracts the specified file from the resources to a fle on the disk, 
		/// but only if it doesn't already exist.
		/// </summary>
		/// <param name="rm"></param>
		/// <param name="fileName"></param>
		private void ExtractBinaryFile(ResourceManager rm, string fileName)
		{
			string resourceFile = System.IO.Path.Combine(Application.StartupPath, fileName);
			if (!File.Exists(resourceFile))
			{
				string resourceName = System.IO.Path.GetFileNameWithoutExtension(fileName);
				try
				{
					Image img = (Image)rm.GetObject(resourceName);
					img.Save(resourceFile);
				}
				catch (Exception ex)
				{
				    throw ex;
				}
			}
		}


		//////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////

		private void InitScraperThread()
		{
			m_scraperThread			 = new BackgroundWorker();
			m_scraperThread.WorkerReportsProgress		 = true;
			m_scraperThread.WorkerSupportsCancellation	 = true;
			m_scraperThread.DoWork						+= new DoWorkEventHandler(m_scraper_DoWork);
			m_scraperThread.ProgressChanged				+= new ProgressChangedEventHandler(m_scraper_ProgressChanged);
			m_scraperThread.RunWorkerCompleted			+= new RunWorkerCompletedEventHandler(m_scraper_RunWorkerCompleted);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		///  Tggles the scraper thread on and off, depending on its current state.
		/// </summary>
		private void ToggleScraperThread()
		{
			if (m_scraperThread == null)
			{
				InitScraperThread();
			}
			if (m_scraperThread != null)
			{
				if (this.checkAutoRefresh.Checked)
				{
					if (m_scraperThread.IsBusy)
					{
						m_scraperThread.CancelAsync();
						Thread.Sleep(1000);
					}
					m_scraperThread.RunWorkerAsync();
				}
				else
				{
					if (m_scraperThread.IsBusy)
					{
						m_scraperThread.CancelAsync();
					}
				}
			}
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Common function that retrieves the latest articles, and displays them 
		/// in a web browser control
		/// </summary>
		private void UpdateDisplay()
		{
			if (m_currentUserID == "")
			{
				m_currentUserID = this.textboxUserID.Text;
			}
			if (m_currentUserID == "")
			{
				MessageBox.Show("Can't use a null userID.", "UserID Error");
				return;
			}

			try
			{
				if (m_articleScraper == null)
				{
					m_articleScraper = new ArticleScraper(m_currentUserID);
				}
				if (this.textboxUserID.Text != m_currentUserID)
				{
					m_currentUserID = this.textboxUserID.Text;
					m_articleScraper.Reset(m_currentUserID);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("{0}\n\n{1}", ex.Message, ex.InnerException));
				return;
			}
			this.Text	= string.Format("{0} - Scraping!", m_windowTitle);
			this.Cursor	= Cursors.WaitCursor;
			m_articleScraper.RetrieveArticles();
			m_articles = m_articleScraper.Articles;
			if (m_articles.Count > 1)
			{
				SortList();
			}
			this.webBrowser1.Navigate("about:blank");
			HtmlDocument doc = this.webBrowser1.Document;
			doc.Write(string.Empty);
			this.webBrowser1.DocumentText = BuildHtml();

			this.Text							= string.Format("{0} - Last Update: {1}", m_windowTitle, DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
			this.labelArticleCount.Text			= m_articles.Count.ToString();
			this.labelAvgRating.Text			= string.Format("{0:0.00}", m_articleScraper.AverageRating);
			this.labelAvgPopularity.Text		= string.Format("{0:0.00}", m_articleScraper.AveragePopularity);
			this.labelArticlesDisplayed.Text	= m_articlesDisplayed.ToString();

			this.Cursor							= Cursors.Default;
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		///  Sets the sort direction (ascending or descending) for when the Sort 
		///  button is pressed.
		/// </summary>
		private void SetCurrentSortDirection()
		{
			bool sortAscending = !this.checkboxSortDescending.Checked;
			for (int i = 0; i < m_articles.Count; i++)
			{
				m_articles[i].SortAscending = sortAscending;
			}
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Sorts the list according to the selected column and sort order.
		/// </summary>
		private void SortList()
		{
			SetCurrentSortDirection();
			int index = comboBox1.SelectedIndex;
			string text = comboBox1.Items[index].ToString();
			switch (text)
			{
				case "Page Views":	
					{ 
						m_articles.Sort(ArticleUpdate.LatestPageViewsCompare); 
					} 
					break; 

				case "Votes":	
					{ 
						m_articles.Sort(ArticleUpdate.LatestVotesCompare); 
					} 
					break;

				case "Rating":	
					{ 
						m_articles.Sort(ArticleUpdate.LatestRatingCompare); 
					} 
					break;

				case "Popularity":	
					{ 
						m_articles.Sort(ArticleUpdate.LatestPopularityCompare); 
					} 
					break;

				case "Bookmarked":	
					{ 
						m_articles.Sort(ArticleUpdate.LatestBookmarksCompare); 
					} 
					break;

				case "Title":	
					{ 
						m_articles.Sort(ArticleUpdate.LatestTitleCompare); 
					} 
					break;

				case "Last Updated":	
					{ 
						m_articles.Sort(ArticleUpdate.LatestLastUpdatedCompare); 
					} 
					break;
			}
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Builds the html displayed in the web browser control.
		/// </summary>
		/// <returns></returns>
		private string BuildHtml()
		{
			StringBuilder builder = new StringBuilder("");
			if (m_articles.Count > 0)
			{
				builder.Append("<html>");
				builder.Append("<head>");
				builder.AppendFormat("<link rel='stylesheet' type='text/css' href=\"{0}\" />", System.IO.Path.Combine(Application.StartupPath, "cpam.css"));
				builder.Append("</head>");
				builder.Append("<body>\n");
				builder.Append("	<table class='articleTable' cellpadding='3'>");
				builder.Append("		<tr class='headerRow'>");
				builder.Append("			<th>Article</th>");
				builder.Append("			<th>Last Updated</th>");
				builder.Append("			<th>Rating</th>");
				builder.Append("			<th>Votes</th>");
				builder.Append("			<th>Views</th>");
				builder.Append("			<th>Popularity</th>");
				builder.Append("			<th>Bookmarked</th>");
				builder.Append("		</tr>");

				int articleNumber = 0;
				for (int i = 0; i < m_articles.Count; i++)
				{
					bool newInfo = (m_articles[i].Changed || m_articles[i].NewArticle);
					bool displayArticle = ((!this.checkNewInfo.Checked) || (this.checkNewInfo.Checked && newInfo));
					if (displayArticle)
					{
						builder.Append(BuildArticleRow(i, articleNumber));
						articleNumber++;
					}
				}
				m_articlesDisplayed = articleNumber;

				builder.Append("	</table>");
				builder.Append("</body>");
				builder.Append("</html>");

			}
			else
			{
				builder.Append("<html><body style='font-family:arial;'>");
				builder.Append("No articles found. CodeProject might be temporarily unavailable.");
				builder.Append("</body></html>");
			}
			return builder.ToString();
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Constructs the table row that displays the specified article's data.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		private string BuildArticleRow(int index, int articleNumber)
		{
			ArticleUpdate article = m_articles[index];

			// retrieve the data here so we can keep the AppendFormat statements short
			string title		= article.LatestTitle;
			string link			= article.LatestLink;
			string description	= article.LatestDescription;
			string updated		= article.LatestLastUpdated.ToString("yyyy/MM/dd");
			string rating		= string.Format("{0:0.00}",	article.LatestRating);
			string votes		= string.Format("{0:#,0}",	article.LatestVotes);
			string views		= string.Format("{0:#,0}",	article.LatestPageViews);
			string popularity	= string.Format("{0:0.00}",	article.LatestPopularity);
			string bookmarks	= string.Format("{0:#,0}",	article.LatestBookmarks);

			string oldRating	= string.Format("{0:0.00}",	article.Rating);
			string oldVotes		= string.Format("{0:#,0}",	article.Votes);
			string oldViews		= string.Format("{0:#,0}",	article.PageViews);
			string oldPopularity= string.Format("{0:0.00}",	article.Popularity);
			string oldBookmarks	= string.Format("{0:#,0}",	article.Bookmarks);

			StringBuilder row	= new StringBuilder("");

			// set our row color
			string rowColor = rowColor = (index == 0 || index % 2 == 0) ? "white" : "#EEE";
			bool articleChanged = (article.PropertyChanged("Votes")		|| 
									article.PropertyChanged("Bookmarks")	|| 
									article.PropertyChanged("PageViews")  ||
									article.NewArticle);
			if (articleChanged)
			{
				rowColor = (articleNumber == 0 || articleNumber % 2 == 0) ? "lightcyan" : "lightblue";
			}

			StringBuilder icons = new StringBuilder("");
			string baseDir = Application.StartupPath;
			string sizeTag = "";
			// if we're showing the icons, get the appropriate icon for the article (if any)
			if (checkShowIcons.Checked)
			{
				if (article.NewArticle)
				{
					icons.AppendFormat("<img src='{0}' {1} alt='New article' border='0'/>", 
										System.IO.Path.Combine(baseDir, "new.png"), sizeTag);
				}
				if (article == m_articleScraper.BestRating())
				{
					icons.AppendFormat("<img src='{0}' {1} alt='Highest rated article' border='0'/>", 
										System.IO.Path.Combine(baseDir, "bestrating.png"), sizeTag);
				}
				else
				{
					if (article == m_articleScraper.WorstRating())
					{
						icons.AppendFormat("<img src='{0}' {1} alt='Lowest rated article' border='0'/>", 
											System.IO.Path.Combine(baseDir, "worstrating.png"), sizeTag);
					}
				}
				if (article == m_articleScraper.MostPopular())
				{
					icons.AppendFormat("<img src='{0}' {1} alt='Most popular article' border='0'/>", 
										System.IO.Path.Combine(baseDir, "mostpopular.png"), sizeTag);
				}
				if (article == m_articleScraper.MostViews())
				{
					icons.AppendFormat("<img src='{0}' {1} alt='Most viewed article' border='0'/>", 
										System.IO.Path.Combine(baseDir, "mostviews.png"), sizeTag);
				}
				if (article == m_articleScraper.MostBookmarks())
				{
					icons.AppendFormat("<img src='{0}' {1} alt='Most bookmarked article' border='0'/>", 
										System.IO.Path.Combine(baseDir, "mostbookmarks.png"), sizeTag);
				}
				if (article == m_articleScraper.MostVotes())
				{
					icons.AppendFormat("<img src='{0}' {1} alt='Most voted article' border='0'/>", 
										System.IO.Path.Combine(baseDir, "mostvotes.png"), sizeTag);
				}
			}
			if (icons.Length > 0)
			{
				icons.Append("<br />");
			}

			// build the row
			row.AppendFormat("<tr style='background-color:{0};border: 1px solid {0};height:50px;'>\n", rowColor);
			row.Append      ("	<td style='padding-right:26px;'>");
			row.AppendFormat("				{0}", icons);
			row.AppendFormat("              <a href='{0}'><span><b>{1}</span></a></b>", link, title);
			row.AppendFormat("				<br /><span class='descText'>{0}</td>", description);
			row.AppendFormat("	<td style='width:90px;text-align:center;'>{0}</td>", updated);
			row.AppendFormat("	<td style='width:80px;text-align:center;'>{0}</td>", GetItemDiv(article.HowChanged("Rating"), oldRating, rating));
			row.AppendFormat("	<td style='width:90px;text-align:center;'>{0}</td>", GetItemDiv(article.HowChanged("Votes"), oldVotes, votes));
			row.AppendFormat("	<td style='width:95px;text-align:center;vertical-align:middle;'>{0}</td>", GetItemDiv(article.HowChanged("PageViews"), oldViews, views));
			row.AppendFormat("	<td style='width:80px;text-align:center;'>{0}</td>", GetItemDiv(article.HowChanged("Popularity"), oldPopularity, popularity));
			row.AppendFormat("	<td style='width:90px;text-align:center;'>{0}</td>", GetItemDiv(article.HowChanged("Bookmarks"), oldBookmarks, bookmarks));
			row.Append      ("</tr>");

			return row.ToString();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Builds the image part of the contents of a cell
		/// </summary>
		/// <param name="changeType"></param>
		/// <returns></returns>
		private string GetImageDiv(ChangeType changeType)
		{
			StringBuilder div = new StringBuilder("");
			string img = "";
			switch (changeType)
			{
				case ChangeType.Up:
					{
						img = System.IO.Path.Combine(Application.StartupPath, "up.png");
					}
					break;
				case ChangeType.Down:
					{
						img = System.IO.Path.Combine(Application.StartupPath, "down.png");
					}
					break;
			}

			if (img != "")
			{
				div.AppendFormat("<div style='float:left;line-height;64px;'><img src='{0}' alt='' border='0'></div><div class='spacerHorz'>", img);
			}

			return div.ToString();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Builds the cell item div
		/// </summary>
		/// <param name="changeType"></param>
		/// <param name="oldValue"></param>
		/// <param name="newValue"></param>
		/// <returns></returns>
		private string GetItemDiv(ChangeType changeType, string oldValue, string newValue)
		{
			StringBuilder div = new StringBuilder("");
			string imageDiv = GetImageDiv(changeType);
			string oldValueStr = (imageDiv != "") ? string.Format("<br/>({0})", oldValue) : "";
			string newValueStr = string.Format("{0}", newValue);

			div.AppendFormat("<div>{0}", imageDiv);

			div.AppendFormat("<div style='float:Left;line-height:{2}px;margin-left:{3}px;'>{0}{1}</div>", 
							newValueStr, 
							oldValueStr, 
							(oldValueStr != "") ? "16" : "64",
							(oldValueStr != "") ? "5"  : "15");

			if (imageDiv != "")
			{
				div.Append("<div class='clearDiv'></div>");
			}

			div.Append("</div>");
			return div.ToString();
		}

	}
}
