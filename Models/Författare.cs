using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bokhandel_WPF_Applikation.Models;

[Table("Författare")]
public partial class Författare
{
    [Key]
    [Column("FörfattareID")]
    public int FörfattareId { get; set; }

    [StringLength(30)]
    public string Förnamn { get; set; } = null!;

    [StringLength(30)]
    public string Efternamn { get; set; } = null!;

    [Precision(0)]
    public DateTime Födelsedatum { get; set; }

    [StringLength(100)]
    public string Land { get; set; } = null!;

    [InverseProperty("Författare")]
    public virtual ICollection<Böcker> Böckers { get; set; } = new List<Böcker>();
}
