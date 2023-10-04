using MVC_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_WebApp.Services
{
    public class DepartmentDataService : IDataAccessService<Department, int>
    {
        RCompanyDbContext ctx;

        public DepartmentDataService()
        {
            ctx = new RCompanyDbContext();
        }


        Department IDataAccessService<Department, int>.Create(Department entity)
        {
           var result = ctx.Departments.Add(entity);
            ctx.SaveChanges();
            return result;
        }

        Department IDataAccessService<Department, int>.Delete(int pk)
        {
            var record = ctx.Departments.Find(pk);
            ctx.Departments.Remove(record);
            ctx.SaveChanges();
            return record;
        }

        IEnumerable<Department> IDataAccessService<Department, int>.Get()
        {
            var result = ctx.Departments.ToList();
            return result;
        }

        Department IDataAccessService<Department, int>.Get(int pk)
        {
            var resut = ctx.Departments.Find(pk);
            return resut;
        }

        Department IDataAccessService<Department, int>.Update(int id, Department entity)
        {
            var record = ctx.Departments.Find(id);
            record.DeptName = entity.DeptName;
            record.Location = entity.Location;
            record.Capacity= entity.Capacity;
            ctx.SaveChanges();
            return record;
        }
    }
}