using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCrudDepartamentosEF.Models
{
    [Table("DEPARTAMENTOS")]
    public class Departamento
    {
        [Key]
        [Column("DEPT_NO")]
        public int IdDepartamento { get; set; }
        [Column("DNOMBRE")]
        public string Nombre { get; set; }
        [Column("LOC")]
        public string Loc { get; set; }
    }
}
