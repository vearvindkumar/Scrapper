using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ScrapperDemo.Model
{
    public class mainRecords
    {
        public int awNo;
        public string webURL;
        public string web1URL;
        public string web2URL;
        public DateTime scrapDT;
        public int AnalyzeNo;

        public string isURLsimilar;
        public string pageContentText;
        public string searchContentText;
        public DateTime searchCtxtDT;
    }

    public class ScrapperRecordMain
    {

        public void insertDatatoMainRecords(mainRecords mainRecord)
        {
            SqlCommand cmd = new SqlCommand("insert into ScraperRecordMain(AWNO,webURL,web1URL,web2URL,scrapDateTime,AnalyzeNo) values(" + mainRecord.awNo + ",'" + mainRecord.webURL + "','" + mainRecord.web1URL + "','" + mainRecord.web2URL + "','" + mainRecord.scrapDT.Date.ToString("yyyy-MM-dd HH:mm:ss") + "'," + mainRecord.AnalyzeNo + ")", sqlConnection.connScrapDb);

            cmd.CommandType = CommandType.Text;

            try
            {
                sqlConnection.connScrapDb.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.connScrapDb.Close();
            }

            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message.ToString());

            }
        }


        public void insertDatatoScraperPageTextData(mainRecords mainRecord)
        {
            SqlCommand cmd = new SqlCommand("insert into ScraperPageTextData(AWNO,webURL,web1URL,web2URL,isURLsimilar,scrapDateTime,pageContentText,SearchContentText,SearchDateTime,AnalyzeNo) values("
                + mainRecord.awNo + ",'" + mainRecord.webURL + "','" + mainRecord.web1URL + "','" + mainRecord.web2URL + "','" + mainRecord.isURLsimilar + "','" + mainRecord.scrapDT.Date.ToString("yyyy-MM-dd HH:mm:ss") + "','" + mainRecord.pageContentText.ToString().Replace("'", "") + "','" + mainRecord.searchContentText + "','" + mainRecord.searchCtxtDT.ToString("yyyy-MM-dd HH:mm:ss") + "'," + mainRecord.AnalyzeNo + ")", sqlConnection.connScrapDb);

            cmd.CommandType = CommandType.Text;

            try
            {
                sqlConnection.connScrapDb.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.connScrapDb.Close();
            }

            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message.ToString());

            }
        }


        public List<int> LoaadAnalyzeNumber()
        {
            List<int> an = new List<int>();

            try
            {
                string oString = "Select AnalyzeNo from ScraperPageTextData";
                using (SqlCommand oCmd = new SqlCommand(oString, sqlConnection.connScrapDb))
                {
                    try
                    {
                        sqlConnection.connScrapDb.Open();
                        SqlDataReader rdr = oCmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            decimal ann = (Decimal)rdr["AnalyzeNo"];
                            int annl = Convert.ToInt16(ann);
                            an.Add(annl);
                        }
                        sqlConnection.connScrapDb.Close();
                    }

                    catch (Exception ex)
                    {
                        sqlConnection.connScrapDb.Close();
                        System.Windows.MessageBox.Show(ex.Message.ToString());

                    }

                    return an;

                }
            }catch (Exception exanlyno)
            {                
                System.Windows.MessageBox.Show(exanlyno.Message.ToString());
                return an;
            }
            
            

        }


        public string getThePlainHTMLContentTextFromDB(int analyzeNo)
        {
            string pageContentPlain = "";
            try
            {
                string oString = "Select pageContentText from ScraperPageTextData where AnalyzeNo = " + analyzeNo;
                using (SqlCommand oCmd = new SqlCommand(oString, sqlConnection.connScrapDb))
                {
                    try
                    {
                        sqlConnection.connScrapDb.Open();
                        SqlDataReader rdr = oCmd.ExecuteReader();                      

                        while (rdr.Read())
                        {
                            pageContentPlain = (string)rdr["pageContentText"];
                           
                        }

                        sqlConnection.connScrapDb.Close();
                    }

                    catch (Exception ex)
                    {
                        sqlConnection.connScrapDb.Close();
                        System.Windows.MessageBox.Show(ex.Message.ToString());

                    }

                    return pageContentPlain;

                }
            }
            catch (Exception exanlyno)
            {
                System.Windows.MessageBox.Show(exanlyno.Message.ToString());
                return pageContentPlain;
            }

           
        }


    }
}
