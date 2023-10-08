using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace API_App.Models
{
    public class ResponseObject<TEntity> where TEntity : class
    {
        // List in Response
        public IEnumerable<TEntity> Records { get; set; }
        // Single Record in Response
        public TEntity Record { get; set; }
        public bool IsSuccess { get; set; } = false;
        public string StatusMessage { get; set; }
        public int StatusCode { get; set; }
    }
}