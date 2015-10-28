using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ScrapperDemo.Model
{
    public class sqlConnection
    {
        public static SqlConnection connScrapDb = new SqlConnection(@"Data Source=VE021015_D\SATWADHIR;Initial Catalog=WebScraperDemo;User ID=sa;Password=ve1;");

        public int getAWNO()
        {
            int AWno = 0;

            SqlCommand getAWno = new SqlCommand("SELECT COUNT(AWNO) FROM ScraperRecordMain", connScrapDb);
            connScrapDb.Open();
            try
            {
                AWno = Convert.ToInt16(getAWno.ExecuteScalar());
            }
            catch (Exception awnoex) { System.Windows.MessageBox.Show(awnoex.Message.ToString()); }
            if (AWno == 0 || AWno == null) { AWno = 1; } else { AWno += 1; }
            
            connScrapDb.Close();            
            return AWno;
        }

        public int getAnalyzeNo()
        {
            int AnalyzeNo = 0;

            SqlCommand getAnalyzeNo = new SqlCommand("SELECT MAX(AnalyzeNo) FROM ScraperRecordMain", connScrapDb);
            connScrapDb.Open();
            try
            {
                AnalyzeNo = Convert.ToInt16(getAnalyzeNo.ExecuteScalar());
            }
            catch (Exception awnoex) { System.Windows.MessageBox.Show(awnoex.Message.ToString()); }
            
            if (AnalyzeNo == 0 || AnalyzeNo == null) { AnalyzeNo = 101; } else { AnalyzeNo += 1; }

            connScrapDb.Close();
            return AnalyzeNo;
        }
    }
}
