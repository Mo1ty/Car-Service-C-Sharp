﻿using CarServiceApp.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.service
{
    internal interface DealService
    {
        Deal findById(Guid Id);
        List<Deal> findAll();
        void addDeal(Deal deal);
        string exportCSV(string Path);
        void importCSV(string Path);
    }
}
