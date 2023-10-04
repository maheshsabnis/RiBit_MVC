using MVC_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_WebApp.Services
{
    /// <summary>
    /// TEntity will be only of the DErived TYpe of EntityBAse class
    /// The 'in' represents an input parameter to method declared in interface
    /// THe 'TPk' will be a primary Key Type
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPK"></typeparam>
    internal interface IDataAccessService<TEntity, in TPk> where TEntity : EntityBase
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TPk pk);
        TEntity Create(TEntity entity);
        TEntity Update(TPk id,TEntity entity);
        TEntity Delete(TPk pk);
    }
}
