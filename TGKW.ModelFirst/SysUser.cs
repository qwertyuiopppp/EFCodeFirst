using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TGKW.ModelFirst;

[Table("SysUser")]
public class SysUser
{
    
    [Key]
    [Column("Id")]
    public long Id { get; set; }
    
    [MaxLength(100)]
    [Column("Name")]
    public string? Name { get; set; }

    [MaxLength(20)]
    [Column("Account")]
    public string? Account { get; set; }

    [MaxLength(20)]
    [Column("Password")]
    public string? Password { get; set; }
}