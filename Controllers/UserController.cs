using loginAssignment.Model;
using loginAssignment.Model.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace loginAssignment.Controllers
{
  
    [ApiController]
    [Route("api/UserModel")]
    
    public class UserController : ControllerBase
    {
       private readonly IDataRepository<UserModel> _dataRepository;
       public UserController(IDataRepository<UserModel> userRepository)
        {
            _dataRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserModel emp)
        {
            var user = _dataRepository.Authenticate(emp.Email, emp.Password);
            if (user != null)

            { return BadRequest("User is null"); }


            _dataRepository.Add(emp);
            return Ok(emp);
            //CreatedAtRoute(
            //      "Get",
            //      new { Id = user.UserId },
            //      user);
        }
        //Token/Api/user
        [AllowAnonymous]
        [HttpPost("log")]
        public IActionResult Login([FromBody] UserModel user)
        {
          var emp =   _dataRepository.Authenticate(user.Email, user.Password);
            if (emp == null)

            { return BadRequest("User is null"); }


          
            return Ok(emp);
        }
        // GET: api/user
        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var emp  = _dataRepository.GetAll();
            return Ok(emp);
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            UserModel user = _dataRepository.Get(id);

            if (user == null)
            {
                return NotFound("The user record couldn't be found.");
            }

            return Ok(user);
        }

        // POST: api/Employee


        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            UserModel userToUpdate = _dataRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Update(userToUpdate, user);
            return NoContent();
        }

        // DELETE: api/UserModel/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            UserModel user = _dataRepository.Get(id);
            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Delete(user);
            return NoContent();
        }
    }
}
