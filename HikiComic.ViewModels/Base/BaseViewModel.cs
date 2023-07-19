using System.ComponentModel.DataAnnotations;

namespace HikiComic.ViewModels.Base
{
    public class BaseViewModel<TUser>
    {
        public virtual bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime DateCreated { get; set; }

        public virtual TUser CreatedBy { get; set; }

        public virtual string UserNameCreatedBy { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime? DateUpdated { get; set; }

        public virtual TUser? UpdatedBy { get; set; }

        public virtual string? UserNameUpdatedBy { get; set; } 
    }
}
