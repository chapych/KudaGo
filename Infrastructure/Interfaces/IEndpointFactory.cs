using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace Infrastructure.Interfaces
{
    public interface IEndpointFactory
    {
        string Create(int pageSize, DateTime actualSince, DateTime actualUntil, Category[] categoriesField);
    }
}
