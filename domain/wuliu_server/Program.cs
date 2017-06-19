using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;
using NHibernate;
using domain;
using Newtonsoft.Json;
using wuliuDAO;
namespace wuliu_server
{
    class Program
    {
        static void Main(string[] args)
        {
            var wssv = new WebSocketServer("ws://localhost:9000");
            wssv.AddWebSocketService<ShowData>("/ShowData");
            wssv.AddWebSocketService<DeleteData>("/DeleteData");
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
                    //Type elements = Type.GetType(e.Data);
                    //Type generic = typeof(IList<>);
                    //generic = generic.MakeGenericType(new Type[] { elements });
                    //var list = Activator.CreateInstance(generic);
                    session = sessionFactory.OpenSession();
                    IList<Basic_Set> basic_set = session.QueryOver<Basic_Set>().List();
                   // FindList<elements>(session, elements);
                    string json = JsonConvert.SerializeObject(basic_set);
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

        public IList<T> FindList<T>(ISession session,T t) where T :class
        {
            IList<T> basic_set = session.QueryOver<T>().List();
            return basic_set;
        } 
    } 

    public class DeleteData :WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Basic_SetDAO bs = new Basic_SetDAO();
            Guid ID;
            ID = new Guid(e.Data);
            var basicset = bs.Get(ID);
            bs.Delete(basicset);
        }
    }
}
