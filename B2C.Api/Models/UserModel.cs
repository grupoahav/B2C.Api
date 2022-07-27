namespace B2C.Api.Models;

public class UserModel
{
    public UserModel(string name, string email, string phoneNumber, string tShopId)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        TShopId = tShopId;
    }

    public string Name { get; }
    public string Email { get; }
    public string PhoneNumber { get; }
    public string TShopId { get; }
}