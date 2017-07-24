using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface ICharter_Fee_DetailDAO
    {
        object Save(Charter_Fee_Detail entity);

        void Update(Charter_Fee_Detail entity);

        void Delete(Charter_Fee_Detail entity);

        Charter_Fee_Detail Get(object id);

        Charter_Fee_Detail Load(object id);

        IList<Charter_Fee_Detail> LoadALL();

        void BatchSave(List<Charter_Fee_Detail> record);

    }
}
