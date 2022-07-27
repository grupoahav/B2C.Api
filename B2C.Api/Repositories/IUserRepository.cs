using B2C.Api.Models;

namespace B2C.Api.Repositories;

public interface IUserRepository
{
    Task<UserModel> GetByEmail(string email);
}