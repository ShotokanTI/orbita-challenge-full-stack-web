using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_A__Educacao.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Key]
        [Column("RA", TypeName = "varchar(20)")]
        public string RA { get; set; }  = string.Empty;

        [Required]
        [MaxLength(11)]
        [Column("CPF", TypeName = "varchar(11)")]
        public string CPF { get; set; } = string.Empty;
    }
}
