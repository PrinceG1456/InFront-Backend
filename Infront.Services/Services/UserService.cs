using Infront.Data;
using Infront.Domain.Models;
using Infront.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infront.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpClient _httpClient;

        public UserService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<UserViewModel>> GetAll()
        {
            return _httpClient.GetUsers();
        }

        public Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            return _httpClient.GetUsers();
        }
    }
}
