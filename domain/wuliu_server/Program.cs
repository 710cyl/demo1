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
            wssv.AddWebSocketService<GetCount>("/GetCount");
            wssv.AddWebSocketService<NowPage>("/NowPage");
            wssv.AddWebSocketService<UpdateData>("/UpdateData");
            wssv.AddWebSocketService<ShowDetail>("/ShowDetail");
            wssv.AddWebSocketService<SaveData>("/SaveDriver_Check");
            wssv.Start();
            Console.ReadKey();
            wssv.Stop();


        }
    }

    public class NowPage : WebSocketBehavior
    {
        public static string nowpage;
        protected override void OnMessage(MessageEventArgs e)
        {
            nowpage = e.Data;
        }
    }
    public class ShowData : WebSocketBehavior
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
                    string json = SwitchData(session, e.Data);

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


        public string SwitchData(ISession session, string s)
        {
            if (s == "Basic_Set")
            {
                // NowPage np = new NowPage();
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<Basic_Set> basic_set = session.QueryOver<Basic_Set>().Skip((page - 1) * 50).Take(50).List();
                string json = JsonConvert.SerializeObject(basic_set);
                return json;
            }

            else if (s == "Fund_Accounts")
            {
                IList<Fund_Accounts> fund_account = session.QueryOver<Fund_Accounts>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Internal_Vehicle")
            {
                IList<Internal_Vehicle> fund_account = session.QueryOver<Internal_Vehicle>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }

            else if (s == "Office_Supply")
            {
                IList<Office_Supply> fund_account = session.QueryOver<Office_Supply>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Order_File")
            {
                IList<Order_File> fund_account = session.QueryOver<Order_File>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Repair_Material")
            {
                IList<Repair_Material> fund_account = session.QueryOver<Repair_Material>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Transportations")
            {
                IList<Transportations> fund_account = session.QueryOver<Transportations>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Variety_Texture")
            {
                IList<Variety_Texture> fund_account = session.QueryOver<Variety_Texture>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Warehouse_Space")
            {
                IList<Warehouse_Space> fund_account = session.QueryOver<Warehouse_Space>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Decorate")
            {
                IList<Decorate> fund_account = session.QueryOver<Decorate>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Discharge")
            {
                IList<Discharge> fund_account = session.QueryOver<Discharge>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Transportations")
            {
                IList<Transportations> fund_account = session.QueryOver<Transportations>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Warehouse_Staff")
            {
                IList<Warehouse_Staff> fund_account = session.QueryOver<Warehouse_Staff>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Charter_Fee_Main")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<Charter_Fee_Main> charter_fee_main = session.QueryOver<Charter_Fee_Main>().Skip((page - 1) * 50).Take(50).List();
                string json = JsonConvert.SerializeObject(charter_fee_main);
                return json;
            }
            else if (s == "Charter_Fee_Detail")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<Charter_Fee_Detail> charter_fee_detail = session.QueryOver<Charter_Fee_Detail>().Skip((page - 1) * 50).Take(50).List();
                string json = JsonConvert.SerializeObject(charter_fee_detail);
                return json;
            }
            else if (s == "Driver_Check")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<Driver_Check> driver_check = session.QueryOver<Driver_Check>().Skip((page - 1) * 50).Take(50).List();
                string json = JsonConvert.SerializeObject(driver_check);
                return json;
            }

            else
                return null;
        }
    }


    public class GetCount : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {
                try
                {
                    ISession session = sessionFactory.OpenSession();
                    long total = CountSwitch(e.Data, session);
                    Send(total.ToString());
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public long CountSwitch(string className, ISession session)
        {
            long total = 0;
            if (className == "Basic_Set")
            {
                total = session.QueryOver<Basic_Set>().RowCountInt64();
                return total;
            }
            else if (className == "Fund_Accounts")
            {
                total = session.QueryOver<Fund_Accounts>().RowCountInt64();
                return total;
            }
            else if (className == "Internal_Vehicle")
            {
                total = session.QueryOver<Internal_Vehicle>().RowCountInt64();
                return total;
            }
            else if (className == "Office_Supply")
            {
                total = session.QueryOver<Office_Supply>().RowCountInt64();
                return total;
            }
            else if (className == "Order_File")
            {
                total = session.QueryOver<Order_File>().RowCountInt64();
                return total;
            }
            else if (className == "Repair_Material")
            {
                total = session.QueryOver<Repair_Material>().RowCountInt64();
                return total;
            }
            else if (className == "Transportations")
            {
                total = session.QueryOver<Transportations>().RowCountInt64();
                return total;
            }
            else if (className == "Variety_Texture")
            {
                total = session.QueryOver<Variety_Texture>().RowCountInt64();
                return total;
            }
            else if (className == "Warehouse_Space")
            {
                total = session.QueryOver<Warehouse_Space>().RowCountInt64();
                return total;
            }
            else if (className == "Warehouse_Staff")
            {
                total = session.QueryOver<Warehouse_Staff>().RowCountInt64();
                return total;
            }
            else if (className == "Decorate")
            {
                total = session.QueryOver<Decorate>().RowCountInt64();
                return total;
            }
            else if (className == "Discharge")
            {
                total = session.QueryOver<Discharge>().RowCountInt64();
                return total;
            }
            else if (className == "Transportations")
            {
                total = session.QueryOver<Transportations>().RowCountInt64();
                return total;
            }
            else if (className == "Charter_Fee_Main")
            {
                total = session.QueryOver<Charter_Fee_Main>().RowCountInt64();
                return total;
            }
            else if (className == "Charter_Fee_Detail")
            {
                total = session.QueryOver<Charter_Fee_Detail>().RowCountInt64();
                return total;
            }
            else if (className == "Driver_Check")
            {
                total = session.QueryOver<Driver_Check>().RowCountInt64();
                return total;
            }
            return total;
        }
    }
    //*****************
    //服务器保存数据
    //*****************
    public class SaveData : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            //if (e.Data.Equals("Basic_Set"))
            //{
            //    Basic_SetDAO bsd = new Basic_SetDAO();
            //    Basic_Set bs = new Basic_Set();
            //    bs = null;
            //    bs = JsonConvert.DeserializeObject<Basic_Set>(e.Data);
            //    bsd.Save(bs);
            //}
            Basic_SetDAO bsd = new Basic_SetDAO();
            Basic_Set bs = new Basic_Set();
            bs = null;
            bs = JsonConvert.DeserializeObject<Basic_Set>(e.Data);
            bsd.Save(bs);

        }
    }



    public class UpdateData : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Basic_SetDAO bsd = new Basic_SetDAO();
            Basic_Set bs = new Basic_Set();
            bs = null;
            string tmp = null;
            tmp = e.Data;
            bs = JsonConvert.DeserializeObject<Basic_Set>(tmp);
            bsd.Update(bs);
        }
    }

    public class DeleteData : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Basic_SetDAO bs = new Basic_SetDAO();
            Guid ID = new Guid(e.Data);
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
            AddDataTableToDB(dt, "dbo.T_Basic_Set");

        }

        public void AddDataTableToDB(DataTable dt, string dbName) //批量导入excel
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=123456;database=test;"))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        using (SqlBulkCopy copy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran))
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


    public class ShowDetail : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {
                ISession session = sessionFactory.OpenSession();
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<Charter_Fee_Detail> car_fee_detail = session.QueryOver<Charter_Fee_Detail>().Where(c =>c.bill_ID == e.Data).Skip((page - 1) * 50).Take(50).List();
                string json = JsonConvert.SerializeObject(car_fee_detail);
                Send(json);
            }
                
        }
    }

    public class SaveDriver_Check : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Driver_CheckDAO dcd = new Driver_CheckDAO();
            Driver_Check dc = new Driver_Check();
            dc = null;
            dc = JsonConvert.DeserializeObject<Driver_Check>(e.Data);
            dcd.Save(dc);
        }

    }

}

