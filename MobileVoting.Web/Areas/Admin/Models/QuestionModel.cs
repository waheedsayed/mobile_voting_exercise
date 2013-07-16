using System.ComponentModel.DataAnnotations;

namespace MobileVoting.Web.Areas.Admin.Models
{
    public class QuestionModel
    {
        [Required, MinLength(5), StringLength(50)]
        [Display(Name = "Question title")]
        public string Title { get; set; }

        [Required, MinLength(5), StringLength(50)]
        [Display(Name = "Question text")]
        public string Text { get; set; }

        [Required, Range(1, 4), Display(Name = "Question type")]
        public int TypeId { get; set; }

        [Display(Name = "Is active?")]
        public bool IsActive { get; set; }

        //TODO: Need to make it dynamic later.
        //[Required(ErrorMessage = "Enter count of options"), Range(3, 7), Display(Name = "Options count")]
        //public int OptionsCount { get { return 5; } }

        [Required, Display(GroupName = "options")]
        public string[] Options { get; set; }
    }
}