using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bokhandel_WPF_Applikation.Models;

[Table("Orderdetaljer")]
[Index("OrderId", "Isbn13", Name = "IX_Orderdetaljer_OrderID_ISBN13", IsUnique = true)]
public partial class Orderdetaljer
{
    [Key]
    [Column("OrderdetaljerID")]
    public int OrderdetaljerId { get; set; }

    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column("ISBN13")]
    [StringLength(13)]
    public string Isbn13 { get; set; } = null!;

    public int Antal { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Pris { get; set; }

    [ForeignKey("Isbn13")]
    [InverseProperty("Orderdetaljers")]
    public virtual Böcker Isbn13Navigation { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("Orderdetaljers")]
    public virtual Ordrar Order { get; set; } = null!;
}
