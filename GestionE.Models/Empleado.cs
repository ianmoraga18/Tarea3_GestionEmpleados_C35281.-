using System.ComponentModel.DataAnnotations;
using System; 

namespace GestionE.Models
{
    public class Empleado
    {


        [Key]
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Nombre { get; set; }

        [Required, StringLength(100)]
        public string Apellidos { get; set; }

        [Required]
        public string Departamento   { get; set; }

        [Required, Range(400000, 10000000)]
        public decimal Salario { get; set; }

        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        public bool Activo { get; set; } = true;    
        public String NombreCompleto  => $"{Nombre} {Apellidos}";


    }
}
