using Infront.Domain.Models;
using Infront.Services.IServices;
using Infront.Services.Provider.Cache;
using Infront.Services.Utility;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infront.Services.Services
{
    public class CachedUserService : IUserService
    {
        private readonly UserService _userService;
        private readonly ICacheProvider _cacheProvider;

        private static readonly SemaphoreSlim GetUsersSemaphore = new SemaphoreSlim(1, 1);

        public CachedUserService(UserService userService, ICacheProvider cacheProvider)
        {
            _userService = userService;
            _cacheProvider = cacheProvider;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            return await GetCachedResponse(CacheKeys.Users, () => _userService.GetAllAsync());
        }

        private async Task<IEnumerable<UserViewModel>> GetCachedResponse(string cacheKey, Func<Task<IEnumerable<UserViewModel>>> func)
        {
            var users = _cacheProvider.GetFromCache<IEnumerable<UserViewModel>>(cacheKey);
            if (users != null) return users;


            users = await func();

            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(15),
                SlidingExpiration = TimeSpan.FromMinutes(2)
            };

            _cacheProvider.SetCache(cacheKey, users, cacheEntryOptions);

            return users;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            return await GetCachedResponse(CacheKeys.Users, GetUsersSemaphore, () => _userService.GetAllAsync());
        }

        private async Task<IEnumerable<UserViewModel>> GetCachedResponse(string cacheKey, SemaphoreSlim semaphore, Func<Task<IEnumerable<UserViewModel>>> func)
        {
            var users = _cacheProvider.GetFromCache<IEnumerable<UserViewModel>>(cacheKey);

            if (users != null) return users;
            try
            {
                await semaphore.WaitAsync();
                users = _cacheProvider.GetFromCache<IEnumerable<UserViewModel>>(cacheKey);
                if (users != null)
                {
                    return users;
                }
                users = await func();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(2),
                    SlidingExpiration = TimeSpan.FromMinutes(1)
                };

                _cacheProvider.SetCache(cacheKey, users, cacheEntryOptions);
            }
            finally
            {
                semaphore.Release();
            }

            return users;
        }
    }
}
