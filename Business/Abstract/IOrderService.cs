﻿using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);
        IDataResult<List<Order>> GetList();

        IDataResult<Order> GetById(int id);

    }
}
