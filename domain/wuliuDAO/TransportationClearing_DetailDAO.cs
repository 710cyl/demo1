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

    public class TransportationClearing_DetailDAO : ITransportationClearing_DetailDAO
    {
        private ISessionFactory sessionFactory;

        public TransportationClearing_DetailDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save(domain.TransportationClearing_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update(domain.TransportationClearing_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete(domain.TransportationClearing_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public domain.TransportationClearing_Detail Get(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.TransportationClearing_Detail>(id);
            }

        }
        public domain.TransportationClearing_Detail Load(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.TransportationClearing_Detail>(id);
            }
        }


        public IList<TransportationClearing_Detail> LoadALL()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Query<domain.TransportationClearing_Detail>().ToList();
            }
        }

        public void BatchSave(List<TransportationClearing_Detail> records)
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
                            //TransportationClearing_Detail item = (TransportationClearing_Detail)obj;
                            TransportationClearing_Detail item = (TransportationClearing_Detail)obj;
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
