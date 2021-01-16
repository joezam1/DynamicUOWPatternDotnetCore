using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using project.Data.UnitOfWork;

namespace project.Data.Models 
{
    [Table("Product")]
    public class Product: UnitOfWorkEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}