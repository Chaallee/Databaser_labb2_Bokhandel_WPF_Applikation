using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bokhandel_WPF_Applikation.Models;

[PrimaryKey("ButiksId", "Isbn13")]
[Table("Lagersaldo")]
public partial class Lagersaldo
{
    [Key]
    [Column("ButiksID")]
    public int ButiksId { get; set; }

    [Key]
    [Column("ISBN13")]
    [StringLength(13)]
    public string Isbn13 { get; set; } = null!;

    public int Antal { get; set; }

    [ForeignKey("ButiksId")]
    [InverseProperty("Lagersaldos")]
    public virtual Butiker Butiks { get; set; } = null!;

    [ForeignKey("Isbn13")]
    [InverseProperty("Lagersaldos")]
    public virtual Böcker Isbn13Navigation { get; set; } = null!;
}
