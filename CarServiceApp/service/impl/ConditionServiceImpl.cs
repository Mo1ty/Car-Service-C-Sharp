using CarServiceApp.EFCore;
using CarServiceApp.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.service.impl
{
    internal class ConditionServiceImpl : ConditionService
    {
        ConditionRepository conditionRepository = new ConditionRepository();

        public void addCondition(Condition condition)
        {
            conditionRepository.addEntity(condition);
        }

        public List<Condition> findAll()
        {
            return conditionRepository.findAll<Condition>();
        }

        public Condition findById(Guid Id)
        {
            return conditionRepository.findById<Condition>(Id);
        }
    }
}
