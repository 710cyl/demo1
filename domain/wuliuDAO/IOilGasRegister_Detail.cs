using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface IOilGasRegister_DetailDAO
    {
        object Save(OilGasRegister_Detail entity);

        void Update(OilGasRegister_Detail entity);

        void Delete(OilGasRegister_Detail entity);

        OilGasRegister_Detail Get(object id);

        OilGasRegister_Detail Load(object id);

        IList<OilGasRegister_Detail> LoadALL();

        void BatchSave(List<OilGasRegister_Detail> record);

    }
}
