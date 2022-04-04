using Microsoft.EntityFrameworkCore;
using Models;
using Projekt_Avancerad_.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Avancerad_.NET.Services
{
    public class TimeReportRepo : IProgramRepository<TimeReport>
    {
        private ProgramDbContext _AppContext;
        public TimeReportRepo(ProgramDbContext AppContext)
        {
            _AppContext = AppContext;
        }

        public async Task<TimeReport> Add(TimeReport NewTR)
        {
            var result = await _AppContext.TimeReports.AddAsync(NewTR);
            await _AppContext.SaveChangesAsync();
            return result.Entity;
        } //klar

        public async Task<TimeReport> Delete(int Id)
        {
            var res = await _AppContext.TimeReports.FirstOrDefaultAsync(t => t.Id == Id);
            if (res != null)
            {
                _AppContext.TimeReports.Remove(res);
                await _AppContext.SaveChangesAsync();
                return res;
            }
            return null;
        } //klar

        public async Task<IEnumerable<TimeReport>> GetAll()
        {
            return await _AppContext.TimeReports.ToListAsync();
        } //klar

        public async Task<TimeReport> GetSingel(int Id)
        {
            return await _AppContext.TimeReports.
                FirstOrDefaultAsync(t => t.Id == Id);
        } //klar

        public async Task<TimeReport> Update(TimeReport TR)
        {
            var res = await _AppContext.TimeReports.FirstOrDefaultAsync(t => t.Id == TR.Id);
            if (res != null)
            {
                res.WeekNumber = TR.WeekNumber;
                res.HoursWorked = TR.HoursWorked;
                res.EmployeeId = TR.EmployeeId;
                res.ProjetId = TR.ProjetId;
                await _AppContext.SaveChangesAsync();
                return res;
            }
            return null;
        } //klar



        public async Task<IEnumerable<TimeReport>> GetEmpWithTime(int id) //Vi vill kunna hämta ut detaljerad information om en specifik anställd och dennas tidsrapporter
        {
            var res = await _AppContext.TimeReports.Include(e => e.Employee).Where(em => em.EmployeeId == id).ToListAsync();
            if (res != null)
            {
                return res;
            }
            return null;
        }
        

        public async Task<IEnumerable<TimeReport>> GetProjectWithEmp(int id) //Vi vill kunna få ut en lista på alla anställda som jobba med ett specifikt projekt
        {
            var res = await _AppContext.TimeReports.Include(x => x.Project).Include(y => y.Employee).Where(e => e.ProjetId == id).ToListAsync();
            if (res != null)
            {
                return res;
            }
            return null;
        } 


        public async Task<IEnumerable<TimeReport>> GetEmpTimeSpecWeek(int id, int week) 
        {
            var res = await _AppContext.TimeReports.Include(x => x.Employee).Where(a => a.EmployeeId == id)
                .Where(b => b.WeekNumber == week).ToListAsync();
            if (res != null)
            {
                return res;
            }
            return null;

        } //Vi vill kunna få ut många timmar en specifik anställd jobbat en specifik vecka
    }
}
