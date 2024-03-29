using System;
using System.ComponentModel.DataAnnotations;

namespace webapp.Models
{
    public class CheffModel
{
    public int Id { get; set; }

    [StringLength(40, MinimumLength = 3)]
    [Required(ErrorMessage="Correo electronico invalido")]
    [EmailAddress]
    [Display]
    public string Email { get; set; }

    [StringLength(20, MinimumLength = 3)]
    [Required(ErrorMessage="Al menos un nombres debe ingresar")]
    [Display]
    public string Nombres { get; set; }

    [StringLength(20, MinimumLength = 3)]
    [Required(ErrorMessage="Al menos un apellidos debe ingresar")]
    [Display]
    public string Apellidos { get; set; }

    [Required(ErrorMessage="Ingrese su fecha de nacimiento")]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }

    [StringLength(20, MinimumLength = 3)]
    [Required(ErrorMessage="Ingrese el tipo de cocina que más le gusta")]
    [Display]
    public string TipoCocina { get; set; }

}
}
