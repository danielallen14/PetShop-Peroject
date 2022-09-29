using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Data.Model
{
    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        [Column("CommentID")]
        public int CommentId { get; set; }
        public string Content { get; set; } = null!;
        [Column("AnimalID")]
        public int? AnimalId { get; set; }

        [ForeignKey("AnimalId")]
        [InverseProperty("Comments")]
        public virtual Animal? Animal { get; set; }
    }
}
