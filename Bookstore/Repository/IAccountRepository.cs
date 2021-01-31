using Bookstore.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public interface IAccountRepository
    {        

        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> SignInAsync(SignInModel signInModel);

        Task SignOutAsync();
    }
}