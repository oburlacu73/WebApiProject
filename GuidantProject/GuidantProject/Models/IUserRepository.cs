using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidantProject.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        bool TryGet(int id, out User User);
        User Add(User User);
        bool TryUpdatePoints(int id, int points);
        User GetByName(string name);
    }
}
