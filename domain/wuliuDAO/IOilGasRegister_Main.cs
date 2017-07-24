using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface IOilGasRegister_MainDAO
    {
        object Save(OilGasRegister_Main entity);

        void Update(OilGasRegister_Main entity);

        void Delete(OilGasRegister_Main entity);

        OilGasRegister_Main Get(object id);

        OilGasRegister_Main Load(object id);

        IList<OilGasRegister_Main> LoadALL();

        void BatchSave(List<OilGasRegister_Main> record);

    }
}
