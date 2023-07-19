using Newtonsoft.Json;

namespace HikiComic.ViewModels.Auth.LoginWithThirdParty
{
    public class UserInfoGoogle
    {
        public string Sub { get; set; }

        public string Name { get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        public string Picture { get; set; }

        public string Email { get; set; }

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        public string Locale { get; set; }
    }

}
