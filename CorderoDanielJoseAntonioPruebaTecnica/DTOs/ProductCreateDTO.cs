using System.ComponentModel.DataAnnotations;

namespace CorderoDanielJoseAntonioPruebaTecnica.DTOs
{
    public class ProductCreateDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Stock { get; set; }
    }

}
