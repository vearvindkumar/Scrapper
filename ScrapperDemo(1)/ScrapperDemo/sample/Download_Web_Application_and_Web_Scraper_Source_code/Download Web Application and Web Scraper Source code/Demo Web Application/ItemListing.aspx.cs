using System;

public partial class ItemListing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Category"] != null && Request.QueryString["Category"] == "MenWear")
        {
            xmlSource.DataFile = "~/XMLDataBase/MenFashion.xml";
        }
        else if (Request.QueryString["Category"] != null && Request.QueryString["Category"] == "WomenWear")
        {
            xmlSource.DataFile = "~/XMLDataBase/WomenFashion.xml";
        }
        else if (Request.QueryString["Category"] != null && Request.QueryString["Category"] == "ChildrenWear")
        {
            xmlSource.DataFile = "~/XMLDataBase/ChildFashion.xml";
        }
    }
}