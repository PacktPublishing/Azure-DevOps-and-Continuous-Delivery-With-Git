using Classifieds.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Classifieds.Web.Services.Identity
{
    public class PasswordValidatorService : IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            var errors = new List<IdentityError>();

            if (password.Contains("Company Name"))
            {
                errors.Add(new IdentityError
                {
                    Code = "Company Name",
                    Description = "Password should not contain name of company"
                });
            }

            if (password.Contains(user.FirstName) || password.Contains(user.LastName))
            {
                errors.Add(new IdentityError
                {
                    Code = "Weak Password",
                    Description = "Password should not contain your name"
                });
            }

            if (password.Contains(user.UserName) || password.Contains(user.Email))
            {
                errors.Add(new IdentityError
                {
                    Code = "Weak Password",
                    Description = "Password should not contain username or email address"
                });
            }

            if (errors.Count > 0)
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            
            return Task.FromResult(IdentityResult.Success);
        }
    }

}
