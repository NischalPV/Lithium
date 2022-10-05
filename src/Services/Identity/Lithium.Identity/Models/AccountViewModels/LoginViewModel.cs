using System.ComponentModel.DataAnnotations;

namespace Lithium.Identity.Models.AccountViewModels;

public record LoginViewModel
{
    [Required]
    [Phone]
    public string Phone { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
    public string ReturnUrl { get; set; }
}
