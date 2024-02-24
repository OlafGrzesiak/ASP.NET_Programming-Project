using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium_3_App.Models
{
    public class Post
    {
        [HiddenInput]
        public int id { get; set; }
        [Required(ErrorMessage = "Musisz podać zawartość!")]
        [Display(Name = "Zawartość")]
        public string? Content { get; set; }

        [Required(ErrorMessage = "Musisz podać autora postu!")]
        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Musisz podać datę publikacji postu!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data publikacji")]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Tagi")]
        public string? Tags { get; set; }
        [Display(Name = "Komenatarze")]
        public string? Comments { get; set; }

        public DateTime Created { get; set; }
        public int? GroupId { get; set; }
        public string? GroupName { get; set; }

        [ValidateNever]
        public List<SelectListItem> Groups { get; set; }

    }
}
