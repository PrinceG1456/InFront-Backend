using Infront.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infront.Services.IServices
{
    public interface ICacheService
    {
        IEnumerable<UserViewModel> GetCachedUser();
        void ClearCache();
    }
}
