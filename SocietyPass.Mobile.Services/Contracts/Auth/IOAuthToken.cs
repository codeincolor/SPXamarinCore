namespace SocietyPass.Mobile.Services.Contracts.Auth
{
    public interface IOAuthToken
    {
        //int ExpiresIn { get; set; }//TODO
        string Token { get; set; }
    }
}