using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Avancerad_.NET.Services
{
    public interface IProgramRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingel(int Id);
        Task<T> Add(T NewEntity);
        Task<T> Delete(int Id);
        Task<T> Update(T Entity);




        Task<IEnumerable<T>> GetEmpWithTime(int id);
        Task<IEnumerable<T>> GetProjectWithEmp(int id);
        Task<IEnumerable<T>> GetEmpTimeSpecWeek(int id, int week);
    }
}
