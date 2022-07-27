using B2C.Api.Models;

namespace B2C.Api.Repositories;

public class UserRepository : IUserRepository
{
    private IList<UserModel> Users;

    public UserRepository()
    {
        Users = new List<UserModel>();
        
        Users.Add(new UserModel("Rafael Marinho", "rafaelmarinho.dev@gmail.com", "62 98100-9021", "1"));
        Users.Add(new UserModel("Katherine Sandes", "sandeskatherine@gmail.com", "62 98100-9022", "2"));
        Users.Add(new UserModel("José da Silva", "rafael.marinho@levva.io", "62 98100-9023", "3"));
        Users.Add(new UserModel("Maria Santos", "grupoahav.dev@gmail.com", "62 98100-9024", "4"));
    }

    public async Task<UserModel> GetByEmail(string email)
    {
        return Users.FirstOrDefault(f => f.Email == email);
    }
}