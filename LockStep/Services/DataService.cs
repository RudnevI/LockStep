using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LockStep.Web.Services
{
    public interface IDataService<T> where T : class
    {
        List<T> GetList();
    }
}