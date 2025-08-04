using System.ComponentModel.DataAnnotations;

namespace BisikletSatis.Entities
{
    public class Tamirhane : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Servise Geliş Tarihi")]
        public DateTime ServiseGelisTarihi { get; set; }
        [Display(Name = "Bisiklet Sorunu")]
        public string BisikletSorunu { get; set; }
        [Display(Name = "Servis Ücreti"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public decimal ServisUcreti { get; set; }
        [Display(Name = "Servisten Çıkış Tarihi")]
        public DateTime ServistenCikisTarihi { get; set; }
        [Display(Name = "Yapılan İşlemler")]
        public string? YapilanIslemler { get; set; }
        [Display(Name = "Garanti Kapsamında Mı?")]
        public bool GarantiKapsamindaMi{ get; set; }
        [StringLength(20)]
        [Display(Name = "Bisiklet No"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string BisikletNo { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Marka { get; set; }
        [StringLength(50)]
        public string? Model { get; set; }
        [StringLength(50)]
        [Display(Name = "Bisiklet Tipi")]
        public string? BisikletTipi { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Notlar { get; set; }
    }
}
