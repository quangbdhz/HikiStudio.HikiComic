namespace HikiComic.ViewModels.Auth.AuthDataRequest
{
    public class LoginWithThirdPartyRequest
    {
        public string AccessToken { get; set; } = null!;

        public int LoginWithThirdPartyId {get; set; }
    }
}
