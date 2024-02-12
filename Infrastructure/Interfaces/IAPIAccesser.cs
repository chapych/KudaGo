using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace Infrastructure.Interfaces
{
    public interface IAPIAccesser
    {
        Task<ResponseData?> GetResponseDataAsync(string endpoint);
    }
}
