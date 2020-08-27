using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoNetPro
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlConnection conn = new SqlConnection();
            //1、第一种写法
            //conn.ConnectionString = "server=.;database=Frame;uid=txx1557;pwd=123";//字符串连接
            //2、第二种写法  Data Source--server  Initial Catalog---database User Id--uid   Password--pwd
            //本地：local或者.表示;
            //conn.ConnectionString = "Data Source=local;Initial Catalog=Frame;User Id=txx1557;Password=123";字符串连接
            //3、第三种写法调用SqlConnectionStringBuilder
            //SqlConnectionStringBuilder connSb = new SqlConnectionStringBuilder();
            //connSb.DataSource=".";
            //connSb.InitialCatalog= "Frame";
            //connSb.UserID = "txx1557";
            //connSb.Password = "123";

            //windows 身份验证  Integerated Security=SSPI/True或者Trusted Connection=True;
            //string connStr = "Data Source=local;Initial Catalog=Frame;Integerated Security=SSPI;";

            /*其它数据库字符串连接的写法
             Oracle :  "Data Source=local;User Id=txx1557;Password=123"
             
             MySql :   "Data Source=local;Initial Catalog=Frame;User Id=txx1557;Password=123"; 
             
             */

            //conn.Database 连接的数据库
            //conn.DataSource 数据源 local . IP,端口号
            //conn.State  连接状态
            //  conn.ConnectionTimeout 15s
            //string str = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            //string str2 = ConfigurationManager.AppSettings["conStrs"].ToString();
            string connSql = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connSql);
            //conn.ConnectionString = str2;

            //try{
            //Console.WriteLine($"DataSource:{conn.DataSource}");
            //Console.WriteLine($"Database:{conn.Database}");
            //Console.WriteLine($"state:{conn.State}");
            ////Console.WriteLine($"vs:{conn.ServerVersion}");
            //conn.Open();
            //Console.WriteLine($"DataSource:{conn.DataSource}");
            //Console.WriteLine($"Database:{conn.Database}");
            //Console.WriteLine($"state:{conn.State}");
            //Console.WriteLine($"version:{conn.ServerVersion}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //}

            //使用using方法来释放非托管资源的对象，必须继承IDisposable接口（Dispose）
            string connSql1 = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SqlConnection conn1 = null;
            using (conn1 = new SqlConnection(connSql1)) {
                Console.WriteLine($"DataSource:{conn1.DataSource}");
                Console.WriteLine($"Database:{conn1.Database}");
                Console.WriteLine($"state:{conn1.State}");
                //Console.WriteLine($"vs:{conn.ServerVersion}");
                conn1.Open();
                Console.WriteLine($"DataSource:{conn1.DataSource}");
                Console.WriteLine($"Database:{conn1.Database}");
                Console.WriteLine($"state:{conn1.State}");
                Console.WriteLine($"version:{conn1.ServerVersion}");
            }
            Console.WriteLine($"state:{conn1.State}");
            Console.ReadKey();
            //创建命令对象
            //conn.CreateCommand();

            //执行命令
            //Console.WriteLine("conn");
            //conn.Close();
            //conn.Dispose();
        }
    }
}
