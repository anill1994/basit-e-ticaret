using CleanerPower.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanerPower.Data.Abstract
{
    public interface IOrderRepository
    {
        Order GetById(int orderId);
        IQueryable<Order> GetAll();
        void AddOrder(Order entity);
        void SaveOrder(Order entity);
        void UpdateOrder(Order entity);
        void DeleteOrder(int orderId);
    }
}
