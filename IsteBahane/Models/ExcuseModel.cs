using System.ComponentModel.DataAnnotations;

namespace IsteBahane.Models
{
    public class ExcuseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş bırakılamaz.")]
        public string Description { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }

        [Required(ErrorMessage = "Yazar adı boş bırakılamaz.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Yazar e-posta adresi boş bırakılamaz.")]
        public string AuthorEmail { get; set; }
        public int ShowCount { get; set; }
    }
}