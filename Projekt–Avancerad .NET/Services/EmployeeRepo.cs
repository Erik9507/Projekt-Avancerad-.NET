using Microsoft.EntityFrameworkCore;
using Models;
using Projekt_Avancerad_.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Avancerad_.NET.Services
{
    public class EmployeeRepo : IProgramRepository<Employee>
    {
        private ProgramDbContext _AppContext;
        public EmployeeRepo(ProgramDbContext AppContext)
        {
            _AppContext = AppContext;
        }
        public async Task<Employee> Add(Employee NewEmp)
        {
            var result = await _AppContext.Employees.AddAsync(NewEmp);
            await _AppContext.SaveChangesAsync();
            return result.Entity;
        } //klar

        public async Task<Employee> Delete(int Id)
        {
            var res = await _AppContext.Employees.FirstOrDefaultAsync(e => e.Id == Id);
            if (res != null)
            {
                _AppContext.Employees.Remove(res);
                await _AppContext.SaveChangesAsync();
                return res;
            }
            return null;
        } //klar

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _AppContext.Employees.ToListAsync();
        } //klar

        public async Task<Employee> GetSingel(int Id)
        {
            return await _AppContext.Employees.
                FirstOrDefaultAsync(e => e.Id == Id);
        } //klar

        public async Task<Employee> Update(Employee emp)
        {
            var res = await _AppContext.Employees.FirstOrDefaultAsync(e => e.Id == emp.Id);
            if (res != null)
            {
                res.FName = emp.FName;
                res.LName = emp.LName;
                res.Title = emp.Title;

                await _AppContext.SaveChangesAsync();
                return res;
            }
            return null;
        } //klar

        Task<IEnumerable<Employee>> IProgramRepository<Employee>.GetEmpTimeSpecWeek(int id, int week)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Employee>> IProgramRepository<Employee>.GetEmpWithTime(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Employee>> IProgramRepository<Employee>.GetProjectWithEmp(int id)
        {
            throw new NotImplementedException();
        }
    }
}
