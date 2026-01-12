using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bokhandel_WPF_Applikation.Models;

[Table("Böcker")]
public partial class Böcker
{
    [Key]
    [Column("ISBN13")]
    [StringLength(13)]
    public string Isbn13 { get; set; } = null!;

    [StringLength(300)]
    public string Titel { get; set; } = null!;

    [StringLength(50)]
    public string Språk { get; set; } = null!;

    [Precision(0)]
    public DateTime Utgivningsdatum { get; set; }

    [Column("FörfattareID")]
    public int FörfattareId { get; set; }

    public int Sidor { get; set; }

    [StringLength(200)]
    public string? Översättare { get; set; }

    [Column("FörlagsID")]
    public int FörlagsId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Pris { get; set; }

    [ForeignKey("FörfattareId")]
    [InverseProperty("Böckers")]
    public virtual Författare Författare { get; set; } = null!;

    [ForeignKey("FörlagsId")]
    [InverseProperty("Böckers")]
    public virtual Förlag Förlags { get; set; } = null!;

    [InverseProperty("Isbn13Navigation")]
    public virtual ICollection<Lagersaldo> Lagersaldos { get; set; } = new List<Lagersaldo>();

    [InverseProperty("Isbn13Navigation")]
    public virtual ICollection<Orderdetaljer> Orderdetaljers { get; set; } = new List<Orderdetaljer>();
}
