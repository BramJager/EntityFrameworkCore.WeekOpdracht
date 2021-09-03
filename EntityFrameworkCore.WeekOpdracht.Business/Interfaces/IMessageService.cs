using EntityFrameworkCore.WeekOpdracht.Business.Entities;
using System.Collections.Generic;

namespace EntityFrameworkCore.WeekOpdracht.Business.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<Message> Get(int userId);
        Message Add(Message message);
        Message GetById(int id);
        IEnumerable<Message> GetAll();
        void Delete(int id);
    }
}
