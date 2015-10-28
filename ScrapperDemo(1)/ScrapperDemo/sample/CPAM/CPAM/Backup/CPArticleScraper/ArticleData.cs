using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPArticleScraper
{
	// for help soring a generic list, I went here:
	// http://dotnetslackers.com/Community/blogs/simoneb/archive/2007/06/20/How-to-sort-a-generic-List_3C00_T_3E00_.aspx
	public class ArticleData : IComparable<ArticleData>
	{
		#region data members
		protected string		m_title			= "";
		protected string		m_link			= "";
		protected string		m_description	= "";
		protected DateTime		m_lastUpdated	= new DateTime(0);
		protected int			m_pageViews		= 0;
		protected int			m_votes			= 0;
		protected decimal		m_rating		= 0.0M;
		protected decimal		m_popularity	= 0.0M;
		protected int			m_bookmarks		= 0;
		protected bool		m_sortAscending	= true;
		#endregion data members

		#region properties
		/// <summary>
		/// Get/set article title
		/// </summary>
		public string Title
		{
			get { return m_title; }
			set { m_title = value; }
		}
		/// <summary>
		/// Get/set article url
		/// </summary>
		public string Link
		{
			get { return m_link; }
			set { m_link = value; }
		}
		/// <summary>
		/// Get/set article description
		/// </summary>
		public string Description
		{
			get { return m_description; }
			set { m_description = value; }
		}
		/// <summary>
		/// Get/set date last updated
		/// </summary>
		public DateTime LastUpdated
		{
			get { return m_lastUpdated; }
			set { m_lastUpdated = value; }
		}
		/// <summary>
		/// Get/set page views
		/// </summary>
		public int PageViews
		{
			get { return m_pageViews; }
			set { m_pageViews = value; }
		}
		/// <summary>
		/// Get/set number of votes
		/// </summary>
		public int Votes
		{
			get { return m_votes; }
			set { m_votes = value; }
		}
		/// <summary>
		/// Get/set article rating
		/// </summary>
		public decimal Rating
		{
			get { return m_rating; }
			set { m_rating = value; }
		}
		/// <summary>
		/// Get/set popularity
		/// </summary>
		public decimal Popularity
		{
			get { return m_popularity; }
			set { m_popularity = value; }
		}
		/// <summary>
		/// Get/set bookmark count
		/// </summary>
		public int Bookmarks
		{
			get { return m_bookmarks; }
			set { m_bookmarks = value; }
		}
		/// <summary>
		/// Get/set sort direction
		/// </summary>
		public bool SortAscending
		{
			get { return m_sortAscending; }
			set { m_sortAscending = value; }
		}
		#endregion properties

		#region Comparison delegates
		/// <summary>
		/// Title comparison for sort function
		/// </summary>
		public static Comparison<ArticleData> TitleCompare = delegate(ArticleData p1, ArticleData p2)
		{
			return (p1.SortAscending) ? p1.m_title.CompareTo(p2.m_title) : p2.m_title.CompareTo(p1.m_title);
		};
		/// <summary>
		/// Page views comparison for sort function
		/// </summary>
		public static Comparison<ArticleData> PageViewsCompare = delegate(ArticleData p1, ArticleData p2)
		{
		    return (p1.SortAscending) ? p1.m_pageViews.CompareTo(p2.m_pageViews) : p2.m_pageViews.CompareTo(p1.m_pageViews);
		};
		/// <summary>
		/// Last Updated comparison for sort function
		/// </summary>
		public static Comparison<ArticleData> LastUpdatedCompare = delegate(ArticleData p1, ArticleData p2)
		{
		    return (p1.SortAscending) ? p1.m_lastUpdated.CompareTo(p2.m_lastUpdated) : p2.m_lastUpdated.CompareTo(p1.m_lastUpdated);
		};
		/// <summary>
		/// Rating comparison for sort function
		/// </summary>
		public static Comparison<ArticleData> RatingCompare = delegate(ArticleData p1, ArticleData p2)
		{
		    return (p1.SortAscending) ? p1.m_rating.CompareTo(p2.m_rating) : p2.m_rating.CompareTo(p1.m_rating);
		};
		/// <summary>
		/// Votes comparison for sort function
		/// </summary>
		public static Comparison<ArticleData> VotesCompare = delegate(ArticleData p1, ArticleData p2)
		{
		    return (p1.SortAscending) ? p1.m_votes.CompareTo(p2.m_votes) : p2.m_votes.CompareTo(p1.m_votes);
		};
		/// <summary>
		/// Popularity comparison for sort function
		/// </summary>
		public static Comparison<ArticleData> PopularityCompare = delegate(ArticleData p1, ArticleData p2)
		{
		    return (p1.SortAscending) ? p1.m_popularity.CompareTo(p2.m_popularity) : p2.m_popularity.CompareTo(p1.m_popularity);
		};
		/// <summary>
		/// Bookmark count comparison for sort function
		/// </summary>
		public static Comparison<ArticleData> BookmarksCompare = delegate(ArticleData p1, ArticleData p2)
		{
		    return (p1.SortAscending) ? p1.m_bookmarks.CompareTo(p2.m_bookmarks) : p2.m_bookmarks.CompareTo(p1.m_bookmarks);
		};
		/// <summary>
		/// Defuault comparison (compares article ID) for sort function
		/// </summary>
		public int CompareTo(ArticleData other)
		{
		    return LastUpdated.CompareTo(other.LastUpdated);
		}
		#endregion Comparison delegates

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Constructor
		/// </summary>
		public ArticleData()
		{
		}

	}
}


