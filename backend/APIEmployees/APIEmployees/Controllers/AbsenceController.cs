using APIEmployees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIEmployees.Models;

namespace APIEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        public readonly employeesContext _dbContext;

        public AbsenceController(employeesContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult getAbsenceRequests()
        {
            List<AbsenceRequest> users = new List<AbsenceRequest>();
            try
            {
                users = _dbContext.AbsenceRequests.Include(e => e.Employee).Include(at => at.AbsenceType).ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = users });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = users });
            }
        }
    }
}
