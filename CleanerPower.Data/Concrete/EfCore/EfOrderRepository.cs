
using CleanerPower.Data.Abstract;
using CleanerPower.Data.Concrete.EfCore;
using CleanerPower.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanerPower.Data.Concrete.EfCore
{
    public class EfOrderRepository : IOrderRepository
    {
        private OrderContext context;
        public EfOrderRepository(OrderContext _context)
        {
            context = _context;
        }
        public void AddOrder(Order entity)
        {
            context.Orders.Add(entity);
            context.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var order = context.Orders.FirstOrDefault(p => p.OrderId == orderId);
            if(order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        public IQueryable<Order> GetAll()
        {
            return context.Orders;
        }


        public Order GetById(int orderId)
        {
            return context.Orders.FirstOrDefault(p => p.OrderId == orderId);
        }

        public void SaveOrder(Order entity)
        {
            if (entity.OrderId == 0)
            {
                entity.Date = DateTime.Now;
                context.Orders.Add(entity);
            }
            else
            {
                var order = GetById(entity.OrderId);
                if (order != null)
                {
                    order.Pieces = entity.Pieces;
                    order.Pay = entity.Pay;
                    order.Name = entity.Name;
                    order.Phone = entity.Phone;
                    order.Province = entity.Province;
                    order.District = entity.District;
                    order.Address = entity.Address;
                   
                }
            }
            context.SaveChanges();

        }

        public void UpdateOrder(Order entity)
        {
            var order = GetById(entity.OrderId);
            if (order != null)
            {
                order.Pieces = entity.Pieces;
                order.Pay = entity.Pay;
                order.Name = entity.Name;
                order.Phone = entity.Phone;
                order.Province = entity.Province;
                order.District = entity.District;
                order.Address = entity.Address;

            }
            context.SaveChanges();

            }
        }
    }

