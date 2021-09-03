using EntityFrameworkCore.WeekOpdracht.Business.Entities;
using EntityFrameworkCore.WeekOpdracht.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore.WeekOpdracht.Business
{
    public class MessageService : IMessageService
    {
        private readonly DataContext context;
        private readonly NLog.Logger logger;

        public MessageService()
        {
            this.logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            this.context = new DataContext();
        }

        public Message Add(Message message)
        {
            logger.Info("Add Message Called By Business");

            if (message == null)
            {
                var ex = new ArgumentNullException(nameof(message));
                logger.Error(ex);
                throw ex;
            }


            context.Set<Message>().Add(message);
            context.SaveChanges();
            logger.Info($"Message {message.Title} has been added to database with Id: {message.Id}");
            return message;
        }

        public void Delete(int id)
        {
            logger.Info("Delete Message Called By Business");

            var entity = context.Set<Message>().Single(x => x.Id == id);
            context.Set<Message>().Remove(entity);
            logger.Info($"Message {entity.Title} has been removed from database with Id: {entity.Id}");
            context.SaveChanges();
        }

        public IEnumerable<Message> Get(int userId)
        {
            logger.Info($"Get All Messages of User: {userId} Called by Business");

            if (userId <= 0)
            {
                var ex = new ArgumentNullException(nameof(userId));
                logger.Error(ex);
                throw ex;
            }

            return context.Set<Message>()
                .Include(x => x.Sender)
                .Where(x => x.SenderId == userId);
        }

        public IEnumerable<Message> GetAll()
        {
            return context.Set<Message>().ToList();
        }

        public Message GetById(int id)
        {
            if (id <= 0)
            {
                var ex = new ArgumentNullException(nameof(id));
                logger.Error(ex);
                throw ex;
            }

            return context.Set<Message>()
                .Include(x => x.Sender)
                .Single(x => x.Id == id);
        }
    }
}
