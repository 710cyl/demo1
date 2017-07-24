using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using domain;
using Newtonsoft.Json;
namespace wuliuDAO
{

    public class Driver_CheckDAO : IDriver_CheckDAO
    {
        private ISessionFactory sessionFactory;

        public Driver_CheckDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save(domain.Driver_Check entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update(domain.Driver_Check entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete(domain.Driver_Check entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public domain.Driver_Check Get(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.Driver_Check>(id);
            }

        }
        public domain.Driver_Check Load(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.Driver_Check>(id);
            }
        }


        public IList<Driver_Check> LoadALL()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Query<domain.Driver_Check>().ToList();
            }
        }

        public void BatchSave(List<Driver_Check> records)
        {

            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    try
                    {
                        session.SetBatchSize(50);
                        foreach (var obj in records)
                        {
                            //Driver_Check item = (Driver_Check)obj;
                            Driver_Check item = (Driver_Check)obj;
                            session.SaveOrUpdate(item);
                            session.Flush();
                        }
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                    }
                }
            }
        }
    }
}
