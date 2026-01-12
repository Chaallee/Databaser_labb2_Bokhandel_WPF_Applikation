using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bokhandel_WPF_Applikation.Models;

[Table("Förlag")]
public partial class Förlag
{
    [Key]
    [Column("FörlagsID")]
    public int FörlagsId { get; set; }

    [StringLength(200)]
    public string Namn { get; set; } = null!;

    [StringLength(150)]
    public string Land { get; set; } = null!;

    [StringLength(200)]
    public string? Hemsida { get; set; }

    [InverseProperty("Förlags")]
    public virtual ICollection<Böcker> Böckers { get; set; } = new List<Böcker>();
}
