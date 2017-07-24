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

    public class Charter_Fee_MainDAO : ICharter_Fee_MainDAO
    {
        private ISessionFactory sessionFactory;

        public Charter_Fee_MainDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save(domain.Charter_Fee_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update(domain.Charter_Fee_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete(domain.Charter_Fee_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public domain.Charter_Fee_Main Get(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.Charter_Fee_Main>(id);
            }

        }
        public domain.Charter_Fee_Main Load(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.Charter_Fee_Main>(id);
            }
        }


        public IList<Charter_Fee_Main> LoadALL()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Query<domain.Charter_Fee_Main>().ToList();
            }
        }

        public void BatchSave(List<Charter_Fee_Main> records)
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
                            //Charter_Fee_Main item = (Charter_Fee_Main)obj;
                            Charter_Fee_Main item = (Charter_Fee_Main)obj;
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
