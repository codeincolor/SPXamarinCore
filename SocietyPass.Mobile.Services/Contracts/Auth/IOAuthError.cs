namespace SocietyPass.Mobile.Services.Contracts.Auth
{
    public interface IOAuthError
    {
        string Description { get; set; }
        string Error { get; set; }
    }
}