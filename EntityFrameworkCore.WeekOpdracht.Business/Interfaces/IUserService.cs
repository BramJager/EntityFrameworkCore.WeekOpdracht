using EntityFrameworkCore.WeekOpdracht.Business.Entities;
using System.Collections.Generic;

namespace EntityFrameworkCore.WeekOpdracht.Business.Interfaces
{
    public interface IUserService
    {
        User Add(User user);
        User Get(int id);
        IEnumerable<User> GetAll();
        void Delete(int id);
    }
}
