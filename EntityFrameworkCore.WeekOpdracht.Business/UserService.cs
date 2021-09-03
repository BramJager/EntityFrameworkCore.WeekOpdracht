using EntityFrameworkCore.WeekOpdracht.Business.Entities;
using EntityFrameworkCore.WeekOpdracht.Business.Interfaces;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore.WeekOpdracht.Business
{
    public class UserService : IUserService
    {
        private readonly DataContext context;
        private readonly NLog.Logger logger;

        public UserService()
        {
            this.logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            this.context = new DataContext();
        }

        public User Add(User user)
        {
            logger.Info("Add User has been called by Business");

            if(user == null)
            {
                var ex = new ArgumentNullException(nameof(user));
                logger.Error(ex);
                throw ex;
            }
                

            var userContext = context.Set<User>();
            var exists = userContext.Any(x=>x.Email == user.Email);

            if (exists)
            {
                var ex = new Exception("User already exists with given e-mail");
                logger.Error(ex);
                throw ex;
            }

            userContext.Add(user);
            context.SaveChanges();
            logger.Info($"User {user.Name} {user.Lastname} has been added to the database with ID: {user.Id}");

            return user;
        }

        public void Delete(int id)
        {
            logger.Info("Delete User Called");
            var entity = context.Set<User>().Single(x => x.Id == id);
            context.Set<User>().Remove(entity);
            context.SaveChanges();
            if (entity == null)
            {
                logger.Warn($"User {id} does not exist and has not been removed.");
            }
            else
            {
                logger.Info($"User {entity.Name} {entity.Lastname} with ID: {entity.Id} has been removed from Database.");
            }
            
        }

        public User Get(int id)
        {
            logger.Info("Get User By Id Called by Business");

            if (id <= 0)
            {
                Exception ex = new ArgumentNullException(nameof(id));
                logger.Error(ex);
                throw ex;
            }

            return context.Set<User>().Single(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            logger.Info("Get All Users Called by Business");

            return context.Set<User>().ToList();
        }
    }
}
