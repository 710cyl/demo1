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

    public class TransportationClearing_MainDAO : ITransportationClearing_MainDAO
    {
        private ISessionFactory sessionFactory;

        public TransportationClearing_MainDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save(domain.TransportationClearing_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update(domain.TransportationClearing_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete(domain.TransportationClearing_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public domain.TransportationClearing_Main Get(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.TransportationClearing_Main>(id);
            }

        }
        public domain.TransportationClearing_Main Load(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.TransportationClearing_Main>(id);
            }
        }


        public IList<TransportationClearing_Main> LoadALL()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Query<domain.TransportationClearing_Main>().ToList();
            }
        }

        public void BatchSave(List<TransportationClearing_Main> records)
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
                            //TransportationClearing_Main item = (TransportationClearing_Main)obj;
                            TransportationClearing_Main item = (TransportationClearing_Main)obj;
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
