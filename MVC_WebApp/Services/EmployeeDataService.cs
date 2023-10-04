using MVC_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_WebApp.Services
{
    public class EmployeeDataService : IDataAccessService<Employee, int>
    {
        RCompanyDbContext ctx;

        public EmployeeDataService()
        {
            ctx = new RCompanyDbContext();
        }


        Employee IDataAccessService<Employee, int>.Create(Employee entity)
        {
           var result = ctx.Employees.Add(entity);
            ctx.SaveChanges();
            return result;
        }

        Employee IDataAccessService<Employee, int>.Delete(int pk)
        {
            var record = ctx.Employees.Find(pk);
            ctx.Employees.Remove(record);
            ctx.SaveChanges();
            return record;
        }

        IEnumerable<Employee> IDataAccessService<Employee, int>.Get()
        {
            var result = ctx.Employees.ToList();
            return result;
        }

        Employee IDataAccessService<Employee, int>.Get(int pk)
        {
            var resut = ctx.Employees.Find(pk);
            return resut;
        }

        Employee IDataAccessService<Employee, int>.Update(int id, Employee entity)
        {
            var record = ctx.Employees.Find(id);
            record.EmpName = entity.EmpName;
            record.Designation = entity.Designation;
            record.Salary = entity.Salary;
            record.DeptNo = entity.DeptNo;
            ctx.SaveChanges();
            return record;
        }
    }
}