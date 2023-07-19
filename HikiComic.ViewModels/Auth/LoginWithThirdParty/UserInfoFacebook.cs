using System.Text.RegularExpressions;

namespace HikiComic.ViewModels.Auth.LoginWithThirdParty
{
    public class UserInfoFacebook
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LastName 
        {
            get
            {
                Regex regex = new Regex(@"(?<lastName>.+)\s+(?<firstName>.+)");

                Match match = regex.Match(Name ?? "");

                return match.Groups["lastName"].Value;
            }
        }

        public string FirstName 
        {
            get
            {
                Regex regex = new Regex(@"(?<lastName>.+)\s+(?<firstName>.+)");

                Match match = regex.Match(Name ?? "");

                return match.Groups["firstName"].Value;
            }
        }
    }
}
