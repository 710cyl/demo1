using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface ITransportationClearing_DetailDAO
    {
        object Save(TransportationClearing_Detail entity);

        void Update(TransportationClearing_Detail entity);

        void Delete(TransportationClearing_Detail entity);

        TransportationClearing_Detail Get(object id);

        TransportationClearing_Detail Load(object id);

        IList<TransportationClearing_Detail> LoadALL();

        void BatchSave(List<TransportationClearing_Detail> record);

    }
}
