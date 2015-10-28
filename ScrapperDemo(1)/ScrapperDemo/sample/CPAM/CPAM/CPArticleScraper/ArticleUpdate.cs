using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPArticleScraper
{
	public enum ChangeType {None=0, Up=1, Down=2};
	/// <summary>
	/// Overrides the ArticleData class so that we  can track updated values for 
	/// a given article.
	/// </summary>
	public class ArticleUpdate : ArticleData, IComparable<ArticleUpdate>
	{
		protected string		m_latestTitle		= "";
		protected string		m_latestLink		= "";
		protected string		m_latestDescription	= "";
		protected DateTime		m_latestLastUpdated	= new DateTime(0);
		protected int			m_latestPageViews	= 0;
		protected int			m_latestVotes		= 0;
		protected decimal		m_latestRating		= 0.0M;
		protected decimal		m_latestPopularity	= 0.0M;
		protected int			m_latestBookmarks	= 0;
		protected DateTime		m_timeUpdated		= new DateTime(0);
		protected bool			m_newArticle		= false;
		protected bool			m_changed			= false;

		#region properties
		/// <summary>
		/// Get/set article title
		/// </summary>
		public string LatestTitle
		{
			get { return m_latestTitle; }
			set { m_latestTitle = value; }
		}
		/// <summary>
		/// Get/set article url
		/// </summary>
		public string LatestLink
		{
			get { return m_latestLink; }
			set { m_latestLink = value; }
		}
		/// <summary>
		/// Get/set article description
		/// </summary>
		public string LatestDescription
		{
			get { return m_latestDescription; }
			set { m_latestDescription = value; }
		}
		/// <summary>
		/// Get/set date last updated
		/// </summary>
		public DateTime LatestLastUpdated
		{
			get { return m_latestLastUpdated; }
			set { m_latestLastUpdated = value; }
		}
		/// <summary>
		/// Get/set page views
		/// </summary>
		public int LatestPageViews
		{
			get { return m_latestPageViews; }
			set { m_latestPageViews = value; }
		}
		/// <summary>
		/// Get/set number of votes
		/// </summary>
		public int LatestVotes
		{
			get { return m_latestVotes; }
			set { m_latestVotes = value; }
		}
		/// <summary>
		/// Get/set article rating
		/// </summary>
		public decimal LatestRating
		{
			get { return m_latestRating; }
			set { m_latestRating = value; }
		}
		/// <summary>
		/// Get/set popularity
		/// </summary>
		public decimal LatestPopularity
		{
			get { return m_latestPopularity; }
			set { m_latestPopularity = value; }
		}
		/// <summary>
		/// Get/set bookmark count
		/// </summary>
		public int LatestBookmarks
		{
			get { return m_latestBookmarks; }
			set { m_latestBookmarks = value; }
		}
		/// <summary>
		/// Get the time stamp of the last update
		/// </summary>
		public DateTime TimeUpdated
		{
			get { return m_timeUpdated; }
		}
		/// <summary>
		/// Get - see if the article is new
		/// </summary>
		public bool NewArticle
		{
			get { return m_newArticle; }
		}
		public bool Changed
		{
			get { return m_changed; }
		}
		#endregion properties

		/// <summary>
		/// Title comparison for sort function
		/// </summary>
		public static Comparison<ArticleUpdate> LatestTitleCompare = delegate(ArticleUpdate p1, ArticleUpdate p2)
		{
			return (p1.SortAscending) ? p1.m_latestTitle.CompareTo(p2.m_latestTitle) : p2.m_latestTitle.CompareTo(p1.m_latestTitle);
		};
		/// <summary>
		/// Page views comparison for sort function
		/// </summary>
		public static Comparison<ArticleUpdate> LatestPageViewsCompare = delegate(ArticleUpdate p1, ArticleUpdate p2)
		{
		    return (p1.SortAscending) ? p1.m_latestPageViews.CompareTo(p2.m_latestPageViews) : p2.m_latestPageViews.CompareTo(p1.m_latestPageViews);
		};
		/// <summary>
		/// Last Updated comparison for sort function
		/// </summary>
		public static Comparison<ArticleUpdate> LatestLastUpdatedCompare = delegate(ArticleUpdate p1, ArticleUpdate p2)
		{
		    return (p1.SortAscending) ? p1.m_latestLastUpdated.CompareTo(p2.m_latestLastUpdated) : p2.m_latestLastUpdated.CompareTo(p1.m_latestLastUpdated);
		};
		/// <summary>
		/// Rating comparison for sort function
		/// </summary>
		public static Comparison<ArticleUpdate> LatestRatingCompare = delegate(ArticleUpdate p1, ArticleUpdate p2)
		{
		    return (p1.SortAscending) ? p1.m_latestRating.CompareTo(p2.m_latestRating) : p2.m_latestRating.CompareTo(p1.m_latestRating);
		};
		/// <summary>
		/// Votes comparison for sort function
		/// </summary>
		public static Comparison<ArticleUpdate> LatestVotesCompare = delegate(ArticleUpdate p1, ArticleUpdate p2)
		{
		    return (p1.SortAscending) ? p1.m_latestVotes.CompareTo(p2.m_latestVotes) : p2.m_latestVotes.CompareTo(p1.m_latestVotes);
		};
		/// <summary>
		/// Popularity comparison for sort function
		/// </summary>
		public static Comparison<ArticleUpdate> LatestPopularityCompare = delegate(ArticleUpdate p1, ArticleUpdate p2)
		{
		    return (p1.SortAscending) ? p1.m_latestPopularity.CompareTo(p2.m_latestPopularity) : p2.m_latestPopularity.CompareTo(p1.m_latestPopularity);
		};
		/// <summary>
		/// Bookmark count comparison for sort function
		/// </summary>
		public static Comparison<ArticleUpdate> LatestBookmarksCompare = delegate(ArticleUpdate p1, ArticleUpdate p2)
		{
		    return (p1.SortAscending) ? p1.m_latestBookmarks.CompareTo(p2.m_latestBookmarks) : p2.m_latestBookmarks.CompareTo(p1.m_latestBookmarks);
		};

		/// <summary>
		/// Defuault comparison (compares article ID) for sort function
		/// </summary>
		public int CompareTo(ArticleUpdate other)
		{
		    return LatestLastUpdated.CompareTo(other.LatestLastUpdated);
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Constructor
		/// </summary>
		public ArticleUpdate()
		{
		}


		//-------------------------------------------------------------------------------
		/// <summary>
		/// If the specified item exists (determined by article title), the article 
		/// data is modified to reflect the changes.
		/// </summary>
		/// <param name="item">The article to check</param>
		/// <returns>True if the article has changed since the last update</returns>
		public bool ApplyChanges(ArticleUpdate item, DateTime timeOfUpdate, bool newArticle)
		{
			bool changed = false;

			// make them all the same
			this.m_title				= m_latestTitle;
			this.m_link					= m_latestLink;
			this.m_lastUpdated			= m_latestLastUpdated;
			this.m_description			= m_latestDescription;
			this.m_pageViews			= m_latestPageViews;
			this.m_rating				= m_latestRating;
			this.m_votes				= m_latestVotes;
			this.m_popularity			= m_latestPopularity;
			this.m_bookmarks			= m_latestBookmarks;

			// set new info
			this.m_latestTitle			= item.m_latestTitle;
			this.m_latestLink			= item.m_latestLink;
			this.m_latestDescription	= item.m_latestDescription;
			this.m_latestPageViews		= item.m_latestPageViews;
			this.m_latestRating			= item.m_latestRating;
			this.m_latestVotes			= item.m_latestVotes;
			this.m_latestPopularity		= item.m_latestPopularity;
			this.m_latestBookmarks		= item.m_latestBookmarks;

			// make a note of the last update time stamp
			this.m_timeUpdated			= timeOfUpdate;
			this.m_newArticle			= newArticle;

			// see if anything changed since the last update
			changed = (this.m_title			!= m_latestTitle		||
					   this.m_link			!= m_latestLink			||
					   this.m_lastUpdated	!= m_latestLastUpdated	||
					   this.m_description	!= m_latestDescription	||
					   this.m_pageViews		!= m_latestPageViews	||
					   this.m_rating		!= m_latestRating		||
					   this.m_votes			!= m_latestVotes		||
					   this.m_popularity	!= m_latestPopularity	||
					   this.m_bookmarks		!= m_latestBookmarks	||
					   this.m_newArticle	== true);

			m_changed = changed;

			return changed;
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// See if the named property has changed
		/// </summary>
		/// <param name="property">The property to check</param>
		/// <returns>True if the named property has changed since the last update</returns>
		public bool PropertyChanged(string property)
		{
			string originalProperty = property;
			property = property.ToLower();
			switch (property)
			{
				case "title"		: return (Title != LatestTitle);
				case "link"			: return (Link != LatestLink);
				case "description"	: return (Description != LatestDescription);
				case "pageviews"	: return (PageViews != LatestPageViews);
				case "rating"		: return (Rating != LatestRating);
				case "votes"		: return (Votes != LatestVotes);
				case "popularity"	: return (Popularity != LatestPopularity);
				case "bookmarks"	: return (Bookmarks != LatestBookmarks);
				case "lastupdated"	: return (LastUpdated != LatestLastUpdated);
			}
			// if we get here, the property is invalid
			throw new Exception(string.Format("Unknown article property - '{0}'", originalProperty));
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Returns how the value changed. Not applicable for title, description, 
		/// link, or last updated properties
		/// </summary>
		/// <param name="property"></param>
		/// <returns></returns>
		public ChangeType HowChanged(string property)
		{
			ChangeType changeType = ChangeType.None;

			string originalProperty = property;
			property = property.ToLower();

			switch (property)
			{
				case "title": 
					break;

				case "link": 
					break;

				case "description": 
					break;

				case "pageviews": 
					{
						if (PageViews != LatestPageViews)
						{
							changeType = ChangeType.Up;
						}
					}
					break;

				case "rating": 
					{
						if (Rating > LatestRating)
						{
							changeType = ChangeType.Down;
						}
						else
						{
							if (Rating < LatestRating)
							{
								changeType = ChangeType.Up;
							}
						}
					}
					break;

				case "votes": 
					{
						if (Votes != LatestVotes)
						{
							changeType = ChangeType.Up;
						}
					}
					break;

				case "popularity": 
					{
						if (Popularity > LatestPopularity)
						{
							changeType = ChangeType.Down;
						}
						else
						{
							if (Popularity < LatestPopularity)
							{
								changeType = ChangeType.Up;
							}
						}
					}
					break;

				case "bookmarks": 
					{
						if (Bookmarks > LatestBookmarks)
						{
							changeType = ChangeType.Down;
						}
						else
						{
							if (Bookmarks < LatestBookmarks)
							{
								changeType = ChangeType.Up;
							}
						}
					}
					break;

				case "lastupdated": 
					break;

				default : throw new Exception(string.Format("Unknown article property - '{0}'", originalProperty));
			}

			return changeType;
		}

	}
}
