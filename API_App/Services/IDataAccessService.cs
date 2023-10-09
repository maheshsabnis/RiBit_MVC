using API_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_App.Services
{
    
    public interface IDataAccessService<TEntity, in TPk> where TEntity  :class
    {
        Task<ResponseObject<TEntity>> GetAsync();
        Task<ResponseObject<TEntity>> GetAsync(TPk pk);
        Task<ResponseObject<TEntity>> CreateAsync(TEntity entity);
        Task<ResponseObject<TEntity>> UpdateAsync(TPk id,TEntity entity);
        Task<ResponseObject<TEntity>> DeleteAsync(TPk pk);
    }
}
