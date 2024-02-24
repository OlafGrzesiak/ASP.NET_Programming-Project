using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("posts")]
    public class PostEntity
    {
        public DateTime Created { get; set; }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Content { get; set; }

        [MaxLength(50)]
        [Required]
        public string? Author { get; set; }

        [Column("publication_date")]
        public DateTime? PublicationDate { get; set; }

        public string Tags { get; set; }

        public string Comments { get; set; }

        public GroupEntity Group { get; set; }

        public int GroupId { get; set; }
    }
}
