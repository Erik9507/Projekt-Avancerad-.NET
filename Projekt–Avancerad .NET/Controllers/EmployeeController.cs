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
    public class EmployeeController : ControllerBase
    {
        private IProgramRepository<Employee> _iProgram;
        public EmployeeController(IProgramRepository<Employee> programRepository)
        {
            this._iProgram = programRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmp()
        {
            try
            {
                return Ok(await _iProgram.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can´t get all employees...");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can´t get specific employee");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var createdEmp = await _iProgram.Add(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmp.Id }, createdEmp);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can´t create employee");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            try
            {
                var EmpToDelete = await _iProgram.GetSingel(id);
                if (EmpToDelete == null)
                {
                    return NotFound($"Employee with id {id} not found");
                }
                return await _iProgram.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can not delete Employee");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee emp)
        {
            try
            {
                if (id != emp.Id)
                {
                    return BadRequest("Employee id does not exist");
                }
                var employeeToUpdate = await _iProgram.GetSingel(id);
                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with id {id} not found");
                }
                return await _iProgram.Update(emp);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can not update employee");
            }
        }


    }
}
