using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbContext.Models;

public class User
{
    public User()
    {
    }

    [Key]
    [Column(TypeName = "int")]
    public string UserId { get; set; }

    [Column(TypeName = "nvarchar (150)")]
    [StringLength(150)]
    [Required]
    public string EmailAddress { get; set; }

    [Column(TypeName = "nvarchar (30)")]
    [StringLength(30)]
    public string UserName { get; set; }
}