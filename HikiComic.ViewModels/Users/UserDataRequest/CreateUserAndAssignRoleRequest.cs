namespace HikiComic.ViewModels.Users.UserDataRequest
{
    public class CreateUserAndAssignRoleRequest
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public IList<Guid> RoleIds { get; set; }
    }
}
