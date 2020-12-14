using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using loginAssignment.Model;
using loginAssignment.Model.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace loginAssignment.Controllers
{
    [Route("api/test")]
    public class TestController : ControllerBase {
        private readonly IDataRepository<UserModel> _dataRepository;


        public TestController(IDataRepository<UserModel> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //IEnumerable<UserModel> Users = _dataRepository.GetAll();
            return new string[] { "vue1", "value2" };
        }

        
    }
}
