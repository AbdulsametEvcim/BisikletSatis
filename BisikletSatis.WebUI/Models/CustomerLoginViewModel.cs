using System.ComponentModel.DataAnnotations;

namespace BisikletSatis.WebUI.Models
{
    public class CustomerLoginViewModel
    {
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Email { get; set; }
        [Display(Name = "Şifre"), StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Sifre { get; set; }
    }
}
