using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIEmployees.Models;

namespace APIEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly employeesContext _dbContext;

        public EmployeeController(employeesContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("getEmployees")]
        public IActionResult getEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = _dbContext.Employees.Include(g=>g.Gender).ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = employees });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = employees });
            }
        }

        [HttpGet]
        [Route("getEmployee/{employeeId:int}")]
        public IActionResult getEmployee(int employeeId)
        {
            Employee employee = _dbContext.Employees.Find(employeeId);
            if (employee == null) { return BadRequest("Employee was not found!"); }

            try
            {
                employee = _dbContext.Employees.Include(g=>g.Gender).Where(e=>e.Id == employeeId).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = employee });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = employee });
            }
        }



        [HttpPost]
        [Route("create/{roleId:int}")]
        public IActionResult createEmployee([FromBody] Employee employee, int roleId)
        {
            try
            {
                Role role = _dbContext.Roles.Find(roleId);
                if (role == null) { return BadRequest("Role to update does not exist!"); }

                _dbContext.Employees.Add(employee);
                
                //Create user for the employee created

                User newUser = new User();
                newUser.UserName = employee.Name.ToLower().Replace(" ","");
                newUser.Password = employee.Name.ToLower().Replace(" ", "");
                newUser.EmployeeId = _dbContext.Employees.Max(e => e.Id);
                newUser.RoleId = roleId;
                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "Employee Saved! \nAnd User Created " +
                    "Successfully for the new Employee" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message});
            }
        }

        [HttpPut]
        [Route("editEmployee/{roleId:int}")]
        public IActionResult editEmployeeContactDetails([FromBody] Employee employee, int roleId)
        {
            Employee employeeToEdit = _dbContext.Employees.Find(employee.Id);
            Role role = _dbContext.Roles.Find(roleId);

            if (employeeToEdit == null){return BadRequest("Employee was not found!");}
            if (role == null) { return BadRequest("Role to update does not exist!"); }

            try
            {
                employeeToEdit.Email = employee.Email;
                employeeToEdit.PhoneNumber = employee.PhoneNumber;

                _dbContext.Employees.Update(employeeToEdit);
                _dbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete/{employeeid:int}")]
        public IActionResult deleteEmployee(int employeeid)
        {
            Employee employeeToDelete = _dbContext.Employees.Find(employeeid);
            

            if (employeeToDelete == null) { return BadRequest("Employee was not found!"); }
            
            try
            {
                _dbContext.Employees.Remove(employeeToDelete);
                _dbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new
                {
                    message = "Employee was Deleted Successfully and it's user too!"
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }



    }
}
