using System;
using System.ComponentModel.DataAnnotations;

namespace webapp.Models
{
    public class CheffModel
{
    public int Id { get; set; }

    [StringLength(20, MinimumLength = 3)]
    [Required(ErrorMessage="Correo electronico invalido")]
    [EmailAddress]
    [Display]
    public string Email { get; set; }

    [StringLength(20, MinimumLength = 3)]
    [Required(ErrorMessage="Al menos un nombre debe ingresar")]
    [EmailAddress]
    [Display]
    public string Nombres { get; set; }

    [StringLength(20, MinimumLength = 3)]
    [Required(ErrorMessage="Al menos un apellido debe ingresar")]
    [EmailAddress]
    [Display]
    public string Apellido { get; set; }


    [StringLength(20, MinimumLength = 3)]
    [Required(ErrorMessage="Ingrese el tipo de cocina que más le gusta")]
    [EmailAddress]
    [Display]
    public string TipoCocina { get; set; }

}
}
