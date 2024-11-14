using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_A__Educacao.Domain.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [Key]
        [Column("RA")]
        public string RA { get; set; } = string.Empty;

        [Column("CPF")]
        public string CPF { get; set; } = string.Empty;
    }
}
