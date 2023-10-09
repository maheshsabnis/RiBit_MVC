using API_App.Models;
using API_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Web.Http;

namespace API_App.Controllers
{
    public class DepartmentController : ApiController
    {
        IDataAccessService<Department, int> deptServ;

        /// <summary>
        /// Inject an instance of DepartmentDataservice
        /// </summary>
        public DepartmentController(IDataAccessService<Department,int> deptServ)
        {

            //deptServ = new DepartmentDataService();
            this.deptServ = deptServ;
        }

        public async Task<IHttpActionResult> GetAsync()
        {
            var response = await this.deptServ.GetAsync();
            return Ok(response);
        }
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var response = await this.deptServ.GetAsync(id);
            return Ok(response);
        }

        public async Task<IHttpActionResult> PostAsync(Department dept)
        {
            var response = await this.deptServ.CreateAsync(dept);
            return Ok(response);
        }

        public async Task<IHttpActionResult> PutAsync(int id, Department dept)
        {
            var response = await this.deptServ.UpdateAsync(id,dept);
            return Ok(response);
        }

        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            var response = await this.deptServ.DeleteAsync(id);
            return Ok(response);
        }


    }
}
