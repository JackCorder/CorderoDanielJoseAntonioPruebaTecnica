using System.ComponentModel.DataAnnotations.Schema;

namespace CorderoDanielJoseAntonioPruebaTecnica.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DescripcionEncriptada { get; set; }

        // Campo no mapeado (para mostrar al cliente)
        [NotMapped]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
