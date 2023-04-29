using CarServiceApp.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.service
{
    internal interface ConditionService
    {
        Condition findById(Guid Id);
        List<Condition> findAll();
        void addCondition(Condition condition);

        string exportCSV();
    }
}
