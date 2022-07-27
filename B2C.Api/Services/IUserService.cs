using B2C.Api.Models;
using Microsoft.Graph;

namespace B2C.Api.Services;

public interface IUserService
{
    public Task<IList<UserModel>> GetAll();
    public Task<UserModel> Create(string email);
    public Task<UserModel> GetByEmail(string email);
}