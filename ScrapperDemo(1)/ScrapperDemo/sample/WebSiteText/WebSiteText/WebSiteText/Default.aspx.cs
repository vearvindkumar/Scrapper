using System;
using WatiN.MsHtmlBrowser;

namespace GenomeClassifier
{

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnWebSiteText_Click(object sender, EventArgs e)
        {
            var browser = new MsHtmlBrowser();
            browser.GoTo(commandLog.Text);
            commandLog.Text = browser.Text;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            commandLog.Text = "";
        }
    }
}