using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Oracle.DataAccess.Client;
using System.Data;

namespace OracleSample
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OracleConn db = new OracleConn();
            OracleConnection con = new OracleConnection();
            string query;

            //string strConn = "Data Source=127.0.0.1:1521/orcl; User ID=system; Password=admin1";

            db.Conn = con;
            db.Server = "localhost:1521/orcl;";
            //db.DB = "test";
            db.UID = "system;";
            db.PWD = "admin1";

            db.Connect();

            query = "SELECT * FROM testtable";
            //query = "DESC fix_register";
            db.Execute(query);

            // 2015-10-28 OracleDataAdapter 사용방법 찾기
            /*
            OracleDataAdapter da = new OracleDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine(string.Format("일련번호 : {0} \n수리번호 : {1}\n", row["idx"], row["fix_idx"]));
                }
            }
            */
            
            db.DisConnect();
            
        }
    }
}
