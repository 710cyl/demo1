using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface ITransportationClearing_MainDAO
    {
        object Save(TransportationClearing_Main entity);

        void Update(TransportationClearing_Main entity);

        void Delete(TransportationClearing_Main entity);

        TransportationClearing_Main Get(object id);

        TransportationClearing_Main Load(object id);

        IList<TransportationClearing_Main> LoadALL();

        void BatchSave(List<TransportationClearing_Main> record);

    }
}
