using Infront.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infront.Data
{
    public interface IHttpClient
    {
        Task<IEnumerable<UserViewModel>> GetUsers();

    }
}
