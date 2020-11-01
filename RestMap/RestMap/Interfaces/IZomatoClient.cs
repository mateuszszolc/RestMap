using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestMap.Interfaces
{
    public interface IZomatoClient
    {
        Task<T> GetAsync<T>(string endpoint);
    }
}
