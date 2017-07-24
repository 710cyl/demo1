using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface ICar_ReimbursementDAO
    {
        object Save(Car_Reimbursement entity);

        void Update(Car_Reimbursement entity);

        void Delete(Car_Reimbursement entity);

        Car_Reimbursement Get(object id);

        Car_Reimbursement Load(object id);

        IList<Car_Reimbursement> LoadALL();

        void BatchSave(List<Car_Reimbursement> record);

    }
}
