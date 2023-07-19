using HikiComic.Utilities.Enums;

namespace HikiComic.Management.Services
{
    public interface IPolicyAuthorize
    {
        public PolicyEnum GetPolicyOfUser(bool isDashboard = false);
    }
}
