using API_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API_App.Services
{
    public class EmployeeDataService : IDataAccessService<Employee, int>
    {
        Task<ResponseObject<Employee>> IDataAccessService<Employee, int>.CreateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        Task<ResponseObject<Employee>> IDataAccessService<Employee, int>.DeleteAsync(int pk)
        {
            throw new NotImplementedException();
        }

        Task<ResponseObject<Employee>> IDataAccessService<Employee, int>.GetAsync()
        {
            throw new NotImplementedException();
        }

        Task<ResponseObject<Employee>> IDataAccessService<Employee, int>.GetAsync(int pk)
        {
            throw new NotImplementedException();
        }

        Task<ResponseObject<Employee>> IDataAccessService<Employee, int>.UpdateAsync(int id, Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}