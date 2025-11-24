using System.ComponentModel.DataAnnotations;

namespace MyPrimerAPI.DAL.Models
{
    public class Category : AuditBase
    {

        [Required] // este atributo indica que el campo es obligatorio
        [Display(Name = "Category Name")] // este atributo define el nombre que se mostrará en la interfaz de usuario
        public string Name { get; set; }
    }
}



