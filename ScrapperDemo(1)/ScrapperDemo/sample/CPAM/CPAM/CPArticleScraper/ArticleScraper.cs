#define __USE_WEB__

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;

namespace CPArticleScraper
{
	public enum ArticleSource { CodeProject=0, TextFile=1 };

	public class ArticleScraper
	{
		private decimal m_averageRating = 0.0M;
		private decimal m_averagePopularity = 0.0M;
		private string m_userID = "";
		private ArticleSource m_articleSource = ArticleSource.CodeProject;
		private string m_sourceFileName = "";
		private List<ArticleUpdate> m_articles = new List<ArticleUpdate>();

		public decimal AverageRating			
		{ 
			get { return m_averageRating; } 
		}
		public decimal AveragePopularity		
		{ 
			get { return m_averagePopularity; } 
		}
		public string UserID				
		{ 
			get { return m_userID; }  
			set { m_userID = value; } 
		}
		public ArticleSource ArticleSource
		{
			get { return m_articleSource; }
			set { m_articleSource = value; }
		}
		public string SourceFileName
		{
			get { return m_sourceFileName; }
			set { m_sourceFileName = value; }
		}
		public List<ArticleUpdate> Articles	
		{ 
			get { return m_articles; } 
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Constructor
		/// </summary>
		public ArticleScraper()
		{
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="userID"></param>
		public ArticleScraper(string userID)
		{
			try
			{
				int numeric = Convert.ToInt32(userID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			m_userID = userID;
			m_articles.Clear();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Resets the user ID and clears the articles list
		/// </summary>
		/// <param name="userID"></param>
		public void Reset(string userID)
		{
			try
			{
				int numeric = Convert.ToInt32(userID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			m_userID = userID;
			m_articles.Clear();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Requests the article list page for the specified user ID, and marshals 
		/// calls to other functons that process the rerturned web page source.
		/// </summary>
		public void RetrieveArticles()
		{
			int userID;

			// see if we need to throw an exception
			if (this.UserID == "" || !Int32.TryParse(this.UserID, out userID))
			{
				throw new Exception("UserID is empty or invalid.");
			}
			if (m_articleSource == ArticleSource.TextFile && this.SourceFileName == "")
			{
				throw new Exception("Article source is set to text file, but not filename has been specified.");
			}
			if (m_articleSource == ArticleSource.TextFile && !File.Exists(this.SourceFileName))
			{
				throw new Exception(string.Format("Article source is set to text file, but the specified file ({0} does not exist.", this.SourceFileName));
			}

			// initialize
			string pageSource = "";

			// if our source is CodeProject, hit the web site
			if (this.ArticleSource == ArticleSource.CodeProject)
			{
				// this code actually hits the codeproject website
				string url = string.Format("http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid={0}", this.UserID);
				Uri uri = new Uri(url);
				WebClient webClient = new WebClient();
				string response = "";

				try
				{
					// added proxy support for those that need it - many thanks to Paul 
					// Conrad for pointing this out.
					webClient.Proxy = WebRequest.DefaultWebProxy;
					webClient.Proxy.Credentials = CredentialCache.DefaultCredentials;
					// get the web page
					response = webClient.DownloadString(uri);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				
				pageSource = response;
			}
			else
			{
				// this code loads a sample page source from a local text file
				StringBuilder builder = new StringBuilder("");
				string filename = System.IO.Path.Combine(Application.StartupPath, "MemberArticles.txt");

				StreamReader reader = null;
				try
				{
					reader = File.OpenText(filename);
					string input = null;
					while ((input = reader.ReadLine()) != null)
					{
						builder.Append(input);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					reader.Close();
				}
				pageSource = builder.ToString();
			}

			if (pageSource == "")
			{
				return;
			}

			int articleNumber = 0;
			bool found = true;

			while (found)
			{
				// establish our trigger points
				string articleStart = string.Format("<span id=\"ctl00_MC_AR_ctl{0}_MAS", string.Format("{0:00}", articleNumber));
				string articleEnd   = string.Format("<span id=\"ctl00_MC_AR_ctl{0}_MAS", string.Format("{0:00}", articleNumber + 1));

				// get the index of the start of the next article
				int startIndex = pageSource.IndexOf(articleStart);

				if (startIndex >= 0)
				{
					// delete everything that came before the starting index
					pageSource = pageSource.Substring(startIndex);
					startIndex = 0;

					// find the end of our articles data
					int endIndex = pageSource.IndexOf(articleEnd);

					// now we get the source string
					if (endIndex == -1)
					{
						endIndex = pageSource.IndexOf("<table");
						if (endIndex == -1)
						{
							endIndex = pageSource.Length - 1;
						}
					}

					// get the substring
					string data = pageSource.Substring(0, endIndex);

					// if we have data, process it
					if (data != "")
					{
						ProcessArticle(data, articleNumber);
					}
					else
					{
						found = false;
					}
					articleNumber++;
				}
				else
				{
					found = false;
				}
			} // while (found)

			CalculateAverages();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Calculates average rating and popularity.
		/// </summary>
		private void CalculateAverages()
		{
			if (m_articles.Count > 0)
			{
				decimal rating = 0.0M;
				decimal popularity = 0.0M;
				for (int i = 0; i < m_articles.Count; i++)
				{
					rating += Convert.ToDecimal(m_articles[i].Rating);
					popularity += Convert.ToDecimal(m_articles[i].Popularity);
				}
				this.m_averageRating = Convert.ToDecimal(rating / m_articles.Count);
				this.m_averagePopularity = Convert.ToDecimal(popularity / m_articles.Count);
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Processes the article data scraped from the html file we scraped 
		/// off CodeProject.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="articleNumber"></param>
		private void ProcessArticle(string data, int articleNumber)
		{
			string link	= GetArticleLink(data);
			data = CleanData(data);
			string[] parts = data.Split('^');
			string title = parts[0];
			string description = parts[7];
			string lastUpdated = GetDataField("Last Update", parts);
			string pageViews = GetDataField("Page Views", parts).Replace(",", "");
			string rating = GetDataField("Rating", parts);
			string votes = GetDataField("Votes", parts).Replace(",", "");
			string popularity = GetDataField("Popularity", parts);
			string bookmarks = GetDataField("Bookmark Count", parts);

			// create the AticleData item and add it to the list
			DateTime lastUpdatedDate;
			ArticleUpdate article = new ArticleUpdate();
			article.LatestLink = string.Format("http://www.codeproject.com{0}", link);
			article.LatestTitle = title;
			article.LatestDescription = description;
			if (DateTime.TryParse(lastUpdated, out lastUpdatedDate))
			{
				article.LatestLastUpdated = lastUpdatedDate;
			}
			else
			{
				article.LatestLastUpdated = new DateTime(1990, 1, 1);
			}
			article.LatestPageViews		= Convert.ToInt32(pageViews);
			article.LatestRating		= Convert.ToDecimal(rating);
			article.LatestVotes			= Convert.ToInt32(votes);
			article.LatestPopularity	= Convert.ToDecimal(popularity);
			article.LatestBookmarks		= Convert.ToInt32(bookmarks);
			AddOrChangeArticle(article);

		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Adds a new article, or changes the matching existing article.
		/// </summary>
		/// <param name="article"></param>
		private void AddOrChangeArticle(ArticleUpdate article)
		{
			bool found = false;
			DateTime now = DateTime.Now;

			// apply changes
			for (int i = 0; i < m_articles.Count; i++)
			{
				ArticleUpdate item = m_articles[i];
				if (item.LatestTitle.ToLower() == article.LatestTitle.ToLower())
				{
					found = true;
					item.ApplyChanges(article, now, false);
					break;
				}
			}

			// if the article was not found, it must be new (or the title has changed), 
			// so we'll add it
			if (!found)
			{
				article.ApplyChanges(article, now, true);
				m_articles.Add(article);
			}

			// remove all articles that weren't updated this time around - we need to 
			// traverse the list in reverse order so we don't lose track of our index
			for (int i = m_articles.Count - 1; i == 0; i--)
			{
				ArticleUpdate item = m_articles[i];
				if (item.TimeUpdated != now)
				{
					m_articles.RemoveAt(i);
				}
			}
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Gets the named data field from the specified array.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="parts"></param>
		/// <returns></returns>
		private string GetDataField(string name, string[] parts)
		{
			string result = "";

			for (int i = 0; i < parts.Length; i++)
			{
				if (parts[i].Trim().IndexOf(name.Trim()) >= 0)
				{
					int valueIndex = parts[i].IndexOf(":");
					if (valueIndex >= 0)
					{
						result = parts[i].Substring(valueIndex + 1).Trim();
					}
					break;
				}
			}

			return result;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Get's the article's url
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private string GetArticleLink(string data)
		{
			string result = data;
			int hrefIndex = result.IndexOf("href=\"") + 6;
			int endIndex = result.IndexOf("\">", hrefIndex);
			result = result.Substring(hrefIndex, endIndex - hrefIndex).Trim();
			return result;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Count the number of occurances of the specified character in the 
		/// specified string.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		private int CountChar(string data, char value)
		{
			int count = 0;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] == value)
				{
					count++;
				}
			}
			return count;
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Strip the html tags starting at the beginning of the string. This serves as an 
		/// attempt to filter out possibly errant &lt; and &gt; characters.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private string ForwardStrip(string data)
		{
			bool	found	= true;
			do
			{
				int tagStart = data.IndexOf("<");
				int tagEnd = data.IndexOf(">");
				if (tagEnd >= 0)
				{
					tagEnd += 1;
				}
				found = (tagStart >= 0 && tagEnd >= 0 && tagEnd-tagStart > 1);
				if (found)
				{
					string tag = data.Substring(tagStart, tagEnd - tagStart);
					data = data.Replace(tag, "");
				}
			} while (found);
			return data;
		}


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Strip the html tags starting at the end of the string. This serves as an attempt to 
		/// filter out possibly errant &lt; and &gt; characters.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private string BackwardStrip(string data)
		{
			bool	found	= true;
			do
			{
				int tagStart = data.LastIndexOf("<");
				int tagEnd = data.LastIndexOf(">");
				if (tagEnd >= 0)
				{
					tagEnd += 1;
				}
				found = (tagStart >= 0 && tagEnd >= 0 && tagEnd-tagStart > 1);
				if (found)
				{
					string tag = data.Substring(tagStart, tagEnd - tagStart);
					data = data.Replace(tag, "");
				}
			} while (found);
			return data;
		}

		//--------------------------------------------------------------------------------------
		/// <summary>
		/// Removes all HTML tags from the specifid string. WARNING: This is NOT an 
		/// exhaustive parser for HTML tags. If the article title and/or description 
		/// contain more than one pointy bracket, this method will be almost 
		/// guaranteed to return only a portion of the actual text of the item in 
		/// question.  If you like, you can google for (and use) one of the many 
		/// exhaustive HTML parsers available on the net.  IMHO, it's not worth the 
		/// effort considering this class' primary usage.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private string RemoveHtmlTags(string data)
		{
			int		ltCount	= CountChar(data, '<');
			int		gtCount	= CountChar(data, '>');

			// If the number of left and right pointy bracks are the same, we stand a 
			// reasonable chance that what we think are html tags really ARE html tags.
			if (ltCount == gtCount)
			{
				data = ForwardStrip(data);
			}
			else
			{
				// Otherwise, we have an errant pointy bracket, which we can almost 
				// always take care of depending on the order in which we search for 
				// tags.
				if (gtCount > ltCount)
				{
					data = BackwardStrip(ForwardStrip(data));
				}
				else
				{
					data = ForwardStrip(BackwardStrip(data));
				}
			}
			return data;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Removes tabs, extra spaces, and double delimiters. 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private string CleanData(string data)
		{
			// get rid of the HTML tags
			data = RemoveHtmlTags(data);

			// get rid of the crap that's left behind
			data = data.Replace("\t", "^").Replace("&nbsp;", "");
			data = data.Replace("\n","").Replace("\r", "");
			data = data.Replace(" / 5", "");
			while (data.IndexOf("  ") >= 0)
			{
				data = data.Replace("  ", " ");
			}
			while (data.IndexOf("^ ^") >= 0)
			{
				data = data.Replace("^ ^", "^");
			}
			while (data.IndexOf("^^") >= 0)
			{
				data = data.Replace("^^", "^");
			}
			data = data.Substring(1);
			data = data.Substring(0, data.Length - 1);
			return data;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Get the article with the most votes
		/// </summary>
		/// <returns></returns>
		public ArticleUpdate MostVotes()
		{
			ArticleUpdate article = null;
			for (int i = 0; i < m_articles.Count; i++)
			{
				if (article == null || article.Votes < m_articles[i].Votes)
				{
					article = m_articles[i];
				}
			}
			return article;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Get the article with the most page views
		/// </summary>
		/// <returns></returns>
		public ArticleUpdate MostViews()
		{
			ArticleUpdate article = null;
			for (int i = 0; i < m_articles.Count; i++)
			{
				if (article == null || article.PageViews < m_articles[i].PageViews)
				{
					article = m_articles[i];
				}
			}
			return article;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Get the most popular article
		/// </summary>
		/// <returns></returns>
		public ArticleUpdate MostPopular()
		{
			ArticleUpdate article = null;
			for (int i = 0; i < m_articles.Count; i++)
			{
				if (article == null || article.Popularity < m_articles[i].Popularity)
				{
					article = m_articles[i];
				}
			}
			return article;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Get the article with the most bookmarks
		/// </summary>
		/// <returns></returns>
		public ArticleUpdate MostBookmarks()
		{
			ArticleUpdate article = null;
			for (int i = 0; i < m_articles.Count; i++)
			{
				if (article == null || article.Bookmarks < m_articles[i].Bookmarks)
				{
					article = m_articles[i];
				}
			}
			return article;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Get the article with the best rating
		/// </summary>
		/// <returns></returns>
		public ArticleUpdate BestRating()
		{
			ArticleUpdate article = null;
			for (int i = 0; i < m_articles.Count; i++)
			{
				if (article == null || article.Rating < m_articles[i].Rating)
				{
					article = m_articles[i];
				}
			}
			return article;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Get the article with the worst rating
		/// </summary>
		/// <returns></returns>
		public ArticleUpdate WorstRating()
		{
			ArticleUpdate article = null;
			for (int i = 0; i < m_articles.Count; i++)
			{
				if (article == null || article.Rating > m_articles[i].Rating)
				{
					article = m_articles[i];
				}
			}
			return article;
		}
	}
}
