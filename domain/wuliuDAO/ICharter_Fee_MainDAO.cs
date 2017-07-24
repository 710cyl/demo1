using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface ICharter_Fee_MainDAO
    {
        object Save(Charter_Fee_Main entity);

        void Update(Charter_Fee_Main entity);

        void Delete(Charter_Fee_Main entity);

        Charter_Fee_Main Get(object id);

        Charter_Fee_Main Load(object id);

        IList<Charter_Fee_Main> LoadALL();

        void BatchSave(List<Charter_Fee_Main> record);

    }
}
