using CleanerPower.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanerPower.Data.Abstract
{
    public interface IMessageRepository
    {
        Message GetById(int messageId);
        IQueryable<Message> GetAll();
        void AddMessage(Message entity);
        void SaveMessage(Message entity);
        void UpdateMessage(Message entity);
        void DeleteMessage(int messageId);
    }
}
