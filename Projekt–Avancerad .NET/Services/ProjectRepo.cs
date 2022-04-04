using Microsoft.EntityFrameworkCore;
using Models;
using Projekt_Avancerad_.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Avancerad_.NET.Services
{
    public class ProjectRepo : IProgramRepository<Project>
    {
        private ProgramDbContext _AppContext;
        public ProjectRepo(ProgramDbContext AppContext)
        {
            _AppContext = AppContext;
        }

        public async Task<Project> Add(Project NewProject)
        {
            var result = await _AppContext.Projects.AddAsync(NewProject);
            await _AppContext.SaveChangesAsync();
            return result.Entity;
        } //klar

        public async Task<Project> Delete(int Id)
        {
            var res = await _AppContext.Projects.FirstOrDefaultAsync(p => p.Id == Id);
            if (res != null)
            {
                _AppContext.Projects.Remove(res);
                await _AppContext.SaveChangesAsync();
                return res;
            }
            return null;
        } //klar

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _AppContext.Projects.ToListAsync();
        } //klar

        public async Task<Project> GetSingel(int Id)
        {
            return await _AppContext.Projects.
                FirstOrDefaultAsync(p => p.Id == Id);
        } //klar

        public async Task<Project> Update(Project project)
        {
            var res = await _AppContext.Projects.FirstOrDefaultAsync(p => p.Id == project.Id);
            if (res != null)
            {
                res.ProjectName = project.ProjectName;
                await _AppContext.SaveChangesAsync();
                return res;
            }
            return null;
        } //klar

        Task<IEnumerable<Project>> IProgramRepository<Project>.GetEmpTimeSpecWeek(int id, int week)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Project>> IProgramRepository<Project>.GetEmpWithTime(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Project>> IProgramRepository<Project>.GetProjectWithEmp(int id)
        {
            throw new NotImplementedException();
        }
    }
}
