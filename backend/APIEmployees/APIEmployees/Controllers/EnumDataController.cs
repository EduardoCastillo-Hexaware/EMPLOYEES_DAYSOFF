using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using APIEmployees.Models;

namespace APIEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumDataController : ControllerBase
    {
        public readonly employeesContext _dbContext;

        public EnumDataController(employeesContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("states")]
        public IActionResult getStates() { 
        
            List<State> states = new List<State>();
            try
            {
                states = _dbContext.States.ToList();
                return StatusCode(StatusCodes.Status200OK, new {message ="ok",response = states });
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = states });
            }

        }

        [HttpPost]
        [Route("createState")]
        public IActionResult createStates([FromBody] State state) {
            try {
                _dbContext.States.Add(state);
                _dbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "State was successfully Saved!"});
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("absencesType")]
        public IActionResult getAbsencesType()
        {
            List<AbsenceType> types = new List<AbsenceType>();
            try { 
                types = _dbContext.AbsenceTypes.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = types });
            }catch (Exception ex) {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = types });
            }
        }

        [HttpPost]
        [Route("createAbsenceType")]
        public IActionResult createAbsenceType([FromBody] AbsenceType absenceType)
        {
            try
            {
                _dbContext.AbsenceTypes.Add(absenceType);
                _dbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "Absence Type was successfully Saved!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("roles")]
        public IActionResult getRoles()
        {
            List<Role> roles = new List<Role>();
            try
            {
                roles = _dbContext.Roles.ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = roles });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = roles });
            }
        }

        [HttpPost]
        [Route("createRole")]
        public IActionResult createRole([FromBody] Role role)
        {
            try
            {
                _dbContext.Roles.Add(role);
                _dbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "Role was successfully Saved!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = ex.Message });
            }
        }
    }
}
