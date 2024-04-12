using InvoiceAppApi.Models;

namespace InvoiceAppApi.Interffaces

{
    public interface IUserRepository
    {
        bool AddNewUser(User NewUser);
        bool LoginCheck(Login login);
        UserDetails GetUserDetails(Login login);
    }
}
