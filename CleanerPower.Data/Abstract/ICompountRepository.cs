using CleanerPower.Entity;
using CleanerPower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanerPower.Data.Abstract
{
    public interface ICompountRepository
    {
        Compount GetById(int compountId);
        IQueryable<Compount> GetAll();
        void AddCompount(Compount entity);
        void SaveCompount(Compount entity);
        void UpdateCompount(Compount entity);
        void DeleteCompount(int compountId);
    }
}
