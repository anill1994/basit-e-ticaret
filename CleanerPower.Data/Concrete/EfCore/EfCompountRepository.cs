
using CleanerPower.Data.Abstract;
using CleanerPower.Data.Concrete.EfCore;
using CleanerPower.Entity;
using CleanerPower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanerPower.Data.Concrete.EfCore
{
    public class EfCompountRepository : ICompountRepository
    {
        private OrderContext context;
        public EfCompountRepository(OrderContext _context)
        {
            context = _context;
        }

        public IQueryable<Compount> GetAll()
        {
            return context.Compounts;
        }
        public void AddCompount(Compount entity)
        {
            context.Compounts.Add(entity);
            context.SaveChanges();
        }

        public void DeleteCompount(int compountId)
        {
            var compount = context.Compounts.FirstOrDefault(p => p.CompountId == compountId);
            if (compount != null)
            {
                context.Compounts.Remove(compount);
                context.SaveChanges();
            }
        }


        public Compount GetById(int compountId)
        {
            return context.Compounts.FirstOrDefault(p => p.CompountId == compountId);
        }

        public void SaveCompount(Compount entity)
        {
            if (entity.CompountId == 0)
            {
                context.Compounts.Add(entity);
            }
            else
            {
                var compount = GetById(entity.CompountId);
                if (compount != null)
                {
                    compount.Order = entity.Order;
                    compount.Message = entity.Message;
                   
                   
                }
            }
            context.SaveChanges();

        }

        public void UpdateCompount(Compount entity)
        {
            var compount = GetById(entity.CompountId);
            if (compount != null)
            {
                compount.Order = entity.Order;
                compount.Message = entity.Message;

            }
            context.SaveChanges();

            }
        }
    }

