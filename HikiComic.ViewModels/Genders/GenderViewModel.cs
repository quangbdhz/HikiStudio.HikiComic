using HikiComic.ViewModels.Base;

namespace HikiComic.ViewModels.Genders
{
    public class GenderViewModel : BaseViewModel<Guid>
    {
        public int GenderId { get; set; }

        public string GenderName { get; set; } = null!;
    }
}
