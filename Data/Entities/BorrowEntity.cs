using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Borrows")]
    public class BorrowEntity
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }
        public int LibraryId { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual PostEntity Book { get; set; }
        public virtual GroupEntity Library { get; set; }
    }

}
