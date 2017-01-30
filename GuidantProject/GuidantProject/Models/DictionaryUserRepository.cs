using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuidantProject.Models
{
    public class DictionaryUserRepository : IUserRepository
    {
        // If we want synchronization we can implement a ConcurrentDictionaryUserRepository using ConcurrentDictionary and Interlocked.Incement to incement the id
        static int nextId = 0;
        static Dictionary<int, User> Users = new Dictionary<int, User>();

        public IEnumerable<User> Get()
        {
            return Users.Values.OrderBy(User => User.Id);
        }

        public bool TryGet(int Id, out User User)
        {
            return Users.TryGetValue(Id, out User);
        }

        public User Add(User User)
        {
            User.Id = nextId++;
            Users[User.Id] = User;
            return User;
        }

        public User GetByName(string name)
        {
            return Users.Values.FirstOrDefault(user => user.Name.ToLowerInvariant() == name.ToLowerInvariant());
        }

        public bool TryUpdatePoints(int id, int points)
        {
            bool updated = Users.ContainsKey(id);

            if(updated)
                Users[id].Points = points;

            return updated;
        }
    }
}