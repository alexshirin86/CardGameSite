using System.ComponentModel.DataAnnotations;

namespace CardGameSite.WEB.Models
{
    public class EditUser
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
