using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;

namespace Weaver_site_parsing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.gagangiri.org/teachings.html");
        }

        private HtmlElement[] GetElementsByClassName(WebBrowser wb, string tagName, string className)
        {
            var l = new List<HtmlElement>();

            var els = webBrowser1.Document.GetElementsByTagName(tagName); // all elems with tag
            foreach (HtmlElement el in els)
            {
                // getting "class" attribute value...
                // but stop! it isn't "class"! It is "className"! 0_o
                // el.GetAttribute("className") working, and el.GetAttribute("class") - not!
                // IE is so IE...
                if (el.GetAttribute("className") == className)
                {
                    l.Add(el);
                }
            }

            return l.ToArray();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // getting city
            var divCity = webBrowser1.Document.GetElementById("city"); // getting an fist div element
            var city = divCity.InnerText;
            label1.Text = "City: " + city;

            // getting precipitation
            var divPrecip = webBrowser1.Document.GetElementById("precip");
            var img = divPrecip.Children[0]; // first child element of precip, i.e. <img>
            var imgSrc = img.GetAttribute("src"); // get src attribute of <img>
            pictureBox1.ImageLocation = imgSrc;

            // getting day and night temperature
            var divsTemp = GetElementsByClassName(webBrowser1, "div", "t");
            // day
            var divDayTemp = divsTemp[0]; // day temperature div
            var dayTemp = divDayTemp.InnerText; // day temperature (i.e. 20 C)
            label2.Text = "Day temperature: " + dayTemp;
            // night
            var divNightTemp = divsTemp[1]; // night temperature div
            var nightTemp = divNightTemp.InnerText; // night temperature (i.e. 18 C)
            label3.Text = "Night temperature: " + nightTemp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // get HTML content from website
            string HTML;
            using (var wc = new WebClient())
            {
                HTML = wc.DownloadString("http://www.gagangiri.org/teachings.html");
            }

            // create HtmlAgilityPack document object from HTML
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(HTML);

            // pasing HTML
            label1.Text = "City: " + doc.GetElementbyId("city").InnerText;
        }
    }
}
