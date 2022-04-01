using Infront.Domain.Models;
using Infront.Services.IServices;
using Infront.Services.Provider.Cache;
using Infront.Services.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infront.Services.Services
{
    public class CacheService : ICacheService
    {
        private readonly ICacheProvider _cacheProvider;

        public CacheService(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }
        public void ClearCache()
        {
            _cacheProvider.ClearCache(CacheKeys.Users);    
        }

        public IEnumerable<UserViewModel> GetCachedUser()
        {
            return _cacheProvider.GetFromCache<IEnumerable<UserViewModel>>(CacheKeys.Users);
        }
    }
}
