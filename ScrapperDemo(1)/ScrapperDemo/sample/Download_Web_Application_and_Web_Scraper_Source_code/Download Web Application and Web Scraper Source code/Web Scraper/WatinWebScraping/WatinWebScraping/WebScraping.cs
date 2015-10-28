using System;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;
using WatiN.Core;

namespace WatinWebScraping
{
    [TestFixture]
    public class WebScraping
    {
        // Regular expression for Category listing page
        private const string _categoryRegEx = @"<A\s.*?class=bold\s.*?href=""(?<href>.*?)"">";
        // Regular expression for paging
        private const string _pagingRegEx = @"(?(?=<SPAN>.*?</SPAN>)<SPAN>(?<PageNumber>.*?)\s*</SPAN>|<A\s*href=""javascript.*?>(?<PageNumber>.*?)\s*</A>)";
        // Regular expression for item listing pages
        private const string _itemRegEx = @"<P\s*id=.*?>ProductID:\s*<B>(?<ProductID>.*?)</B>.*?</P>\s*.*?<P\s*id=.*?>ProductName:\s*<B>(?<ProductName>.*?)</B>.*?</P>\s*.*?<P\s*id=.*?>ProductPrice:\s*<B>(?<ProductPrice>.*?)</B>.*?</P>";

        private const string _pageNumber = "PageNumber";

        private const string _productID = "ProductID";

        private const string _productName = "ProductName";

        private const string _productPrice = "ProductPrice";

        [Test]
        [STAThread]
        public void WebApplicationScraping()
        {
            try
            {
                // Reads the path of the web application
                string webSitePath = Convert.ToString(ConfigurationManager.AppSettings["WebApplicationPath"]);
                string filePhysicalPath = Convert.ToString(ConfigurationManager.AppSettings["ScraperEnginePhysicalLocation"]);

                StreamWriter file = new StreamWriter(filePhysicalPath + "Output.txt");

                if (webSitePath != null && webSitePath != string.Empty)
                {
                    // Create an instance of IE browser
                    IE ieInstance = new IE(webSitePath);

                    // This will opens IE browser in maximized mode
                    ieInstance.ShowWindow(WatiN.Core.Native.Windows.NativeMethods.WindowShowStyle.ShowMaximized);

                    // Watin window will not visible to the end user when web scraping is done
                    //ieInstance.Visible = false;

                    // This will wait for the browser to complete loading of the page
                    ieInstance.WaitForComplete();

                    // This will store page source in categoryPageSource variable
                    string categoryPageSource = ieInstance.Html;

                    // Regular expression pattern to fetch list of categories categories

                    Regex categoryMatches = new Regex(_categoryRegEx, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.CultureInvariant);

                    // Fetches all the categories based upon category regex from category listing page
                    MatchCollection categoryMatchCollection = categoryMatches.Matches(categoryPageSource);

                    // Navigate to each categories and fetch page URL and navigate to the item listing page for each categories
                    foreach (Match categoryMatch in categoryMatchCollection)
                    {
                        GroupCollection categoryGroup = categoryMatch.Groups;

                        // URL of the item listing page
                        string itemListingURL = Convert.ToString(categoryGroup["href"].Value);

                        // Partial web path where demonstration web site is deployed.
                        // Note: This path needs to be modified in App.Config file accordingly.
                        string webSiteHostedLocation = webSitePath.Remove(webSitePath.LastIndexOf("/"));

                        // Creates path of the category listing page.
                        string itemListingpath = webSiteHostedLocation + "/" + itemListingURL;

                        // Navigate to the item listing page
                        ieInstance.GoTo(itemListingpath);

                        ieInstance.WaitForComplete();

                        // HTML source of given generated web page
                        string itemListingPageSource = ieInstance.Html;

                        // Match for the paging Event
                        Regex pagingMatches = new Regex(_pagingRegEx, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.CultureInvariant | RegexOptions.Multiline);

                        // Find Matches.
                        MatchCollection pagingMatchCollection = pagingMatches.Matches(itemListingPageSource);

                        foreach (Match pageMatch in pagingMatchCollection)
                        {
                            GroupCollection pagingGroup = pageMatch.Groups;

                            if (pagingGroup[_pageNumber].Value != "1")
                            {
                                // Fetches the page number of the current page.
                                string linkText = Convert.ToString(pagingGroup[_pageNumber].Value);

                                // Performs click event on the given link. For e.g if linkText contains "2" as a value then 
                                //Watin will perform click event on this second link.
                                ieInstance.Link(Find.ByText(linkText)).Click();

                                // Wait for the operation to complete
                                ieInstance.WaitForComplete();

                                // Store the result of the page in itemListingPageSource variable
                                itemListingPageSource = ieInstance.Html;
                            }

                            Regex itemMatches = new Regex(_itemRegEx, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.CultureInvariant);

                            // Fetches all the items based upon item regex from the item listing page
                            MatchCollection itemMatchCollection = itemMatches.Matches(itemListingPageSource);

                            // Navigate to each item and fetch ProductID, ProductName and ProductPrice and store the result in text file
                            foreach (Match itemMatch in itemMatchCollection)
                            {
                                GroupCollection itemGroups = itemMatch.Groups;

                                // Fetch productId from the given item group
                                string productID = Convert.ToString(itemGroups[_productID].Value);

                                // Fetch productName from the given item Group
                                string productName = Convert.ToString(itemGroups[_productName].Value);

                                // Fetch product price from the given product price
                                string productPrice = Convert.ToString(itemGroups[_productPrice].Value);

                                file.WriteLine("ProductID: " + productID);

                                file.WriteLine("Product Name: " + productName);

                                file.WriteLine("Product Price: " + productPrice);

                                file.WriteLine("-----------------------------------------------------------------------------------------------");

                                file.WriteLine("\n");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Mention category listing website application path");
                }

                file.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}
