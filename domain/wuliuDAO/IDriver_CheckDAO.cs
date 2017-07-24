using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface IDriver_CheckDAO
    {
        object Save(Driver_Check entity);

        void Update(Driver_Check entity);

        void Delete(Driver_Check entity);

        Driver_Check Get(object id);

        Driver_Check Load(object id);

        IList<Driver_Check> LoadALL();

        void BatchSave(List<Driver_Check> record);

    }
}
