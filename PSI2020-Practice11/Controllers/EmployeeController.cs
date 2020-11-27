using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PSI2020_Practice11.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IDbRepository _dbRepository;

        public EmployeeController(ILogger<EmployeeController> logger, IDbRepository dbRepository)
        {
            _logger = logger;
            _dbRepository = dbRepository;
        }

        [HttpGet]
        public IEnumerable<Models.Employee> GetAll()
        {
            return _dbRepository.Employees;
        }

        [HttpPost]
        public ActionResult<Models.Employee> NewEmployee(Models.Employee employee)
        {
            _dbRepository.Employees.Add(employee);
            _dbRepository.SaveChanges();

            return this.Ok(employee);
        }

        [HttpPut]
        public ActionResult<Models.Employee> UpdateEmployee(Models.Employee employee)
        {
            var oldemployee = _dbRepository.Employees.FirstOrDefault(e => e.Name == employee.Name);
            if (oldemployee == null)
            {
                return this.NotFound();                
            }
            oldemployee.Name = employee.Name;
            oldemployee.LastName = employee.LastName;
            oldemployee.Position = employee.Position;
            _dbRepository.SaveChanges();
            return this.Ok(employee);
        }


        [HttpDelete]
        public ActionResult DeleteEmployee(Models.Employee employee)
        {
            var oldemployee = _dbRepository.Employees.FirstOrDefault(e => e.Name == employee.Name);
            if (oldemployee == null)
            {
                return this.NotFound();
            }
            _dbRepository.Employees.Remove(oldemployee);
            _dbRepository.SaveChanges();
            return this.Ok();
        }


        [HttpDelete("{name}")]        
        public ActionResult DeleteEmployee(string name)
        {
            var oldemployee = _dbRepository.Employees.FirstOrDefault(e => e.Name == name);
            if (oldemployee == null)
            {
                return this.NotFound();
            }
            _dbRepository.Employees.Remove(oldemployee);
            _dbRepository.SaveChanges();
            return this.Ok();
        }

    }
}
