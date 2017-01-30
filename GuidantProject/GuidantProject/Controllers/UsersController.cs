using GuidantProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace GuidantProject.Controllers
{
    public class UsersController : ApiController
    {
        // We can create a constructor that takes the interface and implement a DependencyResolver to instantiate the repository
        private IUserRepository repository = new DictionaryUserRepository();

        // GET api/users
        public IEnumerable<User> Get()
        {
            return repository.Get();
        }

        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user;
            if (!repository.TryGet(id, out user))
            {
                return BadRequest(string.Format("User with id {0} does not exist", id));
            }

            return Ok(user);
        }

        // POST: api/Users
        [ResponseType(typeof(int))]
        public IHttpActionResult PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(repository.GetByName(user.Name) != null)
            {
                return BadRequest(string.Format("User with name '{0}' already exists", user.Name));
            }

            User addedUser = repository.Add(user);

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user.Id);
        }

        [Route("api/setpoints")]
        public IHttpActionResult PostSetPoints([FromBody] UserPoints userPoints)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!repository.TryUpdatePoints(userPoints.Id, userPoints.Points))
            {
                return BadRequest(string.Format("Cannot update points. User with id {0} does not exist", userPoints.Id));
            }

            return Ok();
        }

    }
}
