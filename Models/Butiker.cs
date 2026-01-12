using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bokhandel_WPF_Applikation.Models;

[Table("Butiker")]
public partial class Butiker
{
    [Key]
    [Column("ButikID")]
    public int ButikId { get; set; }

    [StringLength(150)]
    public string Butiksnamn { get; set; } = null!;

    [StringLength(200)]
    public string Gatuadress { get; set; } = null!;

    [StringLength(100)]
    public string Stad { get; set; } = null!;

    [StringLength(5)]
    public string Postnummer { get; set; } = null!;

    [InverseProperty("Butiks")]
    public virtual ICollection<Lagersaldo> Lagersaldos { get; set; } = new List<Lagersaldo>();
}
