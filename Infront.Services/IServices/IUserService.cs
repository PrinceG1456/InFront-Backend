using Infront.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infront.Services.IServices
{
    public interface IUserService
    { 
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<IEnumerable<UserViewModel>> GetAllAsync();
    }
}
