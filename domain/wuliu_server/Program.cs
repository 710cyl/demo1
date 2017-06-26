using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;
using NHibernate;
using domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using wuliuDAO;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
namespace wuliu_server
{
    class Program
    {
        static void Main(string[] args)
        {
            var wssv = new WebSocketServer("ws://localhost:9000");
            wssv.AddWebSocketService<ShowData>("/ShowData");
            wssv.AddWebSocketService<DeleteData>("/DeleteData");
            wssv.AddWebSocketService<BatchSave>("/BatchSave");
            wssv.AddWebSocketService<SaveData>("/SaveData");
            wssv.Start();
            Console.ReadKey();
            wssv.Stop();


        }
    }
    public class ShowData :WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {
                ISession session = null;
                try
                {
                    session = sessionFactory.OpenSession();
                    string json = SwitchData(session,e.Data);

                    Console.WriteLine(e.Data);
                    Console.WriteLine(json);
                    Send(json);

                }
                catch (Exception ex)
                {
                    session.Close();
                    Send(ex.Message);
                }
            }
        }

       public string SwitchData(ISession session,string s)
        {
            if (s == "Basic_Set")
            {
               IList<Basic_Set> basic_set = session.QueryOver<Basic_Set>().Skip(0).Take(50).List();
                string json = JsonConvert.SerializeObject(basic_set);
                return json;
            }

            else if (s == "Fund_Accounts")
            {
                IList<Fund_Accounts> fund_account = session.QueryOver<Fund_Accounts>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }

            else
            return null;
        }
    }

    //*****************
    //服务器保存数据
    //*****************
    public class SaveData : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Basic_SetDAO bsd = new Basic_SetDAO();
            Basic_Set bs = new Basic_Set();
            bs = null;
            string tmp = null;
            tmp = e.Data;
            bs = JsonConvert.DeserializeObject<Basic_Set>(tmp);
            bsd.Save(bs);
        }
    }

    public class DeleteData :WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Basic_SetDAO bs = new Basic_SetDAO();
            string ID = string.Empty;
            ID = e.Data;
            var basicset = bs.Get(ID);
            bs.Delete(basicset);
        }
    }

    public class BatchSave : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            string dataString = e.Data;
            DataTable dt = null; 
            dt = JsonConvert.DeserializeObject<DataTable>(dataString);
            AddDataTableToDB(dt,"dbo.T_Basic_Set");

        }

        public void AddDataTableToDB(DataTable dt,string dbName) //批量导入excel
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=sa123456;database=test;"))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        using (SqlBulkCopy copy = new SqlBulkCopy(conn,SqlBulkCopyOptions.Default,tran))
                        {
                            copy.DestinationTableName = dbName;
                            copy.WriteToServer(dt);
                            tran.Commit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
