using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Projekt_Avancerad_.NET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Avancerad_.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportController : ControllerBase
    {
        private IProgramRepository<TimeReport> _iProgram;
        public TimeReportController(IProgramRepository<TimeReport> programRepository)
        {
            this._iProgram = programRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeReports()
        {
            try
            {
                return Ok(await _iProgram.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can´t get all timereports...");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeReport>> GetTimeReport(int id)
        {
            try
            {
                var res = await _iProgram.GetSingel(id);
                if (res == null)
                {
                    return NotFound();
                }
                return res;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can´t get specific timereport");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TimeReport>> CreateTimeReport(TimeReport timeReport)
        {
            try
            {
                if (timeReport == null)
                {
                    return BadRequest();
                }
                var createdTR = await _iProgram.Add(timeReport);
                return CreatedAtAction(nameof(GetTimeReport), new { id = createdTR.Id }, createdTR);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can´t create timereport");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeReport>> Delete(int id)
        {
            try
            {
                var TrToDelete = await _iProgram.GetSingel(id);
                if (TrToDelete == null)
                {
                    return NotFound($"Timereport with id {id} not found");
                }
                return await _iProgram.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can not delete imereport");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TimeReport>> UpdateTimeReport(int id, TimeReport tr)
        {
            try
            {
                if (id != tr.Id)
                {
                    return BadRequest("Timereport id does not exist");
                }
                var TrToUpdate = await _iProgram.GetSingel(id);
                if (TrToUpdate == null)
                {
                    return NotFound($"Timereport with id {id} not found");
                }
                return await _iProgram.Update(tr);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can not update timereport");
            }
        }


        [HttpGet]
        [Route("getempwithtimereport/{id}")]
        public async Task<ActionResult<TimeReport>> GetEmpWithTime(int id)
        {
            try
            {
                var res = await _iProgram.GetEmpWithTime(id);  
                if (res != null)
                {

                    return Ok(res);
                }
                return NotFound("Error");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpGet]
        [Route("getprojectwithemp/{id}")]
        public async Task<ActionResult<TimeReport>> GetProjectWithEmp(int id)
        {
            try
            {
                var res = await _iProgram.GetProjectWithEmp(id);
                if (res != null)
                {

                    return Ok(res);
                }
                return NotFound("Error1");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error2");
            }
        }

        [HttpGet]
        [Route("getemptimespecweek/{id}/{week}")]
        public async Task<ActionResult<TimeReport>> GetEmpTimeSpecWeek(int id, int week)
        {
            try
            {
                var res = await _iProgram.GetEmpTimeSpecWeek(id, week);
                if (res != null)
                {

                    return Ok(res);
                }
                return NotFound("Error not found");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
    }
}
