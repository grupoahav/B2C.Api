using Azure.Identity;
using B2C.Api.Models;
using B2C.Api.Repositories;
using Microsoft.Graph;

namespace B2C.Api.Services;

public class UserService : IUserService
{
    private readonly GraphServiceClient _graphClient;
    private readonly IUserRepository _repository;

    private const string TenantId = "rafaelb2cpoc.onmicrosoft.com";
    private const string AppId = "0bc1e557-6760-4914-b2c8-aacdd32a0de0";
    private const string ClientSecret = "ITw8Q~46IdRXXUiiTgIkYMkfALQ5ercc5xDuNc7p";
    private const string Scopes = "https://graph.microsoft.com/.default";

    public UserService(IUserRepository repository)
    {
        _repository = repository;
        var clientSecretCredential = new ClientSecretCredential(TenantId, AppId, ClientSecret);
        _graphClient = new GraphServiceClient(clientSecretCredential, new[] { Scopes });
    }

    public async Task<IList<UserModel>> GetAll()
    {
        var users = await _graphClient.Users.Request().Select(e => new
        {
            e.DisplayName,
            e.Mail
        }).GetAsync();

        return users.Select(user => new UserModel(user.DisplayName, user.Mail, "", "")).ToList();
    }

    public async Task<UserModel> Create(string email)
    {
        var userModel = await _repository.GetByEmail(email);

        {
            var user = new User
            {
                AccountEnabled = true,
                DisplayName = userModel.Name,
                Mail = userModel.Email,
                MailNickname = "UserMail",
                PasswordProfile = new PasswordProfile
                {
                    Password = "am2vzz8jcaR#"
                }
            };

            await _graphClient.Users.Request().AddAsync(user);
        }

        return userModel!;
    }

    public async Task<UserModel> GetByEmail(string email)
    {
        return await _repository.GetByEmail(email);
    }
}