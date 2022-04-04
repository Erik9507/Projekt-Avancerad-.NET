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
    public class ProjectController : ControllerBase
    {
        private IProgramRepository<Project> _iProgram;
        public ProjectController(IProgramRepository<Project> programRepository)
        {
            this._iProgram = programRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                return Ok(await _iProgram.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can´t get all projects...");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can´t get specific project");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return BadRequest();
                }
                var createdProject = await _iProgram.Add(project);
                return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can´t create project");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> Delete(int id)
        {
            try
            {
                var ProjectToDelete = await _iProgram.GetSingel(id);
                if (ProjectToDelete == null)
                {
                    return NotFound($"Project with id {id} not found");
                }
                return await _iProgram.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can not delete Project");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project pro)
        {
            try
            {
                if (id != pro.Id)
                {
                    return BadRequest("Project id does not exist");
                }
                var projectToUpdate = await _iProgram.GetSingel(id);
                if (projectToUpdate == null)
                {
                    return NotFound($"Project with id {id} not found");
                }
                return await _iProgram.Update(pro);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, can not update project");
            }
        }
    }
}
