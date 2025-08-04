using System.ComponentModel.DataAnnotations;

namespace BisikletSatis.Entities
{
    public class Satis : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Bisiklet")]
        public int BisikletId { get; set; }
        [Display(Name = "Müşteri")]
        public int MusteriId { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal SatisFiyati { get; set; }
        [Display(Name = "Satış Tarihi")]
        public DateTime SatisTarihi { get; set; }
        [Display(Name = "Bisiklet")]
        public virtual Bisiklet? Bisiklet { get; set; }
        [Display(Name = "Müşteri")]
        public virtual Musteri? Musteri { get; set; }
    }
}
