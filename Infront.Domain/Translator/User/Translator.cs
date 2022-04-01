using Infront.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infront.Domain.Translator.User
{
    public static class Translator
    {
        public static UserViewModel ViewModelTranslator(this UserModel model)
        {
            var userViewModel = new UserViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Username = model.Username,
                Email = model.Email,
                Phone = model.Phone
            };

            return userViewModel;
        }
    }
}
