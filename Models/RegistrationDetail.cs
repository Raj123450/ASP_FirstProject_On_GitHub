using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginWithSession.Models;

public partial class RegistrationDetail
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Namee { get; set; }
    [Required]
    public string? Gender { get; set; }
    [Required]
    public int? Age { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Passwords { get; set; }
}
