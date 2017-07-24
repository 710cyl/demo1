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

    public class OilGasRegister_MainDAO : IOilGasRegister_MainDAO
    {
        private ISessionFactory sessionFactory;

        public OilGasRegister_MainDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save(domain.OilGasRegister_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update(domain.OilGasRegister_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete(domain.OilGasRegister_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public domain.OilGasRegister_Main Get(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.OilGasRegister_Main>(id);
            }

        }
        public domain.OilGasRegister_Main Load(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.OilGasRegister_Main>(id);
            }
        }


        public IList<OilGasRegister_Main> LoadALL()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Query<domain.OilGasRegister_Main>().ToList();
            }
        }

        public void BatchSave(List<OilGasRegister_Main> records)
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
                            //OilGasRegister_Main item = (OilGasRegister_Main)obj;
                            OilGasRegister_Main item = (OilGasRegister_Main)obj;
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
