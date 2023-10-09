using API_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API_App.Services
{
    public class DepartmentDataService : IDataAccessService<Department, int>
    {
        RCompanyEntities ctx;

        ResponseObject<Department> response;

        /// <summary>
        /// Inject the RCompanyEntities into the DepartmentDataService class using 
        /// The Constructor Injection
        /// 
        /// The ASP.NET Execution ENgine will query to the DI Container
        /// for RCompanyEntities CLass and will receive the Resolved INstance of it
        /// </summary>
        public DepartmentDataService(RCompanyEntities ctx)
        {
           // ctx = new RCompanyEntities();
           this.ctx = ctx;
            response = new ResponseObject<Department>();
        }

        async Task<ResponseObject<Department>> IDataAccessService<Department, int>.CreateAsync(Department entity)
        {
            try
            {
                response.Record = ctx.Departments.Add(entity);
                await ctx.SaveChangesAsync();
                response.IsSuccess = true;
                response.StatusMessage = "Department added successfully";
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

        async Task<ResponseObject<Department>> IDataAccessService<Department, int>.DeleteAsync(int pk)
        {
            try
            {
                response.Record = await ctx.Departments.FindAsync(pk);
                if (response.Record == null)
                    throw new Exception($"Department based on Id={pk} is not found");

                ctx.Departments.Remove(response.Record);
                await ctx.SaveChangesAsync();
                response.IsSuccess = true;
                response.StatusMessage = "Department deleted successfully";
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

        async Task<ResponseObject<Department>> IDataAccessService<Department, int>.GetAsync()
        {
            try
            {
                var records = await ctx.Departments.ToListAsync();

                response.Records = (from record in records
                                    select new Department()
                                    {
                                        DeptNo = record.DeptNo,
                                        DeptName = record.DeptName,
                                        Location = record.Location,
                                        Capacity = record.Capacity,
                                        DeptUniqueId = record.DeptUniqueId
                                    }).ToList();

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

        async Task<ResponseObject<Department>> IDataAccessService<Department, int>.GetAsync(int pk)
        {
            try
            {
                response.Record = await ctx.Departments.FindAsync(pk);
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

        async Task<ResponseObject<Department>> IDataAccessService<Department, int>.UpdateAsync(int id, Department entity)
        {
            try
            {
                response.Record = await ctx.Departments.FindAsync(id);
                if (response.Record == null)
                    throw new Exception($"Department based on Id={id} is not found");

                response.Record.DeptName = entity.DeptName;
                response.Record.Location = entity.Location;
                response.Record.Capacity = entity.Capacity;

                await ctx.SaveChangesAsync();
                response.IsSuccess = true;
                response.StatusMessage = "Department updated successfully";
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