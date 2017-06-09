using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;
using NHibernate;
using domain;
using Newtonsoft.Json;
namespace wuliu_server
{
    class Program
    {
        static void Main(string[] args)
        {
            var wssv = new WebSocketServer("ws://localhost:9000");
            wssv.AddWebSocketService<ShowData>("/ShowData");
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
                    IList<Basic_Set> basic_set = session.QueryOver<Basic_Set>().List(); ;
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
    } 
}
