#define __USE_WEB__

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Net;

namespace CPAM
{
	public partial class Service1 : ServiceBase
	{
		public class ArticleData
		{
			public string m_title;
			public string m_link;
			public string m_description;
			public DateTime m_lastUpdated;
			public int m_pageViews;
			public double m_rating;
			public int m_votes;
			public double m_popularity;
			public int m_bookmarks;
			public bool m_changed;

			public bool ApplyChanges(ArticleData item)
			{
				bool changed = (this.m_title		!= item.m_title			||
								this.m_link			!= item.m_link			||
								this.m_description	!= item.m_description	||
								this.m_pageViews	!= item.m_pageViews		||
								this.m_rating		!= item.m_rating		||
								this.m_votes		!= item.m_votes			||
								this.m_popularity	!= item.m_popularity	||
								this.m_bookmarks	!= item.m_bookmarks);
				if (changed)
				{
					this.m_title		= item.m_title;
					this.m_link			= item.m_link;
					this.m_description	= item.m_description;
					this.m_pageViews	= item.m_pageViews;
					this.m_rating		= item.m_rating;
					this.m_votes		= item.m_votes;
					this.m_popularity	= item.m_popularity;
					this.m_bookmarks	= item.m_bookmarks;
					this.m_changed      = true;
				}
				else
				{
					this.m_changed = false;
				}
				return changed;
			}

		}
		List<ArticleData> m_articles = new List<ArticleData>();

		//--------------------------------------------------------------------------------
		public Service1()
		{
			InitializeComponent();
		}

		//--------------------------------------------------------------------------------
		protected override void OnStart(string[] args)
		{
			// TODO: Add code here to start your service.
		}

		//--------------------------------------------------------------------------------
		protected override void OnStop()
		{
			// TODO: Add code here to perform any tear-down necessary to stop your service.
		}

		//--------------------------------------------------------------------------------
		private void GetMyArticlesPage()
		{
			string pageSource = "";

#if __USE_WEB__

			// this code actually hits the codeproject website
			string url = "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7741";
			Uri uri = new Uri(url);
			WebClient webClient = new WebClient();
			string response = "";
			try
			{
				response = webClient.DownloadString(uri);
			}
			catch (Exception e)
			{
				if (e != null) { }
			}
			pageSource = response;

#else
			// this code loads a sample page source from a local text file
			StringBuilder builder = new StringBuilder("");
			string filename = System.IO.Path.Combine(Environment.CurrentDirectory, "MemberArticles.txt");
			StreamReader re = File.OpenText(filename);
			string input = null;
			while ((input = re.ReadLine()) != null)
			{
			    builder.Append(input);
			}
			re.Close();
			pageSource = builder.ToString();

#endif

			int articleCount = 0;
			int index = 0;
			bool found = true;
			while (found)
			{
				// establish our trigger points
				string articleTitle = string.Format("<div id=\"ctl00_MC_AR_ctl{0}_MAS", string.Format("{0:000}", 100 + articleCount));
				string articleData  = string.Format("<div id=\"ctl00_MC_AR_ctl{0}_SbD", string.Format("{0:000}", 100 + articleCount));
				string articleBookmarks  = string.Format("<span id=\"ctl00_MC_AR_ctl{0}_BCS", string.Format("{0:000}", 100 + articleCount));
				string articleDesc = "<div style=";
				string articleEnd = string.Format("<div id=\"ctl00_MC_AR_ctl{0}_MAS", string.Format("{0:000}", 100 + articleCount + 1));

				// now find each one
				int titleIndex = pageSource.IndexOf(articleTitle, index);

				// now delete everything that came before the title
				pageSource = pageSource.Substring(titleIndex);

				// and set titleIndex to 0
				titleIndex = 0;

				// now find the rest with the new (much shorter) source string
				int dataIndex		= pageSource.IndexOf(articleData, titleIndex + articleTitle.Length);
				int bookmarksIndex	= pageSource.IndexOf(articleBookmarks, dataIndex + articleData.Length);
				int descIndex		= pageSource.IndexOf(articleDesc, bookmarksIndex + articleBookmarks.Length);
				int endIndex		= pageSource.IndexOf(articleEnd, descIndex + articleDesc.Length);


				// now we get the source string
				string data = "";
				if (endIndex == -1)
				{
					endIndex = pageSource.Length;
				}
				pageSource.Substring(titleIndex, endIndex);

				if (data != "")
				{
					ProcessSpan(data, titleIndex, dataIndex, bookmarksIndex, descIndex);
				}
				else
				{
					found = false;
				}
			}
		}

		//--------------------------------------------------------------------------------
		private void ProcessSpan(string source, int titleIndex, int dataIndex, int bookmarksIndex, int descIndex)
		{
			string title		= "";
			string description	= "";
			string data			= "";
			string link			= "";
			string bookmarks	= "";

			string lastUpdated = "";
			DateTime lastUpdatedDate;
			string pageViews = "";
			string rating = "";
			string votes = "";
			string popularity = "";

			// get the big parts
			link		= GetArticleLink(source.Substring(titleIndex, dataIndex - 1));
			title		= RemoveHtmlTags(source.Substring(titleIndex, dataIndex - 1));
			data		= RemoveHtmlTags(source.Substring(dataIndex, bookmarksIndex - 1)).Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Replace("\n", "^").Trim();
			bookmarks	= RemoveHtmlTags(source.Substring(bookmarksIndex, descIndex - 1)).Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Replace("\n", "^").Replace(",","").Replace("Bookmark Count: ","").Trim();
			description	= RemoveHtmlTags(source.Substring(descIndex));

			// parse the data into separate fields
			string[] parts = data.Split('^');
			lastUpdated = GetDataField("LastUpdate", parts);
			pageViews = GetDataField("PageViews", parts).Replace(",", "");
			rating = GetDataField("rating", parts);
			votes = GetDataField("Votes", parts).Replace(",","");
			popularity = GetDataField("Popularity", parts);

			// create the AticleData item and add it to the list
			ArticleData article = new ArticleData();
			article.m_link = link;
			article.m_title = title;
			article.m_description = description;
			if (DateTime.TryParse(lastUpdated, out lastUpdatedDate))
			{
				article.m_lastUpdated = lastUpdatedDate;
			}
			else
			{
				article.m_lastUpdated = new DateTime(1990, 1, 1);
			}
			article.m_pageViews		= Convert.ToInt32(pageViews);
			article.m_rating		= Convert.ToDouble(rating);
			article.m_votes			= Convert.ToInt32(votes);
			article.m_popularity	= Convert.ToDouble(popularity);
			article.m_bookmarks		= Convert.ToInt32(bookmarks);
			article.m_changed		= false;
			AddOrChangeArticle(article);
		}

		//--------------------------------------------------------------------------------
		private void AddOrChangeArticle(ArticleData article)
		{
			bool found = false;
			for (int i = 0; i < m_articles.Count; i++)
			{
				ArticleData item = m_articles[i];
				if (item.m_title == article.m_title)
				{
					found = true;
					item.ApplyChanges(article);
					break;
				}
			}
			if (!found)
			{
				m_articles.Add(article);
			}
		}

		//--------------------------------------------------------------------------------
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
						result = parts[i].Substring(valueIndex + 1);
					}
					break;
				}
			}

			return result;
		}

		//--------------------------------------------------------------------------------
		private string GetArticleLink(string data)
		{
			string result = data;
			int hrefIndex = result.IndexOf("href=\"" + 6);
			int endIndex = result.IndexOf("\">");
			result = result.Substring(hrefIndex, endIndex - hrefIndex).Trim();
			return result;
		}

		//--------------------------------------------------------------------------------
		private string RemoveHtmlTags(string data)
		{
			string result = data;
			bool found = true;
			do
			{
				int tagStart = result.IndexOf("<");
				int tagEnd = result.IndexOf(">");
				found = (tagStart >= 0 && tagEnd >= 0 && tagEnd-tagStart > 1);
				if (found)
				{
					result = result.Substring(tagStart+1, tagEnd - tagStart);
				}
			} while (found);
			return result;
		}
	}
}
