using Lemontech.DataLayer.Models;
using System.Threading.Tasks;

namespace LemonTech.Repository.Identity.Interface
{
    public interface IIdentityService
    {
        Task<SignUpResult> SignUp(SignUpOptions model);
        Task<LoginResponseModel> Login(Credentials model);
    }
}
