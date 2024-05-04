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
            List<AbsenceRequest> absences = new List<AbsenceRequest>();
            try
            {
                absences = _dbContext.AbsenceRequests.Include(e => e.Employee).Include(at => at.AbsenceType).ToList();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = absences });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = absences });
            }
        }

        [HttpGet]
        [Route("create")]
        public IActionResult createAbsenceRequests([FromBody] AbsenceRequest absenceRequest)
        {
            try
            {
                _dbContext.AbsenceRequests.Add(absenceRequest);   
                return StatusCode(StatusCodes.Status200OK, new { message = "Absence Request Submited!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("chageStatus/{absRequestId:int}/{statusId:int}")]
        public IActionResult changeStatus( int absRequestId, int statusId)
        {
            AbsenceRequest absR = _dbContext.AbsenceRequests.Find(absRequestId);
            State state = _dbContext.States.Find(statusId);

            if (absR == null) { return BadRequest("Absence Request was not found!"); }
            if (state == null) { return BadRequest("State to save does not exist!"); }

            try
            {
                absR.State = state;
                _dbContext.AbsenceRequests.Update(absR);
                _dbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { message = "Absence Request Submited!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }




    }
}
