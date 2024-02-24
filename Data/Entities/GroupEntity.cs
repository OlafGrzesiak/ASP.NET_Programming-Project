using Data.Entities;
using Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Groups")]
public class GroupEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Use Owned to configure LibraryAddress as a complex type

    public ISet<PostEntity> posts { get; set; }

    //public LibraryEntity Library { get; set; }
    //public int LibraryId { get; set; }
}
