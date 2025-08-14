using System.ComponentModel.DataAnnotations;

namespace BisikletSatis.Entities
{
    public class Musteri : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Bisiklet")]
        public int BisikletId { get; set; }
        [StringLength(50)]
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Adi { get; set; }
        [StringLength(50)]
        [Display(Name = "Soyadı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Soyadi { get; set; }
        [StringLength(11)]
        [Display(Name = "TC Numarası")]
        public string? TcNo { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Email { get; set; }
        [StringLength(500)]
        public string? Adres { get; set; }
        [StringLength(20)]
        public string? Telefon { get; set; }
        public string? Notlar { get; set; }
        [Display(Name = "Bisiklet")]
        public virtual Bisiklet? Bisiklet { get; set; }
        [Display(Name = "Ad Soyad"), ScaffoldColumn(false)]
        public string? AdSoyad
        {
            get
            {
                return this.Adi + " " + this.Soyadi;
            }

        }
    }
}
