using API_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API_App.Services
{
    public class EmployeeDataService : IDataAccessService<Employee, int>
    {
        RCompanyEntities ctx;

        ResponseObject<Employee> response;


        public EmployeeDataService()
        {
            ctx = new RCompanyEntities();
            response = new ResponseObject<Employee>();
        }

        async Task<ResponseObject<Employee>> IDataAccessService<Employee, int>.CreateAsync(Employee entity)
        {
            try
            {
                response.Record = ctx.Employees.Add(entity);
                await ctx.SaveChangesAsync();
                response.IsSuccess = true;
                response.StatusMessage = "Employee added successfully";
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                response.StatusMessage = "Error Occurred while adding record";
                response.IsSuccess= false;
                response.StatusCode=500;
            }
            return response;
        }

        async Task<ResponseObject<Employee>> IDataAccessService<Employee, int>.DeleteAsync(int pk)
        {
            try
            {
                response.Record = await ctx.Employees.FindAsync(pk);
                if (response.Record == null)
                    throw new Exception($"Employee based on Id={pk} is not found");

                ctx.Employees.Remove(response.Record);
                await ctx.SaveChangesAsync();
                response.IsSuccess = true;
                response.StatusMessage = "Employee deleted successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusMessage = ex.Message;
                response.StatusCode = 500;
            }
            return response;
        }

        async Task<ResponseObject<Employee>> IDataAccessService<Employee, int>.GetAsync()
        {
            try
            {
                response.Records = await ctx.Employees.ToListAsync();
                response.IsSuccess = true;
                response.StatusMessage = "Data read successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                response.IsSuccess=false;
                response.StatusMessage = "Error Occured while reading";
                /*Logic to Log Error in DB*/
                response.StatusCode=500;
            }
            return response;
        }

        async Task<ResponseObject<Employee>> IDataAccessService<Employee, int>.GetAsync(int pk)
        {
            try
            {
                response.Record = await ctx.Employees.FindAsync(pk);
                response.IsSuccess = true;
                response.StatusMessage = "Data read successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusMessage = $"Record based on Id={pk} is not found";
                /*Logic to Log Error in DB*/
                response.StatusCode = 500;
            }
            return response;
        }

        async Task<ResponseObject<Employee>> IDataAccessService<Employee, int>.UpdateAsync(int id, Employee entity)
        {
            try
            {
                response.Record = await ctx.Employees.FindAsync(id);
                if (response.Record == null)
                    throw new Exception($"Employee based on Id={id} is not found");

                response.Record.EmpName = entity.EmpName;
                response.Record.Designation = entity.Designation;
                response.Record.DeptNo = entity.DeptNo;
                response.Record.Salary = entity.Salary;
                await ctx.SaveChangesAsync();
                response.IsSuccess = true;
                response.StatusMessage = "Employee updated successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusMessage = ex.Message;
                response.StatusCode = 500;
            }
            return response;
        }
    }
}