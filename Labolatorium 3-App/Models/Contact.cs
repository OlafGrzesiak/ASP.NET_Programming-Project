using Labolatorium_3_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium_3_App.Models
{
    public class Contact
    {
        [HiddenInput]
        public DateTime Created { get; set; }
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Musisz podać imię!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długie imie, max 50 znaków")]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string? Phone { get; set; } // TYP? nie jest wymagane (opcjonalne pole)

        [Display(Name = "Data ur.")]
        public DateTime? Birth { get; set; }

        [Display(Name = "Ważność")]
        public Priority Priority { get; set; }

        public int? OrganizationId { get; set; }
        public string? OrganizationName { get; set; }

        [ValidateNever]
        public List<SelectListItem> Organizations { get; set; }
    }
}