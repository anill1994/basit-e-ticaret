
using CleanerPower.Data.Abstract;
using CleanerPower.Data.Concrete.EfCore;
using CleanerPower.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanerPower.Data.Concrete.EfCore
{
    public class EfMessageRepository : IMessageRepository
    {
        private OrderContext context;
        public EfMessageRepository(OrderContext _context)
        {
            context = _context;
        }
        public void AddMessage(Message entity)
        {
            context.Messages.Add(entity);
            context.SaveChanges();
        }

        public void DeleteMessage(int messageId)
        {
            var message = context.Messages.FirstOrDefault(p => p.MessageId == messageId);
            if(message != null)
            {
                context.Messages.Remove(message);
                context.SaveChanges();
            }
        }

        public IQueryable<Message> GetAll()
        {
            return context.Messages;
        }


        public Message GetById(int messageId)
        {
            return context.Messages.FirstOrDefault(p => p.MessageId == messageId);
        }

        public void SaveMessage(Message entity)
        {
            if (entity.MessageId == 0)
            {
                entity.Date = DateTime.Now;
                context.Messages.Add(entity);
            }
            else
            {
                var message = GetById(entity.MessageId);
                if (message != null)
                {
                   
                    message.Name = entity.Name;
                    message.Email = entity.Email;
                    message.Mesaj = entity.Mesaj;
                   
                   
                }
            }
            context.SaveChanges();

        }

        public void UpdateMessage(Message entity)
        {
            var message = GetById(entity.MessageId);
            if (message != null)
            {
                message.Name = entity.Name;
                message.Email = entity.Email;
                message.Mesaj = entity.Mesaj;

            }
            context.SaveChanges();

            }
        }
    }

