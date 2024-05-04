using APIEmployees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIEmployees.Models;

namespace APIEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public readonly employeesContext _dbContext;

        public UserController(employeesContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult getUser()
        {
            List<User> users = new List<User>();
            try
            {
                users = _dbContext.Users.Include(e => e.Employee).Include(r=> r.Role).ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = users });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = users });
            }
        }
    }
}
